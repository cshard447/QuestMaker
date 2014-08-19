using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using QuestMaker.Classes;

namespace QuestMaker.GUI
{
    public partial class EditAimForm : Telerik.WinControls.UI.RadForm
    {
        public CAim editedAim;
        private CPersonManager personManager = CSingleton.Instance.personManager;

        public EditAimForm()
        {
            InitializeComponent();
            editedAim = new CAim();
            fillUIComponents();
        }

        public EditAimForm(CAim _aim)
        {
            InitializeComponent();
            editedAim = _aim;
            fillUIComponents();
            fillAimData();
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

            lvPersons.ValueMember = "Id";
            lvPersons.DisplayMember = "Name";
            lvPersons.DataSource = personManager.getPersonsList();
        }
        private void fillAimData()
        {
            tbAimName.Text = editedAim.getName();
            ddlAimType.SelectedValue = editedAim.type;
            tbcAimDescription.Text = editedAim.description;
            foreach (ListViewDataItem lvPerson in lvPersons.Items)
                if (editedAim.personsId.Contains((int)lvPerson.Value))
                    lvPerson.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
        }
        private void getAimFromUI()
        {
            editedAim.setName(tbAimName.Text);
            editedAim.type = (AimType) ddlAimType.SelectedValue;
            editedAim.description = tbcAimDescription.Text;
            editedAim.personsId.Clear();

            List<int> followers = new List<int>();
            foreach (ListViewDataItem lvPerson in lvPersons.CheckedItems)
                followers.Add((int)lvPerson.Value);
            personManager.refreshAimOnPersons(followers, editedAim.getID());
            editedAim.setFollowPersons(followers);
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
