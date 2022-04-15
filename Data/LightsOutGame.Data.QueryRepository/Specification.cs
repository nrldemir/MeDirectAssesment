﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutGame.Data.QueryRepo
{
    public class Specification<T> : SpecificationBase<T> where T : class
    {
        public int? Skip { get; set; }

        public int? Take { get; set; }
    }
}
