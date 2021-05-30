using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class MyBooksList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["userID"]))
            {
                (this.Master as Student).changeButtonCss("btnMyBooksList");
                gridViewReturnedBookList.Visible = false;
            }
            else
            {
                goBack();
            }
            
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            goBack();
        }
        protected void btnShowNotReturned_Click(object sender, EventArgs e)
        {
            bool isVisible = gridViewNotReturnedBookList.Visible;
            if (isVisible)
            {
                gridViewNotReturnedBookList.Visible = false;
                gridViewReturnedBookList.Visible = true;
            }
            else
            {
                gridViewReturnedBookList.Visible = false;
                gridViewNotReturnedBookList.Visible = true;
            }
        }
        protected void gridViewBookListRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "BOOKDETAIL")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gridViewNotReturnedBookList.Rows[index];

                int id = int.Parse(row.Cells[0].Text.ToString());
                Response.Redirect("MyRentDetail.aspx?RentID=" + id);

            }
        }

        protected void gridViewReturnedBookListRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "BOOKDETAIL")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gridViewReturnedBookList.Rows[index];

                int id = int.Parse(row.Cells[0].Text.ToString());
                Response.Redirect("MyRentDetail.aspx?RentID=" + id);
            }
        }

        public void goBack()
        {
            Response.Redirect("AllBooksList.aspx");
        }
    }
}