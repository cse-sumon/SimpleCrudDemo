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
    public class ColorRepo : IColorRepo
    {
        private ApplicationContext _context;
        private DbSet<Color> colorEntity;
        public ColorRepo(ApplicationContext context)
        {
            _context = context;
            colorEntity = context.Set<Color>();
        }
        public IEnumerable<ColorViewModel> GetAll()
        {
            try
            {
                return (from c in _context.Colors
                        select new ColorViewModel
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).AsEnumerable().ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
