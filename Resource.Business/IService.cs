using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.Business
{
    public interface IService
    {
        public (string, int) UseResource();
    }
}
