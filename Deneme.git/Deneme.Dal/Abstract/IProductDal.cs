using System;
using System.Collections.Generic;
using System.Text;
using Deneme.Core.DataAccess;
using Deneme.Entities.Concrete;

namespace Deneme.Dal.Abstract
{
    public interface IProductDal:IEntityRespository<Product>
    {
        //product a özel methodlar olabilir
    }
}
