using System;
using System.Collections.Generic;
using Notepad.DatabaseUtility;
using Notepad.Models;
using AES;

namespace Notepad
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmailOrPasswordIsIncorrectLabel.Visible = false;
        }

        protected void AlreadyHaveAnAccountLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.Trim();

            if (!EmailValidator.IsEmailValid(email))
            {
                EmailOrPasswordIsIncorrectLabel.Visible = true;
                return;
            }

            string password = PasswordTextbox.Text;

            password = Encryptor.Encrypt(password, Container.PASS);

            User foundUser = DatabaseManager.TryFindUser(email, password);

            if (foundUser != null)
            {
                Session["email"] = foundUser.Email;
                Response.Redirect("Home.aspx");
                return;
            }

            User registeredUser = new User() { Email = email, Password = password, Notes = new List<Note>() };

            DatabaseManager.Instance.Users.Add(registeredUser);
            DatabaseManager.Instance.SaveChanges();

            Session["email"] = registeredUser.Email;
            Response.Redirect("Home.aspx");
        }
    }
}