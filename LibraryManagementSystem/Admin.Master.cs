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
            //isAdmin();
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
           // Response.Redirect("BookList.aspx");
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //TODO : Delete All Session Variables
            Response.Redirect("Login.aspx");
        }


        public void isAdmin()
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
    }
}