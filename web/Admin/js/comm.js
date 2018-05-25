; (function ($) {
    $.fn.layer = function (opt) {
        var opt = $.extend({},
            $.fn.layer.defaults, opt);
        $(this).on(opt.trigger,
            function () {
                mainLayer(opt, 0, $(this));
            });
    }; //$("").layer()
    jQuery.layer = function (opt) {
        var opt = $.extend({},
            $.fn.layer.defaults, opt);
        mainLayer(opt, 1, 0);
    }; //$.layer()
    $.fn.layer.defaults = {
        width: null,
        height: null,
        trigger: "click",
        //触发事件,注意用mouseover代替hover
        autoClose: 0,
        //自动关闭，单位为秒，默认0不关闭
        title: "",
        //标题
        contents: "",
        popType: 0,
        //弹窗类型 0读取本页隐藏div(默认)，1加载外部文档，2直接显示contents文本
        className: "",
        //添加的class样式
        position: "fixed",
        //absolute和fixed。
        closeParent: true,
        //多层弹窗口时是否关闭父窗口
        confirm: null,
        //确定按钮文本，默认为空不显示
        confirmBack: null,
        //确定回调函数，仅当confirm不为null时；确定按钮不为空和回调为空时，确定后关闭窗口
        cancel: null,
        //取消按钮，默认为空，不显示
        cancelBack: null,
        //取消按钮回调，仅当cancel不为null时；取消按钮不为空和回调为空时，取消后关闭窗口
        closeBack: null,
        //关闭时回调，为空时关闭，回调时不关闭窗口
        loadBack: null,
        //窗口加载后回调
        afterBack: null,
        move: true,
        //允许窗口移动
        maskLayer: "body",
        //显示遮罩层，默认为body。false时不显示，值为遮罩层显示位置，即将遮罩层放在指定的标签内，方便在一些框架页里遮罩层只显示在主内容区
        align: true,
        //窗口默认垂直居中对齐，默认为true居中，false时请在css中设置left和top。方便将窗口定位在其它位置
        showClose: true,
        //显示关闭按钮
        shadeClose: false, //点击遮罩关闭 false不关闭
        animation: 1,//弹出层css3动画效果，仅在支持的浏览器。动画序号对应animation样式的alert-anim-*
        noScroll: true //弹出层后body禁止滚动
    };
    function mainLayer(opt, lt, th) {
        $("#grey-background").remove();
        if (opt.maskLayer) {
            $(opt.maskLayer).append('<div id="grey-background"></div>');
        }
        //添加body属性阻止页面滚动，先判断页面是否存在滚动条
        /*if ($(window).height() < $(document).height()) {
         //存在
         $('body').css({position:'fixed',width:'100%',overflowY:'scroll',top: - $( window ).scrollTop()});
         } else {
         //不存在
         $('body').css({overflow:'hidden'});
         }*/
        if (opt.noScroll) {
            $("body").css({ overflow: 'hidden' });
        }
        if (opt.loadBack != null) { //加载后回调
            opt.loadBack();
        }
        if (opt.closeParent) {
            $(".alert-layer").hide();
        } else {
            //两层弹窗时将已展示的弹窗移至遮罩层下面
            $(".alert-layer").each(function () {
                if (!$(this).is(":hidden")) {
                    $(this).css({ "z-index": 20141126 });
                }
            });
        }
        var hc = "";//关闭标签
        var ht = "";//标题标签
        var hb = "";//按钮标签
        var c = "";//当前类样式
        var $c = "";//当前类名形式$(".a")
        hc = '<a href="javascript:;" class="close alert-close bg-icon">×</a>';
        ht = '<h3 class="alert-title"><b></b><span>' + opt.title + '</span></h3>';
        if (opt.confirm != null || opt.cancel != null) {
            hb += '<div class="alert-button">';
            if (opt.confirm != null) {
                hb += '<input class="btn btn-confirm" type="submit" name="button" value="' + opt.confirm + '">';
            }
            if (opt.cancel != null) {
                hb += '<input class="btn btn-cancel" type="reset" name="button" value="' + opt.cancel + '">';
            }
            hb += "</div>";
        }
        var comm = {
            subtr: function () {
                var lc = encodeURIComponent(opt.contents).replace(/%/g, '').replace(/ /g, '').replace(/\./g, '').toLocaleLowerCase();
                return "layer" + lc.substring(0, 10) + lc.substring(lc.length - 5); //过滤%和空格转小写，取前面10位+后5位，减少提示语相近的问题
            },
            position: function (layer) {
                var ww = $(window).width();
                var wh = $(window).height();
                var aw = opt.width == null ? layer.outerWidth(true) : opt.width;
                layer.css({ "width": aw });//在一些情况，还没设置窗口宽时，高度会计算不准确，因此这里先设定宽
                //高度计算方法，参数设定的则按设置的，否则按窗口实际高，如果窗口高于浏览器，则按浏览器高
                //ah = opt.height == null ? $c.outerHeight(true) : opt.height;
                var ah = "";//窗口高
                if (opt.height != null) {
                    ah = opt.height;
                } else {
                    if (layer.outerHeight(true) > wh) {
                        ah = wh;
                    } else {
                        ah = layer.outerHeight(true);
                    }
                }
                var sl = $(window).scrollLeft(); //获取滚动条的宽度
                var st = $(window).scrollTop(); //获取滚动条的高度
                if (opt.position != "absolute") {
                    st = 0;
                }
                var al = sl + (ww - aw) / 2;//窗口left位置
                var at = (wh - ah) / 2;//窗口top位置
                if (at < 0) {
                    at = 0;
                }
                at = st + at;
                layer.css({
                    //"height": ah,
                    "position": opt.position
                });
                if (opt.align) {
                    layer.css({
                        "left": al,
                        "top": at
                    });
                }
                //内容滚动条，需要在css中设置alert-content的overflow:auto。若某些窗口不需要滚动条，只需添加一个样式，重写alert-content的overflow即可,个别情况下需要指定alert-content的高度
                var ac = $c.children(".alert-content");
                if (ac.length > 0) {
                    var scrollHeight = parseInt(getData($c, "scrollHeight"));
                    if (scrollHeight > 0) {
                        ac.css({ "height": scrollHeight });
                    }
                    else {
                        var sh = 0, sat = 0, sc = 0;
                        if ($c.children(".alert-title").length > 0) {
                            sat = parseInt($c.children(".alert-title").outerHeight(true));//标题栏高度
                        }
                        sc = parseInt(ac.css("padding-top")) + parseInt(ac.css("padding-bottom"));//内容边距
                        sh = ah - sat - sc;
                        ac.css({ "height": sh });
                    }
                }
                if (opt.move) {
                    var mt = $c.children(".alert-title");
                    var m = false, dh = $(document).height();
                    var xx, yy;
                    mt.css({ "cursor": "move" });//鼠标显示可移动形状
                    mt.mousedown(function (e) {
                        $("body").append('<div class="alert-moves" style="width:' + (aw - 6) + 'px;height:' + (ah - 6) + 'px;left:' + $c.css("left") + ';top:' + $c.css("top") + ';position:' + opt.position + '" data-layer="' + c + '"></div>');//这里宽高要减去边框的
                        m = true;
                        xx = e.pageX - parseInt($c.css("left"));
                        yy = e.pageY - parseInt($c.css("top"));
                        if (document.attachEvent) {//ie的事件监听，拖拽div时禁止选中内容，firefox与chrome可在css中设置过-moz-user-select: none; -webkit-user-select: none;
                            mt[0].attachEvent('onselectstart', function () {
                                return false;
                            });
                        }
                        return false;
                    });
                    $(document).mousemove(function (e) {
                        if (m) {
                            var x = e.pageX - xx;
                            var y = e.pageY - yy;
                            if (x <= 0) {
                                x = 0
                            } else if (x > ww - aw) {
                                x = ww - aw
                            }
                            if (y <= 0) {
                                y = 0
                            } else if (y > dh - ah) {
                                y = dh - ah
                            }
                            $(".alert-moves").css({
                                top: y,
                                left: x
                            });
                            return false;
                        }
                    }).mouseup(function () {
                        m = false;
                        var am = $(".alert-moves");
                        if (getData(am, "layer") != "") {
                            $("." + getData(am, "layer")).animate({ "left": am.css("left"), "top": am.css("top") });
                        }
                        am.remove();
                    });
                }
            }
        };
        if (opt.popType == 0) { //读取本页隐藏div
            c = opt.contents.replace(".", '');//去掉前面的点
            if (opt.contents == "" && lt == 0) { //如果内容为空时，读取当前节点data-action属性值（要显示的层类名），仅当使用$("").layer()调用才存在当前节点
                c = getData(th, "action");
                $c = $("." + c);
            } else {
                $c = $("." + c);
            }
        } else if (opt.popType == 1) {
            //加载外部
            var h;
            c = comm.subtr();
            $c = $("." + c);
            if ($c.length == 0) {
                $("body").append('<div class="alert-loading">正在加载...</div>');
                h = '<div class="' + c + '" data-type="1">';
                h += '<div class="alert-content"><div class="alert-load"></div></div>';
                h += "</div>";
                $("body").append(h);
                $c = $("." + c);
                $c.find(".alert-load").load(opt.contents,
                    function (response, status, xhr) {
                        $(".alert-loading").remove();//移除正在加载字样
                        if (status == "success") {
                            if (opt.afterBack != null) {
                                opt.afterBack($c)
                            }
                        } else {
                            $c.find(".alert-load").html("加载错误：" + xhr.statusText);
                        }
                        comm.position($c);
                        $c.addClass("alert-anim-" + opt.animation).show();//添加动画样式并显示层
                    });
            } else {
                $c.show();
                if (opt.afterBack != null) {
                    opt.afterBack($c)
                }
            }
            $c = $("." + c);
        }
        else if (opt.popType == 2) {
            //直接显示内容
            var h;
            c = comm.subtr();
            $c = $("." + c);
            if ($c.length == 0) {
                h = '<div class="' + c + '" data-type="1">';
                h += '<div class="alert-content"><div class="alert-txt"><span class="icon"></span>' + opt.contents + '</div></div>';
                h += "</div>";
                $("body").append(h);
            }
            $c = $("." + c);
        } else if (opt.popType == 3) {
            //iframe
            var h;
            c = comm.subtr();
            h = '<div class="' + c + '" data-type="1">';
            h += '<div class="alert-content alert-iframe">';
            h += "<iframe frameborder=\"0\" id=\"alertIFrame\" name=\"alertMain\" scrolling=\"yes\" src=\"" + opt.contents + "\" width=\"100%\"></iframe>";
            h += "</div></div>";
            $("body").append(h);
            $c = $("." + c);
        }
        if (!$c.hasClass("alert-layer")) { //如果没有样式alertlayer，则添加一个
            $c.addClass("alert-layer");
        }
        //居中对齐时设置属性，方便设置窗口在缩放时保持居中
        if (!opt.align) {
            $c.attr("data-resize", "1");
        }
        $c.addClass(opt.className);
        if ($c.children(".alert-title").length == 0 && opt.title != "") {
            $c.prepend(ht);
        }
        if ($c.children(".alert-close").length == 0 && opt.showClose) {
            $c.prepend(hc);
        }
        if ($c.find(".alert-button").length == 0) {
            $c.children(".alert-content").append(hb);
        }
        //加载完成后回调，及计算窗宽高及位置，popType=1外部加载时不在这里返回及计算
        if (opt.popType != 1) {
            comm.position($c);
            $c.addClass("alert-anim-" + opt.animation).show();//添加动画样式并显示层
            //popType=3时
            if(opt.popType==3){
                $("#alertIFrame").height($c.children(".alert-content").height());
            }

            if (opt.afterBack != null) {
                opt.afterBack($c)
            }
        }
        //点击遮罩关闭
        if (opt.shadeClose) {
            $("#grey-background").on("click",
                function () {
                    if (opt.autoClose == 0) {
                        layer.close()
                    }
                })
        }
        var cleartime;
        if (opt.autoClose != 0) {
            $c.find(".alert-closetime").remove();
            $c.append('<div class="alert-closetime"></div>');
            autoCloseTime(parseInt(opt.autoClose));
        }
        function autoCloseTime(time) {
            if (time > 0) {
                --time;
                $c.find(".alert-closetime").html(time + "秒后将关闭！");
                cleartime = setTimeout(function () {
                    autoCloseTime(time);
                },
                    1000);
            } else {
                if (opt.closeback != null) {
                    opt.closeback($c)
                } else {
                    layer.close($c)
                }
            }
        }

        //buttton callback
        if (opt.confirm != null) {
            $c.find(".btn-confirm").click(function (e) {
                if (opt.confirmBack != null) {
                    opt.confirmBack($c);
                } else {
                    clearTimeout(cleartime);
                    layer.close($c);
                }
                e.stopImmediatePropagation();//阻止连续触发事件
            });
        }
        if (opt.cancel != null) {
            $c.find(".btn-cancel").click(function (e) {
                if (opt.cancelBack != null) {
                    opt.cancelBack($c);
                } else {
                    layer.close($c);
                }
                e.stopImmediatePropagation();//阻止连续触发事件
            });
        }
        //close
        $c.on("click", ".close", function (e) {
            //$c.find(".close").on("click", function (e) {
            if (opt.closeBack != null) {
                opt.closeBack($c);
            } else {
                clearTimeout(cleartime);
                layer.close($c);
            }
            e.stopImmediatePropagation();//阻止连续触发事件
        });
        //move

        //浏览器窗口改变时保持居中位置
        $(window).resize(function () {
            var rww = $(window).width(), rwh = $(window).height(), rst = $(window).scrollTop(); //获取滚动条的高度;
            $(".alert-layer").each(function () {
                var rth = $(this);
                if (getData(rth, "resize") != "1") {
                    var rl = (rww - rth.outerWidth(true)) / 2;
                    var rt = (rwh - rth.outerHeight(true)) / 2;
                    if (opt.position == "absolute") {
                        rt = rt + rst;
                    }
                    rth.animate({ "left": rl, "top": rt });
                }
            });

        });
    } //mainLayer
    $.fn.extend({
        placeholder: function (opt) {
            opt = jQuery.extend({
                fc: "focus" //取点焦点时添加的样式
            },
                opt);
            //判断浏览器支持状态，ie9及以下使用
            //如果浏览器不支持placeholder属性
            /*var isie = $.browser.msie,
             v = $.browser.version,
             dm = document.documentMode;
             if ((isie && dm <= 9) || (isie && v <= 9.0 && !dm)) {*/
            if (!('placeholder' in document.createElement('input'))) {
                $(this).each(function () {
                    var $this = $(this);
                    if ($this.attr("placeholder") != "" && typeof ($this.attr("placeholder")) != "undefined" && $this[0].tagName == "INPUT" && $this.next("span.placeholder").length == 0) {
                        var block = "block", t = $this.position().top,
                            lf = $this.position().left;
                        // if (getData($this, "display") == "none") {
                        //     t = 0;
                        //     lf = 0
                        // }
                        if ($this.val() != "") {
                            block = "none"
                        }
                        $this.after('<span class="placeholder" style="z-index:10;display:' + block + ';position:absolute;cursor:text;left:' + lf + 'px;top:' + t + 'px;height:' + $this.outerHeight() + 'px;width:' + $this.width() + 'px;padding-left:' + $this.css("padding-left") + '">' + $this.attr("placeholder") + '</span>');
                        $("span.placeholder").on("click",
                            function () {
                                $(this).prev("input").focus();
                            });
                    }
                });
                $(this).on("focus",
                    function () {
                        var $this = $(this);
                        //IE兼容问题，做个判断只有input才添加焦点样式，div不添加
                        if ($this[0].tagName == "INPUT") {
                            $this.addClass(opt.fc);
                        }
                        $this.next("span.placeholder").hide();
                    }).on("blur",
                    function () {
                        var $this = $(this);
                        $this.removeClass(opt.fc);
                        if ($this.val() != "") {
                            $this.next("span.placeholder").hide();
                        } else {
                            $this.next("span.placeholder").show();
                        }
                    });
                //     .live("keyup", function () {
                //     var $this = $(this);
                //     if ($this.val() != "") {
                //         $this.next("span.placeholder").hide();
                //     } else {
                //         $this.next("span.placeholder").show();
                //     }
                //  });
            }
        },
        tabs: function (opt) {
            opt = jQuery.extend({
                trigger: "click",
                callBack: null,
                content: ".tab-content"
            }, opt);
            var $tab = $(this).find("li");
            var parent = $(opt.content);
            //parent.find('.tab-pane:first').addClass('active');
            $tab.on(opt.trigger, function () {
                var th = $(this);
                var container = th.parents('.tab-container');
                if (container.length > 0) {
                    parent = container.children(opt.content);
                }
                th.addClass("active").siblings().removeClass("active");
                parent.find(".tab-pane").removeClass('active').eq(th.index()).addClass('active');
                if (opt.callBack != null) {
                    opt.callBack(th)
                }
            })
        }
    });
    //查找当前标签属性，经常用到将它提出来
    function getData(th, data) {
        if (typeof (th.data(data)) == "undefined") {
            return "";
        }
        else {
            return th.data(data)
        }
    }
})(jQuery);
var layer = {
    close: function (a) {
        var l = $(".alert-layer"), i = 0;
        if (a) {
            l = a
        }
        l.fadeOut(0,
            function () {
                $(".alert-layer").each(function () {
                    if (!$(this).is(":hidden")) {
                        i++;
                        $(this).css({ "z-index": "" });
                    }
                });
                //如果没传参数进来，则关闭所有窗口并且关闭遮罩层
                if (i <= 0 || !a) {
                    $("#grey-background").remove();
                    //去掉body属性
                    $("body").css({ overflow: 'visible' });
                }
            });
        if (l.data("type") == 1) {
            l.remove()
        }
        return false;
    }
};


$(function () {
    $(".input-control").placeholder();//输入框焦点事件，仅对ie9或以下
    $(".open-layer").layer();//全局放一个弹层，方便使用
    $('.tab').tabs();
    niceScroll();
    $(".left-sidebar h3").click(function () {
        $(this).toggleClass("show");
        $(this).next("ul").toggle(500);
        niceScroll();
    });
    $('.left-siderbar-control').click(function () {
        $('.main-body').toggleClass('open')
    });
    $(".comm-table > tbody > tr:even").addClass("background-color");
    $(".comm-table td").append(" ");
    $(".comm-table > tbody > tr").hover(function () {
        $(this).addClass("tdhover")
    },
    function () {
        $(this).removeClass("tdhover")
    });
    $(".comm-table .item:even").addClass("background-color");
    //全选
    $("#allcheck").click(function () {
        var checked = $(this).prop("checked");
        $(".comm-table input[name=checkbox]").each(function () {
            $(this).prop("checked", checked)
        });
    });
    
    autoHeight();
    $(window).resize(function () {
        autoHeight();
    });
    //表单验证
    if ($("#aspnetForm").length > 0) {
        $("#aspnetForm").validate();
    }


});
/*滚动条*/
function niceScroll() {
    if ($(".niceScroll").length > 0) {
        $(".niceScroll").niceScroll();
    }
}
function autoHeight() {
    var ww = $(window).height() - 65;
    $(".iframe").height(ww);
    $('#iframe').css({ width: '100%', height: ww });
}
//可以自动关闭的提示
function jsprint(msgtitle, url) {
    $("#msgprint").remove();
    var str = "<div id=\"msgprint\"><i></i>" + msgtitle + "</div>";
    $("body").append(str);
    $("#msgprint").animate({ top: 0 });
    if (url == "back") {
        main.history.back(-1);
    } else if (url == "#") {
        //main.location.href = main.location.href;	
    } else if (url != "") {
        main.location.href = url;
    }
    //3秒后清除提示
    setTimeout(function () {
        $("#msgprint").animate({ top: '-40px' }, function () {
            $("#msgprint").remove();
        });

    }, 3000);
}
if ($.validator !== undefined) {

    $.extend($.validator.messages, {
        required: '必选字段',
        equalTo: "请再次输入相同的值",
        number: "请输入合法的数字",
        digits: "只能输入整数",
        email: "电子邮件格式有误"
    });
    jQuery.validator.addMethod("mail",
        function (value, element) {
            var mail = /^[a-z0-9._%-]+@([a-z0-9-]+\.)+[a-z]{2,4}$/;
            return this.optional(element) || (mail.test(value))
        },
        "邮箱格式不对");
    jQuery.validator.addMethod("phone",
        function (value, element) {
            var phone = /^0\d{2,3}-\d{7,8}$/;
            return this.optional(element) || (phone.test(value))
        },
        "电话格式如：020-12345678");
    jQuery.validator.addMethod("mobile",
        function (value, element) {
            var mobile = /^1[3|4|5|7|8]\d{9}$/;
            return this.optional(element) || (mobile.test(value))
        },
        "手机格式不对");
    jQuery.validator.addMethod("fax",
        function (value, element) {
            var fax = /^(\d{3,4})?[-]?\d{7,8}$/;
            return this.optional(element) || (fax.test(value))
        },
        "传真格式如：020-12345678");
    jQuery.validator.addMethod("tm",
        function (value, element) {
            var tm = /(^1[3|4|5|7|8]\d{9}$)|(^\d{3,4}-\d{7,8}$)|(^\d{7,8}$)|(^\d{3,4}-\d{7,8}-\d{1,4}$)|(^\d{7,8}-\d{1,4}$)/;
            return this.optional(element) || (tm.test(value))
        },
        "电话或手机格式不对");
    jQuery.validator.addMethod("idCard",
        function (value, element) {
            var isIDCard1 = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/;
            var isIDCard2 = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/;
            return this.optional(element) || (isIDCard1.test(value)) || (isIDCard2.test(value))
        },
        "请输入正确的身份证号，尾号为X时，请大写");
    jQuery.validator.addMethod("letters",
    function (value, element) {
        var v = /^[0-9a-zA_Z]+$/;
        return this.optional(element) || (v.test(value))
    },
    "请输入字母或数字");
}