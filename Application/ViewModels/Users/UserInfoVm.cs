namespace Application.ViewModels.Users
{
    using AutoMapper;
    using Common.Mapping;
    using Domain.Entities;

    public class UserInfoVm : IMapFrom<User>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public void Mapping(Profile profile) => profile.CreateMap<User, UserInfoVm>()
            .ForMember(nameof(UserId), opt => opt.MapFrom(user => user.UserId.Substring(5)));
    }
}
