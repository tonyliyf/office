using System;
using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Learun.Application.TwoDevelopment.AssetManager;
using Learun.Application.Organization;

namespace Learun.Application.TwoDevelopment.SystemDemo
{
    public class DataUtil : RepositoryFactory
    {
        private DC_ASSETS_LandBaseInfoService landservice = new DC_ASSETS_LandBaseInfoService();
        private DC_ASSETS_BuildingBaseInfoService buidlingService = new DC_ASSETS_BuildingBaseInfoService();
        private PostIBLL postIBLL = new PostBLL();
        /// <summary>
        /// 数据初始化，根据地址将土地，房屋坐标初始化
        /// </summary>
        public void InitLandData()
        {
            var db = this.BaseRepository().BeginTrans();
            string address = "枝江市";
            string city = "枝江市";
            try
            {
                var land = db.FindList<DC_ASSETS_LandBaseInfoEntity>();
                //  var building = db.FindList<DC_ASSETS_BuildingBaseInfoEntity>();
                foreach (var item in land)
                {
                    if (item.F_CenterpointCoordinates.IsEmpty()|| item.F_CenterpointCoordinates == "[]")
                    {
                        if (item.F_ParcelAddress.IsEmpty()) continue;
                        item.F_CenterpointCoordinates = string.Format("[{0}]", GaodeHelper.GetGeocode(address + item.F_ParcelAddress, city));
                        item.Modify(item.F_LBIId);
                        db.Update(item);
                    }
                }


                //foreach (var item in building)
                //{
                //    if (item.F_CenterpointCoordinates.IsEmpty())
                //    {
                //        if (item.F_Address.IsEmpty()) continue;
                //        item.F_CenterpointCoordinates = string.Format("[{0}]", GaodeHelper.GetGeocode(address + item.F_Address, city));
                //        item.Modify(item.F_BBIId);
                //        db.Update(item);
                //    }
                //}
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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


        public void InitLandfoodData()
        {
            var db = this.BaseRepository().BeginTrans();
            string address = "枝江市";
            string city = "枝江市";
            try
            {
                var land = db.FindList<DC_ASSETS_LandBaseInfofoodEntity>();
                //  var building = db.FindList<DC_ASSETS_BuildingBaseInfoEntity>();
                foreach (var item in land)
                {
                    if (item.F_CenterpointCoordinates.IsEmpty() || item.F_CenterpointCoordinates == "[]")
                    {
                        if (item.F_ParcelAddress.IsEmpty()) continue;
                        item.F_CenterpointCoordinates = string.Format("[{0}]", GaodeHelper.GetGeocode(address + item.F_ParcelAddress, city));
                        item.Modify(item.F_LBIId);
                        db.Update(item);
                    }
                }


                //foreach (var item in building)
                //{
                //    if (item.F_CenterpointCoordinates.IsEmpty())
                //    {
                //        if (item.F_Address.IsEmpty()) continue;
                //        item.F_CenterpointCoordinates = string.Format("[{0}]", GaodeHelper.GetGeocode(address + item.F_Address, city));
                //        item.Modify(item.F_BBIId);
                //        db.Update(item);
                //    }
                //}
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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


        public void InitBuildingData()
        {
            var db = this.BaseRepository().BeginTrans();
            string address = "枝江市";
            string city = "枝江市";
            try
            {
                //  var land = db.FindList<DC_ASSETS_LandBaseInfoEntity>();
                var building = db.FindList<DC_ASSETS_BuildingBaseInfoEntity>();
                //foreach (var item in land)
                //{
                //    if (item.F_CenterpointCoordinates.IsEmpty())
                //    {
                //        if (item.F_ParcelAddress.IsEmpty()) continue;
                //        item.F_CenterpointCoordinates = string.Format("[{0}]", GaodeHelper.GetGeocode(address + item.F_ParcelAddress, city));
                //        item.Modify(item.F_LBIId);
                //        db.Update(item);
                //    }
                //}


                foreach (var item in building)
                {
                    if (item.F_CenterpointCoordinates.IsEmpty()|| item.F_CenterpointCoordinates=="[]")
                    {
                        if (item.F_Address.IsEmpty()) continue;
                        item.F_CenterpointCoordinates = string.Format("[{0}]", GaodeHelper.GetGeocode(address + item.F_Address, city));
                        item.Modify(item.F_BBIId);
                        db.Update(item);
                    }
                }
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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


        public void InitHouseData()
        {
            var db = this.BaseRepository().BeginTrans();
            string address = "枝江市";
            string city = "枝江市";
            try
            {
                //  var land = db.FindList<DC_ASSETS_LandBaseInfoEntity>();
                var building = db.FindList<DC_ASSETS_BuildingBaseInfoEntity>();
                //foreach (var item in land)
                //{
                //    if (item.F_CenterpointCoordinates.IsEmpty())
                //    {
                //        if (item.F_ParcelAddress.IsEmpty()) continue;
                //        item.F_CenterpointCoordinates = string.Format("[{0}]", GaodeHelper.GetGeocode(address + item.F_ParcelAddress, city));
                //        item.Modify(item.F_LBIId);
                //        db.Update(item);
                //    }
                //}


                foreach (var item in building)
                {
                    var HouseData = db.FindList<DC_ASSETS_HouseInfoEntity>(i => i.F_BBIId == item.F_BBIId);
                    foreach(var obj in HouseData)
                    {
                        if (string.IsNullOrEmpty(obj.F_Address))
                        {
                            obj.F_Address = item.F_Address;

                            obj.Modify(obj.F_HouseID);
                            db.Update(obj);
                        }

                    }
                   
                }
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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




        public void InitBusStopBillboardsData()
        {
            var db = this.BaseRepository().BeginTrans();
            string address = "枝江市";
            string city = "枝江市";
            try
            {
                //  var land = db.FindList<DC_ASSETS_LandBaseInfoEntity>();
                var building = db.FindList<DC_ASSETS_BusStopBillboardsEntity>();
                //foreach (var item in land)
                //{
                //    if (item.F_CenterpointCoordinates.IsEmpty())
                //    {
                //        if (item.F_ParcelAddress.IsEmpty()) continue;
                //        item.F_CenterpointCoordinates = string.Format("[{0}]", GaodeHelper.GetGeocode(address + item.F_ParcelAddress, city));
                //        item.Modify(item.F_LBIId);
                //        db.Update(item);
                //    }
                //}

                foreach (var item in building)
                {
                    if (item.F_CenterpointCoordinates.IsEmpty()||item.F_CenterpointCoordinates== "[]")
                    {
                        if (item.F_InstallationLocation.IsEmpty()) continue;
                        item.F_CenterpointCoordinates = string.Format("[{0}]", GaodeHelper.GetGeocode(address + item.F_InstallationLocation, city));
                        item.Modify(item.F_BSBId);
                        db.Update(item);
                    }
                }
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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


        public void InitGetData()
        {


            try
            {
                //var userEntitys = this.BaseRepository().FindList<UserEntity>();
                //  var land = db.FindList<DC_ASSETS_LandBaseInfoEntity>();
                var datas = this.BaseRepository().FindTable(@"SELECT
    '枝江金润源建设投资控股集团有限公司>' + c.F_FullName AS '分部',
    d.F_FullName AS '部门',
    u.F_EnCode as '编号',
    u.F_RealName as '姓名',
    u.F_Account as '登录名',
    u.F_Password as '密码',
    (case u.F_Gender when 1 then '男' when 0 then '女' else '其他' end)   as '性别',
    u.F_SecurityLevel as '安全级别',
    '' as '岗位',
    '' as '职务',
    '' as  '职务分类',
    '' as '职称',
    '' as '职级',
    '' as '职责描述',
    '' as '上级领导',
    '' as '助理',
    '' as '状态',
    '' as '办公室',
    '' as '办公地点',
    c.F_OuterPhone as '办公电话',
   u.F_Mobile as '移动电话',
    u.F_Telephone as '其它电话',
    c.F_Fax as '传真',
    u.F_Email as '电子邮件',
    '' as '系统语言',
    '' as '出生日期',
    '' as '民族',
    '' as '籍贯',
    '' as '户口',
    '' as '身份证号码',
    '' as '婚姻状况',
    '' as '政治面貌',
    '' as '入团日期',
    '' as '入党日期',
    '' as '工会会员',
    '' as '学历',
    '' as '学位',
    '' as '健康状况',
    '' as '用工性质',
    '' as '合同开始日期',
    '' as '合同结束日期',
    '' as '试用期结束日期',
    '' as '现居住地',
    '' as '家庭联系电话',
    '' as '暂住证号码',
	u.F_DepartmentId,
	u.F_UserId
FROM
   LR_Base_Company c,
    LR_Base_Department d,
   LR_Base_User u
WHERE

    u.F_CompanyId = c.F_CompanyId

    AND u.F_DepartmentId = d.F_Departmentid

		order by  u.F_Account
");
                //var postList = postIBLL.GetPostList(users.F_UserId);//用户岗位
                //                                                    //获取岗位 收到
                //foreach (var item in postList)
                //{
                //    entity.PostName += item.F_Name;
                //    entity.PostName += ",";
                //}
                //if (!string.IsNullOrEmpty(entity.PostName))
                //{
                //    entity.PostName = entity.PostName.Substring(0, entity.PostName.Length - 1);
                //}

                foreach (DataRow dr in datas.Rows)
                {

                    dr["密码"] = "123456";
                  
                    string temp = string.Empty;
                    string temp1 = string.Empty;
                    var postList = postIBLL.GetPostList(dr["F_UserId"].ToString());//用户岗位

                    foreach (var item in postList)
                    {
                        temp += item.F_Name;
                        temp += ",";
                    }
                    if (!string.IsNullOrEmpty(temp))
                    {
                        temp = temp.Substring(0, temp.Length - 1);
                    }
                    dr["岗位"] = temp;
                    if(!string.IsNullOrEmpty(temp))
                    {
                        foreach (var item in postList)
                        {
                            if(item.F_ParentId!="0"&&item.F_ParentId!="")
                            {
                                string sql = string.Format(@"select  r.F_UserId from LR_Base_Post p left join lR_Base_userRelation r on 
p.F_PostId = r.F_ObjectId where p.F_PostId = '{0}'", item.F_ParentId);
                                var UserId = this.BaseRepository().FindObject(sql);
                                if( UserId!=null&&UserId.ToString()!="")
                                {
                                    var userEntity = this.BaseRepository().FindEntity<UserEntity>(UserId);
                                    dr["上级领导"] = userEntity.F_RealName;
                                }

                            }
                          
                        }

                    }

                    var depart = this.BaseRepository().FindEntity<DepartmentEntity>(dr["F_DepartmentId"]);
                    if(depart.F_ParentId !="0"&&depart.F_ParentId !="" && depart.F_ParentId != "-1")
                    {
                        var departParent= this.BaseRepository().FindEntity<DepartmentEntity>(depart.F_ParentId);
                        dr["部门"] = departParent.F_FullName + ">" + dr["部门"];


                    }

                    dr.AcceptChanges();

                }
                datas.AcceptChanges();
                ExcelHelper.getExcel(datas);



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


    }
}
