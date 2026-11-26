using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace HMEL_Project
{
    public partial class Signup : System.Web.UI.Page
    {
        private static string ComputeSha256(string raw)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(raw));
                StringBuilder sb = new StringBuilder(bytes.Length * 2);
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            string newUser = txtNewUser.Text.Trim();
            string newPass = txtNewPass.Text.Trim();

            if (string.IsNullOrEmpty(newUser) || string.IsNullOrEmpty(newPass))
            {
                lblMsg.Text = "Please fill in all fields.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (newPass.Length < 4)
            {
                lblMsg.Text = "Password must be at least 4 characters long.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string normalizedUser = newUser.ToLowerInvariant();
            bool alreadyExists = false;

            Application.Lock();
            try
            {
                var users = Application["Users"] as Dictionary<string, string>;
                if (users == null)
                {
                    users = new Dictionary<string, string>();
                    Application["Users"] = users;
                }

                if (normalizedUser == "admin" || users.ContainsKey(normalizedUser))
                {
                    alreadyExists = true;
                }
                else
                {
                    users[normalizedUser] = ComputeSha256(newPass);
                }
            }
            finally
            {
                Application.UnLock();
            }

            if (alreadyExists)
            {
                lblMsg.Text = "Username already exists. Please choose another.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = "Account created successfully for " + HttpUtility.HtmlEncode(newUser) + "! You can now log in.";
            txtNewUser.Text = "";
            txtNewPass.Text = "";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}
