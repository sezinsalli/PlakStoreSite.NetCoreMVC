using PlakStoreCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreBusinessLayer.Abstract
{
    public interface IBaseBLL<TEntity>
        where TEntity : BaseEntity
    {
    }
}
