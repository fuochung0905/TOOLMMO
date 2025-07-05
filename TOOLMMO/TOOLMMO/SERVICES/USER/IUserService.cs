using MODELS.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOLMMO.SERVICE
{
    public interface IUserService
    {
        BaseResponse<string> GetAllUser();
    }
}
