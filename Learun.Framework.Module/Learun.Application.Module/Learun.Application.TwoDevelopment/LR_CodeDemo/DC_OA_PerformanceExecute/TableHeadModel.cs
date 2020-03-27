using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public class TableHeadModel
    {
        public TableHeadModel(string label, string name, int width = 100)
        {
            this.label = label;
            this.name = name;
            this.width = width;
            this.align = "center";
        }
        public string label { get; set; }
        public string name { get; set; }
        public int width { get; set; }
        public string align { get; set; }
    }
}
