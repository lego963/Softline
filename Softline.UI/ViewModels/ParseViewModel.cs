using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Softline.UI.ViewModels
{
    public class ParseViewModel
    {
        public string DbName { get; set; }

        public IFormFile File { get; set; }

        public bool IsFirstRowTitle { get; set; }

        public string Separator { get; set; }

        public string[] SeparatorTypes = { "SignOfTabulation", "Semicolon", "Space", "Another" };

        public List<string> TableTitle { get; set; } = new List<string>();

        public List<Row> TableData { get; set; } = new List<Row>();

    }

    public class Row
    {
        public List<string> RowData { get; set; }

        public Row(List<string> rowData)
        {
            RowData = rowData;
        }
    }
}
