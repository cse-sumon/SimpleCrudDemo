using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.IRepo
{
    public interface IUserRepo
    {
        
        IEnumerable<UserViewModel> GetAll();
        UserViewModel Get(int id);
        void Save(UserViewModel user);
        void Update(UserViewModel User);
        void Delete(int id);

    }
}
