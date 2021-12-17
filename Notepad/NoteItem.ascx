<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoteItem.ascx.cs" Inherits="Notepad.NoteItem" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>

    <style>
        .card-body-extension {
            width: 100%;
            height: 150px;
            position: relative;
            background-color: #262626;
        }

        .show-note-button {
            width: 100px;
            height: 50px;
            position: absolute;
            right: 20px;
            bottom: 20px;
            background-color: deepskyblue;
            border: none;
        }

        .show-note-button:hover {
            background-color: white;
        }

        .container {
            width: 100%;
            height: 150px;
            background-color: orange;
            position: relative;
        }

        .show-note-button {
            width: 80px;
            height: 60px;
            border: none;
            position: absolute;
            right: 10px;
            bottom: 10px;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function noteItemOnClick() {
            var noteTitle = '<%=Note.Title%>/*';
            var noteContent = '<%=Note.Content%>/*';
            console.log(noteContent);
            setNoteContent(noteTitle, noteContent);
        }

        function setNoteContent(noteTitle, noteContent) {
            document.getElementById('NoteTitle').value = noteTitle;
            document.getElementById('NoteContent').value = noteContent;
        }

        function test() {
            console.log('hello, world!');
        }
    </script>

</head>
<body>
    <div class="container">
        <asp:Label ID="Title" runat="server">Untitled</asp:Label>
        <asp:Button ID="ShowNoteButton" OnClick="ShowNoteButton_Click" class="show-note-button" Text="Show" runat="server"/>
    </div>
</body>
</html>
