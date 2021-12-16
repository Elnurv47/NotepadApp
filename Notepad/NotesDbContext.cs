using Notepad.Models;
using System.Data.Entity;

namespace Notepad
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<NotesDbContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}