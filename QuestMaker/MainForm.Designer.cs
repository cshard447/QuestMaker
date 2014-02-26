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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn3 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor5 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn3 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor6 = new Telerik.WinControls.Data.SortDescriptor();
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
            this.mainPageView.SelectedPage = this.pageItems;
            this.mainPageView.Size = new System.Drawing.Size(722, 511);
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
            this.pageItems.Size = new System.Drawing.Size(701, 463);
            this.pageItems.Text = "Предметы";
            // 
            // pGridViewItems
            // 
            this.pGridViewItems.Controls.Add(this.gridViewItems);
            this.pGridViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGridViewItems.Location = new System.Drawing.Point(0, 54);
            this.pGridViewItems.Name = "pGridViewItems";
            this.pGridViewItems.Size = new System.Drawing.Size(701, 409);
            this.pGridViewItems.TabIndex = 4;
            // 
            // gridViewItems
            // 
            this.gridViewItems.AutoSize = true;
            this.gridViewItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
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
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.HeaderText = "ID";
            gridViewTextBoxColumn13.Name = "columnID";
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.HeaderText = "Имя";
            gridViewTextBoxColumn14.Name = "columnName";
            gridViewTextBoxColumn14.Width = 68;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.HeaderText = "Описание";
            gridViewTextBoxColumn15.Name = "columnDescription";
            gridViewTextBoxColumn15.Width = 173;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.HeaderText = "Комментарий";
            gridViewTextBoxColumn16.Name = "columnComment";
            gridViewTextBoxColumn16.Width = 128;
            gridViewImageColumn3.EnableExpressionEditor = false;
            gridViewImageColumn3.HeaderText = "Картинка";
            gridViewImageColumn3.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewImageColumn3.Name = "columnImage";
            gridViewImageColumn3.Width = 128;
            this.gridViewItems.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewImageColumn3});
            sortDescriptor5.Direction = System.ComponentModel.ListSortDirection.Descending;
            sortDescriptor5.PropertyName = "column1";
            this.gridViewItems.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor5});
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridViewItems.Size = new System.Drawing.Size(564, 78);
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
            this.pControlsItems.Size = new System.Drawing.Size(701, 54);
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
            this.radPageViewPage1.Controls.Add(this.pControlsAims);
            this.radPageViewPage1.Controls.Add(this.gridViewAims);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(701, 463);
            this.radPageViewPage1.Text = "Цели";
            // 
            // pControlsAims
            // 
            this.pControlsAims.Controls.Add(this.bSaveAims);
            this.pControlsAims.Dock = System.Windows.Forms.DockStyle.Top;
            this.pControlsAims.Location = new System.Drawing.Point(0, 0);
            this.pControlsAims.Name = "pControlsAims";
            this.pControlsAims.Size = new System.Drawing.Size(701, 56);
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
            this.gridViewAims.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gridViewAims.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridViewAims.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridViewAims.Location = new System.Drawing.Point(36, 75);
            // 
            // gridViewAims
            // 
            gridViewTextBoxColumn17.EnableExpressionEditor = false;
            gridViewTextBoxColumn17.HeaderText = "Название";
            gridViewTextBoxColumn17.Name = "columnName";
            gridViewTextBoxColumn17.Width = 147;
            gridViewTextBoxColumn18.AcceptsReturn = true;
            gridViewTextBoxColumn18.AcceptsTab = true;
            gridViewTextBoxColumn18.EnableExpressionEditor = false;
            gridViewTextBoxColumn18.HeaderText = "Описание";
            gridViewTextBoxColumn18.Multiline = true;
            gridViewTextBoxColumn18.Name = "columnDescription";
            gridViewTextBoxColumn18.Width = 181;
            gridViewTextBoxColumn18.WrapText = true;
            gridViewComboBoxColumn3.EnableExpressionEditor = false;
            gridViewComboBoxColumn3.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            gridViewComboBoxColumn3.HeaderText = "Тип";
            gridViewComboBoxColumn3.Name = "columnType";
            gridViewComboBoxColumn3.Width = 131;
            this.gridViewAims.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewComboBoxColumn3});
            sortDescriptor6.PropertyName = "column1";
            this.gridViewAims.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor6});
            this.gridViewAims.Name = "gridViewAims";
            this.gridViewAims.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridViewAims.Size = new System.Drawing.Size(562, 315);
            this.gridViewAims.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 511);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(722, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // openImageFileDialog
            // 
            this.openImageFileDialog.DefaultExt = "bmp";
            this.openImageFileDialog.FileName = "openFileDialog1";
            this.openImageFileDialog.Filter = "Картинки|*.jpg|Картинки|*.png|Все файлы|*.*";
            this.openImageFileDialog.InitialDirectory = "d:\\src_2.0\\Launcher2_0\\res\\Launcher\\";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 533);
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

