namespace QuestMaker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor4 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor3 = new Telerik.WinControls.Data.SortDescriptor();
            this.mainPageView = new Telerik.WinControls.UI.RadPageView();
            this.pagePersons = new Telerik.WinControls.UI.RadPageViewPage();
            this.pageItems = new Telerik.WinControls.UI.RadPageViewPage();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.bSaveitems = new Telerik.WinControls.UI.RadButton();
            this.gridViewItems = new Telerik.WinControls.UI.RadGridView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.bSaveAims = new Telerik.WinControls.UI.RadButton();
            this.gridViewAims = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).BeginInit();
            this.mainPageView.SuspendLayout();
            this.pageItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSaveitems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems.MasterTemplate)).BeginInit();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bSaveAims)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAims)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAims.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPageView
            // 
            this.mainPageView.Controls.Add(this.pagePersons);
            this.mainPageView.Controls.Add(this.pageItems);
            this.mainPageView.Controls.Add(this.radPageViewPage1);
            this.mainPageView.Location = new System.Drawing.Point(27, 34);
            this.mainPageView.Name = "mainPageView";
            this.mainPageView.SelectedPage = this.radPageViewPage1;
            this.mainPageView.Size = new System.Drawing.Size(664, 477);
            this.mainPageView.TabIndex = 10;
            // 
            // pagePersons
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.pagePersons.Location = new System.Drawing.Point(10, 37);
            this.pagePersons.Name = "pagePersons";
            this.pagePersons.Size = new System.Drawing.Size(643, 429);
            this.pagePersons.Text = "Люди";
            // 
            // pageItems
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.pageItems.Controls.Add(this.radButton2);
            this.pageItems.Controls.Add(this.bSaveitems);
            this.pageItems.Controls.Add(this.gridViewItems);
            this.pageItems.Location = new System.Drawing.Point(10, 37);
            this.pageItems.Name = "pageItems";
            this.pageItems.Size = new System.Drawing.Size(643, 429);
            this.pageItems.Text = "Предметы";
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(520, 27);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 24);
            this.radButton2.TabIndex = 2;
            this.radButton2.Text = "test";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // bSaveitems
            // 
            this.bSaveitems.Location = new System.Drawing.Point(375, 27);
            this.bSaveitems.Name = "bSaveitems";
            this.bSaveitems.Size = new System.Drawing.Size(110, 24);
            this.bSaveitems.TabIndex = 1;
            this.bSaveitems.Text = "Сохранить";
            this.bSaveitems.Click += new System.EventHandler(this.bSaveitems_Click);
            // 
            // gridViewItems
            // 
            this.gridViewItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.gridViewItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridViewItems.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gridViewItems.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridViewItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridViewItems.Location = new System.Drawing.Point(17, 72);
            // 
            // gridViewItems
            // 
            this.gridViewItems.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.HeaderText = "Имя";
            gridViewTextBoxColumn8.Name = "columnName";
            gridViewTextBoxColumn8.Width = 87;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.HeaderText = "Описание";
            gridViewTextBoxColumn9.Name = "columnDescription";
            gridViewTextBoxColumn9.Width = 173;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.HeaderText = "Комментарий";
            gridViewTextBoxColumn10.Name = "columnComment";
            gridViewTextBoxColumn10.Width = 128;
            this.gridViewItems.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            sortDescriptor4.PropertyName = "column1";
            this.gridViewItems.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor4});
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridViewItems.Size = new System.Drawing.Size(579, 318);
            this.gridViewItems.TabIndex = 0;
            // 
            // radPageViewPage1
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.radPageViewPage1.Controls.Add(this.gridViewAims);
            this.radPageViewPage1.Controls.Add(this.bSaveAims);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(643, 429);
            this.radPageViewPage1.Text = "Цели";
            // 
            // bSaveAims
            // 
            this.bSaveAims.Location = new System.Drawing.Point(488, 32);
            this.bSaveAims.Name = "bSaveAims";
            this.bSaveAims.Size = new System.Drawing.Size(110, 24);
            this.bSaveAims.TabIndex = 0;
            this.bSaveAims.Text = "Сохранить";
            this.bSaveAims.Click += new System.EventHandler(this.bSaveAims_Click);
            // 
            // gridViewAims
            // 
            this.gridViewAims.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.gridViewAims.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridViewAims.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gridViewAims.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridViewAims.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridViewAims.Location = new System.Drawing.Point(36, 75);
            // 
            // gridViewAims
            // 
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "Название";
            gridViewTextBoxColumn6.Name = "columnName";
            gridViewTextBoxColumn6.Width = 147;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "Описание";
            gridViewTextBoxColumn7.Name = "columnDescription";
            gridViewTextBoxColumn7.Width = 181;
            gridViewComboBoxColumn2.EnableExpressionEditor = false;
            gridViewComboBoxColumn2.HeaderText = "Тип";
            gridViewComboBoxColumn2.Name = "columnType";
            gridViewComboBoxColumn2.Width = 131;
            this.gridViewAims.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewComboBoxColumn2});
            sortDescriptor3.PropertyName = "column1";
            this.gridViewAims.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor3});
            this.gridViewAims.Name = "gridViewAims";
            this.gridViewAims.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridViewAims.Size = new System.Drawing.Size(562, 315);
            this.gridViewAims.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 533);
            this.Controls.Add(this.mainPageView);
            this.Name = "MainForm";
            this.Text = "Редактор квестов";
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).EndInit();
            this.mainPageView.ResumeLayout(false);
            this.pageItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSaveitems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bSaveAims)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAims.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAims)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView mainPageView;
        private Telerik.WinControls.UI.RadPageViewPage pagePersons;
        private Telerik.WinControls.UI.RadPageViewPage pageItems;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton bSaveitems;
        private Telerik.WinControls.UI.RadGridView gridViewItems;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadGridView gridViewAims;
        private Telerik.WinControls.UI.RadButton bSaveAims;

    }
}

