<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPasswordPage.aspx.cs" Inherits="Notepad.ForgetPasswordPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
            background-color: #171414;
        }

        form {
            border: 3px solid #f1f1f1;
        }

        input[type=text], input[type=number], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        .container {
            padding: 16px;
            background-color: white;
        }

        button:hover {
            opacity: 0.8;
        }

        .resetbtn {
            background-color: #1ff89b;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
        }

        .changebtn {
            background-color: #1ff89b;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
        }

        .confirmbtn {
            background-color: #1ff89b;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
        }


        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }

        .loginform {
            margin: auto;
            width: 30%;
            margin-top: 10%;
        }

        .already {
            display: block;
        }

        .forget {
            display: block;
            margin-top: 10px;
        }

        .error-label {
            color: red;
            display: block;
            text-align: center;
            line-height: 150%;
            font-size: 18px;
            margin-top: 20px;
        }

        .container h3 {
            color: #1ff89b;
        }
    </style>
</head>
<body>
    <form id="form1" class="loginform" runat="server">
        <div class="container">

            <center>
                <h3>Reset Password </h3>
            </center>

            <asp:Label ID="EmailLabel" AssociatedControlID="EmailTextBox" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTextBox" placeholder="Enter Email" runat="server"></asp:TextBox>

            <asp:Label ID="VerificationLabel" AssociatedControlID="CodeTextBox" Text="Verification Code" Visible="False" runat="server"></asp:Label>
            <asp:TextBox ID="CodeTextBox" TextMode="Number" placeholder="Enter verification code" Visible="False" runat="server"></asp:TextBox>

            <asp:Label ID="PasswordLabel" AssociatedControlID="PasswordTextBox" Text="Password" Visible="False" runat="server"></asp:Label>
            <asp:TextBox ID="PasswordTextBox" TextMode="Password" placeholder="Enter Password" Visible="False" runat="server"></asp:TextBox>

            <asp:Label ID="ConfirmPasswordLabel" AssociatedControlID="PasswordConfirmTextBox" Text="Confirm Password" Visible="False" runat="server"></asp:Label>
            <asp:TextBox ID="PasswordConfirmTextBox" TextMode="Password" placeholder="Enter Confirm Password" Visible="False" runat="server"></asp:TextBox>

            <asp:Button ID="ResetButton" CssClass="resetbtn" Text="Reset" OnClick="ResetButton_Click" runat="server" />
            <asp:Button ID="ConfirmButton" CssClass="confirmbtn" Text="Confirm" Visible="False" OnClick="ConfirmButton_Click" runat="server" />
            <asp:Button ID="ChangeButton" CssClass="changebtn" Text="Change" Visible="False" OnClick="ChangeButton_Click" runat="server" />


        </div>
    </form>

    <asp:Label ID="ErrorLabel" CssClass="error-label" runat="server" ></asp:Label>
</body>
</html>
