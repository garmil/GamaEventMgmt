using System;
using System.Linq;
using System.Web.Services;
using GamaEventMgmt.ApplicationClasses;

namespace GamaEventMgmt.GamaAdmin
{
    public partial class ManageCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public void BtnSaveClick(string values)
        {
            var gamauser = new GamaUserAccessor();
            //gamauser.InsertGamaUser(txtName.Text,txtSurname.Text,txtEmail.Text,CheckBox1.Checked,Convert.ToInt32(ddlUsertype.SelectedValue));
        }


        [WebMethod]
        public string GetAllTypes()
        {
            var gamauser = new GamaUserAccessor();
            var types = gamauser.GetAllUserTypes().ToArray();
            var serialised = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(types);
            return serialised;
        }
    }
}