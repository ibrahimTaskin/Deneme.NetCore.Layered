using Deneme.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deneme.Bll.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        List<Product> GetByCategoryId(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        Product GetById(int productId);
    }
}
