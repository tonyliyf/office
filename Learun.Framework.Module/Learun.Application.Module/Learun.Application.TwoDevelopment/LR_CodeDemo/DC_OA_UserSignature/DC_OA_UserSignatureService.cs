using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public class DC_OA_UserSignatureService : RepositoryFactory
    {
        public void UpdateEntity(string password, string extension)
        {
            var userEntity = GetEntity();
            userEntity.F_Password = password;
            userEntity.F_Signature = extension;
            this.BaseRepository().Update(userEntity);
        }

        public bool ExistUser()
        {
            UserInfo info = LoginUserInfo.Get();
            return (this.BaseRepository().FindEntity<DC_OA_UserSignatureEntity>(info.userId) != null);
        }

        public DC_OA_UserSignatureEntity GetEntity()
        {
            UserInfo info = LoginUserInfo.Get();
            if (!ExistUser())
            {
                this.BaseRepository().Insert<DC_OA_UserSignatureEntity>(new DC_OA_UserSignatureEntity() { F_UserId = info.userId });
            }
            return this.BaseRepository().FindEntity<DC_OA_UserSignatureEntity>(info.userId);
        }
    }
}
