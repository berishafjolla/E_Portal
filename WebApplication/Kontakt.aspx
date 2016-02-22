<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kontakt.aspx.cs" Inherits="WebApplication.Kontakt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/css.css" rel="stylesheet" />
    
    <style type="text/css">
        .auto-style1 {
            height: 48px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
         <ul id="menu">
                    <h2> <li></li>
                    <li></li>
                    <li></li>
                    <li><a href="/Portlet/Ballina">Ballina</a></li>
                    <li><a href="/Portlet/Dokumente">e-Prokuroria</a></li>
                    <li><a href="/Portlet/Shendetesia">e-Shendetesia</a></li>
                         <li><a href="/Portlet/ASK">e-Statistika</a></li>
                          <li><a href="/Portlet/RedirectToAspx">e-Moti</a></li>
                             <li><a href="/Portlet/Shtet">e-Bota</a></li>
                    
                </ul>
    <div>
    </div>
    <table class="table1" border = "0" style="width: 409px">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Emri*" ForeColor="darkblue"></asp:Label><br />
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server" ValidationGroup = "contact"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
             ControlToValidate = "txtName" ForeColor="darkblue"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Subjekti*" ForeColor="darkblue"></asp:Label><br />
        </td>
        <td>
            <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
             ControlToValidate = "txtSubject" ForeColor="darkblue"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="Label3" runat="server" Text="Email*" ForeColor="darkblue"></asp:Label><br />
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
            <asp:RegularExpressionValidator id="valRegEx" runat="server"
            ControlToValidate="txtEmail"
            ValidationExpression=".*@.*\..*"
            ErrorMessage="*Invalid Email address."
            display="dynamic" ForeColor="darkblue"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
            ControlToValidate = "txtEmail"></asp:RequiredFieldValidator>
            <br />
            <br />
           
        </td></tr><tr>
        <td> <asp:Label ID="Label5" runat="server" Text="Fjalekalimi*" ForeColor="darkblue"></asp:Label><br /></td>
        <td>
            <input type="Password" id="txtPass" runat="server"/><br />  <br />
            <br /></td>
    </tr>
    <tr>
        <td valign = "top" >
            <asp:Label ID="Label4" runat="server" Text="Body*" ForeColor="darkblue"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtBody" runat="server" TextMode = "MultiLine" ></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
            ControlToValidate = "txtBody" ForeColor="darkblue"></asp:RequiredFieldValidator>
        </td>
    </tr>
     <tr>
        <td></td>
        <td>
            <asp:FileUpload ID="FileUpload1" runat="server" />
       </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="btnSend" runat="server" Text="Dergo" OnClick="btnSend_Click" />
       </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor = "Green"></asp:Label>
       </td>
    </tr>
</table>
    </form>
</body>
</html>
