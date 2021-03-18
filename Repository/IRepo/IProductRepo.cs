using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.IRepo
{
    public interface IProductRepo
    {
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel Get(int id);
        void Save(ProductViewModel user);
        void Update(ProductViewModel User);
        void Delete(int id);

    }
}
