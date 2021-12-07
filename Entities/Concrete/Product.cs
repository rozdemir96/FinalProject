using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : IEntity //default olarak internal'dır. Bu class için sadece Entities erişir anlamına gelir.
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; } 
        public decimal UnitPrice { get; set; }

        
    }
}
