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

namespace BowlingTournamentBrackets
{
    public partial class FileUpload : Form
    {
        public static string FilePath;

        public FileUpload()
        {
            InitializeComponent();
            UploadBtn.Enabled = false;
            UploadTxt.ReadOnly = true;
        }

        private void ChooseFileBtn_Click(object sender, EventArgs e)
        {
            // Opens up the user's computer files so they can select
            // a file to upload
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // If the user selects a text file
                if (fileDialog.FileName.Substring(fileDialog.FileName.Length - 4).Contains(".txt")) 
                {
                    // Enable the upload button
                    UploadBtn.Enabled = true;               
                }

                // Assign the file path to the FilePath field
                FilePath = fileDialog.FileName;

                // Display the path in the text box
                UploadTxt.Text = fileDialog.FileName;
            }
        }

        private void UploadBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
