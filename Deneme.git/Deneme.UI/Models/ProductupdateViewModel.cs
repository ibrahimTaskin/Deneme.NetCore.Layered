using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deneme.Entities.Concrete;

namespace Deneme.UI.Models
{
    public class ProductupdateViewModel
    {
        public Product Product { get; internal set; }
        public List<Category> Categories { get; internal set; }
    }
}
