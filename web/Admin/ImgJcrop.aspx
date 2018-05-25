<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImgJcrop.aspx.cs" Inherits="Admin_ImgJcrop" EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Editor/themes/default/default.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.12.4.min.js" type="text/javascript"></script>
    <script src="js/jquery.Jcrop.min.js" type="text/javascript"></script>
    <script src="../Editor/kindeditor-all-min.js" type="text/javascript"></script>
    <script src="js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="js/comm.js" type="text/javascript"></script>

    <script type="text/javascript">
        jQuery(function($) {
            var jcrop_api;
            $('#target').Jcrop({
                onChange: showCoords,
                onSelect: showCoords,
                onRelease: clearCoords
            }, function() {
                jcrop_api = this;
				jcrop_api.animateTo([0,0,<%=iw%>,<%=ih%>]);//初始化位置和大小
				//aspectRatio锁定比例缩放,minSize最小
				jcrop_api.setOptions({ 
				aspectRatio: <%=iw%>/<%=ih%>,
				minSize: [<%=iw%>,<%=ih%>] 
				});
            });
        });

        // Simple event handler, called from onChange and onSelect
        // event handlers, as per the Jcrop invocation above
        function showCoords(c) {
            $('#x1').val(parseInt(c.x));
            $('#y1').val(parseInt(c.y));
            $('#x2').val(parseInt(c.x2));
            $('#y2').val(parseInt(c.y2));
            $('#w').val(parseInt(c.w));
            $('#h').val(parseInt(c.h));
        };

        function clearCoords() {
            // $('#coords input').val('');
        };
       <%-- function imgJcropsuccess(){
            // parent.imgJcropsuccess("<%=id %>", "<%=picPath %>");
            parent.imgJcropsuccess("txtPicUrl", "/UpLoadFile/image/20170827/20170827151022_9115.jpg");
        }--%>
        //$(function(){
        //    $(".ab").click(function(){
        //        imgJcropsuccess();
        //    })
        //})

       
    </script>

    <style type="text/css">
        .img{height: auto; /* overflow: hidden;*/ margin: 0 auto;text-align: center; padding: 0 5px;}
        .img img{/*max-width: 800px;*/margin: 0 auto;text-align: center;}
        .pbutton{margin: 20px auto;display: block; }
        .txt{margin: 20px;text-align: center;color: #f00;line-height: 18px;}
        .uploadb{ margin: 20px auto;text-align: center;}
        .uploadb .ke-upload-area{width:auto!important}
        .uploadb .ke-upload-file{cursor:pointer}
        .uploadb .ke-button-common{height:30px; line-height:30px;}
        .uploadb .ke-button {background:#2e8ded;padding: 0 15px;height:30px; line-height:30px;border:0;color:#fff;cursor:pointer}
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <%
      if (String.IsNullOrEmpty(Request.QueryString["ac"]))
      {		 
    %>
    <script type="text/javascript">
        KindEditor.ready(function(K) {
            var uploadbutton = K.uploadbutton({
                button: K('#uploadButton')[0],
                fieldName: 'imgFile',
                url: '../Editor/handler/upload_json.ashx?dir=image',
                afterUpload: function(data) {
                    if (data.error === 0) {
                        var url = K.formatUrl(data.url, 'absolute');
                        // K('#url').val(url);
                        //window.location.href = "imgjcrop.aspx?ac=next&w=<%=iw%>&h=<%=ih %>&id=<%=id %>&p=" + url;
                        $.layer({ contents: "imgjcrop.aspx?ac=next&w=<%=iw%>&h=<%=ih %>&id=<%=id %>&p="+ url, popType: 3,width:$(window).width(),height:$(window).height()});
                    } else {
                        alert(data.message);
                    }
                },
                afterError: function(str) {
                    alert('自定义错误信息: ' + str);
                }
            });
            uploadbutton.fileBox.change(function(e) {
                uploadbutton.submit();
            });
        });
    </script>

    <div class="uploadb">
        <input type="button" id="uploadButton" value="请先浏览上传图片" class="" />
    </div>
    <%}
      else if (Request.QueryString["ac"] == "next")
      { %>
    <div class="img">
        <div class="txt">
            提示：请拖动左上角图片裁剪选框来选取图片，单击边框拖动可调整选框的大小<br />
            选取确认后请单击裁剪并保存图片按钮。若没显示选取框，<span onclick="location.reload();" style="cursor: pointer;
                color: #00F">请点这里刷新</span>
            <asp:Button ID="Button1" runat="server" Text="裁剪并保存图片" OnClick="saveImg" CssClass="pbutton btn"/>
        </div>
        <asp:Image ID="target" runat="server" />
       <div class="txt">
        <asp:Button ID="Button2" runat="server" Text="裁剪并保存图片" OnClick="saveImg" CssClass="pbutton btn"/>
        </div>
        <div style="display: none">
            x1<asp:TextBox ID="x1" runat="server"></asp:TextBox>
            y1<asp:TextBox ID="y1" runat="server"></asp:TextBox>
            x2<asp:TextBox ID="x2" runat="server"></asp:TextBox>
            y2<asp:TextBox ID="y2" runat="server"></asp:TextBox>
            w<asp:TextBox ID="w" runat="server"></asp:TextBox>
            h<asp:TextBox ID="h" runat="server"></asp:TextBox>
        </div>
    </div>
    <%} %>
    </form>
</body>
</html>
