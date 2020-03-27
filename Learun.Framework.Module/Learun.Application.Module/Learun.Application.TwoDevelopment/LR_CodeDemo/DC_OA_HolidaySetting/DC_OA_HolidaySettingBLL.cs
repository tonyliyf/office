using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-04 11:32
    /// 描 述：节假日设置
    /// </summary>
    public class DC_OA_HolidaySettingBLL : DC_OA_HolidaySettingIBLL
    {
        private DC_OA_HolidaySettingService dC_OA_HolidaySettingService = new DC_OA_HolidaySettingService();

        #region 获取数据
        public IEnumerable<DC_OA_HolidaySettingEntity> GetHolidayDataByMonth(DateTime time)
        {
            try
            {
                return dC_OA_HolidaySettingService.GetHolidayDataByMonth(time);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_HolidaySettingEntity> GetList(string queryJson)
        {
            try
            {
                return dC_OA_HolidaySettingService.GetList(queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }


        public IEnumerable<DC_OA_HolidaySettingEntity> GetList(DateTime dtStart, DateTime dtEnd)
        {
            try
            {
                return dC_OA_HolidaySettingService.GetList(dtStart,dtEnd);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_HolidaySettingEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_HolidaySettingService.GetPageList(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_HolidaySettingEntity GetEntity(string keyValue)
        {
            try
            {
                return dC_OA_HolidaySettingService.GetEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                dC_OA_HolidaySettingService.DeleteEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_OA_HolidaySettingEntity entity)
        {
            try
            {
                dC_OA_HolidaySettingService.SaveEntity(keyValue, entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public void InitHoliday(int startyear, int endyear)
        {
            List<HolidayInfo> list = HolidayInit.InitHoliday(startyear, endyear);


            try
            {
                dC_OA_HolidaySettingService.SaveHolidayInfo(list);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }



        }


        #endregion

    }
}
