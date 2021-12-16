using System;
using System.Collections.Generic;

namespace Notepad.Models
{
    public class User
    {
        public int Id { get; set; }
        public int Email { get; set; }
        public int Password { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}