using AutoMapper;
using WarehouseInventory.API.Models;

namespace WarehouseInventory.API.ItemProfile
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemForCreation, Entities.Item>();

            CreateMap<ItemForUpdate, Entities.Item>();

            CreateMap<Entities.Item, ItemForUpdate>();

            CreateMap<Entities.Item, ItemForAdding>()
                .ForMember(
                    dest => dest.SupplierName,
                    opt => opt.MapFrom(x => x.Supplier.Name));            

            CreateMap<ItemForCreation, ItemForAdding>();

            CreateMap<ItemForAdding, ItemForCreation>();

            CreateMap<ItemForAdding, ItemForUpdate>();

            CreateMap<ItemForUpdate, ItemForAdding>();

            CreateMap<ItemForUpdate, ItemForCreation>();
        }
    }
}
