using AutoMapper;

namespace BookStore.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile() {

            CreateMap<Entities.Genre, Models.GenreDto>(); 
        }
    }
}
