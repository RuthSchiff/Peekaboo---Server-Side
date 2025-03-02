using Dal.Converters;
using Dal.Models;
using Dto.dto_classes;
using Idal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Orders_detail_dal : IdalOrderDetails
    {
        //שליפת כל OrdersDetailDto  
        public async Task<List<OrdersDetailDto>> SelectAll()
        {
            BabyClothingStore1Context db = new BabyClothingStore1Context();
            var q = await db.OrdersDetails.ToListAsync();
            return OrdersDetail_converter.ToListOrdersDetailDto(q);
        }

        //קבלת מוצר לפי ה ID
        public async Task<ProductDto?> GetProductByIdAsync(int productId)
        {
            using (var db = new BabyClothingStore1Context())
            { 
                //חיפוש המוצר לפי ה ID
                var product = await db.Products.FindAsync(productId);
                //אם מצא את המוצר
                //- ממיר לאוביקט מסוג Dto
                //אחרת מחזיר null
                return product != null ? Product_converter.ToProduct(product) : null;
            }
        }
        //יצירת הזמנה
        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            using (var db = new BabyClothingStore1Context())
            {
                //המרה של האביקט מסוג של OrderDto ל -> order
                var order = Order_converter.ToOrder(orderDto);
                //הוספת ההזמנה לטבלת ההזמנות
                db.Orders.Add(order);
                
                //שמירת שינויים על ה db 
                await db.SaveChangesAsync();
                //החזרת order
                return Order_converter.ToOrder(order);
            }
        }
        // OrderDetail - הוספת 
        public async Task AddOrderDetailAsync(OrdersDetailDto orderDetailDto)
        {
            using (var db = new BabyClothingStore1Context())
            {
                // ממירים את ה- DTO לאובייקט Entity
                var orderDetail = new OrdersDetail
                {
                    OrdersId = orderDetailDto.OrderId,
                    ProductId = orderDetailDto.ProductId,
                    Quantity = orderDetailDto.Quantity
                };
                var product = await db.Products.FindAsync(orderDetailDto.ProductId);
                product.StockQuantity -=orderDetail.Quantity;
                // db מוסיפים את פרטי ההזמנה ל 
                db.OrdersDetails.Add(orderDetail);
                await db.SaveChangesAsync();
            }
        }
        //עידכון ההזמנה
        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            using (var db = new BabyClothingStore1Context())
            {
                //מציאת ההזמנה
                var order = await db.Orders.FindAsync(orderDto.OrderId);

                if (order != null)
                {
                    //עידכון פרטי ההזמנה
                    order.CustomerId = orderDto.CustomerId;
                    order.OrderDate = orderDto.OrderDate;
                    order.TotalPayment = orderDto.TotalPayment;
                    order.Note = orderDto.Note;
                    order.Paid = orderDto.Paid;

                    // שמירה ב db
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Order not found.");
                }
            }
        }

    }
  
}



