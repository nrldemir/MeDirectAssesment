using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutGame.Data.QueryRepo
{
    public class PaginationSpecification<T> : SpecificationBase<T> where T : class
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
