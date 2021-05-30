using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class Student : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            isUser();
            labelFullName.Text = Session["FULLNAME"].ToString();
            labelUsername.Text = "@" + Session["USERNAME"].ToString();
        }


        protected void btnAllBooksList_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllBooksList.aspx");
        }
        protected void btnMyBooksList_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllBooksList.aspx");
        }


        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //Delete All Session Variables
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }


        public void isUser()
        {
            try
            {
                if (Session["ROLE"].Equals("") || Session["ROLE"].Equals("User"))
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.Redirect("Login.aspx");
            }
        }

        public void changeButtonCss(String btnID)
        {
            try
            {
                LinkButton btn = this.FindControl(btnID) as LinkButton;
                btn.CssClass = "btn btn-block btn-primary";
            }
            catch (NullReferenceException ex)
            {
                //ignore exception
            }
        }
    }
}