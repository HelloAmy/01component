define(function () {

    var mainModule = {
        roleInfoArray: [],

        init: function () {

            // 获取所有角色信息
            mainModule.roleInfoArray = mainModule.getsync("/RoleInfo/Get");

            // 绑定添加按钮
            $('#addbtn').click(function () {

                var model = {
                    KeyID: '',
                    LoginName: '',
                    Password: '',
                    UserName: '',
                    Telephone: '',
                    Email: '',
                };

                model.RoleInfoArray = mainModule.roleInfoArray;
            });
        },

        getsync: function (url) {
            var returnJson = $.ajax({
                url: url,
                type: "GET",
                dataType: "json",
                async: false,
            }).responseText;

            // 转model
            var obj = $.parseJSON(returnJson);
            return obj;
        },
    };

    $(function () {
        mainModule.init();
    });
});