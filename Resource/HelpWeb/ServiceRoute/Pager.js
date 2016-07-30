define(function () {

    var mainMoudle = {
        main: function () {
            mainMoudle.initEvent();
        },

        initEvent: function () {
            // 修改按钮绑定
            $('.updateButton').click(function () {
                var obj = this;
                var routeid = $(obj).attr("RouteID");
                // 加载数据
                $.ajax({
                    url: "/ServiceRoute/GetServiceRoute",
                    type: "POST",
                    dataType: "json",
                    data: {
                        routeid: routeid
                    },
                    success: function (data) {
                        var result = $.parseJSON(data.Result);
                        mainMoudle.renderHtml('updateTmpl', 'updatediv', result);
                        mainMoudle.Save('update');
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log('responseText=' + XMLHttpRequest.responseText + ',textStatus=' + textStatus + ',errorThrown=' + errorThrown);
                    }
                });
            });

            // 启用禁用按钮
            $('.validOperateButton').click(function () {
                var obj = this;
                var RouteID = $(obj).attr('RouteID');
                var ContractName = $(obj).attr('ContractName');
                var IsValid = $(obj).attr('IsValid');

                var str = IsValid === '1' ? '禁用' : '启用';
                var operate = IsValid === '1' ? 'disable' : 'enable';
                var result = {
                    Title: "启用禁用确认框",
                    Message: str + "路由：" + ContractName + "?"
                };

                layer.confirm(result.Message, function () {
                    layer.closeAll();
                    var param = {
                        Operate: operate,
                        Data: {
                            RouteID: RouteID,
                            ContractName: ContractName,
                            IsValid: IsValid === '1' ? 0 : 1,
                        }
                    };

                    var jsonStr = JSON.stringify(param);
                    $.ajax({
                        url: "/ServiceRoute/Save",
                        type: "POST",
                        dataType: "json",
                        data: {
                            jsonStr: jsonStr
                        },
                        success: function (data) {
                            console.log(data);
                            if (data.IsSuccess === false) {
                                layer.alert(data.ErrorMsg);
                            } else {
                                layer.alert(str + "成功!", true, function () {
                                    layer.closeAll();
                                    $('#query input[name="ContractName"').val(ContractName);
                                    $('#query select[name="IsValid"').val('');
                                    $('#QueryServiceRoute').click();
                                });
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            console.log('responseText=' + XMLHttpRequest.responseText + ',textStatus=' + textStatus + ',errorThrown=' + errorThrown);
                        }
                    });
                });
            });

            // 添加弹出框按钮
            $('#addRefBtn').click(function () {
                var model = {
                    RouteID: '',
                    ContractName: '',
                    ServiceType: 'WCF',
                    DataCenter: 'NW',
                    UniqueSign: 'GJ2014',
                    BindingType: 'net.tcp',
                    ServiceIP: 'localhost',
                    ServicePort: '1212',
                    SvcPath: 'test.svc'
                };

                mainMoudle.renderHtml('updateTmpl', 'updatediv', model);
                mainMoudle.Save('add');
            });

            // 复制添加按钮
            $('.copyAddRefButton').click(function () {

                var obj = this;
                var routeid = $(obj).attr("RouteID");
                // 加载数据
                $.ajax({
                    url: "/ServiceRoute/GetServiceRoute",
                    type: "POST",
                    dataType: "json",
                    data: {
                        routeid: routeid
                    },
                    success: function (data) {
                        var result = $.parseJSON(data.Result);
                        result.RouteID = '';
                        mainMoudle.renderHtml('updateTmpl', 'updatediv', result);
                        mainMoudle.Save('add');
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log('responseText=' + XMLHttpRequest.responseText + ',textStatus=' + textStatus + ',errorThrown=' + errorThrown);
                    }
                });
            });

            // 删除按钮
            $('.deleteRefBtn').click(function () {
                var obj = this;
                var RouteID = $(obj).attr('RouteID');
                var ContractName = $(obj).attr('ContractName');
                var param = {
                    Operate: 'delete',
                    Data: {
                        RouteID: RouteID,
                        ContractName: ContractName,
                        IsDelete: 1,
                    }
                };

                var jsonStr = JSON.stringify(param);
                layer.confirm("确定要删除契约:" + ContractName + "吗?", function () {
                    layer.closeAll();
                    $.ajax({
                        url: "/ServiceRoute/Save",
                        type: "POST",
                        dataType: "json",
                        data: {
                            jsonStr: jsonStr
                        },
                        success: function (data) {
                            console.log(data);
                            if (data.IsSuccess === false) {
                                layer.alert(data.ErrorMsg);
                            } else {
                                layer.alert("删除成功!", true, function () {
                                    layer.closeAll();
                                    $('#QueryServiceRoute').click();
                                });
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            console.log('responseText=' + XMLHttpRequest.responseText + ',textStatus=' + textStatus + ',errorThrown=' + errorThrown);
                        }
                    });
                });
            });
        },

        // 绑定修改数据事件
        Save: function (opertate) {
            $('#updateServiceRouteBtn').removeAttr('disabled');
            // 修改路由信息
            $('#updateServiceRouteBtn').off("click").on("click", function () {
                $('#updateServiceRouteBtn').attr('disabled', true);
                var updateObj = $('#updateform').serializeJson();

                var param = {
                    Operate: opertate,
                    Data: updateObj
                };

                var updateJsonStr = JSON.stringify(param);
                $.ajax({
                    url: "/ServiceRoute/Save",
                    type: "POST",
                    dataType: "json",
                    data: {
                        jsonStr: updateJsonStr
                    },
                    success: function (updateData) {
                        if (updateData.IsSuccess) {
                            $('#updateServiceRouteModal').modal('hide');
                            layer.alert('保存成功!', false, function () {
                                layer.closeAll();
                                $('#query input[name="ContractName"').val(updateObj.ContractName);
                                $('#query input[name="UniqueSign"').val(updateObj.UniqueSign);
                                $('#query select[name="IsValid"').val(updateObj.IsValid);
                                $('#QueryServiceRoute').click();
                            });

                        } else {
                            $('#updateServiceRouteBtn').removeAttr('disabled');
                            layer.alert(updateData.ErrorMsg);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log('responseText=' + XMLHttpRequest.responseText + ',textStatus=' + textStatus + ',errorThrown=' + errorThrown);
                    }
                });
            });
        },

        // 序列化模板
        renderHtml: function (tempId, renderId, data) {
            var tempHtml = $('#' + tempId + '').render(data);
            $('#' + renderId + "").html(tempHtml);
        }
    };

    $(function () {
        mainMoudle.main();
    });
});