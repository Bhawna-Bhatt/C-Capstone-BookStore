using AutoMapper;

namespace BookStore.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile() {
           

                CreateMap<Entities.Author, Models.AuthorDto>();
            
        }
    }
}
