using FakeItEasy;
using Xunit;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Controllers; // Adjust the namespace as needed
using BookStore.Services; // Adjust the namespace as needed
using BookStore.Models; // Adjust the namespace as needed
using BookStore.Entities;

public class GenresControllerTests
{
    private readonly GenresController _controller;
    private readonly IBookstoreRepository _fakeBookstoreRepository;
    private readonly IMapper _fakeMapper;

    public GenresControllerTests()
    {
        // Create fakes for the dependencies
        _fakeBookstoreRepository = A.Fake<IBookstoreRepository>();
        _fakeMapper = A.Fake<IMapper>();

        // Create the controller instance
        _controller = new GenresController(_fakeBookstoreRepository, _fakeMapper);
    }

    [Fact]
    public async Task GetGenres_ReturnsOkResult_WithGenreDtos()
    {
        // Arrange
        var genreEntities = new List<Genre>
        {
            new Genre("Science Fiction") { GenreId = 1 },
            new Genre("Fantasy") { GenreId = 2 }
        };

        var genreDtos = new List<GenreDto>
        {
            new GenreDto { GenreId = 1, GenreName = "Science Fiction" },
            new GenreDto { GenreId = 2, GenreName = "Fantasy" }
        };

        // Set up the repository mock to return genreEntities
        A.CallTo(() => _fakeBookstoreRepository.GetGenresAsync(null, null))
            .Returns(Task.FromResult(genreEntities));

        // Set up the mapper mock to map genreEntities to genreDtos
        A.CallTo(() => _fakeMapper.Map<IEnumerable<GenreDto>>(genreEntities))
            .Returns(genreDtos);

        // Act
        var result = await _controller.GetGenres(null, null);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedDtos = Assert.IsAssignableFrom<IEnumerable<GenreDto>>(okResult.Value);
        Assert.Equal(2, returnedDtos.Count());
        Assert.Contains(returnedDtos, dto => dto.GenreId == 1 && dto.GenreName == "Science Fiction");
        Assert.Contains(returnedDtos, dto => dto.GenreId == 2 && dto.GenreName == "Fantasy");
    }
}