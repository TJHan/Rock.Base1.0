using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock.Framework.DataAccess;

namespace Rock.Framework.Entity
{
    /// <summary>
    /// 实体类父类
    /// </summary>
    public abstract class Entity:Common.IEntity
    {
        public bool Insert()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Find(int id)
        {
            throw new NotImplementedException();
        }

        public bool Find(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
