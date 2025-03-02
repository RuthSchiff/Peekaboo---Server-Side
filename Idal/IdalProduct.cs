﻿using Dto.dto_classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idal
{
    public interface IdalProduct
    {


        //CRUD- create,Read,Update<Delete מממשק תשתיתי שיכיל את פעולות היסוד
        //למחלקה שיהיו פונקציות נוספות ניצור ממשק נוסף שימממש ממשק זה ויכיל את המתודות הנוספות

        public Task<List<ProductDto>> SelectAll();

        public Task<List<ProductDto>> getByCategory(int? categoryId , int? companyId ,string? gender);

        public Task<ProductDto> Add(ProductDto product);

        public Task<List<ProductDto>> SelectNewsProduct();


    }

}

