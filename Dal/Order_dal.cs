﻿using Dal.Converters;
using Dal.Models;
using Dto.dto_classes;
using Idal;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class Order_dal : IdalOrder
    {
            public async Task<List<OrderDto>> SelectAll()
            {
                BabyClothingStore1Context db = new BabyClothingStore1Context();
                var q = await db.Orders.ToListAsync();
                return Order_converter.ToListOrderDto(q);
            }
        }
    }
