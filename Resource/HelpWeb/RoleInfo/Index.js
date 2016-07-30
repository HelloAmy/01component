define(function () {

    // 定义对象
    var mainModule = {

        // 主函数
        main: function () {
            mainModule.initEvent();
        },

        // 初始化事件
        initEvent: function () {

            // 点击添加按钮
            $('#addbtn').click(function () {
                var model = {
                    KeyID: '',
                    RoleName: '',
                    RoleAlias: '',
                    IsValid: 1,
                };

                mainModule.renderHtml('addModalTemplate', 'addModal', model);

                mainModule.save('添加角色', 0);
            });

            // 修改按钮
            $('.updateButton').click(function () {

                var obj = this;
                var keyid = $(obj).attr('KeyID');
                $.ajax({
                    url: "/RoleInfo/Get",
                    type: "POST",
                    dataType: "json",
                    data: {
                        keyid: keyid
                    },
                    success: function (data) {
                        if (data.IsSuccess === false) {
                            layer.alert(data.ErrorMsg);
                            return;
                        } else {
                            mainModule.renderHtml('addModalTemplate', 'addModal', data.Result);
                            mainModule.save('修改角色', 1);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log('responseText=' + XMLHttpRequest.responseText + ',textStatus=' + textStatus + ',errorThrown=' + errorThrown);
                    }
                });
            });
        },

        // 保存绑定事件
        save: function (title, operateType) {
            // 可用
            $('#addModalBtn').removeAttr('disabled');
            $('#addModalBtn').off('click').on('click', function () {

                // 设置不可用，防止多次保存
                $('#addModalBtn').attr('disabled', false);
                var obj = $('#addModalform').serializeJson();
                var param = {
                    Type: operateType,
                    Data: obj,
                };

                var jsonStr = JSON.stringify(param);
                var ret = mainModule.postsync(jsonStr);
                if (ret.IsSuccess) {
                    layer.alert(title + "成功", true, function () {
                        layer.closeAll();
                        $('#Query').click();
                    });
                }
                else {
                    // 保存不成功，按钮设置为可用
                    $('#addModalBtn').removeAttr('disabled');
                    layer.alert(ret.Tips);
                }
            });
        },

        // 同步发送请求
        postsync: function (jsonStr) {
            var returnJson = $.ajax({
                url: "/RoleInfo/Save",
                type: "POST",
                dataType: "json",
                async: false,
                data: {
                    json: jsonStr
                },

            }).responseText;

            // 转model
            var obj = $.parseJSON(returnJson);
            return obj;
        },

        // 序列化模板
        renderHtml: function (tempId, renderId, data) {
            var tempHtml = $('#' + tempId + '').render(data);
            $('#' + renderId + "").html(tempHtml);
        }
    };

    // 入口
    $(function () {
        mainModule.main();
    });
});

