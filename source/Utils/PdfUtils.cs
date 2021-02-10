using iTextSharp.text.pdf;
using iTextSharp.text.xml.xmp;
using PDF_Editor.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PDF_Editor.Utils
{
    public static class PdfUtils
    {
        public static string[] ignorePdfBuiltInKeywords = new string[] { "Producer", "Creator", "Keywords", "CreationDate", "ModDate", "Title", "Author" };

        public static void GetPdfData(PdfOpenedDto pdfOpened)
        {
            using (var file = OpenFile(pdfOpened.FilePath))
            {
                using (var reader = new PdfReader(file))
                {
                    pdfOpened.Keywords = reader.Info["Keywords"]?.ToString();
                    pdfOpened.CustomProperties = GetPdfCustomProperties(reader);
                }
            }
        }

        public static void SavePdfData(PdfOpenedDto pdfOpened)
        {
            
            using (var file = OpenFile(pdfOpened.FilePath))
            {
                using (var reader = new PdfReader(file))
                {
                    using (var output = new MemoryStream())
                    {
                        using (var stamper = new PdfStamper(reader, output))
                        {
                            var saveInfo = reader.Info;
                            saveInfo["Keywords"] = pdfOpened.Keywords;
                            SaveCustomProperties(saveInfo, pdfOpened.CustomProperties, pdfOpened.DeleteCustomProperties);
                            stamper.MoreInfo = saveInfo;

                            using (var xmpMs = new MemoryStream())
                            {
                                var xmp = new XmpWriter(xmpMs, saveInfo);
                                stamper.XmpMetadata = xmpMs.ToArray();
                                xmp.Close();
                            }
                        }

                        var fileBytes = output.ToArray();
                        File.WriteAllBytes(pdfOpened.FilePath, fileBytes);
                    }
                }
            }
        }

        private static MemoryStream OpenFile(string filePath)
        {
            MemoryStream file = new MemoryStream();
            using (FileStream fs = File.OpenRead(filePath))
            {
                fs.CopyTo(file);
            }

            file.Position = 0;
            return file;
        }

        private static IDictionary<string, string> GetPdfCustomProperties(PdfReader reader)
        {
            var properties = new Dictionary<string, string>();
            foreach (var key in reader.Info.Keys)
            {
                if (ignorePdfBuiltInKeywords.Any(x => string.Equals(x, key)))
                {
                    continue;
                }

                var keyValue = reader.Info[key]?.ToString();
                if (string.IsNullOrEmpty(keyValue?.Trim()))
                {
                    continue;
                }

                properties.Add(key.ToString(), keyValue);
            }

            return properties;
        }

        private static void SaveCustomProperties(IDictionary<string, string> saveInfos, IDictionary<string, string> customProperties, IList<string> deleteProperties)
        {
            foreach(var deleteProperty in deleteProperties)
            {
                var stamperProp = saveInfos.FirstOrDefault(x => string.Equals(x.Key, deleteProperty, StringComparison.InvariantCultureIgnoreCase));
                if (!string.IsNullOrEmpty(stamperProp.Key))
                {
                    saveInfos[stamperProp.Key] = null;
                }                    
            }

            foreach(var customProperty in customProperties)
            {
                var stamperProp = saveInfos.FirstOrDefault(x => string.Equals(x.Key, customProperty.Key, StringComparison.InvariantCultureIgnoreCase));

                if (string.IsNullOrEmpty(stamperProp.Key))
                {
                    saveInfos.Add(customProperty.Key, customProperty.Value);
                }
                else
                {
                    saveInfos[stamperProp.Key] = customProperty.Value;
                }
            }            
        }
    }
}
