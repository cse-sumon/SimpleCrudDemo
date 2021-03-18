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
    public class ProductRepo : IProductRepo
    {
        private ApplicationContext _context;
        private DbSet<Product> productEntity;
        public ProductRepo(ApplicationContext context)
        {
            _context = context;
            productEntity = context.Set<Product>();
        }
        public IEnumerable<ProductViewModel> GetAll()
        {
            try
            {
                return (from p in _context.Products
                        where p.StatusId == 1
                        join c in _context.Colors on p.ColorId equals c.Id
                        join s in _context.Colors on p.StatusId equals s.Id
                        select new ProductViewModel
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Image = p.Image,
                            Price = p.Price,
                            Quantity = p.Quantity,
                            Description = p.Description,
                            StatusId = s.Id,
                            StatusName = s.Name,
                            ColorId = c.Id,
                            ColorName = c.Name
                        }).AsEnumerable().ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
      
        public ProductViewModel Get(int id)
        {
            try
            {
                return (from p in _context.Products.AsNoTracking()
                        where p.StatusId == 1 && p.Id == id
                        join c in _context.Colors on p.ColorId equals c.Id
                        join s in _context.Colors on p.StatusId equals s.Id
                        select new ProductViewModel
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Image = p.Image,
                            Price = p.Price,
                            Quantity = p.Quantity,
                            Description = p.Description,
                            StatusId = s.Id,
                            StatusName = s.Name,
                            ColorId = c.Id,
                            ColorName = c.Name
                        }).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
      
        public void Save(ProductViewModel productVM)
        {
            try
            {
                if (productVM == null)
                    throw new ArgumentNullException("ProductModel");

                Product product = new Product
                {
                    Name = productVM.Name,
                    Price = productVM.Price,
                    Image = productVM.Image,
                    Quantity = productVM.Quantity,
                    Description = productVM.Description,
                    StatusId = productVM.StatusId,
                    ColorId = productVM.ColorId
                };

                productEntity.Add(product);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(ProductViewModel productVM)
        {
            try
            {
                if (productVM == null)
                    throw new ArgumentNullException("ProductModel");

                Product product = new Product
                {
                    Id = productVM.Id,
                    Name = productVM.Name,
                    Image = productVM.Image,
                    Price = productVM.Price,
                    Quantity = productVM.Quantity,
                    Description = productVM.Description,
                    StatusId = productVM.StatusId,
                    ColorId = productVM.ColorId
                };

                productEntity.Update(product);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(u => u.Id == id);
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
