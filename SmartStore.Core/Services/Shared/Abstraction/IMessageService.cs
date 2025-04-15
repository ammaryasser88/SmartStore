using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Core.Services.Shared.Abstraction
{
    public interface IMessageService
    {
        string GetMessage(string key);
    }
}
