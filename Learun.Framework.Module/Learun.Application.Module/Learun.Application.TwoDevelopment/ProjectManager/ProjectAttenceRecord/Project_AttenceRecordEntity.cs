using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-07-30 15:42
    /// 描 述：项目考勤记录
    /// </summary>
    public class Project_AttenceRecordEntity 
    {
        #region 实体成员
        /// <summary>
        /// 考勤记录主键
        /// </summary>
        [Column("PROJECT_ATTENCERECORDID")]
        public string Project_AttenceRecordId { get; set; }
        /// <summary>
        /// 考勤日期
        /// </summary>
        [Column("PROJECT_ATTENCEDATE")]
        public DateTime? Project_AttenceDate { get; set; }
        /// <summary>
        /// 考勤时间
        /// </summary>
        [Column("PROJECT_ATTENCEDATETIME")]
        public DateTime? Project_AttenceDateTime { get; set; }


        /// <summary>
        /// 第一次打卡时间
        /// </summary>
        [Column("F_FirstAttenceDateTime")]
        public DateTime? F_FirstAttenceDateTime { get; set; }



        /// <summary>
        /// 第二次打卡时间
        /// </summary>
        [Column("F_SecondAttenceDateTime")]
        public DateTime? F_SecondAttenceDateTime { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// 打卡人部门ID
        /// </summary>
        [Column("F_PROJECT_ATTENCEDEPTID")]
        public string F_Project_AttenceDeptId { get; set; }
        /// <summary>
        /// 打卡人公司ID
        /// </summary>
        [Column("F_PROJECT_ATTENCECOMPANYID")]
        public string F_Project_AttenceCompanyId { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        [Column("LONGITUDE")]
        public string longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [Column("LATITUDE")]
        public string latitude { get; set; }
        /// <summary>
        /// 打卡类型(上午签到、上午签退、下午签到、下午签退）
        /// </summary>
        [Column("F_PROJECT_REPAIRTYPE")]
        public string F_Project_RepairType { get; set; }
        /// <summary>
        /// 打卡来源（手机，电脑）
        /// </summary>
        [Column("F_RECORDFROM")]
        public string F_RecordFrom { get; set; }
        /// <summary>
        /// 定位地点
        /// </summary>
        [Column("F_GPSLOCATION")]
        public string F_GpsLocation { get; set; }
        /// <summary>
        /// 打卡人id
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 打卡人姓名
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 打卡人班级
        /// </summary>
        [Column("F_CLASS")]
        public string F_Class { get; set; }
        /// <summary>
        /// 打卡人职位
        /// </summary>
        [Column("F_TITILE")]
        public string F_Titile { get; set; }
        /// <summary>
        /// 所在项目组
        /// </summary>
        [Column("F_PROJECTID")]
        public string F_ProjectId { get; set; }
        /// <summary>
        /// 考勤月份（如２０１９０４）
        /// </summary>
        [Column("F_MONTH")]
        public string F_Month { get; set; }
        /// <summary>
        /// 监理单位
        /// </summary>
        [Column("F_SUPERVISIONCOMPANY")]
        public string F_SupervisionCompany { get; set; }
        /// <summary>
        /// 建设单位
        /// </summary>
        [Column("F_BUILDCOMPANY")]
        public string F_BuildCompany { get; set; }
        /// <summary>
        /// 施工单位
        /// </summary>
        [Column("F_CONSTRUCTIONCOMPANY")]
        public string F_constructionCompany { get; set; }
        /// <summary>
        /// 考勤天数
        /// </summary>
        [Column("PROJECT_ATTENCEDAYS")]
        public string Project_Attencedays { get; set; }
        /// <summary>
        /// 考勤号码
        /// </summary>
        [Column("PROJECT_ATTENCEDNUMBER")]
        public string Project_Attencednumber { get; set; }
        /// <summary>
        /// 机器码
        /// </summary>
        [Column("PROJECT_MODE")]
        public string Project_mode { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [Column("PROJECT_CODE")]
        public string Project_code { get; set; }
        /// <summary>
        /// 对比方式
        /// </summary>
        [Column("PROJECT_COMPARE")]
        public string Project_compare { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.Project_AttenceRecordId = Guid.NewGuid().ToString();
            //UserInfo userInfo = LoginUserInfo.Get();
            //this.F_CreateUserId = userInfo.userId;
            //this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify( string keyValue)
        {
            this.Project_AttenceRecordId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

