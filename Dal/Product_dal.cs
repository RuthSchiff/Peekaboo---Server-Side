using Dal.Converters;
using Dal.Models;
using Dto.dto_classes;
using Idal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Product_dal : IdalProduct
    {
        public async Task<List<ProductDto>> SelectAll()
        {
            BabyClothingStore1Context db = new BabyClothingStore1Context();
            var q = await db.Products.Include(x => x.Category).Include(y => y.Company).ToListAsync();
            return Product_converter.ToListProductDto(q);
        }

        public async Task<List<ProductDto>> getByCategory(int? categoryId, int? companyId , string? gender)
        {
            BabyClothingStore1Context db = new BabyClothingStore1Context();
            if (categoryId != null && companyId != null && gender != null) {
                var products = await db.Products.Include(x => x.Category).Include(y => y.Company)

                   //1
                   .Where(p => p.Gender.Equals(gender)).Where(p => p.CompanyId.Equals(companyId)).Where(p => p.CategoryId.Equals(categoryId))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            //2
            else if (categoryId != null && companyId != null && gender == null)
            {
                var products = await db.Products.Include(x => x.Category).Include(y => y.Company)
                   .Where(p => p.CategoryId.Equals(categoryId)).Where(p => p.CompanyId.Equals(companyId))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            //3
            else if (categoryId != null && companyId == null && gender != null)
            {
                var products = await db.Products.Include(x => x.Category).Include(y => y.Company)
                   .Where(p => p.Gender.Equals(gender)).Where(p => p.CategoryId.Equals(categoryId))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }//2
             //4
            else if (categoryId != null && companyId == null && gender == null)
            {
                var products = await db.Products.Include(x => x.Category).Include(y => y.Company)
                   .Where(p => p.CategoryId.Equals(categoryId))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            //5
            else if (categoryId == null && companyId != null && gender == null)
            {
                var products = await db.Products.Include(x => x.Category).Include(y => y.Company)
                   .Where(p => p.CompanyId.Equals(companyId))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            //6
            else if (categoryId == null && companyId == null && gender != null)
            {
                var products = await db.Products.Include(x => x.Category).Include(y => y.Company)
                   .Where(p => p.Gender.Equals(gender))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            //6
            //else if (categoryId == null && companyId != null && gender != null)
            //{
            //    var products = await db.Products
            //       .Where(p => p.Gender.Equals(gender)).Where(p=>p.CompanyId.Equals(companyId))
            //       .ToListAsync();
            //    return Product_converter.ToListProductDto(products);
            //}

            //7
            else if (categoryId != null && companyId == null && gender == null)
            {
                var products = await db.Products.Include(x => x.Category).Include(y => y.Company)
                   .Where(p => p.CategoryId.Equals(categoryId))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            else if (gender != null && companyId != null && categoryId == null)
            {
                var products = await db.Products.Include(x => x.Category).Include(y => y.Company)
                   .Where(p => p.Gender.Equals(gender)).Where(p=>p.CompanyId.Equals(companyId))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            //5
            else
            {
                var q = await db.Products.Include(x => x.Category).Include(y => y.Company).ToListAsync();
                return Product_converter.ToListProductDto(q);
            }

        }
        public async Task<ProductDto> Add(ProductDto p)
        {
            BabyClothingStore1Context db = new BabyClothingStore1Context();
            var product = Product_converter.ToProduct(p); // המרת DTO לאובייקט מודל
            db.Products.Add(product); // הוספת הלקוח לבסיס הנתונים
            await db.SaveChangesAsync(); // שמירת השינויים
            return Product_converter.ToProduct(product); // המרת הלקוח שנשמר בחזרה ל-DTO
        }
        public async Task<List<ProductDto>> SelectNewsProduct()
        {
           
            BabyClothingStore1Context db = new BabyClothingStore1Context();
            var q  = await db.Products.ToListAsync();
            return Product_converter.ToListProductDto(q).Where(p=>p.LastUpdated.HasValue).OrderByDescending(p => p.LastUpdated.Value).Take(10).ToList();
        }
    }
}

