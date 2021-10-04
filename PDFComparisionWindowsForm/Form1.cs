using System;
using System.Windows.Forms;

namespace PDFComparisionWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Pdf Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "pdf",
                Filter = "pdf files (*.pdf)|*.pdf",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                FilePath.Text = BrowseFile.FileName;
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Pdf Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "pdf",
                Filter = "pdf files (*.pdf)|*.pdf",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                FilePath2.Text = BrowseFile.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            PDFFileHandler reader = new PDFFileHandler(FilePath,FilePath2);
            var result = reader.ComparePdfFiles().Split("");
            reader.GeneratePdf(result, "compare.pdf");
            // System.Diagnostics.Process.Start("compare.pdf");
            MessageBox.Show("PDF Created Successfully \n" + "Check D:/create.pdf");

        }

       
    }
}
