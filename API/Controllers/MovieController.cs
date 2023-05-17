using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieRepository _movieRepository = new MovieRepository();
    
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Movie> Get(int page)
    {
        return _movieRepository.GetPage(page);
    }
}