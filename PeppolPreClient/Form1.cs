using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PeppolPreClient
{
    public partial class Form1 : Form
    {
        string sConnectionString = "Data Source=dbhost;Initial Catalog=icx_gunnar;Integrated Security=True";
        long lRsEdocType = -1;

        XmlDocument xd = new XmlDocument();
        XmlNamespaceManager xmlnsManager;

        public Form1()  
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            rbUblVersionNotFound.Checked = true;
            rbCustomizationLevelNotFound.Checked = true;
            rbDocumentTypeNotFound.Checked = true;
            rbProfileNotFound.Checked = true;

            txtSupplierCountryCode.Text = string.Empty;
            txtSupplierCountryID.Text = string.Empty;
            txtSupplierID.Text = string.Empty;

            txtCustomerCountryCode.Text = string.Empty;
            txtCustomerCountryID.Text = string.Empty;
            txtCustomerID.Text = string.Empty;

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Init();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = @"C:\Users\gunnar.voyenli\Documents\Temp";
            openFileDialog1.InitialDirectory = @"C:\Users\gunnar.voyenli\Documents\PEPPOL\Test";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDocument.Text = openFileDialog1.FileName;

                webBrowser1.DocumentText = File.ReadAllText(openFileDialog1.FileName);

                xd.Load(openFileDialog1.FileName);


                string sRootElement = xd.DocumentElement.Name;
                if (!(sRootElement.Contains(":")))
                    sRootElement = string.Format("{0}:{1}", sRootElement, sRootElement);

                XmlNode root = xd.DocumentElement;
                string sDocumentType = root.LocalName;
                XmlNode nTmp;

                txtRootNamespace.Text = root.NamespaceURI;
                txtDocumentElementName.Text = root.LocalName;



                xmlnsManager = new XmlNamespaceManager(xd.NameTable);
                xmlnsManager.AddNamespace("Invoice", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
                xmlnsManager.AddNamespace("CreditNote", "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2");
                xmlnsManager.AddNamespace(root.GetPrefixOfNamespace(root.NamespaceURI), root.NamespaceURI);
                xmlnsManager.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                xmlnsManager.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                xmlnsManager.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                xmlnsManager.AddNamespace("ccts", "urn:un:unece:uncefact:documentation:2");


                //UBLVersion
                //string sUBLVersionID = GetXmlNodeText(xd, xmlnsManager, new string[] { 
                //        string.Format("{0}/cbc:UBLVersionID", sRootElement),
                //    });
                nTmp = root.FirstChild;
                string sUBLVersionID = nTmp.Name == "cbc:UBLVersionID" ? nTmp.InnerText : string.Empty;
                rbUblVersionNotFound.Checked = true;
                rbUBLVersion20.Checked = sUBLVersionID == "2.0";
                rbUblVersion21.Checked = sUBLVersionID == "2.1";

                //CustomizationID
                //string sCustomizationID = GetXmlNodeText(xd, xmlnsManager, new string[] { 
                //        string.Format("{0}/cbc:CustomizationID", sRootElement),
                //    });
                nTmp = nTmp.NextSibling;
                string sCustomizationID = nTmp.Name == "cbc:CustomizationID" ? nTmp.InnerText : string.Empty;
                sCustomizationID = sCustomizationID.Substring(sCustomizationID.IndexOf("urn:www.cenbii.eu:transaction"));
                rbCustomizationLevelNotFound.Checked = true;
                rbCustomizationLevelEHF.Checked = IsCustomizationIDEhfFunction(sCustomizationID, sUBLVersionID);
                rbCustomizationLevelPeppol.Checked = IsCustomizationIDPeppolFunction(sCustomizationID, sUBLVersionID);

                ////DocumentID
                //sDocumentID = GetDocumentID(xd.DocumentElement, sCustomizationID, sUBLVersionID);

                //ProfileID
                //sProfileID = GetXmlNodeText(xd, xmlnsManager, new string[] { 
                //        string.Format("{0}/cbc:ProfileID", sRootElement),
                //    });
                nTmp = nTmp.NextSibling;
                string sProfileID = nTmp.Name == "cbc:ProfileID" ? nTmp.InnerText : string.Empty;
                rbProfileNotFound.Checked = true;
                rbProfileInvoiceOnly.Checked = sProfileID.Contains("bii04");
                rbProfileCreditNoteOnly.Checked = sProfileID.Contains("biixx");
                rbProfileInvoiceAndCreditNote.Checked = sProfileID.Contains("bii05");

                //DocumentType
                rbDocumentTypeNotFound.Checked = true;
                rbDocumentTypeInvoice.Checked = IsDocumentTypeInvoiceFunction(sDocumentType);
                rbDocumentTypeCreditNote.Checked = IsDocumentTypeCreditNoteFunction(sDocumentType);

                txtSupplierCountryID.Text = GetXmlNodeText(xd, xmlnsManager, new string[] { 
                        string.Format("{0}/cac:AccountingSupplierParty/cac:Party/cac:PartyLegalEntity/cac:RegistrationAddress/cac:Country/cbc:IdentificationCode", sRootElement),
                        string.Format("{0}/cac:AccountingSupplierParty/cac:Party/cac:PostalAddress/cac:Country/cbc:IdentificationCode", sRootElement)
                    });
                txtSupplierCountryCode.Text = GetContryCode(txtSupplierCountryID.Text);

                txtCustomerCountryID.Text = GetXmlNodeText(xd, xmlnsManager, new string[] { 
                        string.Format("{0}/cac:AccountingCustomerParty/cac:Party/cac:PartyLegalEntity/cac:RegistrationAddress/cac:Country/cbc:IdentificationCode", sRootElement),
                        string.Format("{0}/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cac:Country/cbc:IdentificationCode", sRootElement),
                    });
                txtCustomerCountryCode.Text = GetContryCode(txtCustomerCountryID.Text);

                txtCustomerID.Text = GetXmlNodeText(xd, xmlnsManager, new string[] { 
                        string.Format("{0}/cac:AccountingCustomerParty/cac:Party/cac:PartyLegalEntity/cbc:CompanyID", sRootElement),
                    });

                txtSupplierID.Text = GetXmlNodeText(xd, xmlnsManager, new string[] { 
                        string.Format("{0}/cac:AccountingSupplierParty/cac:Party/cac:PartyLegalEntity/cbc:CompanyID", sRootElement),
                    });

                //if (txtSupplierID.Text == string.Empty)
                //    txtSupplierID.Text = "981641205";

                //if (txtSupplierCountryCode.Text == string.Empty)
                //    txtSupplierCountryCode.Text = "9908";

                //if (txtCustomerID.Text == string.Empty)
                //    txtCustomerID.Text = "981937597";

                //if (txtCustomerCountryCode.Text == string.Empty)
                //    txtCustomerCountryCode.Text = "9908";
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You are about to send this document out on the PEPPOL production network. Do you want to continue", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK)
            {
                // Creat AP Reference
                net.xledger.peppolclient.AccessPointClientServiceClient ap = new net.xledger.peppolclient.AccessPointClientServiceClient();
                
                XmlDocument body = new XmlDocument();
                body.Load(txtDocument.Text);
                string sXmlBody = body.OuterXml;

                if (rbDocumentTypeInvoice.Checked)
                    lRsEdocType = 37501;
                else if (rbDocumentTypeCreditNote.Checked)
                    lRsEdocType = 37502;
                else
                    lRsEdocType = -1;

                string sDocumentID = DocumentID(xd.DocumentElement, CustomizationID, UBLVersionID);


                // Send
                long lRet = 1;
                string sErrorInfo;

                try
                {
                    lRet = ap.SendMessage(SenderID, RecipientID, sDocumentID, ProfileID, sXmlBody, out sErrorInfo);
                    if (lRet == 0)
                    {
                        txtResult.Text = "Document successfully sent!";
                    }
                }
                catch (Exception ex)
                {
                    txtResult.Text = ex.Message;

                    if (lRet == 0)
                        lRet = 1; // Give it an error code
                }
            }
            else
                txtResult.Text = "Document NOT sent!";
        }
       
        private string DocumentID(XmlNode xnRoot, string sCustomizationID, string sUBLVersionID)
        {
            string sRootNamespace = xnRoot.NamespaceURI != string.Empty ? string.Format("{0}::", xnRoot.NamespaceURI) : string.Empty;
            string sVersion = sUBLVersionID != string.Empty ? string.Format("::{0}", sUBLVersionID) : string.Empty;
            return string.Format("{0}{1}##{2}{3}", sRootNamespace, xnRoot.LocalName, sCustomizationID, sVersion);
        }

        string RecipientID { get { return string.Format("{0}:{1}", txtCustomerCountryCode.Text, txtCustomerID.Text); } }

        string SenderID { get { return string.Format("{0}:{1}", txtSupplierCountryCode.Text, txtSupplierID.Text); } }
      
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private string GetContryCode(string p)
        {
            string sRet = string.Empty;
            if (p == "NO")
            {
                sRet = "9908";
            }
            return sRet;
        }

        private string GetXmlNodeText(XmlDocument xd, XmlNamespaceManager xmlnsManager, string[] p)
        {
            XmlNode n;
            n = xd.SelectSingleNode(p[0], xmlnsManager);

            for (int i = 1; i < p.Length; i++) 
            {
                if (!(n == null))
                    break;

                n = xd.SelectSingleNode(p[i], xmlnsManager);
            }

            if (n == null)
                return string.Empty;

            return n.InnerText;
        }

        bool IsCustomizationIDEhfFunction(string sCustomizationID, string version)
        {
            string delimiter = "#";
            if (version == "2.1")
                delimiter = ":extended:";
            return sCustomizationID.Split(new string[] { delimiter }, StringSplitOptions.None).Length == 3;
        }

        bool IsCustomizationIDPeppolFunction(string sCustomizationID, string version)
        {
            string delimiter = "#";
            if (version == "2.1")
                delimiter = ":extended:";
            return sCustomizationID.Split(new string[] { delimiter }, StringSplitOptions.None).Length == 2;
        }

        bool IsDocumentTypeInvoiceFunction(string sDocumentType)
        {
            return sDocumentType.ToLower() == "invoice";
        }

        bool IsDocumentTypeCreditNoteFunction(string sDocumentType)
        {
            return sDocumentType.ToLower() == "creditnote";
        }

        public string GetUblDocumentType(string sConnectionString, long lRsEdocType, string sSupplierCountryCode, string sCustomerCountryCode)
        {
            return string.Format("{0}::{1}##{2}::{3}",
                GetUblRootNameSpace(sConnectionString, RsEdocType),
                GetUblDocumentElementLocalName(sConnectionString, RsEdocType),
                GetUblCustomization(sConnectionString, RsEdocType, sSupplierCountryCode, sCustomerCountryCode),
                GetUblVersion()
                );
        }

        private string GetUblRootNameSpace(string sConnectionString, long lRsEdocType)
        {
            System.Data.IDbCommand oCmd = X.Data.DB.DbFactory.GetFunctionCommand(sConnectionString, "dbo.xf_get_ubl_root_namespace", X.Data.DB.XDbType.NVarChar, 255);
            X.Data.DB.DbFactory.AddParameter(oCmd, "@rs_key", lRsEdocType, X.Data.DB.XDbType.BigInt);

            return (string)X.Data.DB.DbFactory.ExecFunctionCommand(oCmd);
        }

        private string GetUblDocumentElementLocalName(string sConnectionString, long lRsEdocType)
        {
            System.Data.IDbCommand oCmd = X.Data.DB.DbFactory.GetFunctionCommand(sConnectionString, "dbo.xf_get_ubl_document_element_local_name", X.Data.DB.XDbType.NVarChar, 255);
            X.Data.DB.DbFactory.AddParameter(oCmd, "@rs_key", lRsEdocType, X.Data.DB.XDbType.BigInt);

            return (string)X.Data.DB.DbFactory.ExecFunctionCommand(oCmd);
        }

        public string GetUblCustomization(string sConnectionString, long lRsEdocType, string sSupplierCountryCode, string sCustomerCountryCode)
        {
            System.Data.IDbCommand oCmd = X.Data.DB.DbFactory.GetFunctionCommand(sConnectionString, "dbo.xf_get_ubl_customization", X.Data.DB.XDbType.NVarChar, 1000);
            X.Data.DB.DbFactory.AddParameter(oCmd, "@rs_key", lRsEdocType, X.Data.DB.XDbType.BigInt);
            X.Data.DB.DbFactory.AddParameter(oCmd, "@sSenderCountryCode", sSupplierCountryCode, X.Data.DB.XDbType.NVarChar, 4, System.Data.ParameterDirection.Input);
            X.Data.DB.DbFactory.AddParameter(oCmd, "@sReceiverCountryCode", sCustomerCountryCode, X.Data.DB.XDbType.NVarChar, 4, System.Data.ParameterDirection.Input);

            return (string)X.Data.DB.DbFactory.ExecFunctionCommand(oCmd);
        }

        private string GetUblVersion()
        {
            if (rbUBLVersion20.Checked)
                return "2.0";
            else
                return ("2.1");
        }

        //protected static string GetUblRootNameSpace(string sConnectionString, long lRsEdocType)
        //{
        //    System.Data.IDbCommand oCmd = X.Data.DB.DbFactory.GetFunctionCommand(sConnectionString, "dbo.xf_get_ubl_root_namespace", X.Data.DB.XDbType.NVarChar, 255);
        //    X.Data.DB.DbFactory.AddParameter(oCmd, "@rs_key", lRsEdocType, X.Data.DB.XDbType.BigInt);

        //    return (string)X.Data.DB.DbFactory.ExecFunctionCommand(oCmd);
        //}

        //protected static string GetUblDocumentElementLocalName(string sConnectionString, long lRsEdocType)
        //{
        //    System.Data.IDbCommand oCmd = X.Data.DB.DbFactory.GetFunctionCommand(sConnectionString, "dbo.xf_get_ubl_document_element_local_name", X.Data.DB.XDbType.NVarChar, 255);
        //    X.Data.DB.DbFactory.AddParameter(oCmd, "@rs_key", lRsEdocType, X.Data.DB.XDbType.BigInt);

        //    return (string)X.Data.DB.DbFactory.ExecFunctionCommand(oCmd);
        //}

        ///// <summary>
        ///// Get The Customization ID Text down to specified Level
        ///// </summary>
        ///// <param name="sConnectionString">The DB Connectionstring</param>
        ///// <param name="lUblProfileID">Chosen ProfileID</param>
        ///// <param name="sSupplierCountryCode">Country Code for Supplier</param>
        ///// <param name="sCustomerCountryCode">Country Code for Customer</param>
        ///// <returns>Customization Text</returns>
        //public static string GetUblCustomization(string sConnectionString, long lRsEdocType, string sSupplierCountryCode, string sCustomerCountryCode)
        //{
        //    System.Data.IDbCommand oCmd = X.Data.DB.DbFactory.GetFunctionCommand(sConnectionString, "dbo.xf_get_ubl_customization", X.Data.DB.XDbType.NVarChar, 1000);
        //    X.Data.DB.DbFactory.AddParameter(oCmd, "@rs_key", lRsEdocType, X.Data.DB.XDbType.BigInt);
        //    X.Data.DB.DbFactory.AddParameter(oCmd, "@sSenderCountryCode", sSupplierCountryCode, X.Data.DB.XDbType.NVarChar, 4, System.Data.ParameterDirection.Input);
        //    X.Data.DB.DbFactory.AddParameter(oCmd, "@sReceiverCountryCode", sCustomerCountryCode, X.Data.DB.XDbType.NVarChar, 4, System.Data.ParameterDirection.Input);

        //    return (string)X.Data.DB.DbFactory.ExecFunctionCommand(oCmd);
        //}



        private void btnUblGetDocumentType_Click(object sender, EventArgs e)
        {
            txtResult.Text = GetUblDocumentType(sConnectionString, RsEdocType, txtSupplierCountryCode.Text, txtCustomerCountryCode.Text);
            rbCustomizationLevelNotFound .Checked = ((txtCustomerCountryCode.Text == txtSupplierCountryCode.Text) && (txtSupplierCountryCode.Text == "9908"));
            rbCustomizationLevelPeppol.Checked = !rbCustomizationLevelEHF.Checked;
        }

        private long RsEdocType
        {
            get
            {
                if (rbDocumentTypeInvoice.Checked)
                    return 37501;

                return 37502;
            }
        }

        private void btnSmlLookup_Click(object sender, EventArgs e)
        {
            bool bRet = false;
            net.xledger.peppolclient.AccessPointClientServiceClient ApClient = new net.xledger.peppolclient.AccessPointClientServiceClient();

            string sUBLVersionID = UBLVersionID;
            string sCustomizationID = CustomizationID;

            string sDocumentID = DocumentID(xd.DocumentElement, CustomizationID, UBLVersionID);

            string sEndpointID = "";

            string sError = "";
            string sEndpoint = "";
            string sResult = string.Empty;

            try
            {
                bRet = ApClient.SmlLookup(RecipientID, sDocumentID, out sError, out sEndpoint);
                if (bRet)
                {
                    sResult = string.Format("SmlLookup: {0}:{1}", bRet, sEndpoint);
                }
                else
                {
                    sResult = string.Format("SmlLookup: {0}:{1}", bRet, sError);
                };
            }
            catch (Exception ex)
            {   
                sResult += string.Format(" ERROR: {0}", ex.Message);
            }
            txtResult.Text += sResult;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }

        private string UBLVersionID
        {
            get
            {
                string sUBLVersion = "NA";
                if (rbUBLVersion20.Checked) sUBLVersion = "2.0";
                if (rbUblVersion21.Checked) sUBLVersion = "2.1";
                return sUBLVersion;
            }
        }

        private string ProfileIDVersion
        {
            get
            {
                string sProfileIDVersion = "1.0";
                if (UBLVersionID == "2.1") sProfileIDVersion = "2.0";

                return sProfileIDVersion;
            }
        }

        private string ProfileIDVersionLevel3
        {
            //To be used at third level of CustomizationID, because Difi has called first version "1" and not "1.0".
            get
            {
                string sProfileIDVersion2 = "1";
                if (UBLVersionID == "2.1") sProfileIDVersion2 = "2.0";

                return sProfileIDVersion2;
            }
        }

        private string ProfileID
        {
            get
            {
                string sProfileID = string.Empty;

                if (rbProfileInvoiceOnly.Checked)
                    sProfileID = string.Format("urn:www.cenbii.eu:profile:bii04:ver{0}", ProfileIDVersion);
                else if (rbProfileCreditNoteOnly.Checked)
                    sProfileID = string.Format("urn:www.cenbii.eu:profile:biixx:ver{0}", ProfileIDVersion);
                else if (rbProfileInvoiceAndCreditNote.Checked)
                    sProfileID = string.Format("urn:www.cenbii.eu:profile:bii05:ver{0}", ProfileIDVersion);

                return sProfileID;
            }
        }

        private string CustomizationID
        {
            get
            {
                string sCustomizationID = string.Empty;

                string separator1 = ":#";
                string separator2 = "#";
                string sCustomizationIDLevel1 = string.Empty;
                if (UBLVersionID == "2.1")
                {
                    separator1 = ":extended:";
                    separator2 = ":extended:";
                }


                sCustomizationID = CustomizationIDLevel1(rbDocumentTypeInvoice.Checked, ProfileIDVersion);
                if (rbProfileInvoiceOnly.Checked)
                {
                    //Profile INVOICE ONLY
                    if (rbCustomizationLevelPeppol.Checked || rbCustomizationLevelEHF.Checked)
                        sCustomizationID = string.Format("{0}{1}urn:www.peppol.eu:bis:peppol4a:ver{2}", sCustomizationID, separator1, ProfileIDVersion);
                    if (rbCustomizationLevelEHF.Checked)
                    {
                        sCustomizationID = string.Format("{0}{1}urn:www.difi.no:ehf:faktura:ver{2}", sCustomizationID, separator2, ProfileIDVersionLevel3);
                    }
                }
                else if (rbProfileCreditNoteOnly.Checked)
                {
                    //Profile CREDITNOTE ONLY
                    sCustomizationID = string.Format("{0}{1}urn:www.cenbii.eu:profile:biixx:ver{2}{3}urn:www.difi.no:ehf:creditnote:ver{4}", sCustomizationID, ProfileIDVersion, separator1, ProfileIDVersion, separator2, ProfileIDVersionLevel3);
                }
                else if (rbProfileInvoiceAndCreditNote.Checked)
                {
                    //Profile INVOICE AND CREDITNOTE
                    if (rbDocumentTypeInvoice.Checked)
                    {
                        if (rbCustomizationLevelPeppol.Checked || rbCustomizationLevelEHF .Checked)
                            sCustomizationID = string.Format("{0}{1}urn:www.peppol.eu:bis:peppol5a:ver{2}", sCustomizationID, separator1, ProfileIDVersion);
                        if (rbCustomizationLevelEHF.Checked)
                        {
                            sCustomizationID = string.Format("{0}{1}urn:www.difi.no:ehf:faktura:ver{2}", sCustomizationID, separator2, ProfileIDVersionLevel3);
                        }
                    }
                    else if (rbDocumentTypeCreditNote.Checked)
                    {
                        if (rbCustomizationLevelPeppol.Checked || rbCustomizationLevelEHF .Checked)
                            sCustomizationID = string.Format("{0}{1}urn:www.peppol.eu:bis:peppol5a:ver{2}", sCustomizationID, separator1, ProfileIDVersion);
                        if (rbCustomizationLevelEHF.Checked)
                        {
                            sCustomizationID = string.Format("{0}{1}urn:www.difi.no:ehf:kreditnota:ver{2}", sCustomizationID, separator2, ProfileIDVersionLevel3);
                        }
                    }
                }
                return sCustomizationID;
            }
        }

        private string CustomizationIDLevel1(bool IsInvoice, string sProfileIDVersion)
        { 
            string sTmp1 = "biicoretrdm";
            string sTmp2 = "014";

            if (sProfileIDVersion == "2.0")
            {
                sTmp1 = "biitrns";
            }

            if (IsInvoice)
                sTmp2 = "010";

            return string.Format("urn:www.cenbii.eu:transaction:{0}{1}:ver{2}", sTmp1, sTmp2, sProfileIDVersion);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtDocumentID.Text = DocumentID(xd.DocumentElement, CustomizationID, UBLVersionID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sError = string.Empty;
            XDocument xd = XDocument.Load(txtDocument.Text);

            // No need to validate attachments. Remove them to save time.
            var comparison = StringComparison.InvariantCultureIgnoreCase;
            var elements = xd.Descendants()
                     .Where(x => x.Name.LocalName.IndexOf("Attachment", comparison) != -1);

            elements.Remove();

            string sFile = xd.ToString();
            net.xledger.peppolclient.AccessPointClientServiceClient ap = new net.xledger.peppolclient.AccessPointClientServiceClient();
            bool bRet = ap.VefaValidation(sFile, out sError);
            if (bRet)
                txtResult.Text = "Validation OK";
            else
                txtResult.Text = sError;

        }

        //private string UploadMultipart(byte[] file, string filename, string contentType, string url)
        //{
        //    var webClient = new WebClient();
        //    string boundary = "------------------------" + DateTime.Now.Ticks.ToString("x");
        //    webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);
        //    var fileData = webClient.Encoding.GetString(file);
        //    var package = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"file\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", boundary, filename, contentType, fileData);

        //    var nfile = webClient.Encoding.GetBytes(package);

        //    byte[] resp = webClient.UploadData(url, "POST", nfile);
        //    string result = System.Text.Encoding.UTF8.GetString(resp);
        //    return ParseResult(result);
        //}

        //private string ParseResult(string s)
        //{
        //    StringBuilder sbRes = new StringBuilder();
        //    XmlDocument xd = new XmlDocument();

        //    int iStart = s.IndexOf("<body>");
        //    int iEnd = s.IndexOf("</body>");

        //    s = s.Substring(iStart, iEnd - iStart + 7);

        //    xd.LoadXml(s);
        //    XmlNodeList xnList = xd.SelectNodes("/body/div/div/div/div[@class='assertion']");

        //    foreach (XmlNode xn in xnList)
        //    {
        //        string sErrorCategory = string.Empty;
        //        sErrorCategory = xn["div"].InnerText.Trim().ToUpper();
        //        if (sErrorCategory.Contains("ERROR") || sErrorCategory.Contains("FATAL"))
        //        {
        //            XmlNode xn1 = xn.SelectSingleNode("div[@class='title collapsable']");
        //            if (xn1 != null)
        //            {
        //                StringBuilder sbResTemp = new StringBuilder();
        //                try
        //                {
        //                    XmlNode xn2 = xn1.SelectSingleNode("span[@class='identifier']");
        //                    sbResTemp.Append(String.Format("{0} {1}: ", sErrorCategory, xn2.InnerText));

        //                    XmlNode xn3 = xn1.LastChild;
        //                    sbResTemp.Append(String.Format("{0}. ", xn3.InnerText.Replace("\r\n", " ").Trim()));
        //                }
        //                catch (Exception ex)
        //                {
        //                    sbResTemp.Clear();
        //                    sbResTemp.Append(string.Format("{0} ({1}) {2}", sErrorCategory, ex.Message, xn1.InnerText));
        //                }
        //                finally
        //                {
        //                    sbRes.Append(sbResTemp.ToString());
        //                }
        //            }
        //        }
        //    }
        //    return sbRes.ToString();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            string[] filePaths = Directory.GetFiles(@"C:\Users\gunnar.voyenli\Documents\Tmp\Vefa");
            StringBuilder sb = new StringBuilder();
            foreach (string file in filePaths)
            {
                XDocument xd = XDocument.Load(file);

                // No need to validate attachments. Remove them to save time.
                var comparison = StringComparison.InvariantCultureIgnoreCase;
                var elements = xd.Descendants()
                         .Where(x => x.Name.LocalName.IndexOf("Attachment", comparison) != -1);

                elements.Remove();

                byte[] ba = Encoding.UTF8.GetBytes(xd.ToString());

                DateTime dt = DateTime.Now;
                //string s = UploadMultipart(ba, txtDocument.Text, "multipart-formdata", "http://peppolclient.xledger.net:8080/validator-web-2.0.2/");
                //TimeSpan ts = DateTime.Now - dt;
                //txtResult.Text += string.Format("{0}:{1} \r\n", ts.TotalMilliseconds, s);
            }
        }
    }
}

