using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Util.Calculate;
using Learun.Application.Organization;
using Learun.Cache.Base;
using Learun.Cache.Factory;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-26 16:32
    /// 描 述：打卡记录
    /// </summary>
    public class DC_OA_AttenceRecordBLL : DC_OA_AttenceRecordIBLL
    {
        private DC_OA_AttenceRecordService dC_OA_AttenceRecordService = new DC_OA_AttenceRecordService();
        private DC_OA_AttenceSettingIBLL settingBLL = new DC_OA_AttenceSettingBLL();
        private UserIBLL userIBll = new UserBLL();
        private ICache cache = CacheFactory.CaChe();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表分页数据
        /// <summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_AttenceRecordEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_AttenceRecordService.GetPageList(pagination, queryJson);
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



        public IEnumerable<DC_OA_AttenceRecordEntity> GetMyPageList(UserInfo userInfo, Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_AttenceRecordService.GetMyPageList(userInfo,pagination, queryJson);
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

        public DataTable GetList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_AttenceRecordService.GetList(pagination, queryJson);
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

        public IEnumerable<DC_OA_AttenceRecordEntity> GetList(DateTime dt, DateTime dtEnd)
        {
            try
            {
                return dC_OA_AttenceRecordService.GetList(dt, dtEnd);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_AttenceRecordEntity> GetList(string queryJson)
        {
            try
            {
                return dC_OA_AttenceRecordService.GetList(queryJson);
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
        /// 获取DC_OA_AttenceRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_AttenceRecordEntity GetDC_OA_AttenceRecordEntity(string keyValue)
        {
            try
            {
                return dC_OA_AttenceRecordService.GetDC_OA_AttenceRecordEntity(keyValue);
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
                dC_OA_AttenceRecordService.DeleteEntity(keyValue);
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
        public void SaveEntity(UserInfo userInfo, string keyValue, DC_OA_AttenceRecordEntity entity)
        {
            try
            {
                dC_OA_AttenceRecordService.SaveEntity(userInfo, keyValue, entity);
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


        public void SaveRecord(UserInfo userInfo, DC_OA_AttenceRecordEntity entity)
        {

            entity.F_CreateUserName = userInfo.realName;
            entity.F_OA_AttenceCompanyId = userInfo.companyId;
            entity.F_OA_AttenceDeptId = userInfo.departmentId;
            entity.DC_OA_AttenceRecordId = Guid.NewGuid().ToString();
            dC_OA_AttenceRecordService.SaveEntity(entity);

        }


        public bool SaveRecord(UserInfo userInfo, DC_OA_AttenceRecordEntity entity, ref string Msg)
        {
            bool IsTrue = false;
            Msg = "打卡成功";


            DC_OA_AttenceSettingEntity settingEntity = cache.Read<DC_OA_AttenceSettingEntity>("DC_OA_AttenceSetting", CacheId.language);
            if (settingEntity == null)
            {
                settingEntity = settingBLL.GetEnableDC_OA_AttenceSettingEntity();
                cache.Write<DC_OA_AttenceSettingEntity>("DC_OA_AttenceSetting", settingEntity,CacheId.language);
            }
                 
            if(settingEntity!=null)
            {
                double log1 = double.Parse(settingEntity.DC_OA_AttenceLongitude);
                double lat1 = double.Parse(settingEntity.DC_OA_AttenceLatitude);
                double log2 = double.Parse(entity.longitude);
                double lat2 = double.Parse(entity.latitude);
                double instance = LatLonUtil.GetDistance(log1, lat1, log2, lat2);
                 if(instance<= (double)settingEntity.DC_OA_AttenceDistance)//打卡距离小于设定的范围则打卡有效
                {
                    IsTrue = true;
                    entity.F_EnabledMark = 1;
                }
                 else
                {
                    entity.F_EnabledMark = 0;//打卡无效，把记录记入
                    Msg = "不在设定的有限范围内，打卡无效！";
            
                }
                 //插入记录，不管记录有无效，都插入，做为原始记录
                SaveRecord(userInfo,entity);
            }

          
            return IsTrue;
        }


        public bool SaveRecord(UserInfo userInfo, string longitude, string latitude, ref string Msg)
        {
            try
            {
                bool IsTrue = false;
                Msg = "打卡成功";

                DC_OA_AttenceSettingEntity settingEntity = cache.Read<DC_OA_AttenceSettingEntity>("DC_OA_AttenceSetting", CacheId.language);

                if (settingEntity == null)
                {
                    settingEntity = settingBLL.GetEnableDC_OA_AttenceSettingEntity();
                    cache.Write<DC_OA_AttenceSettingEntity>("DC_OA_AttenceSetting", settingEntity, CacheId.language);
                }
                 if (settingEntity != null)
                {
                    DC_OA_AttenceRecordEntity entity = new DC_OA_AttenceRecordEntity();

                    DateTime dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                            settingEntity.DC_OA_AttenceTimeUp1.Value.Hour, settingEntity.DC_OA_AttenceTimeUp1.Value.Minute, 0);//早上上班时间
                    DateTime dt2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                      settingEntity.DC_OA_AttenceTimeOut1.Value.Hour, settingEntity.DC_OA_AttenceTimeOut1.Value.Minute, 0);//中午下班时间
                    DateTime dt3 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                       settingEntity.DC_OA_AttencetTimeUp2.Value.Hour, settingEntity.DC_OA_AttencetTimeUp2.Value.Minute, 0);//下午上班时间
                    DateTime dt4 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                      settingEntity.DC_OA_AttenceTimeOut2.Value.Hour, settingEntity.DC_OA_AttenceTimeOut2.Value.Minute, 0);//下午下班时间

                    entity.F_CreateUserId = userInfo.userId;
                    entity.DC_OA_AttenceDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    entity.DC_OA_AttenceDateTime = DateTime.Now;

                    if(DateTime.Now.Hour<5)
                    {
                        entity.F_EnabledMark = 0;
                        Msg = "早上打卡设定时间范围在5点以后，本次打卡无效！";
                    }
                    else if (DateTime.Now.Hour >=5&&DateTime.Now<=dt1)
                    {
                        entity.F_OA_RepairType = "上班打卡";//上午打卡
                        entity.F_EnabledMark = 1;
                    }
                    else if(DateTime.Now>dt1&&DateTime.Now<dt4)
                    {
                        entity.F_OA_RepairType = "迟到早退";//上午打卡
                        //Msg ="您没在规定的时间范围内打卡，"
                       entity.F_EnabledMark = 1;
                    }
                       //else if(DateTime.Now>dt1.AddHours(-1)&&DateTime.Now<dt2.AddHours(-1))//打卡无效
                    //{
                    //    entity.F_OA_RepairType = "签到无效";//上午打卡
                    //    entity.F_EnabledMark =0;
                    //    Msg = "您已超过上班打卡时间，需要申请补卡或请假流程，打卡无效！";
                    //}
                    //else if (DateTime.Now >= dt2.AddHours(-1)&& DateTime.Now < dt2.AddHours(1))//下班一个小时之前，打卡示为有效
                    //{
                    //    entity.F_OA_RepairType = "上午签退";//上午下班打卡
                    //    entity.F_EnabledMark = 1;
                    //}
                    //else if (DateTime.Now >= dt2.AddHours(1) && DateTime.Now < dt3.AddHours(1))//下班一个小时之后，在下午上班之前为有效
                    //{
                    //    entity.F_OA_RepairType = "下午签到";//下午上班打卡
                    //    entity.F_EnabledMark = 1;
                    //}
                    //else if(DateTime.Now>dt3.AddHours(1)&&DateTime.Now<dt4.AddHours(-1)) //表示下午中途下班
                    //{
                    //    entity.F_OA_RepairType = "签到无效";//上午打卡
                    //    entity.F_EnabledMark = 0;
                    //    Msg = "您提前下班，需要申请补卡或请假流程，打卡无效！";
                    //}
                    else if (DateTime.Now >= dt4&&DateTime.Now.Hour<=22)
                    {
                        entity.F_OA_RepairType = "下班打卡";//下午下班打卡
                        entity.F_EnabledMark = 1;
                    }
                    else
                    {
                        entity.F_EnabledMark = 0;
                        Msg = "下班打卡设定在晚上11点以前，本次打卡无效！";
                    }

                    entity.latitude = latitude;
                    entity.longitude = longitude;
                    double log1 = double.Parse(settingEntity.DC_OA_AttenceLongitude);
                    double lat1 = double.Parse(settingEntity.DC_OA_AttenceLatitude);
                    double log2 = double.Parse(longitude);
                    double lat2 = double.Parse(latitude);
                    double instance = LatLonUtil.GetDistance(log1, lat1, log2, lat2);
                    // Msg += string.Format(" 计算的距离为{0}", instance.ToString());
                    //  System.IO.File.WriteAllText("d:\\aa.txt", "距离:"+instance.ToString());
                    if (entity.F_EnabledMark != 0)
                    {
                        if (instance <= (double)settingEntity.DC_OA_AttenceDistance)//打卡距离小于设定的范围则打卡有效
                        {
                            IsTrue = true;
                        }
                        else
                        {
                            entity.F_EnabledMark = 0;//打卡无效，把记录记入
                            Msg = "您不在设定的有限范围内，打卡无效！";
                        }
                    }
                    entity.F_Description = Msg;
                    //插入记录，不管记录有无效，都插入，做为原始记录
                    SaveRecord(userInfo, entity);
                }
                return IsTrue;
            }
            catch(Exception ex)
            {              
               Msg = Msg+"错误:"+ ex.Message.ToString();
                return false;
            }
        }
        #endregion

    }
}
