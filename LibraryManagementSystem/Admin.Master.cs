using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            isAdmin();
            labelFullName.Text = Session["FULLNAME"].ToString();
            labelUsername.Text = "@" + Session["USERNAME"].ToString();
        }


        protected void btnUserList_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserList.aspx");
        }

        protected void btnBookList_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookList.aspx");
        }

        protected void btnBookRent_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectUser.aspx");
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProfile.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //Delete All Session Variables
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }


        public void isAdmin()
        {
            try
            {
                if (Session["ROLE"].ToString().Equals("") || Session["ROLE"].ToString().Equals("USER"))
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