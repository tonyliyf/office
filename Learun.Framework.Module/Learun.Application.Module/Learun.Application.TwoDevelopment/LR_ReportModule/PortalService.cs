using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public class PortalService : RepositoryFactory
    {
        public DataTable GetSumData()
        {
            UserInfo user = LoginUserInfo.Get();
            string sql = @"select a.num1,b.num2 ,c.num3 from 
        (SELECT count(*)num1 from[dbo].[DeptNotice] where Is_agree = '2' and
        (F_Applicant = @userid or  F_NoticeStaff like @userid)) a
        ,
        (select count(*) num2 from DC_OA_VehicleRepairRecord where
        Is_agree = '2' and F_CreateUserId =@userid) b,
        (select count(*) num3 from DC_OA_PurchaseReply where Is_agree = '2'
        and F_CreateUserId =@userid) c";
            var dp = new DynamicParameters(new { });
            dp.Add("userid", user.userId, DbType.String);
            return this.BaseRepository().FindTable(sql, dp);

        }

    }
}
