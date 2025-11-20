using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Shared.DataTransferObject.Users;

namespace E_Commerce.Service.MappingProfiles;
public class UserProfile
    : Profile
{
    public UserProfile()
    {
        CreateMap<Address, AddressDTO>()
            .ReverseMap();

    }
}
