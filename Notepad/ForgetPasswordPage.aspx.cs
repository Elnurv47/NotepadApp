using Notepad.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Notepad.DatabaseUtility;
using AES;

namespace Notepad
{
    public static class EmailService
    {
        private static Random random;

        public static bool TrySendEmail(string emailTo)
        {
            try
            {
                string from = Container.COMPANY_EMAIL;
                string pass = Container.COMPANY_PASSWORD;
                int code = GenerateCode();

                MailMessage mm = new MailMessage();
                mm.To.Add(new MailAddress(emailTo));
                mm.From = new MailAddress(from, "Pilot Company");
                mm.Subject = "Password Recovery";
                mm.IsBodyHtml = true;
                mm.Body = "Your account recovery code: <b>" + code + "</b>";

                NetworkCredential nc = new NetworkCredential();
                nc.UserName = from;
                nc.Password = pass;

                SmtpClient sc = new SmtpClient();
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                sc.Port = 587;
                sc.UseDefaultCredentials = false;
                sc.Credentials = nc;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.Send(mm);
                DatabaseManager.Instance.RecoveryCodes.Add(
                    new RecoveryCode()
                        {
                            Code = code.ToString(),
                            Email = emailTo,
                        }
                    );

                DatabaseManager.Instance.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        private static int GenerateCode()
        {
            if (random is null)
            {
                random = new Random();
            }

            return random.Next(10000, 100000);
        }
    }
    public partial class ForgetPasswordPage : System.Web.UI.Page
    {
        protected void ResetButton_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.Trim();

            if (DatabaseManager.ContainsEmail(email))
            {
                bool emailSent = EmailService.TrySendEmail(email);

                if (emailSent)
                {
                    EmailLabel.Visible = false;
                    EmailTextBox.Visible = false;
                    ResetButton.Visible = false;

                    VerificationLabel.Visible = true;
                    CodeTextBox.Visible = true;
                    ConfirmButton.Visible = true;

                    return;
                }

                ErrorLabel.Text = "Error occurred while sending recovery code, please try again";
                return;
            }

            ErrorLabel.Text = "There is no account associated with this email";
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string enteredRecoveryCode = CodeTextBox.Text;

            RecoveryCode recoveryCode
                = DatabaseManager.Instance.RecoveryCodes.FirstOrDefault(
                    recoveryCodeSearch => recoveryCodeSearch.Email == email && recoveryCodeSearch.Code == enteredRecoveryCode
                );

            if (recoveryCode is null)
            {
                ErrorLabel.Text = "Recovery code is incorrect";
                return;
            }

            VerificationLabel.Visible = false;
            CodeTextBox.Visible = false;
            ConfirmButton.Visible = false;

            PasswordLabel.Visible = true;
            PasswordTextBox.Visible = true;
            ConfirmPasswordLabel.Visible = true;
            PasswordConfirmTextBox.Visible = true;
            ChangeButton.Visible = true;
        }

        protected void ChangeButton_Click(object sender, EventArgs e)
        {
            string password = PasswordTextBox.Text;
            string confirmPassword = PasswordConfirmTextBox.Text;
            string email = EmailTextBox.Text.Trim();

            if (string.IsNullOrEmpty(password) && string.IsNullOrEmpty(confirmPassword))
            {
                ErrorLabel.Text = "Password fields cannot be empty";
                return;
            }

            if (password != confirmPassword)
            {
                ErrorLabel.Text = "Passwords don't match";
                return;
            }

            User foundUser = DatabaseManager.GetUserWithEmail(email);

            if (foundUser != null)
            {
                foundUser.Password = Encryptor.Encrypt(password, Container.PASS);
                DatabaseManager.Instance.SaveChanges();
                Response.Redirect("Login.aspx");
            }

        }
    }
}