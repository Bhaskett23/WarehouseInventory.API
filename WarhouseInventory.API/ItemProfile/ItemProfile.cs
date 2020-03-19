using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseInventory.API.Models;

namespace WarehouseInventory.API.ItemProfile
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemForCreation, Item>();

            CreateMap<Item, ItemForCreation>();

            CreateMap<Item, ItemForUpdate>();

            CreateMap<ItemForUpdate, Item>();

            CreateMap<ItemForUpdate, ItemForCreation>();
        }
    }
}
