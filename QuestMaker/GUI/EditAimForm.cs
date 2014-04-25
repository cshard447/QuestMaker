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
    public partial class EditAimForm : Telerik.WinControls.UI.RadForm
    {
        public CAim editedAim;

        public EditAimForm(CAim _aim)
        {
            InitializeComponent();
            editedAim = _aim;
            fillUIComponents();
            fillAimData();
        }
        public EditAimForm()
        {
            InitializeComponent();
            editedAim = new CAim();
            fillUIComponents();            
        }

        private void EditAimForm_Load(object sender, EventArgs e)
        {
            CSettings.fillFormSettings(this);
        }
        private void EditAimForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CSettings.setFormSettings(this);
        }

        private void fillUIComponents()
        {
            ddlAimType.ValueMember = "Type";
            ddlAimType.DisplayMember = "DisplayString";
            ddlAimType.DataSource = CAimManager.enumAimList;
        }
        private void fillAimData()
        {
            tbAimName.Text = editedAim.getName();
            ddlAimType.SelectedValue = editedAim.type;
            tbcAimDescription.Text = editedAim.description;        
        }
        private void getAimFromUI()
        {
            editedAim.setName(tbAimName.Text);
            editedAim.type = (AimType) ddlAimType.SelectedValue;
            editedAim.description = tbcAimDescription.Text;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            getAimFromUI();
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
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
        */
    }
}
