using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock.Framework.Common
{
    public interface IEntity
    {
        bool Insert();
        bool Update();
        bool Delete();
        bool Find(int id);
        bool Find(Guid guid);
    }
}
