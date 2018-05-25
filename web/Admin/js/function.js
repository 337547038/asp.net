;(function($){$.fn.layer=function(opt){var opt=$.extend({},$.fn.layer.defaults,opt);$(this).on(opt.trigger,function(){mainlayer(opt,0,$(this))})};jQuery.layer=function(opt){var opt=$.extend({},$.fn.layer.defaults,opt);mainlayer(opt,1,0)};$.fn.layer.defaults={width:null,height:null,trigger:"click",autoclose:0,title:"",contents:"",poptype:0,addclass:"",id:"",position:"fixed",closeparent:true,confirm:null,confirmback:null,cancel:null,cancelback:null,closeback:null,loadback:null,afterback:null,move:true,fadeout:0,fadein:0,masklayer:true,aligncenter:true,showclose:true};function mainlayer(opt,t,th){$("#greybackground").remove();if(opt.masklayer){$("body").append("<div id=\"greybackground\"></div>")}if(opt.loadback!=null){opt.loadback()}if(opt.closeparent){$(".alertlayer").hide()}var _layerclose="<a href=\"javascript:void(0);\" class=\"close layerclose\">关闭</a>",_layertitle="<h3 class=\"layertitle\"><b></b>"+opt.title+"</h3>",_layerbutton="";if(opt.confirm!=null||opt.cancel!=null){_layerbutton+="<div class=\"layerinput\">";if(opt.confirm!=null){_layerbutton+="<input class=\"layerbutton\" type=\"submit\" name=\"button\" value=\""+opt.confirm+"\">"}if(opt.cancel!=null){_layerbutton+="<input class=\"layerreset\" type=\"reset\" name=\"button\" value=\""+opt.cancel+"\">"}_layerbutton+="</div>"}var _alertlayer="";if(opt.poptype==0){var contents=opt.contents;if(opt.contents==""&&t==0){contents="."+th.attr("data-action")}_alertlayer=$(contents)}else if(opt.poptype==1){var _class="";if(opt.addclass!=""){_class=opt.addclass}else{_class="layer"+encodeURIComponent(opt.contents).replace(/%/g,'').replace(/ /g,'').replace(".",'').toLocaleLowerCase().substring(0,10)}var html="<div class=\""+_class+"\" data-type=\"1\">";html+="<div class=\"layercontent\"><p class=\"layerloading\">正在加载...</p></div>";html+="</div>";$("body").append(html);_alertlayer=$("."+_class);_alertlayer.children(".layercontent").load(opt.contents,function(){if(opt.afterback!=null){opt.afterback(_alertlayer)}})}else if(opt.poptype==2){var _class="";if(opt.addclass!=""){_class=opt.addclass}else{_class="layer"+encodeURIComponent(opt.contents).replace(/%/g,'').replace(/ /g,'').toLocaleLowerCase().substring(0,10)}var html="<div class=\""+_class+"\" data-type=\"1\">";html+="<div class=\"layertxt\"><span class=\"layericon\"></span>"+opt.contents+"</div>";html+="</div>";$("body").append(html);_alertlayer=$("."+_class)}else if(opt.poptype==3){var _class="";if(opt.addclass!=""){_class=opt.addclass}else{_class="layer"+encodeURIComponent(opt.contents).replace(/%/g,'').replace(/ /g,'').replace(".",'').toLocaleLowerCase().substring(0,10)}var html="<div class=\""+_class+"\" data-type=\"1\">";html+="<div class=\"layercontent\"><iframe frameborder=\"0\" width=\"100%\" height=\"100%\" src=\""+opt.contents+"\" scrolling=\"auto\" id=\"loadiframe\"></iframe></div>";html+="</div>";$("body").append(html);_alertlayer=$("."+_class)}if(!_alertlayer.hasClass("alertlayer")){_alertlayer.addClass("alertlayer")}_alertlayer.addClass(opt.addclass);if(opt.id!=""){_alertlayer.attr("id",opt.id)}if(_alertlayer.children(".layertitle").length==0&&opt.title!=""){_alertlayer.prepend(_layertitle)}if(_alertlayer.children(".layerclose").length==0&&opt.showclose){_alertlayer.prepend(_layerclose)}if(_alertlayer.children(".layerinput").length==0){_alertlayer.append(_layerbutton)}_alertlayer.fadeIn(opt.fadein);var newwidth=opt.width==null?_alertlayer.outerWidth(true):opt.width,newheight=opt.height==null?_alertlayer.outerHeight(true):opt.height,winwidth=$(window).width(),winheight=$(window).height(),sleft=$(window).scrollLeft(),_stop=$(window).scrollTop();if(opt.position!="absolute"){_stop=0}var left1=sleft+(winwidth-newwidth)/2,top=(winheight-newheight)/2;if(top<0){top=0}var top1=_stop+top;if(opt.aligncenter){_alertlayer.css({"width":newwidth,"height":newheight,"left":left1,"top":top1,"position":opt.position})}else{_alertlayer.css({"width":newwidth,"height":newheight,"position":opt.position})}if(opt.afterback!=null&&opt.poptype!=1){opt.afterback(_alertlayer)}if(opt.poptype==3){var hth=newheight;if(_alertlayer.children(".layertitle").length!=0){hth=newheight-_alertlayer.children(".layertitle").height()}_alertlayer.find("#loadiframe").css("height",hth)}var cleartime,clearautotime;if(opt.autoclose!=0){clearautotime=setTimeout(function(){layer.close(_alertlayer,opt.fadeout)},parseInt(opt.autoclose*1000));_alertlayer.find(".layerclosetime").remove();_alertlayer.append("<div class=\"layerclosetime\"></div>");autoclosetime(parseInt(opt.autoclose))}function autoclosetime(time){if(time>0){--time;_alertlayer.find(".layerclosetime").html(time+"秒后将关闭！");cleartime=setTimeout(function(){autoclosetime(time)},1000)}}if(opt.confirm!=null){_alertlayer.find(".layerbutton").click(function(e){if(opt.confirmback!=null){opt.confirmback(_alertlayer)}else{clearTimeout(cleartime);clearTimeout(clearautotime);layer.close(_alertlayer,opt.fadeout)}})}if(opt.cancel!=null){_alertlayer.find(".layerreset").click(function(e){if(opt.cancelback!=null){opt.cancelback(_alertlayer)}else{layer.close(_alertlayer,opt.fadeout)}})}_alertlayer.find(".close").click(function(e){if(opt.closeback!=null){opt.closeback(_alertlayer)}else{clearTimeout(cleartime);clearTimeout(clearautotime);layer.close(_alertlayer,opt.fadeout)}});if(opt.move){var docheight=$(document).height(),_move=false,_x,_y;_alertlayer.children("h3").mousedown(function(e){_move=true;_x=e.pageX-parseInt(_alertlayer.css("left"));_y=e.pageY-parseInt(_alertlayer.css("top"))});$(document).mousemove(function(e){if(_move){var x=e.pageX-_x;var y=e.pageY-_y;if(x<=0){x=0}if(x>winwidth-newwidth){x=winwidth-newwidth-10}if(y<=0){y=0}if(y>docheight-newheight){y=docheight-newheight}_alertlayer.css({top:y,left:x})}}).mouseup(function(){_move=false})}}})(jQuery);var layer={close:function(a,fo){var alertlayer=".alertlayer";if(a){alertlayer=a}if(!fo){fo=0}$(alertlayer).fadeOut(fo,function(){var layernum=0;$(".alertlayer").each(function(){if(!$(this).is(":hidden")){layernum++}});if(layernum<=0){$("#greybackground").remove()}if($(this).data("type")=="1"){$(this).remove()}})}}
///*****************以上封装弹窗****************//////
$(document).ready(function() {
    //头部点击选项卡
    $("#myCont > div:not(:first)").hide();
    var myLi = $("#myTop > ul > li");
    var myDiv = $("#myCont > div");
    myLi.each(function(i) {
        //$(this).mouseover(function(){
        $(this).click(function() {
            myLi.removeClass("hover");
            $(this).addClass("hover");
            myDiv.hide();
            myDiv.eq(i).show();
            $("#mainleft").show();
        });
    });

    /*添加选项*/
    $("#tabcontents > div:not(:first)").hide();
    var myLit = $("#tab > ul > li");
    var myDivt = $("#tabcontents > div.tabtxt");
    myLit.each(function(i) {
        $(this).click(function() {
            myLit.removeClass("hover");
            $(this).addClass("hover");
            myDivt.hide();
            myDivt.eq(i).show();
        });
    });

    //关闭打开左栏
    $(".closeopen").click(function() {
        $("#mainleft").toggle();
    });
    //左边收缩菜单
    $(".leftnav h3").click(function() {
        $(this).next("ul").toggle(500);
    });
    //窗口大小改变时设定宽高
    windowsize();
    $(window).resize(function() {
        windowsize();
    });
    //表格奇偶行隔色odd
    $(".comtable tr:even").addClass("backgroundcolor");
    //鼠标经过表格时变颜色
    $(".comtable td").append(" "); //在所有单元格上添加空格 
    $(".comtable tr").hover(
         function() {
             $(this).addClass("tdhover");    //鼠标经过添加hover样式 
         },
         function() {
             $(this).removeClass("tdhover");   //鼠标离开移除hover样式 
         }
         );

    //输入框显示提示效果
    $(".input,.textarea").focus(function() {
        $(this).addClass("focus");
    }).blur(function() {
        $(this).removeClass("focus");
    });

    //checkbox
    //全选
    $("#allcheck").click(function() {
        $(".comtable input[name=checkbox]").each(function() {
            $(this).attr("checked", true);
        });
    });

    //反选
    $("#invert").click(function() {
        $(".comtable input[name=checkbox]").each(function() {
            if ($(this).attr("checked")) {
                $(this).attr("checked", false);
            } else {
                $(this).attr("checked", true);
            }
        });
    });

});

/*********************************/
//窗口大小改变
function windowsize() {
    var windowheight = $(window).height();

    $(".mainleft").height(windowheight - 95);
    $("#mainright,#main").height(windowheight - 95);
    
}
/**********************************/
//可以自动关闭的提示
function jsprint(msgtitle, url) {
    $("#msgprint").remove();
    var str = "<div id=\"msgprint\">" + msgtitle + "</div>";
    $("body").append(str);
    $("#msgprint").show();
    if (url == "back") {
        main.history.back(-1);
    } else if (url == "#") {
        //main.location.href = main.location.href;	
    } else if (url != "") {
        main.location.href = url;
    }
    //3秒后清除提示
    setTimeout(function() {
        $("#msgprint").fadeOut(500);
        //如果动画结束则删除节点
        if (!$("#msgprint").is(":animated")) {
            $("#msgprint").remove();
        }
    }, 3000);
}