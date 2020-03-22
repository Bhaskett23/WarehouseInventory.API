using AutoMapper;
using WarehouseInventory.API.Entities;
using WarehouseInventory.API.Models;

namespace WarehouseInventory.API.ItemProfile
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierForViewing>()
                .ForMember(
                    dest => dest.ItemsSupplied,
                    opt => opt.MapFrom(x => x.Items)
                );

            CreateMap<SupplierForCreation, Supplier>();
        }
    }
}
