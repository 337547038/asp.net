<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="netinfo.aspx.cs" Inherits="Admin_netinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="C#" runat="server">
        public void Page_Load(Object sender, EventArgs e)
        {
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            if (!Page.IsPostBack)
            {
                ((Literal)Master.FindControl("breadcrumbs")).Text = "<a href=\"netinfo.aspx\" class=\"home\">服务器探针</a>";
                //取得页面执行开始时间
                DateTime stime = DateTime.Now;


                //取得服务器相关信息
                servername.Text = Server.MachineName;
                serverip.Text = Request.ServerVariables["LOCAL_ADDR"];
                server_name.Text = Request.ServerVariables["SERVER_NAME"];

                //char[] de = {';'};
                //string allhttp=Request.ServerVariables["HTTP_USER_AGENT"].ToString();
                //string[] myFilename = allhttp.Split(de);
                //servernet.Text=myFilename[myFilename.Length-1].Replace(")"," ");
                //serverms.Text=myFilename[0];
                //serverie.Text=myFilename[1];
                serverms.Text = Environment.OSVersion.ToString();
                servernet.Text = System.Environment.Version.ToString();
                ServerRunTime.Text = ((System.Environment.TickCount / 600 / 60) / 100).ToString() + "&nbsp;小时，即：" + ((System.Environment.TickCount / 60000)).ToString() + "分钟，即：" + ((System.Environment.TickCount / 1000)).ToString() + "秒";


                serversoft.Text = Request.ServerVariables["SERVER_SOFTWARE"];
                serverport.Text = Request.ServerVariables["SERVER_PORT"];
                serverout.Text = Server.ScriptTimeout.ToString();
                serverlan.Text = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
                servertime.Text = DateTime.Now.ToString();
                serverppath.Text = Request.ServerVariables["APPL_PHYSICAL_PATH"];
                servernpath.Text = Request.ServerVariables["PATH_TRANSLATED"];
                serverhttps.Text = Request.ServerVariables["HTTPS"];
                if (chkobj("ADODB.RecordSet"))
                {
                    serveraccess.Text = "支持";
                }
                else { serveraccess.Text = "不支持"; }
                if (chkobj("Scripting.FileSystemObject"))
                {
                    serverfso.Text = "支持";
                }
                else { serverfso.Text = "不支持"; }
                if (chkobj("CDONTS.NewMail"))
                {
                    servercdonts.Text = "支持";
                }
                else { servercdonts.Text = "不支持"; }
                servers.Text = Session.Contents.Count.ToString();
                servera.Text = Application.Contents.Count.ToString();

                //0.1版添加的组件验证，原有组件并未转移过来，请原谅。 
                if (chkobj("JMail.SmtpMail"))
                {
                    jmail.Text = "支持";
                }
                else { jmail.Text = "不支持"; }

                if (chkobj("Persits.MailSender"))
                {
                    aspemail.Text = "支持";
                }
                else { aspemail.Text = "不支持"; }

                if (chkobj("Geocel.Mailer"))
                {
                    geocel.Text = "支持";
                }
                else { geocel.Text = "不支持"; }

                if (chkobj("SmtpMail.SmtpMail.1"))
                {
                    smtpmail.Text = "支持";
                }
                else { smtpmail.Text = "不支持"; } //51+aspx

                if (chkobj("Persits.Upload.1"))
                {
                    aspup.Text = "支持";
                }
                else { aspup.Text = "不支持"; }

                if (chkobj("aspcn.Upload"))
                {
                    aspcnup.Text = "支持";
                }
                else { aspcnup.Text = "不支持"; }

                if (chkobj("LyfUpload.UploadFile"))
                {
                    lyfup.Text = "支持";
                }
                else { lyfup.Text = "不支持"; }

                if (chkobj("SoftArtisans.FileManager"))
                {
                    soft.Text = "支持";
                }
                else { soft.Text = "不支持"; }

                if (chkobj("w3.upload"))
                {
                    dimac.Text = "支持";
                }
                else { dimac.Text = "不支持"; }

                if (chkobj("W3Image.Image"))
                {
                    dimacimage.Text = "支持";
                }
                else { dimacimage.Text = "不支持"; }




                //取得用户浏览器信息
                HttpBrowserCapabilities bc = Request.Browser;
                ActiveXControls.Text = bc.ActiveXControls.ToString();
                aol.Text = bc.AOL.ToString();
                back.Text = bc.BackgroundSounds.ToString();
                beta.Text = bc.Beta.ToString();
                ie.Text = bc.Browser.ToString();
                cdf.Text = bc.CDF.ToString();
                cookies.Text = bc.Cookies.ToString();
                crawler.Text = bc.Crawler.ToString();
                frames.Text = bc.Frames.ToString();
                javaa.Text = bc.JavaApplets.ToString();
                javas.Text = bc.JavaScript.ToString();
                mav.Text = bc.MajorVersion.ToString();
                miv.Text = bc.MinorVersion.ToString();
                ms.Text = bc.Platform.ToString();
                tables.Text = bc.Tables.ToString();
                type.Text = bc.Type.ToString();
                vbs.Text = bc.VBScript.ToString();
                vi.Text = bc.Version.ToString();
                win16.Text = bc.Win16.ToString();
                win32.Text = bc.Win32.ToString();


                //取得页面执行结束时间
                DateTime etime = DateTime.Now;


                //计算页面执行时间
                runtime.Text = ((etime - stime).TotalMilliseconds).ToString();
            }
        }

        //组件支持验证代码

        bool chkobj(string obj)
        {
            try
            {
                object meobj = Server.CreateObject(obj);
                return (true);
            }
            catch (Exception objex)
            {
                return (false);
            }
        }

        //100万次循环测试，由0.1sn bulid 021203开始加入

        public void turn_chk(Object Sender, EventArgs e)
        {
            DateTime ontime = DateTime.Now;
            int sum = 0;
            for (int i = 1; i <= 10000000; i++)
            {
                sum = sum + i;
            }
            DateTime endtime = DateTime.Now;
            l1000.Text = ((endtime - ontime).TotalMilliseconds).ToString() + "毫秒";
        }

        //自定义组件检测0.1版加入

        public void chkzujian(Object Sender, EventArgs e)
        {
            string obj = zujian.Text;
            if (chkobj(obj))
            {
                l001.Text = "检测结果：支持组件" + obj;
            }//51-aspx
            else { l001.Text = "检测结果：不支持组件" + obj; }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="comm-table margin-bottom">
        <tr>
            <th colspan="4">.net 服务器相关信息</th>
        </tr>
        <tr>
            <td>服务器名称：</td>
            <td>
                <asp:label id="servername" runat="server" />
            </td>
            <td>服务器IP地址：</td>
            <td>
                <asp:label id="serverip" runat="server" />
            </td>
        </tr>
        <tr>
            <td>服务器域名：</td>
            <td>
                <asp:label id="server_name" runat="server" />
            </td>
            <td>服务器操作系统：</td>
            <td>
                <asp:label id="serverms" runat="server" />
            </td>
        </tr>
        <tr>
            <td>服务器IIS版本：</td>
            <td>
                <asp:label id="serversoft" runat="server" />
            </td>
            <td>.NET解释引擎版本：</td>
            <td>
                <asp:label id="servernet" runat="server" />
            </td>
        </tr>
        <tr>
            <td>HTTP访问端口：</td>
            <td>
                <asp:label id="serverport" runat="server" />
            </td>

            <td>服务端脚本执行超时：</td>
            <td>
                <asp:label id="serverout" runat="server" />
                秒</td>
        </tr>
        <tr>
            <td>所用语言：</td>
            <td>
                <asp:label id="serverlan" runat="server" />
            </td>

            <td>服务器现在时间：</td>
            <td>
                <asp:label id="servertime" runat="server" />
            </td>
        </tr>
        <tr>
            <td>服务器运行时间：</td>
            <td>
                <asp:label id="ServerRunTime" runat="server" />
            </td>

            <td>虚拟目录绝对路径：</td>
            <td>
                <asp:label id="serverppath" runat="server" />
            </td>
        </tr>
        <tr>
            <td>执行文件绝对路径：</td>
            <td>
                <asp:label id="servernpath" runat="server" />
            </td>

            <td>HTTPS：</td>
            <td>
                <asp:label id="serverhttps" runat="server" />
            </td>
        </tr>
        <tr>
            <td>虚拟目录Session总数：</td>
            <td>
                <asp:label id="servers" runat="server" />
            </td>

            <td>虚拟目录Application总数：</td>
            <td>
                <asp:label id="servera" runat="server" />
            </td>
        </tr>
        <tr>
            <th colspan="4">常见组件支持情况</th>
        </tr>
        <tr>
            <td>Access数据库：</td>
            <td>
                <asp:label id="serveraccess" runat="server" />
            </td>

            <td>FSO：</td>
            <td>
                <asp:label id="serverfso" runat="server" />
            </td>
        </tr>
        <tr>
            <td>CDONTS邮件发送：</td>
            <td>
                <asp:label id="servercdonts" runat="server" />
            </td>

            <td>JMail邮件收发：</td>
            <td>
                <asp:label id="jmail" runat="server"></asp:label>
            </td>
        </tr>
        <tr>

            <td>ASPemail发信：</td>
            <td>
                <asp:label id="aspemail" runat="server"></asp:label>
            </td>

            <td>Geocel发信：</td>
            <td>
                <asp:label id="geocel" runat="server"></asp:label>
            </td>
        </tr>
        <tr>
            <td>SmtpMail发信：</td>
            <td>
                <asp:label id="smtpmail" runat="server"></asp:label>
            </td>

            <td>ASPUpload文件上传:</td>
            <td>
                <asp:label id="aspup" runat="server"></asp:label>
            </td>
        </tr>
        <tr>
            <td>ASPCN文件上传：</td>
            <td>
                <asp:label id="aspcnup" runat="server"></asp:label>
            </td>

            <td>刘云峰的文件上传组件:</td>
            <td>
                <asp:label id="lyfup" runat="server"></asp:label>
            </td>
        </tr>
        <tr>
            <td>SoftArtisans文件管理:</td>
            <td>
                <asp:label id="soft" runat="server"></asp:label>
            </td>

            <td>Dimac文件上传:</td>
            <td>
                <asp:label id="dimac" runat="server"></asp:label>
            </td>
        </tr>
        <tr>
            <td>Dimac的图像读写组件:</td>
            <td>
                <asp:label id="dimacimage" runat="server"></asp:label>
            </td>

            <td>自定义组件查询：</td>
            <td>
                <table width="100%">
                    <tr>
                        <td width="72%">
                            <asp:textbox id="zujian" rows="1" runat="server" textmode="SingleLine" style="border-style: solid; border-color: black; border-width: 1px" />
                        </td>
                        <td width="28%">
                            <asp:button id="ckzu" runat="server" text="检测" onclick="chkzujian" cssclass="btn" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">请正确输入你要检测的组件的ProgId或ClassId。</td>
            <td colspan="2">
                <asp:label id="l001" runat="server" />
            </td>
        </tr>
    </table>

    <table class="comm-table margin-bottom">
        <tr>
            <th colspan="2">浏览者的浏览器相关信息</th>
        </tr>
        <tr>
            <td>ActiveXControls:</td>
            <td>
                <asp:label id="ActiveXControls" runat="server" />
            </td>
        </tr>
        <tr>
            <td>AOL:</td>
            <td>
                <asp:label id="aol" runat="server" />
            </td>
        </tr>
        <tr>
            <td>背景音乐:</td>
            <td>
                <asp:label id="back" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Beta:</td>
            <td>
                <asp:label id="beta" runat="server" />
            </td>
        </tr>
        <tr>
            <td>浏览器:</td>
            <td>
                <asp:label id="ie" runat="server" />
            </td>
        </tr>
        <tr>
            <td>CDF:</td>
            <td>
                <asp:label id="cdf" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Cookies:</td>
            <td>
                <asp:label id="cookies" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Crawler:</td>
            <td>
                <asp:label id="crawler" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Frames（分栏）:</td>
            <td>
                <asp:label id="frames" runat="server" />
            </td>
        </tr>
        <tr>
            <td>JavaApplets:</td>
            <td>
                <asp:label id="javaa" runat="server" />
            </td>
        </tr>
        <tr>
            <td>JavaScript:</td>
            <td>
                <asp:label id="javas" runat="server" />
            </td>
        </tr>
        <tr>
            <td>主版本号:</td>
            <td>
                <asp:label id="mav" runat="server" />
            </td>
        </tr>
        <tr>
            <td>副版本号:</td>
            <td>
                <asp:label id="miv" runat="server" />
            </td>
        </tr>
        <tr>
            <td>操作系统:</td>
            <td>
                <asp:label id="ms" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Tables（表格）:</td>
            <td>
                <asp:label id="tables" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Type:</td>
            <td>
                <asp:label id="type" runat="server" />
            </td>
        </tr>
        <tr>
            <td>VBScript:</td>
            <td>
                <asp:label id="vbs" runat="server" />
            </td>
        </tr>
        <tr>
            <td>版本:</td>
            <td>
                <asp:label id="vi" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Win16:</td>
            <td>
                <asp:label id="win16" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Win32:</td>
            <td>
                <asp:label id="win32" runat="server" />
            </td>
        </tr>
    </table>

    <table class="comm-table">
        <tr>
            <td colspan="2"><strong>执行效率相关参数</strong></td>
        </tr>
        <tr>
            <td>1000万次加法循环测试：</td>
            <td>
                <asp:button id="for1000" runat="server" onclick="turn_chk" text="测试" cssclass="submit" />
                <asp:label id="l1000" runat="server"></asp:label>
            </td>
        </tr>
        <tr>
            <td>本页执行时间：</td>
            <td>
                <asp:label id="runtime" runat="server" />
                毫秒</td>
        </tr>
    </table>
</asp:Content>

