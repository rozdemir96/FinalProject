using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity> //Bir tane Entity(Product vs.) ve bir tane Coxtext(NorthwindContext vs.) tipi. 
        where TEntity:class, IEntity, new()//Veritabanı tablosu olacak, referans tip olacak, IEntity yazılamasın diye new'lendi
        where TContext:DbContext, new() //Her class'ı yazamam DBContext'ten inherit edilmesi gerek, new'lenebilir olmalı ki NorthwindContext gibi şeyler gelsin
    {
        public void Add(TEntity entity)
        {
            //using'i araştırmak için: IDisposable pattern implementaiton of C#
            using (TContext context = new TContext())//C#'a özel bir yapıdır. using içerisine yazılan nesneneler using bitince garbage collector'e beni bellekten at diyor. Çünkü Context nesnesi pahalı.
            {
                var addedEntity = context.Entry(entity);//Veri kaynağından benim gönderdiğim product'ı ekle. Referansı yakala.
                addedEntity.State = EntityState.Added;//Durumunu ekleme olarak ayarla, set et.
                context.SaveChanges();//ekle
            }
        }

        public void Delete(TEntity entity)//Veritabanında silme işlemini gerçekleştirir.
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())//
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()//select * from Products döndürür ve listeye çevirir.
                    : context.Set<TEntity>().Where(filter)//Filtrelenmiş datayı döndürür ve listeye çevirir.
                        .ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)//Tek data getiricek metot
        {
            using (TContext context = new TContext())
            {//context.Set<Product>(); DbSet'lerimden Product'a bağlan diyorum
                return context.Set<TEntity>().SingleOrDefault(filter);//Product, category, customer vs. için standart kod.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
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
