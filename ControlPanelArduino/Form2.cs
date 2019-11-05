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

namespace ControlPanelArduino
{
    public partial class EditConfig : Form
    {
        public static string fileContent = string.Empty;
        public static string filePath = string.Empty;

        public EditConfig()
        {
            InitializeComponent();
        }

        
        private async void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //openFileDialogNote.InitialDirectory = "c:\\";
            openFileDialogNote.Filter = "Все типы (*.*)|*.*|Текстовые файлы (*.txt)|*.txt";
            openFileDialogNote.FilterIndex = 2;
            openFileDialogNote.RestoreDirectory = true;

            try
            {
                if (openFileDialogNote.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialogNote.FileName;
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialogNote.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = await reader.ReadToEndAsync();
                        richTextBoxNotepad.Clear();
                        richTextBoxNotepad.AppendText(fileContent);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private async void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Все типы (*.*)|*.*|Текстовые файлы (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "Config.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    using (StreamWriter writer = new StreamWriter(myStream))
                    {
                        fileContent = richTextBoxNotepad.Text;
                        await writer.WriteAsync(fileContent);
                    }
                    myStream.Close();
                }
            }

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
