using PDF_Editor.DTOs;
using PDF_Editor.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PDF_Editor.Forms
{
    public partial class PdfMetadataForm : Form
    {
        private readonly PdfOpenedDto pdfOpened;

        public PdfMetadataForm()
        {
            InitializeComponent();
        }

        public PdfMetadataForm(PdfOpenedDto _pdfOpened)
        {
            InitializeComponent();
            pdfOpened = _pdfOpened;
        }

        public void Save()
        {
            pdfOpened.Keywords = txtKeywords.Text;

            // Prepare custom properties to save
            pdfOpened.CustomProperties = ValidateAndGetCustomProperties();

            PdfUtils.SavePdfData(pdfOpened);
            LoadPdf();
        }

        public void Reload()
        {
            LoadPdf();
        }

        private void PdfMetadataForm_Load(object sender, EventArgs e)
        {
            this.Text = pdfOpened.FilePath;
            LoadPdf();
        }

        private void LoadPdf()
        {
            var fileName = pdfOpened.FilePath.Split('\\').Last();
            this.lblFileName.Text = fileName;

            pdfOpened.DeleteCustomProperties = new List<string>();
            gridProperties.Rows.Clear();

            PdfUtils.GetPdfData(pdfOpened);
            txtKeywords.Text = pdfOpened.Keywords;

            // Load Custom Properties
            foreach (var property in pdfOpened.CustomProperties.OrderBy(o => o.Key))
            {
                gridProperties.Rows.Add(new string[] { property.Key, property.Value });
            }
        }

        private void GridProperties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete || gridProperties.CurrentRow == null)
            {
                return;
            }

            try
            {
                var rowKey = gridProperties.CurrentRow.Cells[0]?.Value?.ToString();

                gridProperties.Rows.Remove(gridProperties.CurrentRow);

                if (!string.IsNullOrEmpty(rowKey))
                {
                    pdfOpened.DeleteCustomProperties.Add(rowKey);
                }
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Invalid operation: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error when trying to remove custom property: {ex.Message}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private IDictionary<string, string> ValidateAndGetCustomProperties()
        {
            var customProperties = new Dictionary<string, string>();
            var count = 0;
            foreach (DataGridViewRow row in gridProperties.Rows)
            {
                count++;

                if (row == null || row.Cells == null || (string.IsNullOrEmpty(row.Cells[0]?.Value?.ToString()) && string.IsNullOrEmpty(row.Cells[1]?.Value?.ToString())))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    throw new ArgumentNullException($"Custom Property Name is required in row {count}");
                }

                if (customProperties.Any(x => string.Equals(x.Key, row.Cells[0].Value.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                {
                    throw new Exception($"Custom Property Name is duplicated in row {count}");
                }

                if (row.Cells[1].Value == null)
                {
                    continue;
                }

                customProperties.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
            }

            return customProperties;
        }
    }
}
