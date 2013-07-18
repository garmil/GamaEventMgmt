using System;
using GamaEventMgmt.ApplicationClasses;

namespace GamaEventMgmt.GamaAdmin
{
    public partial class ManageCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var gamauser = new GamaUserAccessor();
            gamauser.InsertGamaUser(txtName.Text,txtSurname.Text,txtEmail.Text,CheckBox1.Checked,Convert.ToInt32(ddlUsertype.SelectedValue));
        }
    }
}