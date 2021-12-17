using System;
using System.Linq;
using System.Web;
using Notepad.DatabaseUtility;
using Notepad.Models;

namespace Notepad
{
    public partial class NoteItem : System.Web.UI.UserControl
    {
        private Note note;
        public Note Note { get => note; set => note = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalReference.Home.NoteTitleGetter.Text = note.Title;
            GlobalReference.Home.NoteContentGetter.Text = note.Content;
        }

        protected void ShowNoteButton_Click(object sender, EventArgs e)
        {
            Home.CurrentlySelectedNoteItem = this;

            User user = new User()
            {
                Email = "123",
                Password = "1234"
            };

            DatabaseManager.Instance.Users.Add(user);
            DatabaseManager.Instance.SaveChanges();

            Note clickedNote = DatabaseManager.Instance.Notes.FirstOrDefault(searchNote => note.Id == searchNote.Id);
            GlobalReference.Home.NoteTitleGetter.Text = clickedNote.Title;
            GlobalReference.Home.NoteContentGetter.Text = clickedNote.Content;
        }
    }
}