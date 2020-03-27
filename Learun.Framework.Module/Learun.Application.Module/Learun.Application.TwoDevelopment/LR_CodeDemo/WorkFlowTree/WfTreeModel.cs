using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public class WfTreeModel
    {
        public WfTreeModel(string _id, string _text, int cj)
        {
            this.id = _id;
            this.text = _text;

            this.state = "closed";
            this.attributes = new WfAttrebutes(cj);
            this.children = new List<WfTreeModel>();
        }
        public string id { get; set; }
        public string text { get; set; }
        public string iconCls { get; set; }
        public bool @checked { get; set; }
        public string state { get; set; }
        public WfAttrebutes attributes { get; set; }

        public List<WfTreeModel> children { get; set; }
    }
    public class WfAttrebutes
    {
        public WfAttrebutes(int _cj)
        {
            this.cj = _cj;
        }
        public int cj { get; set; }
    }
}
