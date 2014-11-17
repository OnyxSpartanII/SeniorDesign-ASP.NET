using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    public string DefaultFileName = "Upload/"; // is the folder where files are uploaded to

/**
protected void UploadButton_Click(object sender, EventArgs e)
    {
       
        if (FileUploader.HasFile)
            try
            {
                FileUploader.SaveAs(Server.MapPath(DefaultFileName) +
                     FileUploader.FileName );
                Label1.Text = "File name: " +
                     FileUploader.PostedFile.FileName + "<br>" +
                     FileUploader.PostedFile.ContentLength + " kb<br>" +
                     "Content type: " +
                     FileUploader.PostedFile.ContentType + "<br><b>Uploaded Successfully";

            }
            catch (Exception ex)
            {
                Label1.Text = "ERROR: " + ex.Message.ToString();
            }
        else
        {
            Label1.Text = "You have not specified a file.";
        }

    }
    */
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if ((fileuploadExcel.PostedFile != null) && (fileuploadExcel.PostedFile.ContentLength > 0))
        {
            string fn = System.IO.Path.GetFileName(fileuploadExcel.PostedFile.FileName);
            string SaveLocation = Server.MapPath("Data") + "\\" + fn; //specify where to save file
            try
            {
                fileuploadExcel.PostedFile.SaveAs(SaveLocation);
                Response.Write("The file has been uploaded.");
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
                //Note: Exception.Message returns detailed message that describes the current exception.
                //For security reasons, we do not recommend you return Exception.Message to end users in
                //production environments. It would be better just to put a generic error message.
            }
        }
        else
        {
            Response.Write("Please select a file to upload.");
        }
    }
} 