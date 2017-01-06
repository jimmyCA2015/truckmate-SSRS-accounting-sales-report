<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"

    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
         function PopupPicker(ctl, w, h) {
             var PopupWindow = null;
             settings = 'width=' + w + ',height=' + h + ',left=800px,top=300px,location=no,directories=no, menubar=no,toolbar=no,status=no,scrollbars=no,resizable=no, dependent=no';
             PopupWindow = window.open('DatePicker.aspx?Ctl=' +
                ctl, 'DatePicker', settings);
             PopupWindow.focus();
         }
   </script>
</head>
<body>
   
 <form id="Form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <img  style="position:absolute;left:0px;top:0px" src="companylogo.gif" width="100%" height="150px" />    
           <asp:Panel ID="Panel1"  style="position:absolute;border: 1px solid black; width: 100%; top:160px;left:0px" runat="server" >
           <asp:label ID="generallabel" style="position:absolute;width:100%;height:100px;background-color:darkcyan;top:0px;left:0px;text-align:center;font-size:xx-large;padding-top:50px;font-weight:bold"  runat="server"></asp:label>
           <div id="Div1"  style="position:absolute;width:100%;height:50px;background-color:darkcyan;top:100px;left:0px;text-align:left;"  runat="server">Option 1:Search By PO#/Reference # <br />Option 2: Search by pickup start date and pickup end date</div>
     <table style="background-color:lightblue;position:absolute;left:0px;top:150px;height:100px;"> 
           <tr >
              <td>P0 #/Reference #</td>
              <td><asp:TextBox id="referenceGeneral" runat="server"></asp:TextBox></td>
           </tr>
           <tr>
              <td>Pickup Start Date</td>
              <td><asp:TextBox id="pickupStart4" runat="server"></asp:TextBox></td>
              <td><asp:linkbutton ID="Linkbutton1" runat="server"   OnClientClick="PopupPicker('pickupStart4', 250, 250)" ><img src="calendar.gif" alt="delete group" /></asp:linkbutton></td>
              <td style="padding-right:10px"> </td>
              <td>Pickup End Date</td>
              <td><asp:TextBox id="pickupEnd4" runat="server"></asp:TextBox></td>
              <td><asp:linkbutton ID="Linkbutton2" runat="server"   OnClientClick="PopupPicker('pickupEnd4', 250, 250)" ><img src="calendar.gif" alt="delete group" /></asp:linkbutton></td>
              <td style="padding-right:100px"> </td>
              <td ><asp:button id="viewSearch" runat="server" Text="ViewReport" OnClick="viewSearch_Click4"></asp:button></td>
           </tr>
          </table>
   <rsweb:ReportViewer style="position:absolute;left:0px;top:250px" ID="ReportViewer4" runat="server" Width="100%"   Height="100%"  AsyncRendering="False"  SizeToReportContent="True"  ShowParameterPrompts="true" ProcessingMode="Remote">
        </rsweb:ReportViewer>
               </asp:Panel>

</form>


</body>
</html>
