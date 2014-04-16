using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using Telerik.WinControls;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Telerik.WinControls.RichTextBox;
using Telerik.WinControls.RichTextBox.Lists;
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
            //doc.LineSpacing = 12;
            /*
            Paragraph paragraph1 = new Paragraph();
            Stream stream = Application.GetResourceStream(new Uri(@"/RadRichTextBox-Getting-Started;component/Images/RadRichTextBox.png", UriKind.RelativeOrAbsolute)).Stream;
            Size size = new Size(236, 50);
            ImageInline imageInline = new ImageInline(stream, size, "png");
            paragraph1.Inlines.Add(imageInline);
            section.Blocks.Add(paragraph1);
            */
            // вид документа:
            // предыстория, на отдельной странице (потом разрыв)
            // имя персонажа большими буквами посередине страницы
            // описание, сюжет
            // список целей, ненумерованным списком
            // список предметов (если есть), нумерованным списком
            // правила игры


            doc = new RadDocument();
            doc.MergeSpansWithSameStyles();
            doc.ParagraphDefaultSpacingAfter = 0;
            doc.ParagraphDefaultSpacingBefore = 0;
            Padding padding = new System.Windows.Forms.Padding(0, 20, 100, 60);
            doc.SectionDefaultPageMargin = padding;
            //doc.SectionDefaultPageMargin.
            //doc.DefaultPageLayoutSettings.Width = 200;
            //doc.DefaultPageLayoutSettings.Height = 250;
            RadDocument tempDoc = new RadDocument();

            // **** Prehistory***********
            tempDoc = htmlProvider.Import(prehistory.writtenText);
            mergeDocuments(tempDoc);
            doc.CaretPosition.MoveToLastPositionInDocument();
            doc.InsertPageBreak();

            // **** Person Name ***********
            Section section = new Section();
            Paragraph paragraph1 = new Paragraph();
            paragraph1.TextAlignment = Telerik.WinControls.RichTextBox.Layout.RadTextAlignment.Center;
            Span span1 = new Span(chosenPerson.getName());
            span1.FontSize = 24;
            span1.FontStyle = TextStyle.Bold;
            span1.UnderlineType = Telerik.WinControls.RichTextBox.UI.UnderlineType.Wave;
            paragraph1.Inlines.Add(span1);
            section.Blocks.Add(paragraph1);
            doc.Sections.Add(section);

            // **** Prehistory***********
            tempDoc = htmlProvider.Import(chosenPerson.description);
            mergeDocuments(tempDoc, section);

            // **** Aim list***********            
            BulletedList aimList = new BulletedList(char.ConvertFromUtf32(0x25CF)[0] , doc); 
            Section section2 = new Section();
            Paragraph par2 = new Paragraph();
            doc.CaretPosition.MoveToLastPositionInDocument();
            doc.InsertLineBreak();
            Span span2 = new Span("Your Aims:");
            par2.Inlines.Add(span2);
            section2.Blocks.Add(par2);
            
            foreach (int aimID in chosenPerson.aimsId)
            {
                CAim aim = aimManager.getAim(aimID);
                Paragraph par = new Paragraph();
                Span span = new Span(aim.getName());                
                if (aim.description != "")
                    span.Text += " (" + aim.description + ")";
                par.Inlines.Add(span);
                par.LineSpacingType = LineSpacingType.AtLeast;                
                aimList.AddParagraph(par);
                section2.Blocks.Add(par);
            }           
            doc.Sections.Add(section2);

            // **** Item list***********
            if (chosenPerson.itemsId.Count > 0)
            {
                NumberedList itemList = new NumberedList(doc);
                Section section3 = new Section();
                Paragraph par3 = new Paragraph();
                Span span3 = new Span("Your Items:");
                par3.Inlines.Add(span3);
                section3.Blocks.Add(par3);

                foreach (int itemID in chosenPerson.itemsId)
                {
                    CItem item = itemManager.getItem(itemID);
                    Paragraph par = new Paragraph();
                    Span span = new Span(item.getName());
                    if (item.description != "")
                        span.Text += " (" + item.description + ")";
                    par.Inlines.Add(span);
                    par.LineSpacingType = LineSpacingType.AtLeast;
                    itemList.AddParagraph(par);
                    section3.Blocks.Add(par);
                }
                doc.Sections.Add(section3);
            }

            // **** Rules***********
            doc.CaretPosition.MoveToLastPositionInDocument();
            doc.InsertLineBreak();
            tempDoc = htmlProvider.Import(rules.writtenText);
            mergeDocuments(tempDoc, doc.Sections.Last);
        }

        private void mergeDocuments(RadDocument tempDoc, Section prevSection = null)
        {
            foreach (Section sect in tempDoc.Sections)
            {
                Section copySection = sect.CreateDeepCopy() as Section;
                tempDoc.Sections.Remove(sect);
                if (prevSection != null)
                    doc.Sections.AddAfter(prevSection, copySection);
                else
                    doc.Sections.Add(copySection);
            }        
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

            //Stream output = File.OpenWrite("d:\\QuestMaker\\QuestMaker\\QuestMaker\\Result\\" + chosenPerson.getName() + ".docx");           
            //docxProvider.Export(doc, output);
            
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
