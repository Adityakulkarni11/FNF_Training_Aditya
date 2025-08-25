using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginTask
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string hashedPassword = HashPassword(password);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionConfig"].ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {
                    Response.Redirect("UserList.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid username or password. If new user kindly Register";
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}