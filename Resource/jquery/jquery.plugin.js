/*
*   Jquery.plugin
*   wirte by zhujinrong 2016-07-22
*/

(function ($) {

    /**
    * 表单序列化插件
    * 例如：var obj = $('#addform').serializeJson();
    */
    $.fn.serializeJson = function () {
        var serializeObj = {};

        /** 
        this.serializeArray()的如下：
        [
              {
                "name": "KeyId",
                "value": ""
              },
              {
                "name": "carrier",
                "value": "FU-福州"
              },
              {
                "name": "carrier",
                "value": "KY-昆航"
              } 
        ]
        **/
        var array = this.serializeArray();

        // 这个序列化结果如：KeyId=&ProductType=0
        var str = this.serialize();
        $(array).each(function () {
            if (serializeObj[this.name]) {
                if ($.isArray(serializeObj[this.name])) {
                    serializeObj[this.name].push(this.value);
                } else {
                    serializeObj[this.name] = [serializeObj[this.name], this.value];
                }
            } else {
                serializeObj[this.name] = this.value;
            }
        });

        return serializeObj;
    };

})(jQuery);