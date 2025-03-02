using Dto.dto_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idal
{
    public interface IdalOrderDetails
    {

             // OrdersDetails - שליפת כל ה 
            public Task<List<OrdersDetailDto>> SelectAll();
            //**********************************************\\
            
            // :פונקציות לחישוב בתשלום הסופי ועיכון הזמנה 

            //יצירת הזמנה
            public Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
            //קבלת מוצר לפי ID
            public Task<ProductDto?> GetProductByIdAsync(int productId);
            //יצירת  orderDetails
            public Task AddOrderDetailAsync(OrdersDetailDto orderDetailDto);
            //עידכון הזמנה
            public Task UpdateOrderAsync(OrderDto orderDto);

            
            

    }

}

