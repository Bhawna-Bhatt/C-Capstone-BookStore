using BookStore.Models;

namespace BookStore
{
    public class GenreDataStore
    {
        public List<GenreDto> Genres { get; set; }

        public static GenreDataStore Current { get; } = new GenreDataStore();

        public GenreDataStore()
        {

            Genres = new List<GenreDto>()
        {
        new GenreDto()
        {
        GenreId = 1,
        GenreName = "Fiction"}
         };
        }
    }
}
