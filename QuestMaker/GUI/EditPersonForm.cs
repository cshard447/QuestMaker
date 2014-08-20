using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using QuestMaker.Classes;

namespace QuestMaker.GUI
{
    public partial class EditPersonForm : Telerik.WinControls.UI.RadForm
    {
        public CPerson editedPerson;
        private bool newPerson;
        private CAimManager aimManager = CSingleton.Instance.aimManager;
        private CItemManager itemManager = CSingleton.Instance.itemManager;
        private CPersonManager personManager = CSingleton.Instance.personManager;
        private List<int> items;
        private List<int> aims;

        List<int> checkedAimList = new List<int>();
        List<int> checkedItemList = new List<int>();

        public EditPersonForm()
        {
            InitializeComponent();
            editedPerson = new CPerson();
            newPerson = true;
            fillUIComponents();
        }
        public EditPersonForm(CPerson _person)
        {
            InitializeComponent();
            editedPerson = _person;
            newPerson = false;
            fillUIComponents();
            fillPersonData();            
        }

        private void fillUIComponents()
        {
            ddlSex.ValueMember = "EnumSex";
            ddlSex.DisplayMember = "DisplayString";
            ddlSex.DataSource = CPersonManager.enumSexList;

            ddlClan.ValueMember = "Clan";
            ddlClan.DisplayMember = "Display";
            ddlClan.DataSource = CPersonManager.clanList;

            lvAims.Items.Clear();
            lvAims.DataSource = aimManager.getAimsList();
            lvAims.DisplayMember = "DisplayString";
            lvAims.ValueMember = "Id";

            lvItems.Items.Clear();
            lvItems.DataSource = itemManager.getItemsList();
            lvItems.DisplayMember = "DisplayString";
            lvItems.ValueMember = "Id";
        }

        private void EditPersonForm_Load(object sender, EventArgs e)
        {
            CSettings.fillFormSettings(this);
        }
        private void EditPersonForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CSettings.setFormSettings(this);
        }

        private void fillPersonData()
        {
            tbName.Text = editedPerson.getName();
            ddlSex.SelectedValue = editedPerson.sex;
            tbcDescription.Text = editedPerson.description;
            cbUnremovable.Checked = editedPerson.unremovable;
            tbcComment.Text = editedPerson.comment;
            tbAltName.Text = editedPerson.altName;
            ddlClan.SelectedValue = editedPerson.clan;
            foreach (ListViewDataItem lvitem in lvItems.Items)
                if (editedPerson.itemsId.Contains((int)lvitem.Value))
                    lvitem.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            foreach (ListViewDataItem lvaim in lvAims.Items)
                if (editedPerson.aimsId.Contains((int)lvaim.Value))
                    lvaim.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;        
        }

        private void getPersonFromUI()
        {
            editedPerson.setName(tbName.Text);
            editedPerson.sex = (Sex) ddlSex.SelectedValue;
            editedPerson.description = tbcDescription.Text;
            editedPerson.unremovable = cbUnremovable.Checked;
            editedPerson.comment = tbcComment.Text;
            editedPerson.altName = tbAltName.Text;
            editedPerson.clan = (KnownColor)ddlClan.SelectedValue;

            items = new List<int>();
            aims = new List<int>();
            
            foreach (ListViewDataItem lvItem in lvItems.CheckedItems)
                items.Add((int)lvItem.Value);
            foreach (ListViewDataItem lvAim in lvAims.CheckedItems)
                aims.Add((int)lvAim.Value);

            editedPerson.setOwnItems(items);
            editedPerson.setOwnAims(aims);
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            getPersonFromUI();
            int ID = editedPerson.getID();
            if (newPerson)
                ID = personManager.addPerson(editedPerson);
            else
                personManager.updatePerson(editedPerson);
            aimManager.addAimsToPerson(aims, ID);
            itemManager.addItemsToPerson(items, ID);
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddlClan_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.NumberOfColors = 1;
            args.VisualItem.DrawFill = true;
            args.VisualItem.BackColor = Color.FromKnownColor((KnownColor)args.VisualItem.Data.Value);
        }

        private void ddlClan_SelectedValueChanged(object sender, EventArgs e)
        {
            pClanColor.BackColor = Color.FromKnownColor((KnownColor)ddlClan.SelectedValue);
        }

        private void ddlSex_SelectedValueChanged(object sender, EventArgs e)
        {
            tbAltName.Enabled = ( (Sex) ddlSex.SelectedValue == Sex.flexible);
        }

        private void bEditDescription_Click(object sender, EventArgs e)
        {
            markupDescription.Value = tbcDescription.Text.ToString();
            DialogResult dr = markupDescription.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbcDescription.Text = markupDescription.Value.ToString();
                //radTextBox1.Text = markupDescription.Value.ToString();
                // text box don't have a html render :-(((                
            }
        }

        private void bCreateAim_Click(object sender, EventArgs e)
        {
            SaveState();
            EditAimForm editAimForm = new EditAimForm();
            if (editAimForm.ShowDialog() == DialogResult.OK)
            {
                fillUIComponents();
                LoadState(editAimForm.newAimID);
            }
        }

        private void bCreateItem_Click(object sender, EventArgs e)
        {
            SaveState();
            EditItemForm editItemForm = new EditItemForm();
            if (editItemForm.ShowDialog() == DialogResult.OK)
            {                
                fillUIComponents();
                LoadState(editItemForm.newItemID);
            }
        }

        private void SaveState()
        {
            checkedAimList.Clear();
            foreach (ListViewDataItem lvAim in lvAims.CheckedItems)
                checkedAimList.Add((int)lvAim.Value);
            checkedItemList.Clear();
            foreach (ListViewDataItem lvItem in lvItems.CheckedItems)
                checkedItemList.Add((int)lvItem.Value);        
        }
        private void LoadState(int added = -1)
        {
            foreach (ListViewDataItem lvaim in lvAims.Items)
                if (checkedAimList.Contains((int)lvaim.Value) || added == (int)lvaim.Value)
                    lvaim.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            foreach (ListViewDataItem lvitem in lvItems.Items)
                if (checkedItemList.Contains((int)lvitem.Value) || added == (int)lvitem.Value)
                    lvitem.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;        
        }


    }
}
