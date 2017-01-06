using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Data.OleDb;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;
using PdfSharp;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using System.Net;
using System.IO.Compression;



public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
        generallabel.Text = "Accounting Sales Report";

    }
 
    public string GetConnectionString2()
    {
        //sets the connection string from your web config file "ConnString" is the name of your Connection String
        return System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString2"].ConnectionString;
    }





    public void viewSearch_Click4(object sender, EventArgs e)
    {
        OleDbConnection connPopulate = new OleDbConnection(GetConnectionString2());
       // OleDbCommand cmd = new OleDbCommand(@"select * from TMWIN.""Rogue_EDIUsers""  where ""UserID""='vwrtest';", connPopulate);
        string sql;
        DataSetGeneral dsGeneral = new DataSetGeneral();
        if (referenceGeneral.Text == String.Empty)
        {
            sql = @"SELECT a.DETAIL_LINE_ID,MIN(TRACE_NO) AS ""REFERENCE"",min(created_time)AS ""Ordertime"",min(BILL_DATE) AS ""BILL_DATE"",min(INVOICE_TYPE) AS ""INVOICE_TYPE"",min(CUSTOMER) AS ""CUSTOMER"",min(SERVICE_LEVEL) AS ""SERVICE_LEVEL"",min(b.BILL_TO_CODE) AS ""BILL_TO_CODE"",min(BILL_TO) AS ""BILL_TO"",min(BILL_TO_NAME) AS ""BILL_TO_NAME"",min(BILL_NUMBER)
AS ""BILL_NUMBER"",min(CURRENT_STATUS) AS ""STATUS"", MIN(PALLETS) AS ""PALLETS"",min(AS_WEIGHT) AS ""AS_WEIGHT"",min(CUBE_WEIGHT) AS ""CUBE_WEIGHT"",min(WEIGHT) AS ""WEIGHT"",
min(pick_up_by) AS ""ACTUAL_PICKUP"",min(PICKUP_AT_CONTACT) AS
""PICKUP_AT_CONTACT"",min(PICKUP_AT_NAME) AS ""PICKUP_AT_NAME"",min(PICKUP_AT_ADDR1) AS ""PICKUP_AT_ADDR1"",min(PICKUP_AT_ADDR2) AS ""PICKUP_AT_ADDR2"",min(PICKUP_AT_CITY) AS ""PICKUP_AT_CITY"",min(PICKUP_AT_PROV) AS ""PICKUP_AT_PROV"",
min(PICKUP_AT_UNIT) AS ""PICKUP_AT_UNIT"",min(PICKUP_AT_ZONE) AS ""PICKUP_AT_ZONE"",min(PICKUP_AT_PC) AS ""PICKUP_AT_POSTALCODE"",min(deliver_by) AS ""ACTUAL_DELIVERY"",min(DESTCONTACT) AS ""DESTCONTACT"",min(DESTINATION) AS ""DESTINATION"",min(DESTNAME) AS ""DESTNAME"",min(DESTADDR1) AS ""DESTADDR1"",min(DESTADDR2) AS ""DESTADDR2"",min(DESTCITY)
AS ""DESTCITY"",min(DESTPROV) AS ""DESTPROV"", min(DESTPC) AS ""DESTINATIONPOSTALCODE"",
min(DESTUNIT) AS ""DESTUNIT"",min(DEST_TIMEZONE) AS ""DEST_TIMEZONE"",min(PIECES) AS ""PIECES"",min(CHARGES) AS ""CHARGES"",min(CHARGE_TYPE) AS ""CHARGE_TYPE"",min(SUPPLIER_CHARGES) AS ""SUPPLIER_CHARGES"",min(FUEL_WARMUPS) AS ""FUEL_WARMUPS"",min(NO_CHARGE) AS ""NO_CHARGE"",min(XCHARGES) AS ""XCHARGES"",MAX(CASE WHEN a.ACODE_ID='FSC-LTL' then a.charge_amount ELSE 0  END) AS ""FSCLTLFUELSURCHARGE"",
MAX(CASE WHEN a.ACODE_ID='TGPICK' then a.charge_amount ELSE 0  END) AS ""TGPICKTAILGATE"",MAX(CASE WHEN a.ACODE_ID='FSC-LTL-IN' then a.charge_amount ELSE 0  END) AS ""FSCLTLINFUELSURCHARGE"",min(TAX_1) AS ""TAX_1"",min(TAX_2) AS ""TAX_2"",min(TOTAL_CHARGES) AS ""TOTAL_CHARGES""
FROM TMWIN.TLORDER b INNER JOIN TMWIN.ACHARGE_TLORDER a on b.detail_line_id=a.detail_line_id where pick_up_by >? and deliver_by <? group by a.detail_line_id;";
           
            OleDbDataAdapter myCommand4 = new OleDbDataAdapter(sql, connPopulate);
            myCommand4.SelectCommand.Parameters.Add("@p1", OleDbType.DBDate).Value = pickupStart4.Text;
            myCommand4.SelectCommand.Parameters.Add("@p2", OleDbType.DBDate).Value = pickupEnd4.Text;
            myCommand4.Fill(dsGeneral, "DataTable1");
            connPopulate.Open();



            myCommand4.SelectCommand.CommandType = CommandType.Text;
            myCommand4.SelectCommand.ExecuteNonQuery();

        }
        else if (referenceGeneral.Text != String.Empty)
        {
             sql = @"SELECT a.DETAIL_LINE_ID,MIN(TRACE_NO) AS ""REFERENCE"",min(created_time)AS ""Ordertime"",min(BILL_DATE) AS ""BILL_DATE"",min(INVOICE_TYPE) AS ""INVOICE_TYPE"",min(CUSTOMER) AS ""CUSTOMER"",min(SERVICE_LEVEL) AS ""SERVICE_LEVEL"",min(b.BILL_TO_CODE) AS ""BILL_TO_CODE"",min(BILL_TO) AS ""BILL_TO"",min(BILL_TO_NAME) AS ""BILL_TO_NAME"",min(BILL_NUMBER)
AS ""BILL_NUMBER"",min(CURRENT_STATUS) AS ""STATUS"", MIN(PALLETS) AS ""PALLETS"",min(AS_WEIGHT) AS ""AS_WEIGHT"",min(CUBE_WEIGHT) AS ""CUBE_WEIGHT"",min(WEIGHT) AS ""WEIGHT"",
min(pick_up_by) AS ""ACTUAL_PICKUP"",min(PICKUP_AT_CONTACT) AS
""PICKUP_AT_CONTACT"",min(PICKUP_AT_NAME) AS ""PICKUP_AT_NAME"",min(PICKUP_AT_ADDR1) AS ""PICKUP_AT_ADDR1"",min(PICKUP_AT_ADDR2) AS ""PICKUP_AT_ADDR2"",min(PICKUP_AT_CITY) AS ""PICKUP_AT_CITY"",min(PICKUP_AT_PROV) AS ""PICKUP_AT_PROV"",
min(PICKUP_AT_UNIT) AS ""PICKUP_AT_UNIT"",min(PICKUP_AT_ZONE) AS ""PICKUP_AT_ZONE"",min(PICKUP_AT_PC) AS ""PICKUP_AT_POSTALCODE"",min(deliver_by) AS ""ACTUAL_DELIVERY"",min(DESTCONTACT) AS ""DESTCONTACT"",min(DESTINATION) AS ""DESTINATION"",min(DESTNAME) AS ""DESTNAME"",min(DESTADDR1) AS ""DESTADDR1"",min(DESTADDR2) AS ""DESTADDR2"",min(DESTCITY)
AS ""DESTCITY"",min(DESTPROV) AS ""DESTPROV"", min(DESTPC) AS ""DESTINATIONPOSTALCODE"",
min(DESTUNIT) AS ""DESTUNIT"",min(DEST_TIMEZONE) AS ""DEST_TIMEZONE"",min(PIECES) AS ""PIECES"",min(CHARGES) AS ""CHARGES"",min(CHARGE_TYPE) AS ""CHARGE_TYPE"",min(SUPPLIER_CHARGES) AS ""SUPPLIER_CHARGES"",min(FUEL_WARMUPS) AS ""FUEL_WARMUPS"",min(NO_CHARGE) AS ""NO_CHARGE"",min(XCHARGES) AS ""XCHARGES"",MAX(CASE WHEN a.ACODE_ID='FSC-LTL' then a.charge_amount ELSE 0  END) AS ""FSCLTLFUELSURCHARGE"",
MAX(CASE WHEN a.ACODE_ID='TGPICK' then a.charge_amount ELSE 0  END) AS ""TGPICKTAILGATE"",MAX(CASE WHEN a.ACODE_ID='FSC-LTL-IN' then a.charge_amount ELSE 0  END) AS ""FSCLTLINFUELSURCHARGE"",min(TAX_1) AS ""TAX_1"",min(TAX_2) AS ""TAX_2"",min(TOTAL_CHARGES) AS ""TOTAL_CHARGES""
FROM TMWIN.TLORDER b INNER JOIN TMWIN.ACHARGE_TLORDER a on b.detail_line_id=a.detail_line_id where TRACE_NO=? group by a.detail_line_id;";
             
             OleDbDataAdapter myCommand4 = new OleDbDataAdapter(sql, connPopulate);
             myCommand4.SelectCommand.Parameters.Add("@p1", OleDbType.VarChar).Value = referenceGeneral.Text;
             myCommand4.Fill(dsGeneral, "DataTable1");
             connPopulate.Open();



             myCommand4.SelectCommand.CommandType = CommandType.Text;
             myCommand4.SelectCommand.ExecuteNonQuery();
            


        }
        //OleDbDataReader ddlValues;
       
        
       /* while (ddlValues.Read())
        {
            wow.Text = ddlValues["MasterAccountID"].ToString();
        }
        * */
        ReportViewer4.ProcessingMode = ProcessingMode.Local;
        ReportViewer4.LocalReport.ReportPath = Server.MapPath("~/SSRS.rdlc");
        ReportDataSource datasource = new ReportDataSource("DataSet1", dsGeneral.Tables[0]);
        ReportViewer4.LocalReport.DataSources.Clear();
        ReportViewer4.LocalReport.DataSources.Add(datasource);
        ReportViewer4.LocalReport.EnableHyperlinks = true;
       // string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        connPopulate.Close();

    }








   
}