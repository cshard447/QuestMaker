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
    public partial class EditPersonForm : Telerik.WinControls.UI.RadForm
    {
        private CPerson editedPerson;
        public EditPersonForm(CPerson _person)
        {
            InitializeComponent();
            editedPerson = _person;
            fillUIComponents();
        }

        private void fillUIComponents()
        {
            ddlSex.ValueMember = "EnumSex";
            ddlSex.DisplayMember = "DisplayString";
            ddlSex.DataSource = CPersonManager.list;            

            tbName.Text = editedPerson.getName();
            ddlSex.SelectedValue = editedPerson.sex;
            tbcDescription.Text = editedPerson.description;
            cbUnremovable.Checked = editedPerson.unremovable;
            tbcComment.Text = editedPerson.comment;
            tbAltName.Text = editedPerson.altName;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
