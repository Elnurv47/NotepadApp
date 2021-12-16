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

            Note note = new Note()
            {
                Title = "Test",
                Content = "",
                DateCreated = DateTime.Now
            };

            DatabaseManager.Instance.Notes.Add(note);
            DatabaseManager.Instance.SaveChanges();

            Note clickedNote = DatabaseManager.Instance.Notes.FirstOrDefault(searchNote => note.Id == searchNote.Id);
            GlobalReference.Home.NoteTitleGetter.Text = note.Title;
            GlobalReference.Home.NoteContentGetter.Text = note.Content;
        }
    }
}