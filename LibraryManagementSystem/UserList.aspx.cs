using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void gridViewUserListRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UPDATEUSER")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                GridViewRow row = gridViewUserList.Rows[index];

                int id = int.Parse(row.Cells[0].Text.ToString());
                //Response.Write("<script>alert('" + id.ToString() + "');</script>");

                Response.Redirect("UpdateUser.aspx?userID=" + id);
                // Add code here 
                //gridViewUserList.DataBind();
            }

            if (e.CommandName == "DELETE")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gridViewUserList.Rows[index];
                int id = int.Parse(row.Cells[0].Text.ToString());
                userListDataSource.DeleteCommand = "DELETE FROM Users WHERE ID = '" + id + "'";
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }

    }
}