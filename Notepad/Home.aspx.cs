using System;
using System.Web.UI;
using System.Collections.Generic;
using Notepad.Models;
using Notepad.DatabaseUtility;
using System.Web.UI.WebControls;

namespace Notepad
{
    public static class GlobalReference
    {
        public static Home Home { get; set; }
    }
    public partial class Home : Page
    {
        private static NoteItem currentlySelectedNoteItem;
        public static NoteItem CurrentlySelectedNoteItem { set => currentlySelectedNoteItem = value; }

        public TextBox NoteTitleGetter { get => NoteTitle; }
        public TextBox NoteContentGetter { get => NoteContent; }

        private static List<NoteItem> noteUserControls = new List<NoteItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalReference.Home = this;
            RefreshNotes();
        }

        protected void NewNoteButton_Click(object sender, EventArgs e)
        {
            NoteItem noteItem = (UserControl)Page.LoadControl("/NoteItem.ascx") as NoteItem;

            currentlySelectedNoteItem = noteItem;

            Note createdNote = new Note()
            {
                Title = "Untitled",
                Content = "",
                DateCreated = DateTime.Now,
            };

            noteItem.Note = createdNote;
            DatabaseManager.Instance.Notes.Add(createdNote);
            DatabaseManager.Instance.SaveChanges();

            noteUserControls.Add(noteItem);

            RefreshNotes();
        }

        protected void SaveNoteButton_Click(object sender, EventArgs e)
        {
            NotesDbContext notesDbContext = DatabaseManager.Instance;
            notesDbContext.Notes.Add(currentlySelectedNoteItem.Note);
            notesDbContext.SaveChanges();
            RefreshNotes();
        }

        private void RefreshNotes()
        {
            NotesContainer.Controls.Clear();

            foreach (Control control in noteUserControls)
            {
                NotesContainer.Controls.Add(control);
            }
        }
    }
}