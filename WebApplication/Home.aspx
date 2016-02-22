<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../../Content/my-slider.css" rel="stylesheet" />
    <link href="Content/css.css" rel="stylesheet" />
    <script src="../../JQuery/ism-2.1.js"></script>
    <style type="text/css">
        .white {
            width: 121px;
            margin-top: 0px;
            top: 4822px;
            left: -24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <div>    <p><img src="../../Content/ks.png" alt="ks" width="100" height="100" /> </p>
        <h2 id="white"><a href="/Portlet/Portal">E-Qeverisja</a></h2>
                   
                </div>
         <div id="menucontainer">
                
                <ul id="menu">
                    <h2> <li><a href="/Portlet/Ballina">Ballina</a></li>
                    <li><a href="/Portlet/Dokumente">e-Prokuroria</a></li>
                    <li><a href="/Portlet/Shendetesia">e-Shendetesia</a></li>
                         <li><a href="/Portlet/ASK">e-Statistika</a></li>
                          <li><a href="/Portlet/RedirectToAspx">e-Moti</a></li>
                             <li><a href="/Portlet/Shtet">e-Bota</a></li>
                    
                </ul>
            </div>
    <div class="ism-slider" id="my-slider">
  <ol>
    <li>
      <img src="../../Content/1.jpg">
      <div class="ism-caption ism-caption-0">E-qeverisja</div>
    </li>
    <li>
      <img src="../../Content/2.jpg">
      <div class="ism-caption ism-caption-0">Kosova</div>
    </li>
    <li>
      <img src="../../Content/kos.jpg">
      <div class="ism-caption ism-caption-0" ></div>
    </li>
      <li>
      <img src="../../Content/3.jpg">
      <div class="ism-caption ism-caption-0"></div>
    </li>
      <li>
      <img src="../../Content/4.jpg">
    </li>
    
  </ol>
</div>
        </div>
        
        <div style="width: 204px; height: 158px; margin-left: 32px; margin-top:20px;">
    <asp:button ID="btnKosova" CssClass="btn" runat="server" OnClick="Kosova" Text="Kosova" />
            <br />
            <br />
        <asp:button ID="btnKush" CssClass="btn" runat="server" OnClientClick="Kushtetuta" OnClick="btnKush_Click" Text="Kushtetuta" />
        
            <br />
            <br />
        
        <asp:button ID="btnQeve" CssClass="btn" runat="server" OnClientClick="Qeveria" OnClick="btnQeve_Click" Text="Qeveria"/>
            <br />
            <br />
        <asp:button ID="btnFinanca" CssClass="btn" runat="server" OnClientClick="Financa" OnClick="btnFinanca_Click" Text="Financat"/>

          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

          

        </div>
        <div id="lblRez" style="width: 840px; background: linear-gradient(white,silver,yellow); overflow:hidden; margin-left: 265px; padding-top:10px; margin-top:-30px; font-family: 'Yu Gothic'; color:blue; font-size: 15px;" runat="server">
              &nbsp;&nbsp;&nbsp;&nbsp;
              <br />
              <asp:Label ID="Label1" runat="server">Informata</asp:Label>
             
          </div>
    </form>

</body>
</html>
