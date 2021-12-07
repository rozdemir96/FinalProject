using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Category : IEntity//Category ve Product nesneleri bir veritbanı nesnesidir. Bunu ifade etmek için bir imzalama gerçekleştirdim. Bu imzalama IEntity ile yapılır.
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        
    }
}
