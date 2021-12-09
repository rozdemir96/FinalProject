using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();//Tümünü listeler.
        Category GetById(int categoryId); //Id'ye göre çekileceği için tek bir kategoriyi göstermesi için List yerine Category olarak yazıldı.

    }
}
