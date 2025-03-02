using Dal.Models;
using Dto.dto_classes;

namespace Ibll
{

    public interface IproductBll
    { 
        public Task<List<ProductDto>> SelectAll();

        public Task<List<ProductDto>> SelectNewsProduct();

        Task<List<ProductDto>> getByCategory(int? categoryId , int? companyId , string? gender);

        Task<ProductDto> Add(ProductDto c);

    }
}


