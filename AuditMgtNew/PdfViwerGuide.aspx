<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PdfViwerGuide.aspx.cs" Inherits="AuditMgtNew.PdfViwerGuide" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/StyleSheet3.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <form id="form1" runat="server">
    
    
        <center>  
        <iframe id ="pdf" name= "pdf" runat="Server" src = "Dubai Holding User Guide.pdf"  enableviewstate="true" align="middle" height="1200px" width="1200px"> </iframe>
    
   
    </center>  



   
    </form>
</body>
</html>


    