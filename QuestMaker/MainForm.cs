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
            //! @todo переделывать на манер items
            aimManager.removeAllAims();
            for (int row = 0; row < gridViewAims.RowCount; row++)
            {
                string name = Common.convertNullString(gridViewAims.Rows[row].Cells["columnName"].Value);
                string desc = Common.convertNullString(gridViewAims.Rows[row].Cells["columnDescription"].Value);
                AimType type = (AimType)gridViewAims.Rows[row].Cells["columnType"].Value;
                aimManager.addAim(name, desc, type);
            }
            aimManager.saveAimsToFile();
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
                row.Cells["columnPath"].Value = item.pathToImage;                
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


        private void gridViewItems_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "columnImage")
            {
                if (e.CellElement.RowInfo.Cells["columnPath"].Value != null)
                {
                    int id = int.Parse(e.CellElement.RowInfo.Cells["columnID"].Value.ToString());
                    e.CellElement.Image = itemManager.getItem(id).image;
                }
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
