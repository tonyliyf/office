using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public class EasyUiTreeModel
    {
        public EasyUiTreeModel(string _id, string _text, bool isFolder, bool isDepartment, bool _checked, bool isRoot = false, string _parentName = "")
        {
            this.id = _id;
            this.text = _text;
            if (isFolder)
            {
                this.iconCls = "icon-folder";
            }
            else
            {
                if (isDepartment)
                {
                    this.iconCls = "icon-department";
                }
                else
                {
                    this.iconCls = "icon-company";
                }
            }
            this.state = "closed";
            this.@checked = _checked;
            this.attributes = new UserAttrebutes(isDepartment, isFolder, isRoot, _parentName);
            this.children = new List<EasyUiTreeModel>();
        }
        public string id { get; set; }
        public string text { get; set; }
        public string iconCls { get; set; }
        public bool @checked { get; set; }
        public string state { get; set; }
        public UserAttrebutes attributes { get; set; }

        public List<EasyUiTreeModel> children { get; set; }
    }
    public class UserAttrebutes
    {
        public UserAttrebutes(bool _isDepartment, bool _isFolder, bool _isRoot = false, string _parentName = "")
        {
            this.isDepartment = _isDepartment;
            this.isFolder = _isFolder;
            this.parentName = _parentName;
            this.isRoot = _isRoot;
        }
        public bool isDepartment { get; set; }
        public bool isFolder { get; set; }
        public string parentName { get; set; }
        public bool isRoot { get; set; }
    }
}
