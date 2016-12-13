define(function () {
    var FileInput = function () {
        var oFile = new Object();

        //初始化fileinput控件（第一次初始化）
        oFile.Init = function (ctrlName, uploadUrl) {
            var control = $('#' + ctrlName);

            //初始化上传控件的样式
            control.fileinput({
                language: 'zh', //设置语言
                uploadUrl: uploadUrl, //上传的地址
                allowedFileExtensions: ['xlsx', 'xls'],//接收的文件后缀
                showUpload: true, //是否显示上传按钮
                showCaption: false,//是否显示标题
                browseClass: "btn btn-primary", //按钮样式
                //dropZoneEnabled: false,//是否显示拖拽区域
                //minImageWidth: 50, //图片的最小宽度
                //minImageHeight: 50,//图片的最小高度
                //maxImageWidth: 1000,//图片的最大宽度
                //maxImageHeight: 1000,//图片的最大高度
                //maxFileSize: 0,//单位为kb，如果为0表示不限制文件大小
                //minFileCount: 0,
                maxFileCount: 10, //表示允许同时上传的最大文件个数
                enctype: 'multipart/form-data',
                validateInitialCount: true,
                previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
                msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！",
            });

            //导入文件上传完成之后的事件
            $("#" + ctrlName).on("fileuploaded", function (event, data, previewId, index) {
                $("#myModal").modal('hide');
                var res = data.response;
                if (res.IsSuccess) {

                    tableNameListMoudle.show(res);
                } else {
                    layer.alert(res.ErrorMsg);
                }
            });
        }

        return oFile;
    };

    var tableNameListMoudle =  {
        show:function(res){
            mainMoudle.renderHtml('tableNameListTemplate', 'tableNameList', res);
            tableNameListMoudle.bindEvent();
        },
        bindEvent:function(){
            $('#generateSqlBtn').click(function(){
                var model = {};
                model.fileName=$('input[name="fileName"').val();
                var tempTableNames = [];

                $('.col-sm-3 input:checkbox:checked').each(function(i){

                    var obj = this;
                    if ($(obj).val() !== ''){
                        tempTableNames.push($(obj).val());
                    }
                });

                model.tableNames = tempTableNames.toString();

                mainMoudle.postasync('/DBCreater/GenerateSQL', model, function(data){

                    if (data && data.IsSuccess){
                        $('#generatorSqlText').val(data.Result.Result)
                    } else{
                        layer.alert(data.ErrorMsg);
                    }
                },function(data){

                    layer.alert('错误详细:'+JSON.stringify(data));
                });
            });
        },
    };

    var mainMoudle = {
        main: function () {
            mainMoudle.init();
        },
        init: function () {
            var oFileInput = new FileInput();
             
            $("#btn_import").click(function () {

                // var initstr = '<a href="/DBCreater/DownloadFile?fileName=UserManageDB.xls&contentType=xls" class="form-control" style="border:none;">下载导入模板</a><input type="file" name="file" id="uploadFile" multiple class="file-loading" />'
                // $('#uploadFile-modal-body').html(initstr);

                mainMoudle.renderHtml('importTemplate','myModal');
                oFileInput.Init("uploadFile", "/DBCreater/ImportExcelFile");
                $("#myModal").modal();
            });

        },
        // 序列化模板
        renderHtml: function (tempId, renderId, data) {
            if (data)
            {
                var tempHtml = $('#' + tempId + '').render(data);
                $('#' + renderId + "").html(tempHtml);
            } else{
                var html = $('#' + tempId + '').html();
                 $('#' + renderId + "").html(html);
            }
        },
        postasync: function (url, data, successfun, errorfun) {

            if (successfun && errorfun) {
                $.ajax({
                    url: url,
                    type: "POST",
                    dataType: "json",
                    data: data,
                    success: successfun,
                    error: errorfun,
                });
            } else if (successfun) {
                $.ajax({
                    url: url,
                    type: "POST",
                    dataType: "json",
                    data: data,
                    success: successfun,
                });
            } else if (errorfun) {
                $.ajax({
                    url: url,
                    type: "POST",
                    dataType: "json",
                    data: data,
                    error: errorfun,
                });
            }
        }
    };

    $(function () {
        mainMoudle.main();
    });
});