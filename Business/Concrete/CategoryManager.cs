using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;//Şimdilik EntityFramework ile çalışıyorum ancak ilerde NHibernate vs. kullanabilirim. Bağımlılığı minimize etmek için bu yapılıyor.

        public CategoryManager(ICategoryDal categoryDal)//Interface üzerinden DataAccess katmanına bağımlı. Kurallarına uymak zorunda.
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //İş kodları

            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)//Select * from Categories where CategoryId = x
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
