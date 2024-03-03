using AutoMapper;
using ExpenseTracker.Entities.DbSet;
using ExpenseTracker.Entities.Dtos.Wallet;

namespace ExpenseTracker.API.MappingProfiles;

public class DomainToRequest : Profile
{
    public DomainToRequest()
    {
        CreateMap<Wallet, GetWalletDto>()
            .ForMember(
                des => des.TypeName,
                option => option.MapFrom(src => src.Type));
    }
}
