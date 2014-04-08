namespace QuestMaker.GUI
{
    partial class EditItemForm
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.cbVisibility = new Telerik.WinControls.UI.RadCheckBox();
            this.cbSingleUse = new Telerik.WinControls.UI.RadCheckBox();
            this.tbName = new Telerik.WinControls.UI.RadTextBox();
            this.tbcDescription = new Telerik.WinControls.UI.RadTextBoxControl();
            this.tbComment = new Telerik.WinControls.UI.RadTextBox();
            this.bOK = new Telerik.WinControls.UI.RadButton();
            this.bCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVisibility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSingleUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(39, 41);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(31, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Имя:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(39, 72);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(60, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Описание:";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(39, 137);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(80, 18);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Комментарий:";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(39, 171);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(127, 18);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Видимый при осмотре:";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(39, 211);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(166, 18);
            this.radLabel5.TabIndex = 1;
            this.radLabel5.Text = "Однокуратное использование:";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(39, 252);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 18);
            this.radLabel6.TabIndex = 1;
            this.radLabel6.Text = "Картинка:";
            // 
            // cbVisibility
            // 
            this.cbVisibility.Location = new System.Drawing.Point(183, 171);
            this.cbVisibility.Name = "cbVisibility";
            this.cbVisibility.Size = new System.Drawing.Size(69, 18);
            this.cbVisibility.TabIndex = 4;
            this.cbVisibility.Text = "Видимый";
            // 
            // cbSingleUse
            // 
            this.cbSingleUse.Location = new System.Drawing.Point(220, 211);
            this.cbSingleUse.Name = "cbSingleUse";
            this.cbSingleUse.Size = new System.Drawing.Size(92, 18);
            this.cbSingleUse.TabIndex = 5;
            this.cbSingleUse.Text = "Однократный";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(152, 41);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(141, 20);
            this.tbName.TabIndex = 6;
            this.tbName.TabStop = false;
            // 
            // tbcDescription
            // 
            this.tbcDescription.Location = new System.Drawing.Point(152, 68);
            this.tbcDescription.Multiline = true;
            this.tbcDescription.Name = "tbcDescription";
            this.tbcDescription.Size = new System.Drawing.Size(386, 57);
            this.tbcDescription.TabIndex = 7;
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(152, 135);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(386, 20);
            this.tbComment.TabIndex = 8;
            this.tbComment.TabStop = false;
            // 
            // bOK
            // 
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOK.Location = new System.Drawing.Point(281, 406);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(110, 24);
            this.bOK.TabIndex = 9;
            this.bOK.Text = "ОК";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(428, 406);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(110, 24);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "Отмена";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // EditItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 477);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.tbcDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.cbSingleUse);
            this.Controls.Add(this.cbVisibility);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "EditItemForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "EditItemForm";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVisibility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSingleUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadCheckBox cbVisibility;
        private Telerik.WinControls.UI.RadCheckBox cbSingleUse;
        private Telerik.WinControls.UI.RadTextBox tbName;
        private Telerik.WinControls.UI.RadTextBoxControl tbcDescription;
        private Telerik.WinControls.UI.RadTextBox tbComment;
        private Telerik.WinControls.UI.RadButton bOK;
        private Telerik.WinControls.UI.RadButton bCancel;
    }
}
