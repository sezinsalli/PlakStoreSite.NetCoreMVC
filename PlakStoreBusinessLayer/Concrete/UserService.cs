
using PlakStore.Model.Entities;
using PlakStore.Model.Enums;
using PlakStoreBusinessLayer.Abstract;
using PlakStoreBusinessLayer.Concrete.NewFolder2;
using PlakStoreBusinessLayer.Concrete.ResultServiceBLL;
using PlakStoreDataAccessLayer.Abstract;
using PlakStoreViewModel.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreBusinessLayer.Concrete
{
    public class UserService : IUserBLL
    {
        IUserDAL userRepository;
        public UserService(IUserDAL userRepository)
        {
            this.userRepository = userRepository;
        }
        private void CheckPassword(string password)
        {
            if (password.Length <= 3)
            {
                throw new Exception("Password min 3 charakter");
            }
        }
        public ResultService<bool> ActivedUser(Guid guid)
        {
            ResultService<bool> result = new ResultService<bool>();
            try
            {
                User user = userRepository.Get(a => a.ActivationCode == guid && !a.ısActive);
                if (user == null)
                {
                    result.AddError("null hatası", "Bu guide sahip user yok");
                    return result;
                }

                user.ısActive = true;
                User updatedUser = userRepository.Update(user);

                if (updatedUser == null)
                {
                    result.AddError("update hatası", "Update başarılı değil");
                    return result;
                }
                result.Data = true;
                return result;
            }
            catch (Exception ex)
            {
                result.AddError("Exception", ex.Message);
                return result;
            }
        }

        public ResultService<bool> CheckUserForLogin(string email, string password)
        {
            ResultService<bool> result = new ResultService<bool>(); 
            
            User user = userRepository.Get(a => a.Email == email && a.Password == password && a.ısActive);//is active true ıse 
            if (user == null)
            {
                //eger boş ise error dön
                result.AddError("Login Hatası", "Login Başarısız");
                return result;
            }
            result.Data = true;
            return result;
        }

        public ResultService<UserCreateVM> Insert(UserCreateVM user)
        {
            ResultService<UserCreateVM> userResult = new ResultService<UserCreateVM>();
            try
            {
                //AutoMapper
                CheckPassword(user.Password);
                User addedUser = userRepository.Add(
                       new User
                       {
                           FirstName = user.FirstName,
                           LastName = user.LastName,
                           Email = user.Email,
                           Password = user.Password,
                           Address = user.Address,
                           PhoneNumber = user.PhoneNumber,

                           //Role = UserRole.Standard,
                           ActivationCode = Guid.NewGuid()
                       }
                       );
                if (addedUser == null)
                {
                    //throw new Exception("ekleme başarılı değil");
                    userResult.AddError("Ekleme Hatasi", "ekleme başarılı değil");
                    return userResult;
                }
                //ekleme yapıldıysa ve basarılı ıse SEND MAIL SERVICE STATIC OLDUGU ICIN DIREK GELICEK NEWLEMEYE IHTIYAC YOK
                bool isSend = SendMailService.SendMail($"{addedUser.FirstName} {addedUser.LastName}", addedUser.Email, addedUser.ActivationCode);
                if (!isSend)
                {
                    userResult.AddError("mailHatasi", "mail gönderilemedi");
                    return userResult;
                }
                userResult.Data = user;
            }
            catch (Exception ex)
            {
                userResult.AddError("Exception", ex.Message);
            }
            return userResult;
        }
    }
}
