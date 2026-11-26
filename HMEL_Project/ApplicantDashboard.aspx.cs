using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMEL_Project
{
    public partial class ApplicantDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeMockData();
                BindGrids();
            }
        }

        private void InitializeMockData()
        {
            if (Session["AvailableJobs"] == null)
            {
                DataTable available = new DataTable();
                available.Columns.Add("JobId");
                available.Columns.Add("JobTitle");
                available.Columns.Add("Description");

                available.Rows.Add("101", "Backend Engineer", "Work with APIs and databases.");
                available.Rows.Add("102", "Data Analyst", "Interpret data, analyze results.");
                available.Rows.Add("103", "Frontend Developer", "Design user interfaces with React.");

                Session["AvailableJobs"] = available;
            }

            if (Session["AppliedJobs"] == null)
            {
                DataTable applied = new DataTable();
                applied.Columns.Add("JobTitle");
                applied.Columns.Add("Status");

                Session["AppliedJobs"] = applied;
            }
        }

        private void BindGrids()
        {
            gvAppliedJobs.DataSource = Session["AppliedJobs"];
            gvAppliedJobs.DataBind();

            rptJobs.DataSource = Session["AvailableJobs"];
            rptJobs.DataBind();
        }

        protected void ApplyJob(object sender, CommandEventArgs e)
        {
            string jobId = Convert.ToString(e.CommandArgument);

            DataTable available = Session["AvailableJobs"] as DataTable;
            DataTable applied = Session["AppliedJobs"] as DataTable;
            if (available == null || applied == null) return;

            DataRow match = available.Rows.Cast<DataRow>()
                .FirstOrDefault(r => string.Equals(r["JobId"].ToString(), jobId, StringComparison.Ordinal));

            if (match != null)
            {
                string title = match["JobTitle"].ToString();
                applied.Rows.Add(title, "Applied");
                available.Rows.Remove(match);

                Session["AvailableJobs"] = available;
                Session["AppliedJobs"] = applied;

                BindGrids();

                string safeTitle = HttpUtility.JavaScriptStringEncode("Applied for " + title);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + safeTitle + "');", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected string GetStepClass(string step, string currentStatus)
        {
            string[] stages = { "Applied", "Review", "Interview", "Final" };
            int currentIndex = Array.IndexOf(stages, currentStatus);
            int stepIndex = Array.IndexOf(stages, step);

            if (stepIndex < currentIndex)
                return "step completed";
            else if (stepIndex == currentIndex)
                return "step current";
            else
                return "step";
        }
    }
}
