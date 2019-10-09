using System.Collections.Generic;

namespace Softline.UI.ViewModels
{
    public class ParseViewModel
    {
        public string DbName { get; set; }

        public string FilePath { get; set; }

        public bool IsFirstRowTitle { get; set; }

        public SeparatorType Separator { get; set; }

        public List<string> TableTitle { get; set; }

        public List<Row> TableData { get; set; }
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
