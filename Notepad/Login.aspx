<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Notepad.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: #171414;
        }

        #container {
            width: 60vh;
            height: 70vh;
            background-color: white;
            margin: 15vh auto;
        }

        #navbar {
            width: 100%;
            height: 20%;
        }

        #navbar h1 {
            color: #1ff89b;
            font-size: 40px;
            text-align: center;
            margin-top: 0px;
            margin-bottom: 0px;
            padding-top: 100px;
        }

        #body {
            width: 100%;
            height: 50%;
            position: relative;
            display: flex;
            justify-content: center;
        }

        .email-textbox, .password-textbox {
            width: 70%;
            height: 80px;
            background-color: #f8f2f2;
            border: 2px solid #1ff89b;
            font-size: 20px;
        }

        .forget-password {
            position: absolute;
            right: 85px;
            bottom: 30px;
        }

        .email-textbox {
            position: absolute;
            top: 25%;
        }

        .password-textbox {
            position: absolute;
            top: 55%;
        }

        #footer {
            width: 100%;
            height: 30%;
            position: relative;
        }

        #LoginButton {
            width: 160px;
            height: 50px;
            border-radius: 25px;
            background-color: #1ff89b;
            border: none;
            color: white;
            font-size: 20px;
            box-shadow: 1px 0px 5px black;
            margin: 0;
            position: absolute;
            top: 50%;
            left: 50%;
            -ms-transform: translate(-50%, -80%);
            transform: translate(-50%, -80%);
        }

        .email-or-password-incorrect-label {
            color: red;
            font-size: 20px;
            margin-left: 30%;
        }

        #DontHaveAnAccountLink {
            position: absolute;
            bottom: 15px;
            left: 37%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div id="container">
                <div id="navbar">
                    <h1>Login</h1>
                </div>

                <div id="body">
                    <asp:TextBox ID="EmailTextBox" class="email-textbox" runat="server" PlaceHolder="Email"></asp:TextBox>
                    <asp:TextBox ID="PasswordTextbox" class="password-textbox" runat="server" PlaceHolder="Password " TextMode="Password"></asp:TextBox>
                    <a href="ForgetPasswordPage.aspx" class="forget-password">Forget Password ?</a>
                </div>

                <div id="footer">
                    <asp:Label ID="EmailOrPasswordIsIncorrectLabel" class="email-or-password-incorrect-label" runat="server">Email or password is incorrect</asp:Label>
                    <asp:Button ID="LoginButton" OnClick="LoginButton_Click" Text="Login" runat="server"/>
                    <asp:LinkButton ID="DontHaveAnAccountLink" OnClick="DontHaveAnAccountLink_Click" runat="server">Don't have an account ?</asp:LinkButton>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
