using PlakStoreBusinessLayer.Concrete.NewFolder2;
using PlakStoreViewModel.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreBusinessLayer.Abstract
{
    public interface IUserBLL
    {
        ResultService<UserCreateVM> Insert(UserCreateVM user);
        ResultService<bool> ActivedUser(Guid guid);
        ResultService<bool> CheckUserForLogin(string email, string password);
    }
}
