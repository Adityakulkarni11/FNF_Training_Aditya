using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LoginTask
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionConfig"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Username FROM Users", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rptUsers.DataSource = dt;
                rptUsers.DataBind();
            }
        }

        protected void ShowDetails(object sender, CommandEventArgs e)
        {
            int userId = Convert.ToInt32(e.CommandArgument);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionConfig"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Username FROM Users WHERE Id = @Id", conn);
                da.SelectCommand.Parameters.AddWithValue("@Id", userId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dvUserDetails.DataSource = dt;
                dvUserDetails.DataBind();
                dvUserDetails.Visible = true;
            }
        }

    }
}