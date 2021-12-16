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
    </style>

    <script type="text/javascript" language="javascript">
        function noteItemOnClick() {
            var noteTitle = '<%=Note.Title%>/*';
            var noteContent = '<%=Note.Content%>/*';
            console.log(noteContent);
            setNoteContent(noteTitle, noteContent);
        }

        function setNoteContent(noteTitle, noteContent) {
            console.log('here');
            document.getElementById('NoteTitle').value = noteTitle;
            document.getElementById('NoteContent').value = noteContent;
        }

        function test() {
            console.log('hello, world!');
        }
    </script>

</head>
<body>
    <div class="card w-100">
        <div class="card-body card-body-extension">
            <h5 id="CardTitle" class="card-title" runat="server"><%=Note.Title%></h5>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="ShowNoteButton_Click"></asp:Button>
        </div>
    </div>
</body>
</html>
