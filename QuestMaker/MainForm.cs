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

            GridViewTextBoxColumn column3 = (GridViewTextBoxColumn)gridViewItems.Columns["columnID"];
            column3.DataSourceNullValue = -1;

            GridViewTextBoxColumn column4 = (GridViewTextBoxColumn)gridViewAims.Columns["columnID"];
            column4.DataSourceNullValue = -1;
        }

        private void bSaveitems_Click(object sender, EventArgs e)
        {
            itemManager.UpdateItemsFromGrid(gridViewItems);
            itemManager.saveItemsToFile();
            ShowItemsOnGridView();
            // DataSourceNullValue
        }

        private void bSaveAims_Click(object sender, EventArgs e)
        {
            aimManager.UpdateAimsFromGrid(gridViewAims);
            aimManager.saveAimsToFile();
            ShowAimsOnGridView();
        }

        private void ShowItemsOnGridView()
        {
            gridViewItems.Rows.Clear();
            Dictionary<int, CItem> _items = itemManager.getAllItems();
            object[] values = new object[8];
            foreach (CItem item in _items.Values)
            {
                values[0] = item.getID();
                values[1] = item.getName();
                values[2] = item.description;
                values[3] = item.comment;
                values[4] = item.image;
                values[5] = item.pathToImage;
                values[6] = item.visibility;
                values[7] = item.singleUse;
                gridViewItems.Rows.Add(values);
            }
            gridViewItems.Update();
        }

        private void ShowAimsOnGridView()
        {
            gridViewAims.Rows.Clear();
            Dictionary<int, CAim> _aims = aimManager.getAllAims();
            object[] values = new object[4];
            foreach (CAim aim in _aims.Values)
            {
                values[0] = aim.getID();
                values[1] = aim.getName();
                values[2] = aim.description;
                values[3] = aim.type;
                gridViewAims.Rows.Add(values);
            }
            gridViewAims.Update();
        }


        private void gridViewItems_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            /*
             // это когда-то работало ок, только группировка глючила 
            if (e.CellElement.ColumnInfo.Name == "columnImage")
            {
                if (e.CellElement.RowInfo.Cells["columnPath"].Value != null)
                {
                    int id = int.Parse(e.CellElement.RowInfo.Cells["columnID"].Value.ToString());
                    e.CellElement.Image = itemManager.getItem(id).image;
                }
            }
            */
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
                    if (!File.Exists(destination))
                        File.Copy(path, destination,true);
                    int id = int.Parse(gridViewItems.Rows[e.RowIndex].Cells["columnID"].Value.ToString());
                    Image img = Image.FromFile(destination);
                    itemManager.updateItem(id, destination);
                    itemManager.updateItem(id, img);
                    ShowItemsOnGridView();
                }
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            //itemManager.TestXML();
            //gridViewAims.Columns[2].data
        }



    }
}
