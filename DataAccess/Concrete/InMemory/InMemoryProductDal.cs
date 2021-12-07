using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;//class'ın içinde ama metotların dışında olduğu için global değişkendir, _ ile isim verilir. naming convention

        public InMemoryProductDal()
        {
            //Oracle, Sql Server, Postgre, MongoDb'den gelirmiş gibi simüle ediyoruz 
            _products = new List<Product>//İçinde ürünleri barındıran liste
            {
                new Product {ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product {ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product {ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product {ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product {ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1}
                
            };
        }


        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            _products.Add(product);//Business'tan gönderilen ürünü veritabanına ekleme işlemi.
        }
        public List<Product> GetAll()//Veritabanındaki datayı business'e verme işlemi.
        {
            return _products;
        }
        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//Aşağıdaki foreach'in Linq ile kullanımı.
            _products.Remove(productToDelete);
            /*
            Product productToDelete = null; // = Product(); denseydi bellek boş yere yorulmuş olacaktı.Çünkü bellekten yeni bir referans almıyorum, sadece referans numarasını atama yapıyorum.
            foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p; //Kendim bir product oluşturup referansı ona attım. Tek tek elemanları dolaşıp benim gönderdiğim id'ye eşitse siliyorum.
                }
            }

            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //SingleOrDefault tek bir eleman bulmaya yarar. _products'ı tek tek dolaşır.
            //p => (her p için) 
            //p.ProductId (p'nin ProductId'si)  benim gönderdiğim product.ProductId'sine eşit mi?
            //eşitse productToDelete'e eşitle. Bu kod yukardaki foreach ile aynı işlevdedir. Genelde id olan aramalarda SingleOrDefault kullanılır. Bunun yerine First veya FirstOrDefault'ta olur.

            

            _products.Remove(productToDelete);
            //_products.Remove(product)//Referans tip olduğundan dolayı bu şekilde silinmez. Ürünler silinirken PK kullanılır.
            */
        }
        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü  bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();//where; içindeki şarta uyan bütün elemanları yeni bir liste haline getirip döndürür.
        }
    }
}
