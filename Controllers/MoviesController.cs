using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CopaFilmesWebApi.Models;
using CopaFilmesWebApi.Repository;
using CopaFilmesWebApi.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CopaFilmesWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        readonly MoviesRepository repository;

        readonly WorldCupService worldCupService;

        public MoviesController(MoviesRepository repository, WorldCupService worldCupService)
        {
            this.repository = repository;
            this.worldCupService = worldCupService;
        }

        [HttpGet]
        public List<Movie> Index()
        {
            return repository.GetMovies();
        }

        [HttpPost]
        public Champions SelectedMovies(List<Movie> movies)
        {
            var champions = this.worldCupService.PlayChampionship(movies);
            return champions;
        }

    }
}
