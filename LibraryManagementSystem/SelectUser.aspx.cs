using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class SelectUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void gridViewUserListRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SELECTUSER")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gridViewUserList.Rows[index];

                int id = int.Parse(row.Cells[0].Text.ToString());
                if (checkRentedBookAmount(id))
                {
                    Response.Write("<script>alert('Aynı anda en fazla 3 kitap kiralanabilir.');</script>");
                }
                else
                {
                    Response.Redirect("SelectBook.aspx?userID=" + id);
                }
            }
        }

        private Boolean checkRentedBookAmount(int id)
        {
            if (id.Equals(null)) return false;
            try
            {
                Database db = new Database();
                SqlCommand command = new SqlCommand("SELECT COUNT(1) from RentBook where isReturned = 0 and UserID='" + id + "'", db.Connection());

                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        int amount = Int32.Parse(sqlDataReader.GetValue(0).ToString());
                        if (amount >= 3)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                db.Connection().Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
            return false;
        }
    }
}