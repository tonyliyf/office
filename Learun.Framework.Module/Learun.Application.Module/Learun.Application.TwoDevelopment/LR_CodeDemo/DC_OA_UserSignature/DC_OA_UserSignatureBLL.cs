using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public class DC_OA_UserSignatureBLL : DC_OA_UserSignatureIBLL
    {
        private DC_OA_UserSignatureService dC_OA_UserSignatureService = new DC_OA_UserSignatureService();

        public void UpdateEntity(string password, string extension)
        {
            try
            {
                dC_OA_UserSignatureService.UpdateEntity(password, extension);
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
        public bool ExistUser()
        {
            try
            {
                return dC_OA_UserSignatureService.ExistUser();
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

        public DC_OA_UserSignatureEntity GetEntity()
        {
            try
            {
                return dC_OA_UserSignatureService.GetEntity();
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
    }
}
