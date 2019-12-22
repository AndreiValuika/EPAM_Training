using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        public string GetId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
