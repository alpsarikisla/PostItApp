using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostIt
{
    public partial class Form1 : Form
    {
        bool kayit;
        bool bold;
        public Form1()
        {
            InitializeComponent();
            kayit = false;
            bold = false;
            saveFileDialog1.Filter = "Zengin Metin Biçimi|*.rtf|Metin Belgesi|*.txt";
            FontlariGetir();
            STMIRenkButton.BackColor = Color.Black;
        }

        private void AcTSMI_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName);
            }
        }

        private void kaydetTSMI_Click(object sender, EventArgs e)
        {
            if (kayit == false)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName;
                    richTextBox1.SaveFile(path);
                }
            }
        }

        public void FontlariGetir()
        {
            List<FontFamily> fontlar = FontFamily.Families.ToList();
            foreach (FontFamily item in fontlar)
            {
                TSCBFont.Items.Add(item.Name);
            }

            string fnt = richTextBox1.Font.Name;
            TSCBFont.SelectedItem = fnt;
            Font f = new Font(richTextBox1.Font.FontFamily, 11);
            richTextBox1.Font = f;

            string size = richTextBox1.Font.Size.ToString();
            TSCBSize.SelectedItem = size;
        }

        private void TSCBFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = TSCBFont.SelectedItem.ToString();

            float size = 11f;
            if (TSCBSize.SelectedItem != null)
            {
                size = (float)Convert.ToDouble(TSCBSize.Text);
            }

            Font selectedfont = new Font(name, size);
            richTextBox1.Font = selectedfont;
        }

        private void TSCBSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = TSCBFont.SelectedItem.ToString();

            float size = 11f;
            if (TSCBSize.SelectedItem != null)
            {
                size = (float)Convert.ToDouble(TSCBSize.Text);
            }

            Font selectedfont = new Font(name, size);
            richTextBox1.Font = selectedfont;
        }

        private void TSMIFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText != null)
                {
                    richTextBox1.SelectionFont = fontDialog1.Font;
                }
                else
                {
                    richTextBox1.Font = fontDialog1.Font;
                }
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != null)
            {
                Font fnt = richTextBox1.SelectionFont;
                FontStyle fs = fnt.Bold ? FontStyle.Regular : FontStyle.Bold;

                Font newfont = new Font(fnt.FontFamily, fnt.Size, fs);
                richTextBox1.SelectionFont = newfont;
            }
            else
            {
                if (bold)
                {
                    Font fnt = richTextBox1.Font;
                    Font newfont = new Font(fnt.FontFamily, fnt.Size, FontStyle.Regular);
                    richTextBox1.Font = newfont;
                    bold = false;
                }
                else
                {
                    Font fnt = richTextBox1.Font;
                    Font newfont = new Font(fnt.FontFamily, fnt.Size, FontStyle.Bold);
                    richTextBox1.Font = newfont;
                    bold = true;
                }
               
            }
        }

        private void STMIRenkButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color clr = colorDialog1.Color;
                STMIRenkButton.BackColor = clr;
                richTextBox1.ForeColor = clr;
            }
        }

        private void TSMIYazdir_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;


            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            // Set margins
            pg.Margins = new System.Drawing.Printing.Margins(9, 0, 0, 7); //centesimas de pulgada
            pg.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 417, 110); //centesimas de pulgada
            pg.PrinterResolution.Kind = System.Drawing.Printing.PrinterResolutionKind.High;
            this.printDocument1.DefaultPageSettings = pg;
           
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void Dokuman_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font(richTextBox1.Text.ToString(), richTextBox1.Font.Size), System.Drawing.Brushes.Black, 66, 50);
        }
    }
}
