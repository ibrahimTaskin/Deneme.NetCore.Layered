using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deneme.Entities.Concrete;

namespace Deneme.UI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; internal set; }
        public int CurrentCategory { get; internal set; }
    }
}
