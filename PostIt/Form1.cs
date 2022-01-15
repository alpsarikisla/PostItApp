using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostIt
{
    public partial class Form1 : Form
    {
        bool kayit;
        public Form1()
        {
            InitializeComponent();
            kayit = false;
            saveFileDialog1.Filter = "Zengin Metin Biçimi|*.rtf|Metin Belgesi|*.txt";
            FontlariGetir();
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
                toolStripComboBox1.Items.Add(item.Name);
            }

            string fnt = richTextBox1.Font.Name;
            toolStripComboBox1.SelectedItem = fnt;
            Font f = new Font(richTextBox1.Font.FontFamily, 11);
            richTextBox1.Font = f;

            string size = richTextBox1.Font.Size.ToString();
            toolStripComboBox2.SelectedItem = size;
        }
    }
}
