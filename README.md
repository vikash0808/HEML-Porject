# 💼 HMEL Recruitment & Job Portal

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Web Forms](https://img.shields.io/badge/Web_Forms-5C2D91?style=for-the-badge)

A role-based enterprise **Job Portal & Recruitment Workflow Management System** built with **ASP.NET Web Forms (.NET Framework 4.7.2) and C#**. The application streamlines authentication, job postings, approval workflows, and candidate applications across dedicated Admin, Approver, and Applicant portals — running out of the box with zero external database setup required.

---

## ✨ Key Modules & Features

- **Authentication & Onboarding (`Signup.aspx`, `Login.aspx`, `HomePage.aspx`):**
  - Registers new accounts in `Application["Users"]` with **SHA-256 hashed passwords** and duplicate-username checks.
  - Supports logging in with any newly registered account or the built-in demo admin (`admin` / `1234`), setting `Session["LoggedInUser"]` and redirecting to `AdminDashboard.aspx`.
- **Admin Dashboard (`AdminDashboard.aspx`):** Centralized navigation to create, manage, and delete job openings.
- **Persistent Job CRUD (`CreateJob.aspx`, `ManageJob.aspx`, `DeleteJob.aspx`, `JobDetails.aspx`):**
  - Thread-safe random Job ID generation (`JOB-XXXX`) and full Create, Edit/Update, and Delete persistence via `Session["ManagedJobs"]`.
- **Approval Workflow (`ApprovalDashboard.aspx`):** Thread-safe Approve, Reject, View, and Reset actions with live pending/approved/rejected counters.
- **Applicant Portal (`Applicant.aspx`, `ApplicantDashboard.aspx`):** Browse open roles, apply with safe LINQ filtering (no `DataTable.Select` string concatenation), and track application pipeline stages.
- **Security Hardening:** Uses `HttpUtility.HtmlEncode` on rendered labels and `HttpUtility.JavaScriptStringEncode` on client-side alert messages to prevent reflected XSS.



## 📁 Project Structure

```text
HEML-Porject/
├── HMEL_Project.sln                 # Visual Studio solution file
├── HMEL_Project/
│   ├── HomePage.aspx(.cs)           # Landing page
│   ├── Login.aspx(.cs)              # SHA-256 user auth & AdminDashboard redirect
│   ├── Signup.aspx(.cs)             # Account registration (Application store)
│   ├── AdminDashboard.aspx(.cs)     # Admin control panel
│   ├── ApprovalDashboard.aspx(.cs)  # Thread-safe approval workflow dashboard
│   ├── ApplicantDashboard.aspx(.cs) # Candidate job browser & status tracker
│   ├── Applicant.aspx(.cs)          # Applicant profile / submission
│   ├── CreateJob.aspx(.cs)          # Post new job opening to Session store
│   ├── ManageJob.aspx(.cs)          # Inline edit & delete persisted jobs
│   ├── DeleteJob.aspx(.cs)          # Remove job listings
│   ├── JobDetails.aspx(.cs)         # Detailed job view
│   ├── Global.asax(.cs)             # Application lifecycle events
│   └── Web.config                   # ASP.NET (.NET Framework 4.7.2) configuration
├── .gitignore
└── README.md
```

---

## 💻 Getting Started

### Prerequisites
- Windows with **Visual Studio** (with the *ASP.NET and web development* workload installed)
- **.NET Framework 4.7.2**

### Running Locally
1. Clone the repository:
   ```bash
   git clone https://github.com/vikash0808/HEML-Porject.git
   ```
2. Open `HMEL_Project.sln` in Visual Studio.
3. Restore NuGet packages and press **F5** to build and launch with IIS Express (no external SQL Server setup required for demo mode).
4. Log in with `admin` / `1234`, or create a new user on `Signup.aspx`.

---

## 👨‍💻 Author

**Vikash Dhillan** — B.Tech Computer Science  
GitHub: [@vikash0808](https://github.com/vikash0808)
