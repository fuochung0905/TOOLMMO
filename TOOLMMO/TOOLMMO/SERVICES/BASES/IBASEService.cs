using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOLMMO.SERVICES.BASES
{
    public interface IBASEService
    {
        Task MoChromeAnDanh(string url, string proxyString, string username, string password);
    }
}
