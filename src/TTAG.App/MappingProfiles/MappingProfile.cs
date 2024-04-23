namespace TTAG.App.MappingProfiles
{
    using AutoMapper;
    using TTAG.Domain.Model;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<User, UserViewModel>();
        }
    }
}
