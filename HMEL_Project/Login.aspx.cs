using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace HMEL_Project
{
    public partial class Login : System.Web.UI.Page
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMsg.Text = "Please enter both username and password.";
                return;
            }

            bool isValid = false;

            // Default demo admin account
            if (string.Equals(username, "admin", StringComparison.OrdinalIgnoreCase) && password == "1234")
            {
                isValid = true;
            }
            else
            {
                var users = Application["Users"] as Dictionary<string, string>;
                if (users != null)
                {
                    string storedHash;
                    if (users.TryGetValue(username.ToLowerInvariant(), out storedHash) &&
                        string.Equals(storedHash, ComputeSha256(password), StringComparison.Ordinal))
                    {
                        isValid = true;
                    }
                }
            }

            if (isValid)
            {
                Session["LoggedInUser"] = username;
                Response.Redirect("AdminDashboard.aspx");
            }
            else
            {
                lblMsg.Text = "Invalid username or password.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}
