using PDF_Editor.Forms;
using PDF_Editor.Utils;
using System;
using System.Windows.Forms;

namespace PDF_Editor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            OpenPdfFile();
        }

        private void tbBtnOpen_Click(object sender, EventArgs e)
        {
            OpenPdfFile();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            SavePdfFile();
        }

        private void tbBtmSave_Click(object sender, EventArgs e)
        {
            SavePdfFile();
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void tbBtnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void OpenPdfFile()
        {
            PdfMetadataForm pdfForm = null;

            try
            {
                var pdfFile = FileHandler.OpenFile(Controls);
                if (pdfFile != null)
                {
                    pdfForm = new PdfMetadataForm(pdfFile);
                    pdfForm.MdiParent = this;
                    pdfForm.WindowState = FormWindowState.Maximized;
                    pdfForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error when trying to open PDF File: {ex.Message}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (pdfForm != null)
                {
                    pdfForm.Close();
                }
            }
        }
    
        private void SavePdfFile()
        {
            try
            {
                var activePdf = GetCurrentOpenedPdf();
                if (activePdf == null)
                {
                    MessageBox.Show("You need to open a PDF file before save!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                activePdf.Save();
                MessageBox.Show("File saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error when trying to save PDF File: {ex.Message}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }        

        private void Reload()
        {
            try
            {
                var activePdf = GetCurrentOpenedPdf();
                if (activePdf == null)
                {
                    MessageBox.Show("You need to open a PDF file before reload!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                activePdf.Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error when trying to reload PDF File: {ex.Message}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private PdfMetadataForm GetCurrentOpenedPdf()
        {
            var activeChild = this.ActiveMdiChild;
            if (activeChild == null || !(activeChild is PdfMetadataForm))
            {                
                return null;
            }

            return (PdfMetadataForm)activeChild;
        }
    }
}
