using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextRedaktor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public System.Drawing.Color SelectionColor { get; set; }

        private void bOpen_Click(object sender, EventArgs e)
        {
          if (openFileDialog1.ShowDialog() == DialogResult.OK) //проверяем был ли  выбран файл 
            { 
                richTextBox1.Clear(); //очищаем richTextBox
                openFileDialog1.Filter = "Text Files (*.txt|*.txt"; //указываем, что нас интересуют только текстовые файлы 
                string fileName = openFileDialog1.FileName; //получаем наименование файл и путь к нему
                richTextBox1.Text = File.ReadAllText(fileName, Encoding.GetEncoding(1251)); //передаем содержимое файла в текстбокс
            }  
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt"; //задаем доступные расширения
            saveFileDialog1.DefaultExt = ".txt"; //задаем расширение по умолчанию

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) //проверяем подтверждение
            { 
                var name = saveFileDialog1.FileName; //задаем имя файлу 
                File.WriteAllText(name, richTextBox1.Text, Encoding.GetEncoding(1251)); //записывает в файл содержимое текстбокс с кодироовкой 1251

            }
            richTextBox1.Clear();
        }

        private void сервисToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void выравниваниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
               
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font myFont = new Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            string Hello = "Hello World!";
            e.Graphics.DrawString(Hello, myFont, Brushes.Black, 20, 20);
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Clear();
        }

        private void bFont_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void bColor_Click(object sender, EventArgs e)
        {
          
        }
        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK) 
                printDocument1.Print();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //проверяем был ли  выбран файл 
            {
                richTextBox1.Clear(); //очищаем richTextBox
                openFileDialog1.Filter = "Text Files (*.txt|*.txt"; //указываем, что нас интересуют только текстовые файлы 
                string fileName = openFileDialog1.FileName; //получаем наименование файл и путь к нему
                richTextBox1.Text = File.ReadAllText(fileName, Encoding.GetEncoding(1251)); //передаем содержимое файла в текстбокс
            }
        }

        private void предварительныйПросмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
           
        }

        private void настройкаПринтераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void bCut_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Cut();
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Copy();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Clear();
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            richTextBox1.Select();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
            
        }

        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void поЛевомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void поПравомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.Color = richTextBox1.SelectionColor;

            // Determine if the user clicked OK in the dialog and that the color has changed.
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               colorDialog1.Color != richTextBox1.SelectionColor)
            {
                // Change the selection color to the user specified color.
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void bColor_Click_1(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.Color = richTextBox1.SelectionColor;

            // Determine if the user clicked OK in the dialog and that the color has changed.
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               colorDialog1.Color != richTextBox1.SelectionColor)
            {
                // Change the selection color to the user specified color.
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }
    }
}
