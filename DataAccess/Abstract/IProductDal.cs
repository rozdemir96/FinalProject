using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product> //Product'la ilgili veritabanında yapacağım operasyonları (CRUD) içeren interface. 
    {//Aslında her entity diğer katmanlarda kodlanıyor. Entities'deki Product'ın DataAccess'deki karşılığı bu interface. Bunun somutu ise Concrete klasöründeki InMemory.

        List<ProductDetailDto> getProductDetails();
    }
}
