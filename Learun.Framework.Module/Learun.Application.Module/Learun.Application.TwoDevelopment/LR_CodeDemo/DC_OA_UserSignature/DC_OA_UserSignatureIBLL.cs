using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public interface DC_OA_UserSignatureIBLL
    {
        void UpdateEntity(string password, string extension);
        bool ExistUser();
        DC_OA_UserSignatureEntity GetEntity();
    }
}
