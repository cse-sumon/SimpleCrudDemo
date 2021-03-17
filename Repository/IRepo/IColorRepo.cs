using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.IRepo
{
    public interface IColorRepo
    {
        IEnumerable<ColorViewModel> GetAll();
    }
}
