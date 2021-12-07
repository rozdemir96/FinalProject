using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;

namespace DataAccess.Abstract//Generic Repository Design Pattern 
{
    //Generic constraint - generic kısıt. 
    //class: T bir referans tip olmalı
    //IEntity: T bir IEntity olabilir veya IEntity'den implemente edilen bir nesne(product, customer vs.) olabilir.
    //new(): new'lenebilir olmalı. IEntity interface olduğundan new'lenemez. Bu yüzden sadece onu implemente eden somut class'lar kullanılabilir.
    public interface IEntityRepository<T> where  T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//filtre=null; filtre vermeyedebilirsin demek. Eğer filtre verilmemişse tüm datayı istiyor demektir. Filtre vermişse filtreliyip vericek.
        T Get(Expression<Func<T, bool>> filter);//T döndüren bir Get operasyonu
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
