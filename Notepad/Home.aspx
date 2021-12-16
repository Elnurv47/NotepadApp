<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Notepad.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Notepad</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        #form1 {
            width: 100%;
            height: 100vh;
        }

        #menu-div {
            width: 15%;
            height: 100vh;
            background-color: black;
            float: left;
        }

        #account-info {
            height: 18%;
            width: 100%;
            background-color: #151515;
        }

        #full-name, #email {
            margin: 0px;
            height: 50%;
            color: white;
            padding-left: 30px;
            padding-right: 30px;
        }

        #full-name {
            font-size: 24px;
            padding-top: 15px;
        }

        #email {
            font-size: 20px;
        }
        
        #NewNoteButton {
            width: 50%;
            height: 50px;
            background-color: deepskyblue;
            border: none;
            border-radius: 30px;
            margin: 12.5% 25% 12.5% 25%;
        }

        #notes-panel-div {
            width: 25%;
            height: 100vh;
            background-color: #1a1a1a;
            float: left;
            color: white;
        }

        #notes-menu-header {
            width: 100%;
            height: 18%;
        }

        #notes-text {
            margin-top: 0px;
            margin-left: 30px;
            font-size: 40px;
        }

        #notes-count-text {
            font-size: 20px;
            margin-left: 30px;
        }

        #NotesContainer {
            width: 100%;
            height: 82%;
            position: relative;
        }

        #note-menu-item {
            width: 472px;
            height: 160px;
            background-color: gray;
            position: relative;
        }

        #note-menu-item-name {
            margin: 0px;
            font-size: 30px;
            position: absolute;
            top: 40px;
            left: 40px;
        }

        #note-info-div {
            width: 60%;
            height: 100vh;
            background-color: #262626;
            float: left;
        }

        #NoteNavbar {
            width: 100%;
            height: 10vh;
        }

        #NoteTitle {
            width: 100%;
            height: 10vh;
            font-size: 32px;
            border: none;
            color: white;
            background-color: #262626;
        }

        #note-body {
            width: 100%;
            height: 80vh;
            border: none;
            color: white;
            background-color: #262626;
        }

        #NoteContent {
            width: 100%;
            height: 100%;
            border: none;
            text-align: start;
            color: white;
            background-color: #262626;
        }

        #note-content-footer {
            width: 100%;
            height: 10vh;
        }

        #SaveNoteButton {
            width: 15%;
            height: 50px;
            display: block;
            margin: auto;
            color: white;
            font-size: 25px;
            background-color: deepskyblue;
            border: none;
            border-radius: 30px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="menu-div">

                <div id="account-info">
                    <p id ="full-name">
                        Elnur Valiyev
                    </p>

                    <p id="email">
                        elnurdev@gmail.com
                    </p>
                </div>

                <div id="menu-items">
                    <asp:Button ID="NewNoteButton" runat="server" Text="New Note" OnClick="NewNoteButton_Click" />
                </div>

            </div>

            <div id="notes-panel-div">

                <div id="notes-menu-header">
                    <p id="notes-text">Notes</p>

                    <p id="notes-count-text">10 notes</p>
                </div>

                <div id="NotesContainer" runat="server">
                    
                </div>

            </div>

            <div id="note-info-div">

                <div id="NoteNavbar" runat="server">
                    <asp:TextBox ID="NoteTitle" placeholder="Title" Text="" runat="server"></asp:TextBox>
                </div>

                <div id ="note-body">
                    <asp:TextBox ID="NoteContent" placeHolder="Start writing" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>

                <div id="note-content-footer">
                    <asp:Button ID="SaveNoteButton" OnClick="SaveNoteButton_Click" Text="Save" runat="server" />
                </div>

            </div>
        </div>
    </form>
</body>
</html>
