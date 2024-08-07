using AutoMapper;

namespace BookStore.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile() {
           

            CreateMap<Entities.Author, Models.AuthorDto>();
            CreateMap<Models.AuthorForCreationDto, Entities.Author>();
            CreateMap<Models.AuthorForUpdateDto, Entities.Author>();

        }
    }
}
