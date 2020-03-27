using Dapper;
using Learun.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public class WfTreeService : RepositoryFactory
    {
        public List<TreeDbModel> GetRawDbData()
        {
            var dp = new DynamicParameters(new { });
            //            return BaseRepository().FindList<TreeDbModel>(
            //                @"select F_CompanyId as id,F_ParentId as pid,F_FullName as name,1 as cj from LR_Base_Company where F_DeleteMark!=1
            //union 
            //select F_DepartmentId asid ,case F_ParentId when '0' then F_CompanyId else F_ParentId end as pid,F_FullName as name, 2 as cj from LR_Base_Department where F_DeleteMark!=1
            //union 
            //select F_PostId as id,case F_ParentId when '0' then F_DepartmentId else F_ParentId end as pid,F_Name as name,3 from LR_Base_Post where F_DeleteMark!=1", dp
            //                ).ToList();
            return BaseRepository().FindList<TreeDbModel>(
                @"select F_CompanyId as id,F_ParentId as pid,F_FullName as name,1 as cj from LR_Base_Company where F_DeleteMark!=1
union 
select F_DepartmentId asid ,case F_ParentId when '0' then F_CompanyId else F_ParentId end as pid,F_FullName as name, 2 as cj from LR_Base_Department where F_DeleteMark!=1", dp
                ).ToList();
        }

        public List<WfTreeModel> GetTreeData()
        {
            var rawData = GetRawDbData();
            List<WfTreeModel> result = new List<WfTreeModel>();
            var root = rawData.Where(c => c.pid == "0").ToList();
            foreach (var rootitem in root)
            {
                var rootnode = new WfTreeModel(rootitem.id, rootitem.name, rootitem.cj);
                RenderChild(rawData, rootnode);
                result.Add(rootnode);
            }
            return result;
        }

        public void RenderChild(List<TreeDbModel> data, WfTreeModel node)
        {
            var child = data.Where(c => c.pid == node.id).ToList();
            foreach (var childitem in child)
            {
                var childnode = new WfTreeModel(childitem.id, childitem.name, childitem.cj);
                RenderChild(data, childnode);
                node.children.Add(childnode);
            }
        }
    }
}
