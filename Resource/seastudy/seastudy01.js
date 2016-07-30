define(function(){
	var mainMoudle = {
		main:function()
		{
			mainMoudle.initEvent();
		},
		result1deal:function()
		{
			var	data1 = {  
			    "name": "Josh",  
			    "address": {  
			       "city": "Shanghai"  
			    }     
			}  

			mainMoudle.renderHtml("result1Tmpl","result1",data1);
		},
		result2deal:function()
		{
			var data2=[  
				{  
				    "name": "Josh",  
				    "address": {  
				    "city": "Shanghai"  
				    }  
				},  
				{  
				    "name": "Wangsheng",  
					"address": {  
					    "city": "BiJie"  
					}  
				}  
				];

			mainMoudle.renderHtml("result1Tmpl","result1",data2);
		},
		result3deal:function()
		{
			var data = {  
			      "description": "A <b>very nice</b> appartment"  
			    };  
			mainMoudle.renderHtml("result3Tmpl","result3",data);
		},
		resultPeople:function()
		{
			var people = [  
		      {  
		        "name": "Pete",  
		        "address": {  
		          "city": "Seattle"  
		        }  
		      },  
		      {  
		        "name": "Heidi",  
		        "address": {  
		          "city": "Sidney"  
		        }  
		      }  
		    ];  

		    mainMoudle.renderHtml("peopleTemplate","peopleList",people);
		},

		result4deal:function()
		{
			var data = {  
			  "title": "The People:",  
			  "members": [  
			    {  
			      "name": "JoshWang",  
			      "address": {  
			        "city": "ShangHai"  
			      }  
			    },  
			    {  
			      "name": "WangSheng",  
			      "address": {  
			        "city": "GuiYang"  
			      }  
			    }  
			  ]  
			};  

			mainMoudle.renderHtml("result4Template","result4",data);
		},
		result5deal:function()
		{
			var data = {  
			  "title": "The A team",  
			  "members": []  
			};  

			mainMoudle.renderHtml("result5Template","result5",data);
		},

		result6deal:function()
		{
			var data = [  
			  {  
			    "title": "The A team",  
			    "members": [  
			      {  
			        "name": "JoshWang"  
			      },  
			      {  
			        "name": "Micheal Shi"  
			      }  
			    ],  
			    "standby": [  
			      {  
			        "name": "Xavier"  
			      }  
			    ]  
			  },  
			  {  
			    "title": "The B team",  
			    "members": [],  
			    "standby": [  
			      {  
			        "name": "Dunk"  
			      },  
			      {  
			        "name": "Adriana"  
			      }  
			    ]  
			  },  
			  {  
			    "title": "The C team",  
			    "standby": []  
			  }  
			];  

			mainMoudle.renderHtml("result6Template","result6",data);
		},
		renderHtml:function(tempId, renderId, data)
		{
			var tempHtml = $('#'+tempId+'').render(data);
			$('#' + renderId + "").html(tempHtml);
		},

		initEvent:function(){
			mainMoudle.result1deal();
			mainMoudle.result2deal();
			mainMoudle.result3deal();
			mainMoudle.resultPeople();
			mainMoudle.result4deal();
			mainMoudle.result5deal();
			mainMoudle.result6deal();
		}
	};

	$(function () {
        mainMoudle.main();
    });
});
