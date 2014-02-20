using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
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
        }

        private void bSaveitems_Click(object sender, EventArgs e)
        {
            itemManager.removeAllItems();
            for (int row = 0; row < gridViewItems.RowCount; row++)
            {
                string name = Common.convertNullString(gridViewItems.Rows[row].Cells["columnName"].Value );
                string desc = Common.convertNullString(gridViewItems.Rows[row].Cells["columnDescription"].Value );
                string comm = Common.convertNullString(gridViewItems.Rows[row].Cells["columnComment"].Value );
                //string vis = gridViewItems.Rows[row].Cells["columnVisibility"].Value.ToString();
                itemManager.addItem(name, desc, comm, true );
            }
            itemManager.saveItemsToFile();
            // DataSourceNullValue
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            //itemManager.TestXML();
            //gridViewAims.Columns[2].data
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
                // ok works
                //string strtype = gridViewAims.Rows[row].Cells["columnType"].Value.ToString();
                //AimType type = aimManager.getType(strtype);
                //Type ttt =  gridViewAims.Rows[row].Cells["columnType"].Value.GetType();
                AimType type = (AimType) gridViewAims.Rows[row].Cells["columnType"].Value;
                aimManager.addAim(name, desc, type);
            }
            aimManager.saveAimsToFile();

        }

    }
}
