using Microsoft.EntityFrameworkCore;
using Model;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Repository.Repo
{
    public class UserRepo : IUserRepo
    {
        private ApplicationContext context;
        private DbSet<User> userEntity;
        public UserRepo(ApplicationContext context)
        {
            this.context = context;
            userEntity = context.Set<User>();
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            try
            {
                return (from u in context.Users
                        join g in context.Genders on u.GenderId equals g.Id
                        select new UserViewModel
                        {
                            Id = u.Id,
                            Name = u.Name,
                            GenderId = g.Id,
                            GenderName = g.Name,
                            Email = u.Email,
                            Mobile = u.Mobile,
                            Address = u.Address,
                        } ).AsEnumerable().ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public UserViewModel Get(int id)
        {
            try
            {
                return (from u in context.Users
                        where u.Id == id
                        join g in context.Genders on u.GenderId equals g.Id
                        select new UserViewModel
                        {
                            Id = u.Id,
                            Name = u.Name,
                            GenderId = g.Id,
                            GenderName = g.Name,
                            Email = u.Email,
                            Mobile = u.Mobile,
                            Address = u.Address,
                        }).AsNoTracking().SingleOrDefault();

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public void Save(UserViewModel userVM)
        {
            try
            {
                if (userVM == null)
                {
                    throw new ArgumentNullException("UserModel");
                }
                User user = new User
                {
                    Name = userVM.Name,
                    GenderId = userVM.GenderId,
                    Email = userVM.Email,
                    Mobile = userVM.Mobile,
                    Address = userVM.Address,
                };
                userEntity.Add(user);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Update(UserViewModel userVM)
        {
            try
            {
                if (userVM == null)
                {
                    throw new ArgumentNullException("UserModel");
                }
                User user = new User
                {
                    Id = userVM.Id,
                    Name = userVM.Name,
                    GenderId = userVM.GenderId,
                    Email = userVM.Email,
                    Mobile = userVM.Mobile,
                    Address = userVM.Address,
                };
                userEntity.Update(user);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Delete(int id)
        {
            User user = context.Users.FirstOrDefault(u=>u.Id==id);
            userEntity.Remove(user);
            context.SaveChanges();
        }
    }
}
