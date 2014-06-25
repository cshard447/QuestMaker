namespace QuestMaker.GUI
{
    partial class EditAimForm
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
            this.bOK = new Telerik.WinControls.UI.RadButton();
            this.bCancel = new Telerik.WinControls.UI.RadButton();
            this.ddlAimType = new Telerik.WinControls.UI.RadDropDownList();
            this.tbAimName = new Telerik.WinControls.UI.RadTextBox();
            this.tbcAimDescription = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.lvPersons = new Telerik.WinControls.UI.RadListView();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAimType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAimName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcAimDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(33, 27);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(58, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Название:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(33, 77);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(60, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Описание:";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(33, 53);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(28, 18);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Тип:";
            // 
            // bOK
            // 
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOK.Location = new System.Drawing.Point(72, 368);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(110, 24);
            this.bOK.TabIndex = 3;
            this.bOK.Text = "ОК";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(216, 368);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(110, 24);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Отмена";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // ddlAimType
            // 
            this.ddlAimType.Location = new System.Drawing.Point(120, 51);
            this.ddlAimType.Name = "ddlAimType";
            this.ddlAimType.Size = new System.Drawing.Size(254, 20);
            this.ddlAimType.TabIndex = 5;
            // 
            // tbAimName
            // 
            this.tbAimName.Location = new System.Drawing.Point(120, 25);
            this.tbAimName.Name = "tbAimName";
            this.tbAimName.Size = new System.Drawing.Size(254, 20);
            this.tbAimName.TabIndex = 6;
            this.tbAimName.TabStop = false;
            // 
            // tbcAimDescription
            // 
            this.tbcAimDescription.Location = new System.Drawing.Point(120, 77);
            this.tbcAimDescription.Multiline = true;
            this.tbcAimDescription.Name = "tbcAimDescription";
            this.tbcAimDescription.Size = new System.Drawing.Size(254, 104);
            this.tbcAimDescription.TabIndex = 7;
            // 
            // radLabel4
            // 
            this.radLabel4.AutoSize = false;
            this.radLabel4.Location = new System.Drawing.Point(33, 187);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(88, 54);
            this.radLabel4.TabIndex = 8;
            this.radLabel4.Text = "Персонажи, преследующие эту цель:";
            // 
            // lvPersons
            // 
            this.lvPersons.Location = new System.Drawing.Point(120, 187);
            this.lvPersons.Name = "lvPersons";
            this.lvPersons.ShowCheckBoxes = true;
            this.lvPersons.Size = new System.Drawing.Size(254, 155);
            this.lvPersons.TabIndex = 9;
            // 
            // EditAimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 404);
            this.Controls.Add(this.lvPersons);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.tbcAimDescription);
            this.Controls.Add(this.tbAimName);
            this.Controls.Add(this.ddlAimType);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "EditAimForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Редактирование цели";
            this.ThemeName = "ControlDefault";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditAimForm_FormClosed);
            this.Load += new System.EventHandler(this.EditAimForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAimType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAimName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcAimDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton bOK;
        private Telerik.WinControls.UI.RadButton bCancel;
        private Telerik.WinControls.UI.RadDropDownList ddlAimType;
        private Telerik.WinControls.UI.RadTextBox tbAimName;
        private Telerik.WinControls.UI.RadTextBoxControl tbcAimDescription;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadListView lvPersons;
    }
}
