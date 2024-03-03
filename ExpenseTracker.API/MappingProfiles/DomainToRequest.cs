using AutoMapper;
using ExpenseTracker.Entities.DbSet;
using ExpenseTracker.Entities.Dtos.TransactionDetails;
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

        CreateMap<TransactionDetails, GetTransactionDto>()
            .ForMember(
                des => des.WalletName,
                option => option.MapFrom(src => src.Wallet.Name))
            .ForMember(
                des => des.CategoryName,
                option => option.MapFrom(src => src.Category.Name));
            
    }
}
