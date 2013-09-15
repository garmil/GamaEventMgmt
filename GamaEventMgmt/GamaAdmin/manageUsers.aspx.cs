using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GamaEventMgmt.ApplicationClasses;

namespace GamaEventMgmt.GamaAdmin
{
    public partial class manageUsers : System.Web.UI.Page
    {
        GamaUserAccessor objUsers = new GamaUserAccessor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] != null && Session["loggedIn"].ToString() == "true")
            {
                var hypLogin = (HyperLink)Master.FindControl("hypLogin");
                hypLogin.Visible = false;

                if (Session["usr_id"] != null && Convert.ToInt32(Session["ust_id"]) > 2)
                {
                    Response.Redirect("~/accessDenied.aspx");
                }

            }
            else
            {

                Response.Redirect("~/accessDenied.aspx");

            }

            if (!Page.IsPostBack)
            {
                FillUsersGrid();
            }
        }

        private void FillUsersGrid()
        {
            DataTable dtCustomer = objUsers.GetAllUsersDataTable();
            
            if (dtCustomer.Rows.Count > 0)
            {
                gvwUsers.DataSource = dtCustomer;
                gvwUsers.DataBind();
            }
            else
            {
                dtCustomer.Rows.Add(dtCustomer.NewRow());
                gvwUsers.DataSource = dtCustomer;
                gvwUsers.DataBind();

                int TotalColumns = gvwUsers.Rows[0].Cells.Count;
                gvwUsers.Rows[0].Cells.Clear();
                gvwUsers.Rows[0].Cells.Add(new TableCell());
                gvwUsers.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                gvwUsers.Rows[0].Cells[0].Text = "No Record Found";
            }
        }

        protected void gvwUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlEditUserType = (DropDownList)e.Row.FindControl("ddlEditUserType");

                if (ddlEditUserType != null)
                {
                    ddlEditUserType.DataSource = objUsers.getAllUserTypes();
                    ddlEditUserType.DataBind();
                    ddlEditUserType.SelectedValue = gvwUsers.DataKeys[e.Row.RowIndex].Values[1].ToString();
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList ddlNewUserType = (DropDownList)e.Row.FindControl("ddlNewUserType");
                ddlNewUserType.DataSource = objUsers.getAllUserTypes();
                ddlNewUserType.DataBind();
            } 
        }

        protected void gvwUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                bool isActive = false;
                bool verified = false;

                TextBox tbxNewName = (TextBox)gvwUsers.FooterRow.FindControl("tbxNewName");
                TextBox tbxNewSurname = (TextBox) gvwUsers.FooterRow.FindControl("tbxNewSurname");
                TextBox tbxNewEmail = (TextBox)gvwUsers.FooterRow.FindControl("tbxNewEmail");
                TextBox tbxNewPassword = (TextBox)gvwUsers.FooterRow.FindControl("tbxNewPassword");

                DropDownList ddlNewUserType = (DropDownList)gvwUsers.FooterRow.FindControl("ddlNewUserType");
                CheckBox chkNewActive = (CheckBox) gvwUsers.FooterRow.FindControl("chkNewActive");
                CheckBox chkNewVerified = (CheckBox)gvwUsers.FooterRow.FindControl("chkNewVerified");

                if (chkNewVerified.Checked)
                    verified = true;

                if (chkNewActive.Checked)
                    isActive = true;

                objUsers.InsertGamaUser(tbxNewName.Text, tbxNewSurname.Text, tbxNewEmail.Text, isActive, Convert.ToInt32(ddlNewUserType.SelectedValue), tbxNewPassword.Text, verified);
                FillUsersGrid();
                lblDisplayMessages.Text = "User added";
                dvSystemMessages.Visible = true;
            } 
        }

        protected void gvwUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvwUsers.EditIndex = e.NewEditIndex;
            FillUsersGrid();
        }

        protected void gvwUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvwUsers.EditIndex = -1;
            FillUsersGrid();
        }

        protected void gvwUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool isActive = false;
            bool verified = false;

            TextBox tbxEditName = (TextBox)gvwUsers.Rows[e.RowIndex].FindControl("tbxEditName");
            TextBox tbxEditSurname = (TextBox)gvwUsers.Rows[e.RowIndex].FindControl("tbxEditSurname");
            DropDownList ddlEditUserType = (DropDownList)gvwUsers.Rows[e.RowIndex].FindControl("ddlEditUserType");
            TextBox tbxEditEmail = (TextBox)gvwUsers.Rows[e.RowIndex].FindControl("tbxEditEmail");
            TextBox tbxEditPassword = (TextBox)gvwUsers.Rows[e.RowIndex].FindControl("tbxEditPassword");
            CheckBox chkEditActive = (CheckBox) gvwUsers.Rows[e.RowIndex].FindControl("chkEditActive");
            CheckBox chkEditVerified = (CheckBox) gvwUsers.Rows[e.RowIndex].FindControl("chkEditVerified");

            if (chkEditVerified.Checked)
                    verified = true;

                if (chkEditActive.Checked)
                    isActive = true;

            objUsers.UpdateGamaUser(int.Parse(ddlEditUserType.SelectedValue), tbxEditName.Text, tbxEditSurname.Text, tbxEditEmail.Text, isActive, int.Parse(gvwUsers.DataKeys[e.RowIndex].Values[0].ToString()), verified, tbxEditPassword.Text);
            gvwUsers.EditIndex = -1;
            FillUsersGrid();
            lblDisplayMessages.Text = "User updated";
            dvSystemMessages.Visible = true;
        }

        protected void gvwUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objUsers.deleteGamaUser(int.Parse(gvwUsers.DataKeys[e.RowIndex].Values[0].ToString()));
            FillUsersGrid();
            lblDisplayMessages.Text = "User deactivated";
            dvSystemMessages.Visible = true;
        }
    }
}