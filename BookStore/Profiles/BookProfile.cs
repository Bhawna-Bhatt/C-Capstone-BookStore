using AutoMapper;

namespace BookStore.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {

            CreateMap<Entities.Book, Models.BookDto>();
            CreateMap<Models.BookForCreationDto, Entities.Book>();
            CreateMap<Models.BookForUpdateDto, Entities.Book>();
        }
    }
}
