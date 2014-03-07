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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            this.mainPageView = new Telerik.WinControls.UI.RadPageView();
            this.pagePersons = new Telerik.WinControls.UI.RadPageViewPage();
            this.pageItems = new Telerik.WinControls.UI.RadPageViewPage();
            this.pGridViewItems = new Telerik.WinControls.UI.RadPanel();
            this.gridViewItems = new Telerik.WinControls.UI.RadGridView();
            this.pControlsItems = new Telerik.WinControls.UI.RadPanel();
            this.buttonTest = new Telerik.WinControls.UI.RadButton();
            this.bSaveItems = new Telerik.WinControls.UI.RadButton();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.pControlsAims = new Telerik.WinControls.UI.RadPanel();
            this.bSaveAims = new Telerik.WinControls.UI.RadButton();
            this.gridViewAims = new Telerik.WinControls.UI.RadGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).BeginInit();
            this.mainPageView.SuspendLayout();
            this.pageItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pGridViewItems)).BeginInit();
            this.pGridViewItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pControlsItems)).BeginInit();
            this.pControlsItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSaveItems)).BeginInit();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pControlsAims)).BeginInit();
            this.pControlsAims.SuspendLayout();
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
            this.mainPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPageView.Location = new System.Drawing.Point(0, 0);
            this.mainPageView.Name = "mainPageView";
            this.mainPageView.SelectedPage = this.radPageViewPage1;
            this.mainPageView.Size = new System.Drawing.Size(874, 511);
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
            this.pageItems.Controls.Add(this.pGridViewItems);
            this.pageItems.Controls.Add(this.pControlsItems);
            this.pageItems.Location = new System.Drawing.Point(10, 37);
            this.pageItems.Name = "pageItems";
            this.pageItems.Size = new System.Drawing.Size(853, 463);
            this.pageItems.Text = "Предметы";
            // 
            // pGridViewItems
            // 
            this.pGridViewItems.Controls.Add(this.gridViewItems);
            this.pGridViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGridViewItems.Location = new System.Drawing.Point(0, 54);
            this.pGridViewItems.Name = "pGridViewItems";
            this.pGridViewItems.Size = new System.Drawing.Size(853, 409);
            this.pGridViewItems.TabIndex = 4;
            // 
            // gridViewItems
            // 
            this.gridViewItems.AutoSize = true;
            this.gridViewItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.gridViewItems.CausesValidation = false;
            this.gridViewItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewItems.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gridViewItems.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridViewItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridViewItems.Location = new System.Drawing.Point(0, 0);
            // 
            // gridViewItems
            // 
            this.gridViewItems.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.Name = "columnID";
            gridViewTextBoxColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Имя";
            gridViewTextBoxColumn2.Name = "columnName";
            gridViewTextBoxColumn2.Width = 68;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "Описание";
            gridViewTextBoxColumn3.Name = "columnDescription";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "Комментарий";
            gridViewTextBoxColumn4.Name = "columnComment";
            gridViewTextBoxColumn4.Width = 128;
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.HeaderText = "Картинка";
            gridViewImageColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewImageColumn1.Name = "columnImage";
            gridViewImageColumn1.Width = 128;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "Путь";
            gridViewTextBoxColumn5.Name = "columnPath";
            gridViewTextBoxColumn5.Width = 115;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.HeaderText = "Видимый";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "columnVisibility";
            gridViewCheckBoxColumn1.Width = 87;
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.HeaderText = "Однократный";
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "columnSingleUse";
            gridViewCheckBoxColumn2.Width = 93;
            this.gridViewItems.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewImageColumn1,
            gridViewTextBoxColumn5,
            gridViewCheckBoxColumn1,
            gridViewCheckBoxColumn2});
            sortDescriptor1.PropertyName = "columnID";
            this.gridViewItems.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridViewItems.Size = new System.Drawing.Size(833, 78);
            this.gridViewItems.TabIndex = 1;
            this.gridViewItems.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.gridViewItems_CellFormatting);
            this.gridViewItems.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridViewItems_CellDoubleClick);
            // 
            // pControlsItems
            // 
            this.pControlsItems.Controls.Add(this.buttonTest);
            this.pControlsItems.Controls.Add(this.bSaveItems);
            this.pControlsItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.pControlsItems.Location = new System.Drawing.Point(0, 0);
            this.pControlsItems.Name = "pControlsItems";
            this.pControlsItems.Size = new System.Drawing.Size(853, 54);
            this.pControlsItems.TabIndex = 3;
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(313, 15);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(110, 24);
            this.buttonTest.TabIndex = 3;
            this.buttonTest.Text = "test";
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // bSaveItems
            // 
            this.bSaveItems.Location = new System.Drawing.Point(84, 15);
            this.bSaveItems.Name = "bSaveItems";
            this.bSaveItems.Size = new System.Drawing.Size(110, 24);
            this.bSaveItems.TabIndex = 2;
            this.bSaveItems.Text = "Сохранить";
            this.bSaveItems.Click += new System.EventHandler(this.bSaveitems_Click);
            // 
            // radPageViewPage1
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.radPageViewPage1.Controls.Add(this.gridViewAims);
            this.radPageViewPage1.Controls.Add(this.pControlsAims);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(853, 463);
            this.radPageViewPage1.Text = "Цели";
            // 
            // pControlsAims
            // 
            this.pControlsAims.Controls.Add(this.bSaveAims);
            this.pControlsAims.Dock = System.Windows.Forms.DockStyle.Top;
            this.pControlsAims.Location = new System.Drawing.Point(0, 0);
            this.pControlsAims.Name = "pControlsAims";
            this.pControlsAims.Size = new System.Drawing.Size(853, 56);
            this.pControlsAims.TabIndex = 2;
            // 
            // bSaveAims
            // 
            this.bSaveAims.Location = new System.Drawing.Point(388, 14);
            this.bSaveAims.Name = "bSaveAims";
            this.bSaveAims.Size = new System.Drawing.Size(110, 24);
            this.bSaveAims.TabIndex = 1;
            this.bSaveAims.Text = "Сохранить";
            this.bSaveAims.Click += new System.EventHandler(this.bSaveAims_Click);
            // 
            // gridViewAims
            // 
            this.gridViewAims.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.gridViewAims.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridViewAims.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewAims.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gridViewAims.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridViewAims.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridViewAims.Location = new System.Drawing.Point(0, 56);
            // 
            // gridViewAims
            // 
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "ID";
            gridViewTextBoxColumn6.Name = "columnID";
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "Название";
            gridViewTextBoxColumn7.Name = "columnName";
            gridViewTextBoxColumn7.Width = 147;
            gridViewTextBoxColumn8.AcceptsReturn = true;
            gridViewTextBoxColumn8.AcceptsTab = true;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.HeaderText = "Описание";
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "columnDescription";
            gridViewTextBoxColumn8.Width = 181;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            gridViewComboBoxColumn1.HeaderText = "Тип";
            gridViewComboBoxColumn1.Name = "columnType";
            gridViewComboBoxColumn1.Width = 131;
            this.gridViewAims.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewComboBoxColumn1});
            sortDescriptor2.PropertyName = "column1";
            this.gridViewAims.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
            this.gridViewAims.Name = "gridViewAims";
            this.gridViewAims.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridViewAims.Size = new System.Drawing.Size(853, 407);
            this.gridViewAims.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 511);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(874, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // openImageFileDialog
            // 
            this.openImageFileDialog.DefaultExt = "bmp";
            this.openImageFileDialog.FileName = "openFileDialog1";
            this.openImageFileDialog.Filter = "Все файлы|*.*";
            this.openImageFileDialog.InitialDirectory = "d:\\src_2.0\\Launcher2_0\\res\\Launcher\\";
            this.openImageFileDialog.Tag = "Картинки|*.jpg|Картинки|*.png|Все файлы|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 533);
            this.Controls.Add(this.mainPageView);
            this.Controls.Add(this.statusStrip);
            this.Name = "MainForm";
            this.Text = "Редактор квестов";
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).EndInit();
            this.mainPageView.ResumeLayout(false);
            this.pageItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pGridViewItems)).EndInit();
            this.pGridViewItems.ResumeLayout(false);
            this.pGridViewItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pControlsItems)).EndInit();
            this.pControlsItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSaveItems)).EndInit();
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pControlsAims)).EndInit();
            this.pControlsAims.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bSaveAims)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAims.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAims)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView mainPageView;
        private Telerik.WinControls.UI.RadPageViewPage pagePersons;
        private Telerik.WinControls.UI.RadPageViewPage pageItems;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadGridView gridViewAims;
        private Telerik.WinControls.UI.RadPanel pControlsItems;
        private Telerik.WinControls.UI.RadButton buttonTest;
        private Telerik.WinControls.UI.RadButton bSaveItems;
        private Telerik.WinControls.UI.RadPanel pControlsAims;
        private Telerik.WinControls.UI.RadButton bSaveAims;
        private Telerik.WinControls.UI.RadPanel pGridViewItems;
        private Telerik.WinControls.UI.RadGridView gridViewItems;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.OpenFileDialog openImageFileDialog;

    }
}

