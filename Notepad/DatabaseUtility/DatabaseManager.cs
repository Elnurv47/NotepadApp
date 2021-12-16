using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notepad.DatabaseUtility
{
    public class DatabaseManager
    {
        private static NotesDbContext instance;
        public static NotesDbContext Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new NotesDbContext();
                    return instance;
                }

                return instance;
            }
        }
    }
}