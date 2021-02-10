using PDF_Editor.DTOs;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace PDF_Editor.Utils
{
    public static class FileHandler
    {
        public static PdfOpenedDto OpenFile(ControlCollection controls)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return new PdfOpenedDto
                    {
                        FilePath = openFileDialog.FileName
                    };
                }

                return null;                
            }
        }
    }
}
