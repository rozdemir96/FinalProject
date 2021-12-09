using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)//şu an inmemory ama yarın öbür gün entity framework vs olabilir
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İş kodları buraya yazılır. if else gibi.
            //Yetkisi var mı?

            return _productDal.GetAll();//Eğer bütün kuralları geçmişse ürünleri verir.
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> getProductDetails()
        {
            return _productDal.getProductDetails();
        }
    }
}
