using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace QuestMaker
{
    public partial class MainForm : Form
    {
        CItemManager itemManager = new CItemManager();

        public MainForm()
        {
            InitializeComponent();
            //GridViewDataColumn col = gridViewItems.Columns.GetColumnByFieldName("columnVisibility").First();
            //col.DataTypeConverter = new TypeConverter();
            itemManager.loadItemsFromFile();
            ShowItemsOnGridView();
        }

        public static bool ConvertStringToBool(string str)
        {
            return str.Equals("true");
        }

        private void bSaveitems_Click(object sender, EventArgs e)
        {
            itemManager.removeAllItems();
            for (int row = 0; row < gridViewItems.RowCount; row++)
            {
                string name = gridViewItems.Rows[row].Cells["columnName"].Value.ToString();
                string desc = gridViewItems.Rows[row].Cells["columnDescription"].Value.ToString();
                string comm = gridViewItems.Rows[row].Cells["columnComment"].Value.ToString();
                //string vis = gridViewItems.Rows[row].Cells["columnVisibility"].Value.ToString();
                itemManager.addItem(name, desc, comm, true );
            }
            itemManager.saveItemsToFile();
            
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            itemManager.TestXML();
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

    }
}
