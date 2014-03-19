using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.RichTextBox.Model;
using Telerik.WinControls.RichTextBox.FileFormats.Html;
using Telerik.WinControls.RichTextBox.FileFormats;
using System.IO;
using QuestMaker.Classes;

namespace QuestMaker
{
    public partial class MainForm : Form
    {
        CItemManager itemManager = new CItemManager();
        CAimManager aimManager = new CAimManager();
        CRules rules = new CRules();
        CPrehistory prehistory = new CPrehistory();
        
        HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
        //TxtFormatProvider txtProvider = new TxtFormatProvider();
        //XamlFormatProvider xamlProvider = new XamlFormatProvider();

        public MainForm()
        {
            InitializeComponent();
            FillTableColumns();
            itemManager.loadItemsFromFile();
            ShowItemsOnGridView();
            aimManager.loadAimsFromFile();
            ShowAimsOnGridView();
            rules.loadTextFromFile();
            rtbRules.Document = htmlProvider.Import(rules.writtenText);
            prehistory.loadTextFromFile();
            rtbPrehistory.Document = htmlProvider.Import(prehistory.writtenText);            
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
            else if (e.Column.Name == "columnDescription")
            {
                markupItems.Value = e.Value.ToString();
                DialogResult dr = markupItems.ShowDialog();
                if (dr == DialogResult.OK)
                    gridViewItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = markupItems.Value.ToString();
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            //itemManager.TestXML();
            //gridViewAims.Columns[2].data
            //gridViewItems.Columns["columnID"].IsVisible = !gridViewItems.Columns["columnID"].IsVisible;
            gridViewItems.Columns["columnPath"].IsVisible = !gridViewItems.Columns["columnPath"].IsVisible;

        }

        private void gridViewAims_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "columnDescription")
            {
                markupItems.Value = e.Value.ToString();
                DialogResult dr = markupItems.ShowDialog();
                if (dr == DialogResult.OK)
                    gridViewAims.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = markupItems.Value.ToString();
            }

        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            string saveFile = Common.path + "Result.xml";
            itemManager.saveItemsToFile(saveFile);
            aimManager.saveAimsToFile(saveFile);
            rules.saveTextToFile(saveFile);
            prehistory.saveTextToFile(saveFile);
        }

        private void menuButtonWipeOutColumns_Click(object sender, EventArgs e)
        {
            gridViewItems.Columns["columnPath"].IsVisible = !gridViewItems.Columns["columnPath"].IsVisible;
            gridViewItems.Columns["columnId"].IsVisible = !gridViewItems.Columns["columnId"].IsVisible;
            gridViewAims.Columns["columnID"].IsVisible = !gridViewAims.Columns["columnID"].IsVisible;
        }

        private void bEditRules_Click(object sender, EventArgs e)
        {            

        }

        private void bSaveRules_Click(object sender, EventArgs e)
        {

        }

        private void cmbSavePrehistory_Click(object sender, EventArgs e)
        {
            string prehistoryText = htmlProvider.Export(rtbPrehistory.Document);
            prehistory.updateTextFromUI(prehistoryText);
            prehistory.saveTextToFile();
        }

        private void cmdEditPrehistory_Click(object sender, EventArgs e)
        {
            markupPrehistory.Value = htmlProvider.Export(rtbPrehistory.Document);
            if (markupPrehistory.ShowDialog() == DialogResult.OK)
            {
                rtbPrehistory.Document = htmlProvider.Import(markupPrehistory.Value.ToString());
            }
        }

        private void cmbSaveRules_Click(object sender, EventArgs e)
        {
            string rulesText = htmlProvider.Export(rtbRules.Document);
            rules.updateTextFromUI(rulesText);
            rules.saveTextToFile();
        }

        private void cmbdEditRules_Click(object sender, EventArgs e)
        {
            markupRules.Value = htmlProvider.Export(rtbRules.Document);
            //htmlProvider.ExportSettings.
            //markupRules.Value = rules.writtenText.ToString();

            if (markupRules.ShowDialog() == DialogResult.OK)
            {
                rtbRules.Document = htmlProvider.Import(markupRules.Value.ToString());
            }
        }

    }
}
