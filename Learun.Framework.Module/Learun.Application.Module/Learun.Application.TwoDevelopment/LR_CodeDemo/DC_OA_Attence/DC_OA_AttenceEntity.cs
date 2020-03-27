using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-25 16:49
    /// 描 述：DC_OA_Attence
    /// </summary>
    public class DC_OA_AttenceEntity
    {
        #region 实体成员 

        /// <summary> 
        /// 考勤人姓名 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_OA_ATTENCEUSERNAME")]
        public string F_OA_AttenceUserName { get; set; }

        /// <summary> 
        /// 部门名称 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_DEPTNAME")]
        public string F_DeptName { get; set; }


        /// <summary>
        /// 岗位名称
        /// </summary>
        [Column("POSTNAME")]
        public string PostName { get; set; }

        /// <summary> 
        /// 考勤月份 
        /// </summary> 
        /// <returns></returns> 
        [Column("DC_OA_ATTENCEMONTH")]
        public string DC_OA_AttenceMonth { get; set; }
             
      
        /// <summary> 
        /// 出勤天数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SUMDAYS")]
        public int? F_SumDays { get; set; }
        /// <summary> 
        /// 正常天数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_COMONDAYS")]
        public int? F_ComonDays { get; set; }
        /// <summary> 
        /// 请假天数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_LEAVEDAYS")]
        public double? F_LeaveDays { get; set; }

        /// <summary> 
        /// 出差天数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_OUTDAYS")]
        public double? F_OutDays { get; set; }
        /// <summary> 
        /// 上班缺卡 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_FORGETNUMS")]
        public int? F_ForgetNums { get; set; }
        /// <summary> 
        /// 补卡次数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_REPAIRNUMS")]
        public int? F_RepairNums { get; set; }
      
       
        /// <summary> 
        /// 迟到早退次数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_LATERNUMS")]
        public int? F_laterNums { get; set; }
        /// <summary> 
        /// 下班缺卡 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_OUTFORGETNUMS")]
        public int? F_OutForgetNums { get; set; }
        /// <summary> 
        /// 旷工天数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_NOTWORKDAYS")]
        public double? F_NotWorkDays { get; set; }
        /// <summary> 
        /// 事假天数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_THINGDAYS")]
        public double? F_thingDays { get; set; }
        /// <summary> 
        /// 休假天数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_XIUJIADAYS")]
        public double? F_xiujiaDays { get; set; }
        /// <summary> 
        /// 报备天数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_PERSONBACKDAYS")]
        public double? F_PersonBackDays { get; set; }
        /// <summary> 
        /// 病假天数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_SICKLEAVEDAYS")]
        public double? F_SickLeaveDays { get; set; }
        /// <summary> 
        /// 调休天数 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_TIAODAYS")]
        public double? F_TiaoDays { get; set; }

        /// <summary> 
        /// 工作时长 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_WORKHOURS")]
        public double? F_WorkHours { get; set; }



        /// <summary> 
        /// day1 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY1")]
        public string day1 { get; set; }
        /// <summary> 
        /// day2 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY2")]
        public string day2 { get; set; }
        /// <summary> 
        /// day3 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY3")]
        public string day3 { get; set; }
        /// <summary> 
        /// day4 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY4")]
        public string day4 { get; set; }
        /// <summary> 
        /// day5 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY5")]
        public string day5 { get; set; }
        /// <summary> 
        /// day6 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY6")]
        public string day6 { get; set; }
        /// <summary> 
        /// day7 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY7")]
        public string day7 { get; set; }
        /// <summary> 
        /// day8 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY8")]
        public string day8 { get; set; }
        /// <summary> 
        /// day9 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY9")]
        public string day9 { get; set; }
        /// <summary> 
        /// day10 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY10")]
        public string day10 { get; set; }
        /// <summary> 
        /// day11 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY11")]
        public string day11 { get; set; }
        /// <summary> 
        /// day12 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY12")]
        public string day12 { get; set; }
        /// <summary> 
        /// day13 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY13")]
        public string day13 { get; set; }
        /// <summary> 
        /// day14 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY14")]
        public string day14 { get; set; }
        /// <summary> 
        /// day15 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY15")]
        public string day15 { get; set; }
        /// <summary> 
        /// day16 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY16")]
        public string day16 { get; set; }
        /// <summary> 
        /// day17 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY17")]
        public string day17 { get; set; }
        /// <summary> 
        /// day18 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY18")]
        public string day18 { get; set; }
        /// <summary> 
        /// day19 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY19")]
        public string day19 { get; set; }
        /// <summary> 
        /// day20 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY20")]
        public string day20 { get; set; }
        /// <summary> 
        /// day21 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY21")]
        public string day21 { get; set; }
        /// <summary> 
        /// day22 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY22")]
        public string day22 { get; set; }
        /// <summary> 
        /// day23 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY23")]
        public string day23 { get; set; }
        /// <summary> 
        /// day24 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY24")]
        public string day24 { get; set; }
        /// <summary> 
        /// day25 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY25")]
        public string day25 { get; set; }
        /// <summary> 
        /// day26 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY26")]
        public string day26 { get; set; }
        /// <summary> 
        /// day27 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY27")]
        public string day27 { get; set; }
        /// <summary> 
        /// day28 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY28")]
        public string day28 { get; set; }
        /// <summary> 
        /// day29 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY29")]
        public string day29 { get; set; }
        /// <summary> 
        /// day30 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY30")]
        public string day30 { get; set; }
        /// <summary> 
        /// day31 
        /// </summary> 
        /// <returns></returns> 
        [Column("DAY31")]
        public string day31 { get; set; }


        /// <summary> 
        /// 考勤表主键 
        /// </summary> 
        /// <returns></returns> 
        [Column("DC_OA_ATTENCEID")]
        public string DC_OA_AttenceId { get; set; }

        /// <summary> 
        /// 有效标志0否1是 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary> 
        /// 创建人ID 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary> 
        /// 编辑人 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary> 
        /// 编辑人ID 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary> 
        /// 删除标记0否1是 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }

        /// <summary> 
        /// 编辑日期 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary> 
        /// 创建人 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary> 
        /// 创建时间 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary> 
        /// 备注 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary> 
        /// 考勤人ID 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_OA_ATTENCEUSERID")]
        public string F_OA_AttenceUserId { get; set; }
        /// <summary> 
        /// 考勤人部门ID 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_OA_ATTENCEDEPTID")]
        public string F_OA_AttenceDeptId { get; set; }
        /// <summary> 
        /// 考勤人公司ID 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_OA_ATTENCECOMPANYID")]
        public string F_OA_AttenceCompanyId { get; set; }
        /// <summary> 
        /// 考勤类型(正常、迟到、早退、出差、请假） 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_OA_ATTENCETYPE")]
        public string F_OA_AttenceType { get; set; }
        /// <summary> 
        /// 公司名称 
        /// </summary> 
        /// <returns></returns> 
        [Column("F_COMPANYNAME")]
        public string F_CompanyName { get; set; }
        #endregion

        #region 扩展操作 
        /// <summary> 
        /// 新增调用 
        /// </summary> 
        public void Create()
        {
            this.DC_OA_AttenceId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary> 
        /// 编辑调用 
        /// </summary> 
        /// <param name="keyValue"></param> 
        public void Modify(string keyValue)
        {
            this.DC_OA_AttenceId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
    }
}

