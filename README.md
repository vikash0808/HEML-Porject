# 💼 HMEL Recruitment & Job Portal

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Web Forms](https://img.shields.io/badge/Web_Forms-5C2D91?style=for-the-badge)

A role-based enterprise **Job Portal & Recruitment Workflow Management System** built with **ASP.NET Web Forms and C#**. The application streamlines job postings, approval workflows, and candidate applications across dedicated Admin, Approver, and Applicant portals.

---

## ✨ Key Modules & Features

- **Authentication & Onboarding:** User registration (`Signup.aspx`) and role-based login (`Login.aspx`) with landing page navigation (`HomePage.aspx`).
- **Admin Dashboard (`AdminDashboard.aspx`):** Centralized administration interface for overseeing job listings and recruitment activity.
- **Job Lifecycle Management:** Create (`CreateJob.aspx`), view (`JobDetails.aspx`), update (`ManageJob.aspx`), and remove (`DeleteJob.aspx`) job openings.
- **Approval Workflow (`ApprovalDashboard.aspx`):** Dedicated review and approval stage for managing recruitment requests and applications.
- **Applicant Portal (`Applicant.aspx`, `ApplicantDashboard.aspx`):** Candidate interface to browse open positions, submit applications, and track application status.

---

## 📁 Project Structure

```text
HEML-Porject/
├── HMEL_Project.sln                 # Visual Studio solution file
├── HMEL_Project/
│   ├── HomePage.aspx(.cs)           # Landing page
│   ├── Login.aspx(.cs)              # User authentication
│   ├── Signup.aspx(.cs)             # Account registration
│   ├── AdminDashboard.aspx(.cs)     # Admin control panel
│   ├── ApprovalDashboard.aspx(.cs)  # Approval workflow dashboard
│   ├── ApplicantDashboard.aspx(.cs) # Candidate dashboard
│   ├── Applicant.aspx(.cs)          # Applicant profile / submission
│   ├── CreateJob.aspx(.cs)          # Post new job opening
│   ├── ManageJob.aspx(.cs)          # Edit existing job listings
│   ├── DeleteJob.aspx(.cs)          # Remove job listings
│   ├── JobDetails.aspx(.cs)         # Detailed job view
│   ├── Global.asax(.cs)             # Application lifecycle events
│   └── Web.config                   # ASP.NET & connection configuration
└── README.md
```

---

## 💻 Getting Started

### Prerequisites
- Windows with **Visual Studio** (with the *ASP.NET and web development* workload installed)
- **.NET Framework** matching `HMEL_Project.csproj`
- SQL Server / LocalDB (configure the connection string in `HMEL_Project/Web.config`)

### Running Locally
1. Clone the repository:
   ```bash
   git clone https://github.com/vikash0808/HEML-Porject.git
   ```
2. Open `HMEL_Project.sln` in Visual Studio.
3. Update the database connection string in `HMEL_Project/Web.config` if needed.
4. Restore NuGet packages and press **F5** to build and launch with IIS Express.

---

## 👨‍💻 Author

**Vikash Dhillan** — B.Tech Computer Science  
GitHub: [@vikash0808](https://github.com/vikash0808)
