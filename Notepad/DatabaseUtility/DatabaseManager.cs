using Notepad.Models;
using AES;
using System;
using System.Linq;

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

        public static User TryFindUser(string enteredEmail, string enteredPassword)
        {
            foreach (User user in Instance.Users)
            {
                if (user.Email == enteredEmail)
                {
                    if (Decryptor.Decrypt(user.Password, Container.PASS) == enteredPassword)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        public static User GetUserWithEmail(string email)
        {
            return Instance.Users.FirstOrDefault(user => user.Email == email);
        }

        public static bool ContainsEmail(string email)
        {
            User userWithEmail = Instance.Users.FirstOrDefault(user => user.Email == email);

            return userWithEmail != null;
        }
    }
}