using System;
using System.Web.UI;

namespace HMEL_Project
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCreateJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateJob.aspx");
        }

        protected void btnDeleteJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteJob.aspx");
        }

        protected void btnManageJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageJob.aspx");
        }

        protected void btnHomepage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}
