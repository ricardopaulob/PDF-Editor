using System.Collections.Generic;

namespace PDF_Editor.DTOs
{
    public class PdfOpenedDto
    {
        public PdfOpenedDto()
        {
            DeleteCustomProperties = new List<string>();
        }

        public string FilePath { get; set; }

        public string Keywords { get; set; }

        public IDictionary<string, string> CustomProperties { get; set; }

        public IList<string> DeleteCustomProperties { get; set; }
    }
}
