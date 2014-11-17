<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testWebForm.aspx.cs" Inherits="upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Upload</title>
   
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
        <!--
        Select File &nbsp;<asp:FileUpload ID="FileUploader" runat="server" /><br />
        <br />
        <asp:Button ID="UploadButton" runat="server" Text="Upload" OnClick="UploadButton_Click" /><br />
        <br />
         <asp:Label ID="Label1" runat="server"></asp:Label><br />
            -->
        <h1> Upload Excel file to human trafficking database</h1>
    <asp:FileUpload ID="fileuploadExcel" runat="server" />
    <!-- <asp:Button ID="Button1" runat="server" Text="Button" onclick="UploadButton_Click" /> -->
</div>
    </form>

</body>
</html> 