namespace QuestMaker.GUI
{
    partial class PrintResultForm
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
            Telerik.WinControls.UI.RadPrintWatermark radPrintWatermark4 = new Telerik.WinControls.UI.RadPrintWatermark();
            this.ddlPersonChoose = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlSexChoose = new Telerik.WinControls.UI.RadDropDownList();
            this.bSaveAsPdfDocument = new Telerik.WinControls.UI.RadButton();
            this.bCancel = new Telerik.WinControls.UI.RadButton();
            this.bSaveAsDocument = new Telerik.WinControls.UI.RadButton();
            this.printDocument = new Telerik.WinControls.UI.RadPrintDocument();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPersonChoose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSexChoose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSaveAsPdfDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSaveAsDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlPersonChoose
            // 
            this.ddlPersonChoose.DefaultItemsCountInDropDown = 12;
            this.ddlPersonChoose.Location = new System.Drawing.Point(54, 70);
            this.ddlPersonChoose.Name = "ddlPersonChoose";
            this.ddlPersonChoose.NullText = "<Выберите персонажа>";
            this.ddlPersonChoose.Size = new System.Drawing.Size(185, 20);
            this.ddlPersonChoose.TabIndex = 0;
            this.ddlPersonChoose.SelectedValueChanged += new System.EventHandler(this.ddlPersonChoose_SelectedValueChanged);
            // 
            // ddlSexChoose
            // 
            this.ddlSexChoose.Location = new System.Drawing.Point(313, 70);
            this.ddlSexChoose.Name = "ddlSexChoose";
            this.ddlSexChoose.NullText = "<Выберите пол>";
            this.ddlSexChoose.Size = new System.Drawing.Size(125, 20);
            this.ddlSexChoose.TabIndex = 1;
            // 
            // bSaveAsPdfDocument
            // 
            this.bSaveAsPdfDocument.Location = new System.Drawing.Point(189, 463);
            this.bSaveAsPdfDocument.Name = "bSaveAsPdfDocument";
            this.bSaveAsPdfDocument.Size = new System.Drawing.Size(110, 24);
            this.bSaveAsPdfDocument.TabIndex = 2;
            this.bSaveAsPdfDocument.Text = "Сохранить в pdf";
            this.bSaveAsPdfDocument.Click += new System.EventHandler(this.bSaveAsPdfDocument_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(328, 463);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(110, 24);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Выйти";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSaveAsDocument
            // 
            this.bSaveAsDocument.Location = new System.Drawing.Point(44, 463);
            this.bSaveAsDocument.Name = "bSaveAsDocument";
            this.bSaveAsDocument.Size = new System.Drawing.Size(110, 24);
            this.bSaveAsDocument.TabIndex = 4;
            this.bSaveAsDocument.Text = "Сохранить в  docx";
            this.bSaveAsDocument.Click += new System.EventHandler(this.bSaveAsDocument_Click);
            // 
            // printDocument
            // 
            this.printDocument.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printDocument.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printDocument.Watermark = radPrintWatermark4;
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "docx";
            this.saveDialog.Filter = "Documents|*.docx|PDF file|*.pdf";
            // 
            // PrintResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 527);
            this.Controls.Add(this.bSaveAsDocument);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSaveAsPdfDocument);
            this.Controls.Add(this.ddlSexChoose);
            this.Controls.Add(this.ddlPersonChoose);
            this.Name = "PrintResultForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Печать результата";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.ddlPersonChoose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSexChoose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSaveAsPdfDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSaveAsDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlPersonChoose;
        private Telerik.WinControls.UI.RadDropDownList ddlSexChoose;
        private Telerik.WinControls.UI.RadButton bSaveAsPdfDocument;
        private Telerik.WinControls.UI.RadButton bCancel;
        private Telerik.WinControls.UI.RadButton bSaveAsDocument;
        private Telerik.WinControls.UI.RadPrintDocument printDocument;
        private System.Windows.Forms.SaveFileDialog saveDialog;
    }
}
