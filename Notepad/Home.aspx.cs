using System;
using System.Web.UI;
using System.Collections.Generic;
using Notepad.Models;
using Notepad.DatabaseUtility;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Notepad
{
    public static class GlobalReference
    {
        public static Home Home { get; set; }
    }

    public static class EmailValidator
    {
        public static bool IsEmailValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
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

            EmailLabel.Text = (string)Session["email"];

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

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}