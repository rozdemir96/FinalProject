using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{//NuGet: İlerleyen zamanlarda başkalarının yazdığı kodları(paketleri) kullanabilirim. Bu kodların ortak koyulduğu ve yönetildiği ortamdır. 
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //using'i araştırmak için: IDisposable pattern implementaiton of C#
            using (NorthwindContext context = new NorthwindContext())//C#'a özel bir yapıdır. using içerisine yazılan nesneneler using bitince garbage collector'e beni bellekten at diyor. Çünkü Context nesnesi pahalı.
            {
                var addedEntity = context.Entry(entity);//Veri kaynağından benim gönderdiğim product'ı ekle. Referansı yakala.
                addedEntity.State = EntityState.Added;//Durumunu ekleme olarak ayarla, set et.
                context.SaveChanges();//ekle
            }
        }

        public void Delete(Product entity)//Veritabanında silme işlemini gerçekleştirir.
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())//
            {
                return filter == null
                    ? context.Set<Product>().ToList()//select * from Products döndürür ve listeye çevirir.
                    : context.Set<Product>().Where(filter)//Filtrelenmiş datayı döndürür ve listeye çevirir.
                        .ToList();  
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)//Tek data getiricek metot
        {
            using (NorthwindContext context = new NorthwindContext())
            {//context.Set<Product>(); DbSet'lerimden Product'a bağlan diyorum
                return context.Set<Product>().SingleOrDefault(filter);//Product, category, customer vs. için standart kod.
            }
        }
        
        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        //Biraz daha ilerleyince bu kodları category ve customer için tekrarlamam lazım. Sadece parametreler değişiyor gerisi aynı, kod tekrarı yok.
        //İlerleyen aşamalarda BaseEntityFrameworkRepository kullanılıcam. Daha ileri soyutlama tekniklerini içeriyor.
    }
}
