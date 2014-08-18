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
        private CAimManager aimManager;
        private CItemManager itemManager;
        private CPersonManager personManager;

        List<int> checkedAimList = new List<int>();
        List<int> checkedItemList = new List<int>();

        public EditPersonForm(CPerson _person, ref CAimManager _aimManager, ref CItemManager _itemManager, ref CPersonManager _personManager)
        {
            InitializeComponent();
            editedPerson = _person;
            aimManager = _aimManager;
            itemManager = _itemManager;
            personManager = _personManager;
            fillUIComponents();
            fillPersonData();
            
        }
        public EditPersonForm(ref CAimManager _aimManager, ref CItemManager _itemManager, ref CPersonManager _personManager)
        {
            InitializeComponent();
            editedPerson = new CPerson();
            aimManager = _aimManager;
            itemManager = _itemManager;
            personManager = _personManager;
            fillUIComponents();
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

            List<int> items = new List<int>();
            List<int> aims = new List<int>();
            
            foreach (ListViewDataItem lvItem in lvItems.CheckedItems)
                items.Add((int)lvItem.Value);
            foreach (ListViewDataItem lvAim in lvAims.CheckedItems)
                aims.Add((int)lvAim.Value);

            aimManager.addAimsToPerson(aims, editedPerson.getID());
            itemManager.addItemsToPerson(items, editedPerson.getID());

            editedPerson.setOwnItems(items);
            editedPerson.setOwnAims(aims);
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            getPersonFromUI();
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
            EditAimForm editAimForm = new EditAimForm(ref personManager);            
            if (editAimForm.ShowDialog() == DialogResult.OK)
            {
                int newID = aimManager.addAim(editAimForm.editedAim);
                fillUIComponents();
                LoadState(newID);
            }
        }

        private void bCreateItem_Click(object sender, EventArgs e)
        {
            SaveState();
            EditItemForm editItemForm = new EditItemForm(ref personManager);
            if (editItemForm.ShowDialog() == DialogResult.OK)
            {
                int newID = itemManager.addItem(editItemForm.editedItem);
                fillUIComponents();
                LoadState(newID);
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
