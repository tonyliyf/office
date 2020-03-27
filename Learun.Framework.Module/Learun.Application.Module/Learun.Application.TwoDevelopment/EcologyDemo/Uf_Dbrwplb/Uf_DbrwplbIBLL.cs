using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-01-02 10:05
    /// 描 述：督办任务评论
    /// </summary>
    public interface Uf_DbrwplbIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<uf_dbrwplbEntity> GetList(string taskid, string subtaskid);

        DataSet GettableList(string taskikd, string subtaskid);
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<uf_dbrwplbEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        uf_dbrwplbEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SaveEntity(string keyValue, uf_dbrwplbEntity entity);

        /// <summary>
        /// 保存实体数据（评论回复）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SavePLHF(string keyValue, uf_dbrwplbEntity entity,string replyid);
        #endregion

    }
}
