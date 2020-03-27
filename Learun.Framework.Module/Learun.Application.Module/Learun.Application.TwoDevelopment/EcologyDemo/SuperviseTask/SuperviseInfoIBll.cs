using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.EcologyDemo.SuperviseTask
{
    public interface SuperviseInfoIBll
    {


        DataTable GetUserid(string cookieid);
        //1获取督办主任务


        DataTable GetTaskInfo(int type);

        DataTable GetTaskDetailInfo(int id);

        //获取督办子任务

        DataTable GetSubTaskInfo(int taskid);


        //获取子任务详细

        DataTable GetSubTaskDetailInfo(int id);

        //获取主任务督办评论
        DataSet GetTaskPl(string  taskid);

        //插入主任务督办评论

        //获取子任务督办评论

        DataSet GetSubTaskPl(string taskid,string subid);

        //督办任务，协办任务，办结任务数据列表
        DataTable GetMaxTaskInfo(string userid, string type);
        //督办任务数据数量
        DataTable GetMaxTaskNum(string userid);
        //协办任务数据数量
        DataTable GetMaxAssistNum(string userid);
        //办结任务数据数量
        DataTable GetMaxEndNum(string userid);
        //执行任务详细
        DataTable GetMaxTasklist(string id);

        /// <summary>
        /// 保存实体数据（修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void UpdateTasklist(string keyValue, uf_durwzxnewEntity entity);
        /// <summary>
        /// 保存实体数据（办结）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SaveTasklist(string keyValue);
      
    }
}
