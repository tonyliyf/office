
using System.Data.Entity.ModelConfiguration;
using Learun.Application.Message;
namespace Learun.Application.Mapping.LR_Message
{
    public class DC_OA_MessageMap : EntityTypeConfiguration<DC_OA_MessageEntity>
    {
        public DC_OA_MessageMap()
        {
            #region 表、主键 
            //表 
            this.ToTable("DC_OA_MESSAGE");
            //主键 
            this.HasKey(t => t.F_MessageId);
            #endregion

            #region 配置关系 
            #endregion
        }
    }
}
