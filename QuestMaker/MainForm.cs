using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.IO;
using QuestMaker.Classes;

namespace QuestMaker
{
    public partial class MainForm : Form
    {
        CItemManager itemManager = new CItemManager();
        CAimManager aimManager = new CAimManager();

        public MainForm()
        {
            InitializeComponent();
            //GridViewDataColumn col = gridViewItems.Columns.GetColumnByFieldName("columnVisibility").First();
            //col.DataTypeConverter = new TypeConverter();
            FillTableColumns();
            itemManager.loadItemsFromFile();
            ShowItemsOnGridView();
            aimManager.loadAimsFromFile();
            ShowAimsOnGridView();
        }

        void FillTableColumns()
        {
            GridViewComboBoxColumn column = (GridViewComboBoxColumn)gridViewAims.Columns["columnType"];
            column.ValueMember = "Type";
            column.DisplayMember = "DisplayString";
            column.FieldName = "Type";
            column.DataSource = aimManager.list;
            column.DataSourceNullValue = AimType.secondary;

            GridViewImageColumn column2= (GridViewImageColumn)gridViewItems.Columns["columnImage"];
            column2.DataSourceNullValue = "";
        }

        private void bSaveitems_Click(object sender, EventArgs e)
        {/*
            itemManager.removeAllItems();
            for (int row = 0; row < gridViewItems.RowCount; row++)
            {
                string name = Common.convertNullString(gridViewItems.Rows[row].Cells["columnName"].Value );
                string desc = Common.convertNullString(gridViewItems.Rows[row].Cells["columnDescription"].Value );
                string comm = Common.convertNullString(gridViewItems.Rows[row].Cells["columnComment"].Value );
                //string vis = gridViewItems.Rows[row].Cells["columnVisibility"].Value.ToString();
                itemManager.addItem(name, desc, comm, true );
            }*/
            itemManager.saveItemsToFile();
            // DataSourceNullValue
        }

        private void ShowItemsOnGridView()
        {
            gridViewItems.Rows.Clear();
            Dictionary<int, CItem> _items = itemManager.getAllItems();
            foreach (CItem item in _items.Values)
            {
                GridViewRowInfo row = new GridViewRowInfo(gridViewItems.MasterView);
                row.Cells["columnName"].Value = item.getName();
                row.Cells["columnDescription"].Value = item.description;
                row.Cells["columnComment"].Value = item.comment;
                row.Cells["columnID"].Value = item.getID();
                //row.Cells["columnVisibility"].Value = false;
                gridViewItems.Rows.Add(row);
            }
            gridViewItems.Update();
        }

        private void ShowAimsOnGridView()
        {
            gridViewAims.Rows.Clear();
            Dictionary<int, CAim> _aims = aimManager.getAllAims();
            foreach (CAim aim in _aims.Values)
            {
                GridViewRowInfo row = new GridViewRowInfo(gridViewAims.MasterView);
                row.Cells["columnName"].Value = aim.getName();
                row.Cells["columnDescription"].Value = aim.description;
                row.Cells["columnType"].Value = aim.type;
                gridViewAims.Rows.Add(row);
            }
            gridViewAims.Update();
        }

        private void bSaveAims_Click(object sender, EventArgs e)
        {
            aimManager.removeAllAims();
            for (int row = 0; row < gridViewAims.RowCount; row++)
            {
                string name = Common.convertNullString(gridViewAims.Rows[row].Cells["columnName"].Value);
                string desc = Common.convertNullString(gridViewAims.Rows[row].Cells["columnDescription"].Value);
                AimType type = (AimType) gridViewAims.Rows[row].Cells["columnType"].Value;
                aimManager.addAim(name, desc, type);
            }
            aimManager.saveAimsToFile();
        }

        private void gridViewItems_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (!gridViewItems.IsDisplayed)
                return;
            if (e.CellElement.ColumnInfo.Name == "columnImage")
            {
                int id = int.Parse(gridViewItems.Rows[e.RowIndex].Cells["columnID"].Value.ToString());
                CItem item = itemManager.getItem(id);
                if (item.pathToImage != "")
                    e.CellElement.Image = Image.FromFile(item.pathToImage);
                //e.CellElement.Image = Image.FromFile("d:\\src_2.0\\Launcher2_0\\res\\Launcher\\vk.png");
                
            }
        }

        private void gridViewItems_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "columnImage")
            {
                if (openImageFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //! @todo подумать над тем, если файл с таким именем привязан к другому объекту
                    string fileName = openImageFileDialog.SafeFileName;
                    string path = openImageFileDialog.FileName;
                    string destination = Common.path + fileName;
                    File.Copy(path, destination);
                    int id = int.Parse(gridViewItems.Rows[e.RowIndex].Cells["columnID"].Value.ToString());
                    Image img = Image.FromFile(destination);
                    itemManager.updateItem(id, destination);
                    itemManager.updateItem(id, img);
                }
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            //itemManager.TestXML();
            //gridViewAims.Columns[2].data

            //System.Drawing.Graphics g;
            //g = radPanel1.CreateGraphics();
            Bitmap bm = new Bitmap("d:\\src_2.0\\Launcher2_0\\res\\Launcher\\vk.png");
            //radPanel1.ImageList.Images.Add(bm);
            //radPanel1.ImageList.Draw(g, 0, 0, 0);
            Image image = Image.FromFile("d:\\src_2.0\\Launcher2_0\\res\\Launcher\\vk.png");
            //image.
            //image.
            //g.DrawImage(image, 0, 0);


            GridViewImageColumn column = (GridViewImageColumn)gridViewItems.Columns["columnImage"];
            column.ImageLayout = ImageLayout.Center;
            gridViewItems.Rows[0].Cells["columnImage"].Value = image;
            //gridViewItems.cell

            //DataGridViewImageCell imgCell = new DataGridViewImageCell();
            //imgCell.Value = Image.FromFile("d:\\src_2.0\\Launcher2_0\\res\\Launcher\\vk.png");

            //gridViewItems.Rows[0].Cells[3].Value = imgCell.Value;
        }

    }
}
