using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Telerik.WinControls.UI;
using Telerik.WinControls.RichTextBox.Model;
using Telerik.WinControls.RichTextBox.FileFormats;
using Telerik.WinControls.RichTextBox.FileFormats.Html;
using QuestMaker.Classes;
using QuestMaker.GUI;

namespace QuestMaker
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        CItemManager itemManager = CSingleton.Instance.itemManager;
        CAimManager aimManager = CSingleton.Instance.aimManager;
        CPersonManager peopleManager = CSingleton.Instance.personManager;
        CEventManager eventManager = CSingleton.Instance.eventManager;
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
            aimManager.loadAimsFromFile();
            rules.loadTextFromFile();
            prehistory.loadTextFromFile();
            peopleManager.loadPersonsFromFile();
            eventManager.loadEventsFromFile();
            CSettings.loadSettingsFromFile();
            CSettings.fillGridViewSettings(gridViewAims);
            CSettings.fillGridViewSettings(gridViewItems);
            CSettings.fillGridViewSettings(gridViewPersons);
            CSettings.fillGridViewSettings(gridViewEvents);
            if (CommonError.isError)
                MessageBox.Show(CommonError.getCurrentError(), "Ошибка открытия данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            UpdateDataOnGridViews();
            if (CommonError.isError)
                MessageBox.Show(CommonError.getCurrentError(), "Ошибка открытия данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }

        void FillTableColumns()
        {
            GridViewComboBoxColumn column = (GridViewComboBoxColumn)gridViewAims.Columns["columnType"];
            column.ValueMember = "Type";
            column.DisplayMember = "DisplayString";
            column.FieldName = "Type";
            column.DataSource = CAimManager.enumAimList;
            column.DataSourceNullValue = AimType.secondary;

            GridViewComboBoxColumn column2 = (GridViewComboBoxColumn)gridViewPersons.Columns["columnSex"];
            column2.ValueMember = "EnumSex";
            column2.DisplayMember = "DisplayString";
            column2.FieldName = "EnumSex";
            column2.DataSource = CPersonManager.enumSexList;
            column2.DataSourceNullValue = Sex.flexible;

            GridViewTextBoxColumn column3 = (GridViewTextBoxColumn)gridViewItems.Columns["columnID"];
            column3.DataSourceNullValue = -1;
            GridViewTextBoxColumn column4 = (GridViewTextBoxColumn)gridViewAims.Columns["columnID"];
            column4.DataSourceNullValue = -1;
            GridViewTextBoxColumn column5 = (GridViewTextBoxColumn)gridViewPersons.Columns["columnID"];
            column5.DataSourceNullValue = -1;
            GridViewTextBoxColumn column6 = (GridViewTextBoxColumn)gridViewEvents.Columns["columnID"];
            column6.DataSourceNullValue = -1;

            GridViewComboBoxColumn column7 = (GridViewComboBoxColumn)gridViewPersons.Columns["columnClanColor"];
            column7.ValueMember = "Clan";
            column7.DisplayMember = "Display";
            column7.FieldName = "Clan";            
            //column7.ConditionalFormattingObjectList
            column7.DataSource = CPersonManager.clanList;
            column7.DataSourceNullValue = KnownColor.Gray;

            GridViewComboBoxColumn column8 = (GridViewComboBoxColumn)gridViewEvents.Columns["columnEventType"];
            column8.ValueMember = "Type";
            column8.DisplayMember = "DisplayString";
            column8.FieldName = "Type";
            column8.DataSource = CEventManager.enumEventList;
            column8.DataSourceNullValue = EventType.announcement;
        }
        //***************************************************
        //*********Data save by button click*****************
        private void cmbSaveItems_Click(object sender, EventArgs e)
        {
            itemManager.UpdateItemsFromGrid(gridViewItems);
            itemManager.saveItemsToFile();
            ShowItemsOnGridView();
            // DataSourceNullValue
        }

        private void cmbSaveAims_Click(object sender, EventArgs e)
        {
            aimManager.UpdateAimsFromGrid(gridViewAims);
            aimManager.saveAimsToFile();
            ShowAimsOnGridView();
        }
        private void cmdSavePersons_Click(object sender, EventArgs e)
        {
            peopleManager.UpdatePersonsFromGrid(gridViewPersons);
            peopleManager.savePersonsToFile();
            ShowPersonsOnGridView();
        }
        private void cmbSaveEvents_Click(object sender, EventArgs e)
        {
            eventManager.UpdateEventsFromGrid(gridViewEvents);
            eventManager.saveEventsToFile();
            ShowEventsOnGridView();
        }
        //***************************************************
        //*********Show data on grid views and docs**********
        private void UpdateDataOnGridViews()
        {
            ShowItemsOnGridView();
            ShowAimsOnGridView();
            ShowPersonsOnGridView();
            ShowEventsOnGridView();
            rtbRules.Document = htmlProvider.Import(rules.writtenText);
            rtbPrehistory.Document = htmlProvider.Import(prehistory.writtenText);
        }

        private void ShowItemsOnGridView()
        {
            gridViewItems.Rows.Clear();
            Dictionary<int, CItem> _items = itemManager.getAllItems();
            object[] values = new object[9];
            gridViewItems.BeginUpdate();
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
                values[8] = peopleManager.getPersonsNamesFromId( item.personsId );
                gridViewItems.Rows.Add(values);
            }
            gridViewItems.EndUpdate();            
        }

        private void ShowAimsOnGridView()
        {
            gridViewAims.Rows.Clear();
            Dictionary<int, CAim> _aims = aimManager.getAllAims();
            object[] values = new object[5];
            gridViewAims.BeginUpdate();
            foreach (CAim aim in _aims.Values)
            {
                values[0] = aim.getID();
                values[1] = aim.getName();
                values[2] = aim.description;
                values[3] = aim.type;
                values[4] = peopleManager.getPersonsNamesFromId( aim.personsId );
                gridViewAims.Rows.Add(values);
            }
            gridViewAims.EndUpdate();
        }

        private void ShowPersonsOnGridView()
        {
            gridViewPersons.Rows.Clear();
            Dictionary<int, CPerson> _people = peopleManager.getAllPersons();
            object[] values = new object[10];
            gridViewPersons.BeginUpdate();
            foreach(CPerson person in _people.Values)
            {
                values[0] = person.getID();
                values[1] = person.getName();
                values[2] = person.sex;
                values[3] = person.unremovable;
                values[4] = person.description;
                values[5] = itemManager.getItemsNamesFromId(person.itemsId);
                values[6] = aimManager.getAimsNamesFromId(person.aimsId);
                values[7] = person.altName;
                values[8] = person.comment;
                values[9] = person.clan;
                gridViewPersons.Rows.Add(values);
            }
            gridViewPersons.EndUpdate();
        }
        private void ShowEventsOnGridView()
        {
            gridViewEvents.Rows.Clear();
            Dictionary<int, CAuthorEvent> _events = eventManager.getAllEvents();
            object[] values = new object[5];
            gridViewEvents.BeginUpdate();
            foreach (CAuthorEvent _event in _events.Values)
            {
                values[0] = _event.getID();
                values[1] = _event.description;
                values[2] = _event.precondition;
                values[3] = _event.time;
                values[4] = _event.type;
                gridViewEvents.Rows.Add(values);
            }
            gridViewEvents.EndUpdate();
        }
        //****************************************************************
        //********* Main MENU   ******************************************
        private void menuItemLoad_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                itemManager.loadItemsFromFile(filename);
                aimManager.loadAimsFromFile(filename);
                peopleManager.loadPersonsFromFile(filename);
                rules.loadTextFromFile(filename);
                prehistory.loadTextFromFile(filename);
                eventManager.loadEventsFromFile(filename);

                UpdateDataOnGridViews();
            }
        }
        
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //string saveFile = Common.path + "Result.xml";
                string saveFile = saveFileDialog.FileName;
                itemManager.saveItemsToFile(saveFile);
                aimManager.saveAimsToFile(saveFile);
                rules.saveTextToFile(saveFile);
                prehistory.saveTextToFile(saveFile);
                peopleManager.savePersonsToFile(saveFile);
                eventManager.saveEventsToFile(saveFile);
            }
        }

        private void menuItemPrintForm_Click(object sender, EventArgs e)
        {
            PrintResultForm prf = new PrintResultForm(prehistory, rules);
            prf.Show();
        }

        private void menuButtonWipeOutColumns_Click(object sender, EventArgs e)
        {
            gridViewItems.Columns["columnPath"].IsVisible = !gridViewItems.Columns["columnPath"].IsVisible;
            gridViewItems.Columns["columnId"].IsVisible = !gridViewItems.Columns["columnId"].IsVisible;
            gridViewAims.Columns["columnID"].IsVisible = !gridViewAims.Columns["columnID"].IsVisible;
            gridViewEvents.Columns["columnID"].IsVisible = !gridViewEvents.Columns["columnID"].IsVisible;
            gridViewPersons.Columns["columnID"].IsVisible = !gridViewPersons.Columns["columnID"].IsVisible;
            gridViewPersons.Columns["columnAltName"].IsVisible = !gridViewPersons.Columns["columnAltName"].IsVisible;
        }
        //***************************************************
        //*********Prehistory and Rules**********************
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
        //***************************************************
        //*******Create and Edit*****************************
        private void cmbCreatePerson_Click(object sender, EventArgs e)
        {
            EditPersonForm epf = new EditPersonForm();
            if (epf.ShowDialog() == DialogResult.OK)
            {
                peopleManager.addPerson(epf.editedPerson);
                UpdateDataOnGridViews();
            }
        }

        private void cmbEditPerson_Click(object sender, EventArgs e)
        {
            List<GridViewRowInfo> rows = gridViewPersons.SelectedRows.ToList();
            int id = int.Parse(rows[0].Cells["columnID"].Value.ToString());
            CPerson person = peopleManager.getPerson(id);
            EditPersonForm epf = new EditPersonForm(person);
            if (epf.ShowDialog() == DialogResult.OK)
            {
                peopleManager.updatePerson(epf.editedPerson);
                UpdateDataOnGridViews();
            }
        }
        private void cmbCreateAim_Click(object sender, EventArgs e)
        {
            EditAimForm eaf = new EditAimForm();
            if (eaf.ShowDialog() == DialogResult.OK)
            {
                aimManager.updateAim(eaf.editedAim);
                UpdateDataOnGridViews();
            }
        }

        private void cmbEditAims_Click(object sender, EventArgs e)
        {
            List<GridViewRowInfo> rows = gridViewAims.SelectedRows.ToList();
            int id = int.Parse(rows[0].Cells["columnID"].Value.ToString());
            CAim aim = aimManager.getAim(id);
            EditAimForm eaf = new EditAimForm(aim);
            if (eaf.ShowDialog() == DialogResult.OK)
            {
                // find out, aim updated even without this function!
                aimManager.updateAim(eaf.editedAim);
                UpdateDataOnGridViews();
            }
        }

        private void cmbCreateItem_Click(object sender, EventArgs e)
        {
            EditItemForm eif = new EditItemForm();
            if (eif.ShowDialog() == DialogResult.OK)
            {
                itemManager.addItem(eif.editedItem);
                UpdateDataOnGridViews();
            }
        }

        private void cmbEditItems_Click(object sender, EventArgs e)
        {
            List<GridViewRowInfo> rows = gridViewItems.SelectedRows.ToList();
            int id = int.Parse(rows[0].Cells["columnID"].Value.ToString());
            CItem item = itemManager.getItem(id);
            EditItemForm eif = new EditItemForm(item);
            if (eif.ShowDialog() == DialogResult.OK)
            {
                itemManager.updateItem(eif.editedItem);
                UpdateDataOnGridViews();
            }
        }
        //************************************************************
        //********* Stuff   ******************************************
        private void gridViewItems_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "columnImage")
            {
                if (openImageFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openImageFileDialog.SafeFileName;
                    string path = openImageFileDialog.FileName;
                    int id = int.Parse(gridViewItems.Rows[e.RowIndex].Cells["columnID"].Value.ToString());
                    itemManager.addImageToItem(path, fileName, id);
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
        private void gridViewPersons_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "columnClanColor")
            {
                e.CellElement.DrawFill = true;
                if (e.CellElement.RowInfo.Cells["columnClanColor"].Value != null)
                    e.CellElement.BackColor = Color.FromKnownColor((KnownColor)e.CellElement.Value);
            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
            }
        }

        private void cmbPersonsColumnChooser_Click(object sender, EventArgs e)
        {
            gridViewPersons.ColumnChooser.Show();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            //itemManager.TestXML();
            gridViewAims.ColumnChooser.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CSettings.setFormSettings(this);
            CSettings.setGridViewSettings(gridViewAims);
            CSettings.setGridViewSettings(gridViewItems);
            CSettings.setGridViewSettings(gridViewPersons);
            CSettings.setGridViewSettings(gridViewEvents);
            CSettings.saveSettingsToFile();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CSettings.fillFormSettings(this);
        }

        //***************************************************
        //*******Save data after editing on grids************
        private void gridViewPersons_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            peopleManager.UpdatePersonsFromGrid(gridViewPersons);
        }

        private void gridViewPersons_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            peopleManager.UpdatePersonsFromGrid(gridViewPersons);
            ShowPersonsOnGridView();
        }

        private void gridViewAims_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            aimManager.UpdateAimsFromGrid(gridViewAims);
        }

        private void gridViewAims_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            aimManager.UpdateAimsFromGrid(gridViewAims);
            ShowAimsOnGridView();
        }

        private void gridViewItems_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            itemManager.UpdateItemsFromGrid(gridViewItems);
        }

        private void gridViewItems_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            itemManager.UpdateItemsFromGrid(gridViewItems);
            ShowItemsOnGridView();
        }

        private void gridViewEvents_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            eventManager.UpdateEventsFromGrid(gridViewEvents);
        }
        //***************************************************

    }
}
