using PlakStore.Model.Entities;
using PlakStoreCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreDataAccessLayer.Abstract
{
    public interface IOrderDAL:IRepository<Order>
    {
    }
}
