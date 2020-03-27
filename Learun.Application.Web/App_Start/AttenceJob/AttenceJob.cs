using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;
using Learun.Application.Organization;
using Learun.Application.Message;
using Learun.Application.TwoDevelopment.ProjectManager;

namespace Learun.Application.Web.App_Start.AttenceJob
{


   
    public class AttenceJob : IJob
    {
        private DC_OA_HolidaySettingIBLL dC_OA_HolidaySettingIBLL = new DC_OA_HolidaySettingBLL();//节假日操作
        private DC_OA_AttenceSettingIBLL dC_OA_AttenceSettingIBLL = new DC_OA_AttenceSettingBLL();//考勤设置
        private DC_OA_AttenceRecordIBLL dC_OA_AttenceRecordIBLL = new DC_OA_AttenceRecordBLL();//打卡记录
        private DC_OA_AttenceRepairRocordIBLL dc_OA_AttenceRepairdIBLL = new DC_OA_AttenceRepairRocordBLL();//  补卡记录
        private LeaveReqIBLL leaveReqIBLL = new LeaveReqBLL(); //leave请假
        private EvectionReqIBLL evectionReqIBLL = new EvectionReqBLL();//出差
        private DC_OA_AttenceRecordIBLL DC_OA_AttenceRecordBLL = new DC_OA_AttenceRecordBLL();//考勤记录
        private UserIBLL userIBLL = new UserBLL();
        private LR_StrategyInfoIBLL lR_Strategy = new LR_StrategyInfoBLL();
        private DC_EngineProject_ProjectInfoContractBLL ibll = new DC_EngineProject_ProjectInfoContractBLL();

        public void Execute(IJobExecutionContext context)
        {
            ibll.UpdateProjectContract();
            /////定时任务，每个月第一天生成上个月人员考勤记录
            ////考勤生成，根据 假日表（节假日，周未不记考勤）、请假表，出差记录表，打卡记录及补卡记录生成
            ////获取上个月，所有人出差记录
            ////获取上个月，所有人打卡记录
            ////获取上个月，所有人请假记录
            ////获取上个月，所有人补卡记录
            ////获取上个月假日，周未
            ////获取考勤设置，判断上下班时间是否正常
            ////获取上个月第一天
            //DateTime dtStart = Time.FirstDayOfPreviousMonth(DateTime.Now);
            ////获取这个月第一天
            //DateTime dtEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //List<UserEntity> Userlist = userIBLL.GetAllList();//所有人
            //var Leavelist = leaveReqIBLL.GetList(dtStart, dtEnd);//在此区间内的请假
            //var Evectionlist = evectionReqIBLL.GetList(dtStart, dtEnd);
            //var Repairlist = dc_OA_AttenceRepairdIBLL.GetList(dtStart,dtEnd);
            ////消息注册中的code，必须填写
            //lR_Strategy.SendMessage("",)


        }
    }
}