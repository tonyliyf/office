using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace Learun.Application.Mapping
{
    /// <summary> 
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架 
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司 
    /// 创 建：超级管理员 
    /// 日 期：2019-02-07 14:22 
    /// 描 述：DC_OA_PurchasePublic 
    /// </summary> 
    public class DC_OA_PurchasePublicMap : EntityTypeConfiguration<DC_OA_PurchasePublicEntity>
    {
        public DC_OA_PurchasePublicMap()
        {
            #region 表、主键 
            //表 
            this.ToTable("DC_OA_PURCHASEPUBLIC");
            //主键 
            this.HasKey(t => t.F_PurchasePublicId);
            #endregion

            #region 配置关系 
            #endregion
        }
    }
} 
  
 
namespace Learun.Application.Mapping
{
    /// <summary> 
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架 
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司 
    /// 创 建：超级管理员 
    /// 日 期：2019-02-07 14:22 
    /// 描 述：DC_OA_PurchasePublic 
    /// </summary> 
    public class DC_OA_PurchasePublicDetailMap : EntityTypeConfiguration<DC_OA_PurchasePublicDetailEntity>
    {
        public DC_OA_PurchasePublicDetailMap()
        {
            #region 表、主键 
            //表 
            this.ToTable("DC_OA_PURCHASEPUBLICDETAIL");
            //主键 
            this.HasKey(t => t.DC_OA_PurchasePublicDetailId);
            #endregion

            #region 配置关系 
            #endregion
        }
    }
}
