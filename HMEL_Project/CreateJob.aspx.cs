using System;
using System.Data;
using System.Web;
using System.Web.UI;

namespace HMEL_Project
{
    public partial class CreateJob : System.Web.UI.Page
    {
        private static readonly Random Rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateRandomJobId();
            }
        }

        private void GenerateRandomJobId()
        {
            int num;
            lock (Rnd)
            {
                num = Rnd.Next(1000, 10000);
            }
            txtJobId.Text = "JOB-" + num;
        }

        private DataTable GetOrInitManagedJobs()
        {
            var dt = Session["ManagedJobs"] as DataTable;
            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("JobId");
                dt.Columns.Add("Title");
                dt.Columns.Add("Location");
                dt.Columns.Add("PostedDate");

                dt.Rows.Add("101", "Software Developer", "Bengaluru", DateTime.Now.ToString("yyyy-MM-dd"));
                dt.Rows.Add("102", "System Analyst", "Noida", DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd"));
                Session["ManagedJobs"] = dt;
            }
            return dt;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            lblTitleError.Text = "";
            lblDescError.Text = "";
            lblLocError.Text = "";
            lblTypeError.Text = "";
            lblMessage.Text = "";

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                lblTitleError.Text = "This is required";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                lblDescError.Text = "This is required";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                lblLocError.Text = "This is required";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(ddlType.SelectedValue))
            {
                lblTypeError.Text = "This is required";
                isValid = false;
            }

            if (!isValid) return;

            string jobId = txtJobId.Text.Trim();
            string title = txtTitle.Text.Trim();
            string location = txtLocation.Text.Trim();

            DataTable jobs = GetOrInitManagedJobs();
            jobs.Rows.Add(jobId, title, location, DateTime.Now.ToString("yyyy-MM-dd"));
            Session["ManagedJobs"] = jobs;

            lblMessage.Text = string.Format(
                "Job '{0}' posted successfully with ID {1}!",
                HttpUtility.HtmlEncode(title),
                HttpUtility.HtmlEncode(jobId)
            );

            ClearFields();
            GenerateRandomJobId();
        }

        private void ClearFields()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtLocation.Text = "";
            ddlType.SelectedIndex = 0;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}
