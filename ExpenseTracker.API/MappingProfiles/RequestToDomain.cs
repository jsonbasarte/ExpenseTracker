using AutoMapper;
using ExpenseTracker.Entities.DbSet;
using ExpenseTracker.Entities.Dtos.Category;
using ExpenseTracker.Entities.Dtos.TransactionDetails;
using ExpenseTracker.Entities.Dtos.Wallet;

namespace ExpenseTracker.API.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateCategoryDto, Category>();

        CreateMap<UpdateCategoryDto, Category>();

        CreateMap<CreateWalletDto, Wallet>()
            .ForMember(
                des => des.Name,
                option => option.MapFrom(src => src.WalletName))
            .ForMember(
                des => des.Type,
                option => option.MapFrom(src => src.WalletType));

        CreateMap<UpdateWalletDto, Wallet>()
            .ForMember(
                des => des.Name,
                option => option.MapFrom(src => src.WalletName))
            .ForMember(
                des => des.Type,
                option => option.MapFrom(src => src.WalletType));

        CreateMap<CreateTransactionDto, TransactionDetails>()
              .ForMember(
                des => des.DateCreated,
                option => option.MapFrom(src => DateTime.UtcNow));
    }
}
