﻿using PBSA.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Interface
{
   public interface IProductService
    {
        int CreateProduct(ProductRequest product);
    }
}