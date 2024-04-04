<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DemoInfo.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .login-container {
            width: 300px;
            margin: auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            text-align: center;
            margin-top:10em;
        }
        .register-container{
               width: 300px;
            margin: auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            text-align: center;
            margin-top:6em;
        }

        .login-container label {
            display: block;
            margin-bottom: 10px;
        }
        .register-container label{
               display: block;
            margin-bottom: 10px;
        }

        .login-container input[type="text"],
        .login-container input[type="password"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            box-sizing: border-box; /* Ensure the padding and border are included in the width */
        }
      .register-container input[type="text"],
        .register-container input[type="password"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            box-sizing: border-box; /* Ensure the padding and border are included in the width */
        }

        .login-container input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
         .register-container input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <div id="main" runat="server">
        Unauthorize
    </div>
     <div id="div1" runat="server">
        User is deleted
    </div>
    <form id="form1" runat="server">
        <input type="hidden" id="userID" runat="server" />
        <div style="display:flex; justify-content:space-between">
            <h2>Hello</h2>
            <h2 id="name" runat="server"></h2>
            <a href="<%= Page.ResolveUrl("~/Logout.aspx") %>">Log Out</a>
        </div>
        <div id="registerUser" runat="server">
         <div class="register-container">
            <h2>Edit</h2>
            <div>
                <label for="txtUsernameEdit">Username:</label>
                <asp:TextBox ID="txtUsernameEdit" runat="server"></asp:TextBox>
            </div>
               <div>
                <label for="txtEmailEdit">Email:</label>
                <asp:TextBox ID="txtEmailEdit" runat="server"></asp:TextBox>
            </div>
             <div>
                <label for="ddlDistrict">District </label>
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" title="District"  EnableViewState="true">
                        </asp:DropDownList>
             </div>
            <div>
                <label for="txtPasswordEdit">Password:</label>
                <asp:TextBox ID="txtPasswordEdit" runat="server" TextMode="Password"></asp:TextBox>
            </div>
                
            <div>
                <asp:Button ID="btnEdit" runat="server" Text="Edit/Save" OnClick="btnEdit_Click" />
               <span id="msgUpdate" runat="server"></span>
        <div>
            <div>
                 <asp:Button ID="btnDelete" runat="server" Text="Delete User" OnClick="btnDelete_Click" />
            </div>
       
       </div>
            </div>
        </div>
       </div>
    </form>
</body>
</html>
