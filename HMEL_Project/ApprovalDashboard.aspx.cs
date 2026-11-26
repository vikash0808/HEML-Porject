using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMEL_Project
{
    public partial class ApprovalDashboard : System.Web.UI.Page
    {
        public class ApprovalRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
        }

        private static readonly object RequestsLock = new object();
        private static readonly List<ApprovalRequest> requests = new List<ApprovalRequest>
        {
            new ApprovalRequest { Id = 1, Name = "Alice", Status = "Pending" },
            new ApprovalRequest { Id = 2, Name = "Bob", Status = "Approved" },
            new ApprovalRequest { Id = 3, Name = "Charlie", Status = "Rejected" },
            new ApprovalRequest { Id = 4, Name = "David", Status = "Pending" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRequests();
            }
        }

        private void BindRequests()
        {
            lock (RequestsLock)
            {
                gvRequests.DataSource = requests;
                gvRequests.DataBind();

                lblPendingCount.Text = requests.FindAll(r => r.Status == "Pending").Count.ToString();
                lblApprovedCount.Text = requests.FindAll(r => r.Status == "Approved").Count.ToString();
                lblRejectedCount.Text = requests.FindAll(r => r.Status == "Rejected").Count.ToString();
            }
        }

        protected void gvRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int requestId;
            if (!int.TryParse(Convert.ToString(e.CommandArgument), out requestId)) return;

            string popupScript = null;
            lock (RequestsLock)
            {
                var req = requests.Find(r => r.Id == requestId);
                if (req == null) return;

                switch (e.CommandName)
                {
                    case "Approve":
                        req.Status = "Approved";
                        break;
                    case "Reject":
                        req.Status = "Rejected";
                        break;
                    case "View":
                        string safeMsg = HttpUtility.JavaScriptStringEncode(
                            string.Format("Name: {0}\nID: {1}\nStatus: {2}", req.Name, req.Id, req.Status)
                        );
                        popupScript = "alert('" + safeMsg + "');";
                        break;
                }
            }

            if (popupScript != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "DetailsPopup", popupScript, true);
            }

            BindRequests();
        }

        protected void btnResetAll_Click(object sender, EventArgs e)
        {
            lock (RequestsLock)
            {
                foreach (var req in requests)
                {
                    req.Status = "Pending";
                }
            }
            BindRequests();
        }
    }
}
