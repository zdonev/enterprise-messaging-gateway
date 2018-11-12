using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMessagingGateway.Core.Interfaces
{
    public interface ISettings
    {
        T Get<T>(string key);
    }
}
