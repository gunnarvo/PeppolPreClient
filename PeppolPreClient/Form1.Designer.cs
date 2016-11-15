namespace PeppolPreClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSupplierCountryCode = new System.Windows.Forms.TextBox();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtCustomerCountryCode = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocument = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.rbCustomizationLevelCenBii = new System.Windows.Forms.RadioButton();
            this.rbCustomizationLevelPeppol = new System.Windows.Forms.RadioButton();
            this.rbCustomizationLevelEHF = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCustomizationLevelNotFound = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbUblVersionNotFound = new System.Windows.Forms.RadioButton();
            this.rbUblVersion21 = new System.Windows.Forms.RadioButton();
            this.rbUBLVersion20 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbDocumentTypeNotFound = new System.Windows.Forms.RadioButton();
            this.rbDocumentTypeCreditNote = new System.Windows.Forms.RadioButton();
            this.rbDocumentTypeInvoice = new System.Windows.Forms.RadioButton();
            this.btnUblGetDocumentType = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtSupplierCountryID = new System.Windows.Forms.TextBox();
            this.txtCustomerCountryID = new System.Windows.Forms.TextBox();
            this.btnSmlLookup = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbProfileInvoiceAndCreditNote = new System.Windows.Forms.RadioButton();
            this.rbProfileCreditNoteOnly = new System.Windows.Forms.RadioButton();
            this.rbProfileInvoiceOnly = new System.Windows.Forms.RadioButton();
            this.rbProfileNotFound = new System.Windows.Forms.RadioButton();
            this.txtRootNamespace = new System.Windows.Forms.TextBox();
            this.txtDocumentElementName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDocumentID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client for Accessing PeppolClient";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(156, 388);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSupplierCountryCode
            // 
            this.txtSupplierCountryCode.Location = new System.Drawing.Point(221, 78);
            this.txtSupplierCountryCode.Name = "txtSupplierCountryCode";
            this.txtSupplierCountryCode.Size = new System.Drawing.Size(47, 20);
            this.txtSupplierCountryCode.TabIndex = 2;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(274, 78);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.Size = new System.Drawing.Size(100, 20);
            this.txtSupplierID.TabIndex = 3;
            // 
            // txtCustomerCountryCode
            // 
            this.txtCustomerCountryCode.Location = new System.Drawing.Point(221, 104);
            this.txtCustomerCountryCode.Name = "txtCustomerCountryCode";
            this.txtCustomerCountryCode.Size = new System.Drawing.Size(47, 20);
            this.txtCustomerCountryCode.TabIndex = 4;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(274, 104);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerID.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Supplier (Sender for outbound)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Customer (Receiver for outbound)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Document";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtDocument
            // 
            this.txtDocument.Location = new System.Drawing.Point(156, 48);
            this.txtDocument.Name = "txtDocument";
            this.txtDocument.Size = new System.Drawing.Size(446, 20);
            this.txtDocument.TabIndex = 9;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(608, 46);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(29, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // rbCustomizationLevelCenBii
            // 
            this.rbCustomizationLevelCenBii.AutoSize = true;
            this.rbCustomizationLevelCenBii.Location = new System.Drawing.Point(6, 42);
            this.rbCustomizationLevelCenBii.Name = "rbCustomizationLevelCenBii";
            this.rbCustomizationLevelCenBii.Size = new System.Drawing.Size(58, 17);
            this.rbCustomizationLevelCenBii.TabIndex = 12;
            this.rbCustomizationLevelCenBii.TabStop = true;
            this.rbCustomizationLevelCenBii.Text = "Cen Bii";
            this.rbCustomizationLevelCenBii.UseVisualStyleBackColor = true;
            // 
            // rbCustomizationLevelPeppol
            // 
            this.rbCustomizationLevelPeppol.AutoSize = true;
            this.rbCustomizationLevelPeppol.Location = new System.Drawing.Point(6, 65);
            this.rbCustomizationLevelPeppol.Name = "rbCustomizationLevelPeppol";
            this.rbCustomizationLevelPeppol.Size = new System.Drawing.Size(58, 17);
            this.rbCustomizationLevelPeppol.TabIndex = 13;
            this.rbCustomizationLevelPeppol.TabStop = true;
            this.rbCustomizationLevelPeppol.Text = "Peppol";
            this.rbCustomizationLevelPeppol.UseVisualStyleBackColor = true;
            // 
            // rbCustomizationLevelEHF
            // 
            this.rbCustomizationLevelEHF.AutoSize = true;
            this.rbCustomizationLevelEHF.Location = new System.Drawing.Point(6, 88);
            this.rbCustomizationLevelEHF.Name = "rbCustomizationLevelEHF";
            this.rbCustomizationLevelEHF.Size = new System.Drawing.Size(46, 17);
            this.rbCustomizationLevelEHF.TabIndex = 14;
            this.rbCustomizationLevelEHF.TabStop = true;
            this.rbCustomizationLevelEHF.Text = "EHF";
            this.rbCustomizationLevelEHF.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCustomizationLevelNotFound);
            this.groupBox1.Controls.Add(this.rbCustomizationLevelEHF);
            this.groupBox1.Controls.Add(this.rbCustomizationLevelPeppol);
            this.groupBox1.Controls.Add(this.rbCustomizationLevelCenBii);
            this.groupBox1.Location = new System.Drawing.Point(459, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 117);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customization Level";
            // 
            // rbCustomizationLevelNotFound
            // 
            this.rbCustomizationLevelNotFound.AutoSize = true;
            this.rbCustomizationLevelNotFound.Location = new System.Drawing.Point(6, 19);
            this.rbCustomizationLevelNotFound.Name = "rbCustomizationLevelNotFound";
            this.rbCustomizationLevelNotFound.Size = new System.Drawing.Size(75, 17);
            this.rbCustomizationLevelNotFound.TabIndex = 15;
            this.rbCustomizationLevelNotFound.TabStop = true;
            this.rbCustomizationLevelNotFound.Text = "Not Found";
            this.rbCustomizationLevelNotFound.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbUblVersionNotFound);
            this.groupBox2.Controls.Add(this.rbUblVersion21);
            this.groupBox2.Controls.Add(this.rbUBLVersion20);
            this.groupBox2.Location = new System.Drawing.Point(153, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 117);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UBL version";
            // 
            // rbUblVersionNotFound
            // 
            this.rbUblVersionNotFound.AutoSize = true;
            this.rbUblVersionNotFound.Location = new System.Drawing.Point(6, 19);
            this.rbUblVersionNotFound.Name = "rbUblVersionNotFound";
            this.rbUblVersionNotFound.Size = new System.Drawing.Size(75, 17);
            this.rbUblVersionNotFound.TabIndex = 2;
            this.rbUblVersionNotFound.TabStop = true;
            this.rbUblVersionNotFound.Text = "Not Found";
            this.rbUblVersionNotFound.UseVisualStyleBackColor = true;
            // 
            // rbUblVersion21
            // 
            this.rbUblVersion21.AutoSize = true;
            this.rbUblVersion21.Location = new System.Drawing.Point(8, 65);
            this.rbUblVersion21.Name = "rbUblVersion21";
            this.rbUblVersion21.Size = new System.Drawing.Size(88, 17);
            this.rbUblVersion21.TabIndex = 1;
            this.rbUblVersion21.TabStop = true;
            this.rbUblVersion21.Text = "2.1 (EHF 2.0)";
            this.rbUblVersion21.UseVisualStyleBackColor = true;
            // 
            // rbUBLVersion20
            // 
            this.rbUBLVersion20.AutoSize = true;
            this.rbUBLVersion20.Location = new System.Drawing.Point(6, 42);
            this.rbUBLVersion20.Name = "rbUBLVersion20";
            this.rbUBLVersion20.Size = new System.Drawing.Size(88, 17);
            this.rbUBLVersion20.TabIndex = 0;
            this.rbUBLVersion20.TabStop = true;
            this.rbUBLVersion20.Text = "2.0 (EHF 1.6)";
            this.rbUBLVersion20.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbDocumentTypeNotFound);
            this.groupBox3.Controls.Add(this.rbDocumentTypeCreditNote);
            this.groupBox3.Controls.Add(this.rbDocumentTypeInvoice);
            this.groupBox3.Location = new System.Drawing.Point(40, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(107, 117);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Document Type";
            // 
            // rbDocumentTypeNotFound
            // 
            this.rbDocumentTypeNotFound.AutoSize = true;
            this.rbDocumentTypeNotFound.Location = new System.Drawing.Point(6, 19);
            this.rbDocumentTypeNotFound.Name = "rbDocumentTypeNotFound";
            this.rbDocumentTypeNotFound.Size = new System.Drawing.Size(75, 17);
            this.rbDocumentTypeNotFound.TabIndex = 2;
            this.rbDocumentTypeNotFound.TabStop = true;
            this.rbDocumentTypeNotFound.Text = "Not Found";
            this.rbDocumentTypeNotFound.UseVisualStyleBackColor = true;
            // 
            // rbDocumentTypeCreditNote
            // 
            this.rbDocumentTypeCreditNote.AutoSize = true;
            this.rbDocumentTypeCreditNote.Location = new System.Drawing.Point(6, 65);
            this.rbDocumentTypeCreditNote.Name = "rbDocumentTypeCreditNote";
            this.rbDocumentTypeCreditNote.Size = new System.Drawing.Size(78, 17);
            this.rbDocumentTypeCreditNote.TabIndex = 1;
            this.rbDocumentTypeCreditNote.TabStop = true;
            this.rbDocumentTypeCreditNote.Text = "Credit Note";
            this.rbDocumentTypeCreditNote.UseVisualStyleBackColor = true;
            // 
            // rbDocumentTypeInvoice
            // 
            this.rbDocumentTypeInvoice.AutoSize = true;
            this.rbDocumentTypeInvoice.Location = new System.Drawing.Point(6, 42);
            this.rbDocumentTypeInvoice.Name = "rbDocumentTypeInvoice";
            this.rbDocumentTypeInvoice.Size = new System.Drawing.Size(60, 17);
            this.rbDocumentTypeInvoice.TabIndex = 0;
            this.rbDocumentTypeInvoice.TabStop = true;
            this.rbDocumentTypeInvoice.Text = "Invoice";
            this.rbDocumentTypeInvoice.UseVisualStyleBackColor = true;
            this.rbDocumentTypeInvoice.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // btnUblGetDocumentType
            // 
            this.btnUblGetDocumentType.Location = new System.Drawing.Point(245, 389);
            this.btnUblGetDocumentType.Name = "btnUblGetDocumentType";
            this.btnUblGetDocumentType.Size = new System.Drawing.Size(139, 23);
            this.btnUblGetDocumentType.TabIndex = 18;
            this.btnUblGetDocumentType.Text = "Get UBL Document Type";
            this.btnUblGetDocumentType.UseVisualStyleBackColor = true;
            this.btnUblGetDocumentType.Click += new System.EventHandler(this.btnUblGetDocumentType_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResult.Location = new System.Drawing.Point(40, 418);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(597, 201);
            this.txtResult.TabIndex = 19;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(643, 48);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(240, 571);
            this.webBrowser1.TabIndex = 20;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // txtSupplierCountryID
            // 
            this.txtSupplierCountryID.Location = new System.Drawing.Point(187, 78);
            this.txtSupplierCountryID.Name = "txtSupplierCountryID";
            this.txtSupplierCountryID.Size = new System.Drawing.Size(28, 20);
            this.txtSupplierCountryID.TabIndex = 21;
            // 
            // txtCustomerCountryID
            // 
            this.txtCustomerCountryID.Location = new System.Drawing.Point(187, 104);
            this.txtCustomerCountryID.Name = "txtCustomerCountryID";
            this.txtCustomerCountryID.Size = new System.Drawing.Size(28, 20);
            this.txtCustomerCountryID.TabIndex = 22;
            // 
            // btnSmlLookup
            // 
            this.btnSmlLookup.Location = new System.Drawing.Point(41, 389);
            this.btnSmlLookup.Name = "btnSmlLookup";
            this.btnSmlLookup.Size = new System.Drawing.Size(109, 23);
            this.btnSmlLookup.TabIndex = 23;
            this.btnSmlLookup.Text = "SML Lookup";
            this.btnSmlLookup.UseVisualStyleBackColor = true;
            this.btnSmlLookup.Click += new System.EventHandler(this.btnSmlLookup_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(563, 389);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbProfileInvoiceAndCreditNote);
            this.groupBox4.Controls.Add(this.rbProfileCreditNoteOnly);
            this.groupBox4.Controls.Add(this.rbProfileInvoiceOnly);
            this.groupBox4.Controls.Add(this.rbProfileNotFound);
            this.groupBox4.Location = new System.Drawing.Point(285, 186);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(168, 117);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Profile";
            // 
            // rbProfileInvoiceAndCreditNote
            // 
            this.rbProfileInvoiceAndCreditNote.AutoSize = true;
            this.rbProfileInvoiceAndCreditNote.Location = new System.Drawing.Point(6, 88);
            this.rbProfileInvoiceAndCreditNote.Name = "rbProfileInvoiceAndCreditNote";
            this.rbProfileInvoiceAndCreditNote.Size = new System.Drawing.Size(154, 17);
            this.rbProfileInvoiceAndCreditNote.TabIndex = 3;
            this.rbProfileInvoiceAndCreditNote.TabStop = true;
            this.rbProfileInvoiceAndCreditNote.Text = "BII05, faktura og kreditnota";
            this.rbProfileInvoiceAndCreditNote.UseVisualStyleBackColor = true;
            // 
            // rbProfileCreditNoteOnly
            // 
            this.rbProfileCreditNoteOnly.AutoSize = true;
            this.rbProfileCreditNoteOnly.Location = new System.Drawing.Point(6, 65);
            this.rbProfileCreditNoteOnly.Name = "rbProfileCreditNoteOnly";
            this.rbProfileCreditNoteOnly.Size = new System.Drawing.Size(127, 17);
            this.rbProfileCreditNoteOnly.TabIndex = 2;
            this.rbProfileCreditNoteOnly.TabStop = true;
            this.rbProfileCreditNoteOnly.Text = "BIIXX, Kun kreditnota";
            this.rbProfileCreditNoteOnly.UseVisualStyleBackColor = true;
            // 
            // rbProfileInvoiceOnly
            // 
            this.rbProfileInvoiceOnly.AutoSize = true;
            this.rbProfileInvoiceOnly.Location = new System.Drawing.Point(6, 42);
            this.rbProfileInvoiceOnly.Name = "rbProfileInvoiceOnly";
            this.rbProfileInvoiceOnly.Size = new System.Drawing.Size(111, 17);
            this.rbProfileInvoiceOnly.TabIndex = 1;
            this.rbProfileInvoiceOnly.TabStop = true;
            this.rbProfileInvoiceOnly.Text = "BII04, Kun faktura";
            this.rbProfileInvoiceOnly.UseVisualStyleBackColor = true;
            // 
            // rbProfileNotFound
            // 
            this.rbProfileNotFound.AutoSize = true;
            this.rbProfileNotFound.Location = new System.Drawing.Point(6, 19);
            this.rbProfileNotFound.Name = "rbProfileNotFound";
            this.rbProfileNotFound.Size = new System.Drawing.Size(75, 17);
            this.rbProfileNotFound.TabIndex = 0;
            this.rbProfileNotFound.TabStop = true;
            this.rbProfileNotFound.Text = "Not Found";
            this.rbProfileNotFound.UseVisualStyleBackColor = true;
            // 
            // txtRootNamespace
            // 
            this.txtRootNamespace.Location = new System.Drawing.Point(187, 130);
            this.txtRootNamespace.Name = "txtRootNamespace";
            this.txtRootNamespace.Size = new System.Drawing.Size(446, 20);
            this.txtRootNamespace.TabIndex = 26;
            // 
            // txtDocumentElementName
            // 
            this.txtDocumentElementName.Location = new System.Drawing.Point(187, 156);
            this.txtDocumentElementName.Name = "txtDocumentElementName";
            this.txtDocumentElementName.Size = new System.Drawing.Size(100, 20);
            this.txtDocumentElementName.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Root Namespace";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Document Element Name";
            // 
            // txtDocumentID
            // 
            this.txtDocumentID.Location = new System.Drawing.Point(98, 309);
            this.txtDocumentID.Multiline = true;
            this.txtDocumentID.Name = "txtDocumentID";
            this.txtDocumentID.Size = new System.Drawing.Size(453, 74);
            this.txtDocumentID.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Document ID";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(557, 307);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 32;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Vefa Validate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 631);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDocumentID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDocumentElementName);
            this.Controls.Add(this.txtRootNamespace);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSmlLookup);
            this.Controls.Add(this.txtCustomerCountryID);
            this.Controls.Add(this.txtSupplierCountryID);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUblGetDocumentType);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDocument);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.txtCustomerCountryCode);
            this.Controls.Add(this.txtSupplierID);
            this.Controls.Add(this.txtSupplierCountryCode);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSupplierCountryCode;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.TextBox txtCustomerCountryCode;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDocument;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.RadioButton rbCustomizationLevelCenBii;
        private System.Windows.Forms.RadioButton rbCustomizationLevelPeppol;
        private System.Windows.Forms.RadioButton rbCustomizationLevelEHF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbUblVersion21;
        private System.Windows.Forms.RadioButton rbUBLVersion20;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbDocumentTypeCreditNote;
        private System.Windows.Forms.RadioButton rbDocumentTypeInvoice;
        private System.Windows.Forms.Button btnUblGetDocumentType;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.RadioButton rbCustomizationLevelNotFound;
        private System.Windows.Forms.RadioButton rbUblVersionNotFound;
        private System.Windows.Forms.RadioButton rbDocumentTypeNotFound;
        private System.Windows.Forms.TextBox txtSupplierCountryID;
        private System.Windows.Forms.TextBox txtCustomerCountryID;
        private System.Windows.Forms.Button btnSmlLookup;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbProfileInvoiceAndCreditNote;
        private System.Windows.Forms.RadioButton rbProfileCreditNoteOnly;
        private System.Windows.Forms.RadioButton rbProfileInvoiceOnly;
        private System.Windows.Forms.RadioButton rbProfileNotFound;
        private System.Windows.Forms.TextBox txtRootNamespace;
        private System.Windows.Forms.TextBox txtDocumentElementName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDocumentID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button button1;
    }
}

