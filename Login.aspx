<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DemoInfo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

     <meta charset="utf-8" />
    <title>Master Details App - Login</title>
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
    <form id="form1" runat="server">
        <%-- Login form div --%>
        <div id="login" runat="server">
         <div class="login-container">
            <h2>Login</h2>
            <div>
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                 <span id="emailError" class="error"></span>

            </div>
            <div>
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                 <span id="passwordError" class="error"></span>
            </div>
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClientClick="return validateForm()" OnClick="btnLogin_Click" />
                <label>Don't have an account?</label>
        <div>
        <asp:Button ID="btnShowRegister" runat="server" Text="Register" OnClick="btnShowRegister_Click" />
       </div>
            </div>
        </div>
       </div>
        <%-- Register form div --%>
        <div id="registerUser" runat="server">
         <div class="register-container">
            <h2>Register</h2>
            <div>
                <label for="txtUsername">Username:</label>
                <asp:TextBox ID="txtUsernameRegister" runat="server"></asp:TextBox>
            </div>
               <div>
                <label for="txtEmailRegister">Email:</label>
                <asp:TextBox ID="txtEmailRegister" runat="server"></asp:TextBox>
            </div>
             <div>
                <label for="ddlDistrict">District </label>
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" title="District"  EnableViewState="true">
                        </asp:DropDownList>
             </div>
            <div>
                <label for="txtPasswordRegister">Password:</label>
                <asp:TextBox ID="txtPasswordRegister" runat="server" TextMode="Password"></asp:TextBox>
            </div>
                <div>
                <label for="txtConfirmPassword">Confirm Password:</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                <label>Have an account?</label>
        <div>
        <asp:Button ID="btnShowLogin" runat="server" Text="Login" OnClick="btnShowLogin_Click" />
       </div>
            </div>
        </div>
       </div>
        <div id="gotoLogin" runat="server">
            <label id="lblMsg" runat="server"></label>
              <asp:Button ID="Button1" runat="server" Text="Login" OnClick="btnShowLogin_Click" />
        </div>
    </form>
    <script >
        /*validation for login form*/
        function validateForm() {
            var email = document.getElementById("txtEmail").value;
            var password = document.getElementById("txtPassword").value;
            var emailError = document.getElementById("emailError");
            var passwordError = document.getElementById("passwordError");

           
            emailError.innerHTML = "";
            passwordError.innerHTML = "";

            // Email Validation
            if (email === "") {
                emailError.innerHTML = "Email is required";
                return false; // Prevent form submission
            } else if (!isValidEmail(email)) {
                emailError.innerHTML = "Invalid email format";
                return false;
            }

            // Password Validation
            if (password === "") {
                passwordError.innerHTML = "Password is required";
                return false;
            } else if (password.length < 8) {
                passwordError.innerHTML = "Password must be at least 8 characters long";
                return false;
            }

            // If all validations pass, return true 
            return true;
        }

        // Function to check valid email 
        function isValidEmail(email) {
            var re = /^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$/

    </script>
</body>
</html>
