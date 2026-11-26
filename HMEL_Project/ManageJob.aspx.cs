using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMEL_Project
{
    public partial class ManageJob : System.Web.UI.Page
    {
        private DataTable JobTable
        {
            get
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
            set
            {
                Session["ManagedJobs"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobGrid();
            }
        }

        private void BindJobGrid()
        {
            GridViewJobs.DataSource = JobTable;
            GridViewJobs.DataBind();
        }

        protected void GridViewJobs_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewJobs.EditIndex = e.NewEditIndex;
            BindJobGrid();
        }

        protected void GridViewJobs_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewJobs.EditIndex = -1;
            BindJobGrid();
        }

        protected void GridViewJobs_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string jobId = GridViewJobs.DataKeys[e.RowIndex].Value.ToString();
            string title = ((TextBox)GridViewJobs.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
            string location = ((TextBox)GridViewJobs.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim();

            DataTable dt = JobTable;
            DataRow row = dt.Rows.Cast<DataRow>()
                .FirstOrDefault(r => string.Equals(r["JobId"].ToString(), jobId, StringComparison.Ordinal));

            if (row != null)
            {
                if (!string.IsNullOrEmpty(title)) row["Title"] = title;
                if (!string.IsNullOrEmpty(location)) row["Location"] = location;
                dt.AcceptChanges();
                JobTable = dt;
            }

            GridViewJobs.EditIndex = -1;
            BindJobGrid();
        }

        protected void GridViewJobs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string jobId = GridViewJobs.DataKeys[e.RowIndex].Value.ToString();
            DataTable dt = JobTable;
            DataRow row = dt.Rows.Cast<DataRow>()
                .FirstOrDefault(r => string.Equals(r["JobId"].ToString(), jobId, StringComparison.Ordinal));

            if (row != null)
            {
                row.Delete();
                dt.AcceptChanges();
                JobTable = dt;
            }

            BindJobGrid();
        }

        protected void btnBackHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}
