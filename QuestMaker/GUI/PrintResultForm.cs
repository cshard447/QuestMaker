﻿using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using Telerik.WinControls;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Telerik.WinControls.RichTextBox.Model;
using Telerik.WinControls.RichTextBox.Model.Styles;
using Telerik.WinControls.RichTextBox.FileFormats.Html;
using Telerik.WinControls.RichTextBox.FileFormats.OpenXml.Docx;
using Telerik.Windows.Documents.Fixed.FormatProviders.Text;

using QuestMaker.Classes;

namespace QuestMaker.GUI
{
    public partial class PrintResultForm : Telerik.WinControls.UI.RadForm
    {
        CPersonManager personManager;
        CAimManager aimManager;
        CItemManager itemManager;
        CPrehistory prehistory;
        CRules rules;

        CPerson chosenPerson;
        RadDocument doc = new RadDocument();               
        DocxFormatProvider docxProvider = new DocxFormatProvider();
        HtmlFormatProvider htmlProvider = new HtmlFormatProvider();        

        public PrintResultForm(CPersonManager _personManager, CAimManager _aimManager, CItemManager _itemManager, CPrehistory _prehistory, CRules _rules)
        {
            InitializeComponent();
            personManager = _personManager;
            aimManager = _aimManager;
            itemManager = _itemManager;
            prehistory = _prehistory;
            rules = _rules;
            fillUIComponents();
            // remove then
            ddlPersonChoose.SelectedValue = 4;
        }

        void fillUIComponents()
        {
            ddlPersonChoose.ValueMember = "Id";
            ddlPersonChoose.DisplayMember = "Name";
            ddlPersonChoose.DataSource = personManager.getPersonsList();

            ddlSexChoose.ValueMember = "EnumSex";
            ddlSexChoose.DisplayMember = "DisplayString";
            ddlSexChoose.DataSource = CPersonManager.enumSexList;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddlPersonChoose_SelectedValueChanged(object sender, EventArgs e)
        {
            chosenPerson = personManager.getPerson((int)ddlPersonChoose.SelectedValue);
            ddlSexChoose.SelectedValue = chosenPerson.sex;
        }

        private void compileDocument()
        {
            string temp = "";
            temp += prehistory.writtenText + "<br>";
            temp += chosenPerson.getName() + "<br>";
            temp += chosenPerson.description + "<br>";

            temp += "Your Aims:<br>";
            foreach (int aimID in chosenPerson.aimsId)
            {
                CAim aim = aimManager.getAim(aimID);
                temp += aim.getName();
                if (aim.description != "")
                    temp += " (" + aim.description + ")";
                temp += ".<br>";
            }

            temp += "Your own Items:<br>";
            foreach (int itemID in chosenPerson.itemsId)
            {
                CItem item = itemManager.getItem(itemID);
                temp += item.getName();
                if (item.description != "")
                    temp += " (" + item.description + ")";
                temp += ".<br>";
            }

            temp += rules.writtenText;

            StyleDefinition def = new StyleDefinition();
            
            //doc.Insert(chosenPerson.getName(), def);
            //doc.InsertLineBreak();
            //doc.Insert(chosenPerson.description, def);

            //doc = htmlProvider.Import(chosenPerson.description);
            doc = htmlProvider.Import(temp);
            doc.LineSpacingType = LineSpacingType.Auto;
            //doc.LineSpacing = 12;
            
            //doc = doc + doc;
            //doc.Insert(chosenPerson.        
        }

        private void bPrintPreview_Click(object sender, EventArgs e)
        {
            
        }

        private void bSaveAsDocument_Click(object sender, EventArgs e)
        {
            compileDocument();
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = chosenPerson.getName();
            saveDialog.DefaultExt = ".docx";
            saveDialog.Filter = "Documents|*.docx";
            DialogResult dialogResult = saveDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                using (Stream output = saveDialog.OpenFile())
                {
                    docxProvider.Export(doc, output);
                    //MessageBox.Show("Saved Successfuly!");
                }
            }
        }
    }
}