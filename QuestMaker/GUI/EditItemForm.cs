using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace QuestMaker.GUI
{
    public partial class EditItemForm : Telerik.WinControls.UI.RadForm
    {
        public CItem editedItem;
        
        public EditItemForm()
        {
            InitializeComponent();
            editedItem = new CItem();
        }

        public EditItemForm(CItem _item)
        {
            InitializeComponent();
            editedItem = _item;
            fillItemData();
        }

        private void fillItemData()
        {
            tbName.Text = editedItem.getName();
            tbcDescription.Text = editedItem.description;
            tbComment.Text = editedItem.comment;
            cbVisibility.Checked = editedItem.visibility;
            cbSingleUse.Checked = editedItem.singleUse;
        }
        private void getItemFromUI()
        {
            editedItem.setName(tbName.Text);
            editedItem.description = tbcDescription.Text;
            editedItem.comment = tbComment.Text;
            editedItem.visibility = cbVisibility.Checked;
            editedItem.singleUse = cbSingleUse.Checked;
            editedItem.pathToImage = "";
            
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            getItemFromUI();
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
