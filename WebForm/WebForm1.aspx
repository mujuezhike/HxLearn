<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Select1 {
            width: 166px;
        }
        #Button1 {
            width: 145px;
            margin-left: 26px;
        }
        .auto-style1 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <table style="width: 46%;">
        <tr>
            <td>td1<input id="Text1" type="text" /></td>
            <td>td2<input id="Text2" type="text" /></td>
            <td>td3<input id="Text3" type="text" /></td>
        </tr>
        <tr>
            <td>
                <select id="Select1" name="D1">
                    <option></option>
                </select></td>
            <td>
                <input id="Button1" type="button" value="submit" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
    </table>
</body>
</html>
