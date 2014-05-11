using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using QuestMaker.Classes;

namespace QuestMaker.GUI
{
    public partial class EditItemForm : Telerik.WinControls.UI.RadForm
    {
        public CItem editedItem;
        bool opening;
        
        public EditItemForm()
        {
            InitializeComponent();
            editedItem = new CItem();
        }

        public EditItemForm(CItem _item)
        {
            InitializeComponent();
            editedItem = _item;
            opening = true;
            fillItemData();
            ((OpenFileDialog)(beImage.Dialog)).DefaultExt = ".jpg";
            ((OpenFileDialog)(beImage.Dialog)).Filter = "Картинки|*.jpg|Картинки|*.png";
        }

        private void EditItemForm_Load(object sender, EventArgs e)
        {
            CSettings.fillFormSettings(this);
        }
        private void EditItemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CSettings.setFormSettings(this);
        }

        private void fillItemData()
        {
            tbName.Text = editedItem.getName();
            tbcDescription.Text = editedItem.description;
            tbComment.Text = editedItem.comment;            
            beImage.Value = editedItem.pathToImage;
            pImage.BackgroundImage = editedItem.image;
            cbVisibility.Checked = editedItem.visibility;
            cbSingleUse.Checked = editedItem.singleUse;
            opening = false;
        }
        private void getItemFromUI()
        {
            editedItem.setName(tbName.Text);
            editedItem.description = tbcDescription.Text;
            editedItem.comment = tbComment.Text;
            editedItem.visibility = cbVisibility.Checked;
            editedItem.singleUse = cbSingleUse.Checked;
            editedItem.pathToImage = beImage.Value;
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

        private void beImage_ValueChanged(object sender, EventArgs e)
        {
            if (!opening)
            {
                string fileName = ((OpenFileDialog)(beImage.Dialog)).SafeFileName;
                string path = ((OpenFileDialog)(beImage.Dialog)).FileName;
                //MessageBox.Show("ПОлучили: " + fileName + "\n" + path);
                Image image = Image.FromFile(path);
                pImage.BackgroundImage = image;
            }
        }

        private void cbZoomImage_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (cbZoomImage.Checked)
                pImage.BackgroundImageLayout = ImageLayout.Zoom;
            else
                pImage.BackgroundImageLayout = ImageLayout.Center;
        }

    }
}
