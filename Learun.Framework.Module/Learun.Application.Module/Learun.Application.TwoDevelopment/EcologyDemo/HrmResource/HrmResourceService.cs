using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-02 15:29
    /// 描 述：HrmResource
    /// </summary>
    public class HrmResourceService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public HrmResourceService()
        {
            fieldSql=@"
                t.id,
                t.loginid,
                t.password,
                t.lastname,
                t.sex,
                t.birthday,
                t.nationality,
                t.systemlanguage,
                t.maritalstatus,
                t.telephone,
                t.mobile,
                t.mobilecall,
                t.email,
                t.locationid,
                t.workroom,
                t.homeaddress,
                t.resourcetype,
                t.startdate,
                t.enddate,
                t.jobtitle,
                t.jobactivitydesc,
                t.joblevel,
                t.seclevel,
                t.departmentid,
                t.subcompanyid1,
                t.costcenterid,
                t.managerid,
                t.assistantid,
                t.bankid1,
                t.accountid1,
                t.resourceimageid,
                t.createrid,
                t.createdate,
                t.lastmodid,
                t.lastmoddate,
                t.lastlogindate,
                t.datefield1,
                t.datefield2,
                t.datefield3,
                t.datefield4,
                t.datefield5,
                t.numberfield1,
                t.numberfield2,
                t.numberfield3,
                t.numberfield4,
                t.numberfield5,
                t.textfield1,
                t.textfield2,
                t.textfield3,
                t.textfield4,
                t.textfield5,
                t.tinyintfield1,
                t.tinyintfield2,
                t.tinyintfield3,
                t.tinyintfield4,
                t.tinyintfield5,
                t.certificatenum,
                t.nativeplace,
                t.educationlevel,
                t.bememberdate,
                t.bepartydate,
                t.workcode,
                t.regresidentplace,
                t.healthinfo,
                t.residentplace,
                t.policy,
                t.degree,
                t.height,
                t.usekind,
                t.jobcall,
                t.accumfundaccount,
                t.birthplace,
                t.folk,
                t.residentphone,
                t.residentpostcode,
                t.extphone,
                t.managerstr,
                t.status,
                t.fax,
                t.islabouunion,
                t.weight,
                t.tempresidentnumber,
                t.probationenddate,
                t.countryid,
                t.passwdchgdate,
                t.needusb,
                t.serial,
                t.account,
                t.lloginid,
                t.needdynapass,
                t.dsporder,
                t.passwordstate,
                t.accounttype,
                t.belongto,
                t.dactylogram,
                t.assistantdactylogram,
                t.passwordlock,
                t.sumpasswordwrong,
                t.oldpassword1,
                t.oldpassword2,
                t.msgStyle,
                t.messagerurl,
                t.pinyinlastname,
                t.tokenkey,
                t.userUsbType,
                t.outkey,
                t.adsjgs,
                t.adgs,
                t.adbm,
                t.mobileshowtype,
                t.usbstate,
                t.totalSpace,
                t.occupySpace,
                t.ecology_pinyin_search,
                t.isADAccount,
                t.accountname,
                t.notallot,
                t.beforefrozen,
                t.resourcefrom,
                t.isnewuser,
                t.created,
                t.creater,
                t.modified,
                t.modifier,
                t.salt,
                t.mobilecaflag
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<HrmResourceEntity> GetList( string queryJson )
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                //var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM ecology.dbo.HrmResource t ");
                return this.BaseRepository().FindList<HrmResourceEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<HrmResourceEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM HrmResource t ");
                return this.BaseRepository("ecologySql").FindList<HrmResourceEntity>(strSql.ToString(), pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public HrmResourceEntity GetEntity(int keyValue)
        {
            try
            {
                return this.BaseRepository("ecologySql").FindEntity<HrmResourceEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
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
        public void DeleteEntity(int keyValue)
        {
            try
            {
                this.BaseRepository("ecologySql").Delete<HrmResourceEntity>(t=>t.id == keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(int keyValue, HrmResourceEntity entity)
        {
            try
            {
                if (!keyValue.IsEmpty())
                {
                    entity.Modify(keyValue);
                    this.BaseRepository("ecologySql").Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository("ecologySql").Insert(entity);
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

    }
}
