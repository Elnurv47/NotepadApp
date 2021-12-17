using System;
using Notepad.Models;
using Notepad.DatabaseUtility;

namespace Notepad
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmailOrPasswordIsIncorrectLabel.Visible = false;
        }

        protected void DontHaveAnAccountLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string enteredEmail = EmailTextBox.Text.Trim();

            if (!EmailValidator.IsEmailValid(enteredEmail))
            {
                EmailOrPasswordIsIncorrectLabel.Visible = true;
                return;
            }

            string enteredPassword = PasswordTextbox.Text;

            User loggedUser = DatabaseManager.TryFindUser(enteredEmail, enteredPassword);

            if (loggedUser != null)
            {
                Session["email"] = loggedUser.Email;
                Response.Redirect("Home.aspx");
            }
            else
            {
                EmailOrPasswordIsIncorrectLabel.Visible = true;
            }
        }
    }
}