using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamaEventMgmt.EventMgmt
{
    public partial class eventInvitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;

            if (this.fupRecipients.HasFile)
            {
                this.fupRecipients.SaveAs("c:\\gamaUploads\\" + this.fupRecipients.FileName);

                fileName = "c:\\gamaUploads\\" + this.fupRecipients.FileName;

                foreach (string line in File.ReadLines(fileName))
                {
                    string email = line;

                }
            }
        }
    }
}