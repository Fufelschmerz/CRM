namespace CRM.Application.Infrastructure.Files.Excel.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using ClosedXML.Excel;
    using Abstractions;

    public class ExcelService : IExcelService
    {
        public byte[] ExportData<T>(IEnumerable<string> header, IEnumerable<T> data, string tableName)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(tableName);

                FillHeader(worksheet, header);
                
                FillBody(worksheet, data);

                return CreateArrayOfBytes(workbook);
            }
        }

        private void FillHeader(IXLWorksheet worksheet, IEnumerable<string> header)
        {
            int currentRow = 1; 
            int currentColumn = 1;
            foreach (var h in header)
            {
                worksheet.Cell(currentRow, currentColumn).Value = h;
                currentColumn++;
            }
        }

        private void FillBody<T>(IXLWorksheet worksheet, IEnumerable<T> data)
        {
            int currentRow = 2;

            foreach (var d in data)
            {
                int currentColumn = 1;

                var properties = d.GetType().GetProperties().Select(x=>x.GetValue(d));

                foreach (var p in properties)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = p;
                    currentColumn++;
                }
                
                currentRow++;
            }
        }

        private byte [] CreateArrayOfBytes(XLWorkbook workbook)
        {
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);

                return stream.ToArray();
            }
        }
    }
}