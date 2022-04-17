using PlakStore.Model.Entities;
using PlakStoreBusinessLayer.Concrete.NewFolder2;
using PlakStoreViewModel.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreBusinessLayer.Abstract
{
    public interface IUserBLL:IBaseBLL<User>
    {
        ResultService<UserCreateVM> Insert(UserCreateVM user);

        // eger kontrollerda metod olusturursam bu sekılde metod olusutururm
        ResultService<bool> ActivedUser(Guid guid);
    }
}
