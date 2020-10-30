using System.Collections.Generic;
using CopaFilmesWebApi.Models;

namespace CopaFilmesWebApi.Services
{
    public interface IWorldCupService
    {
        Champions PlayChampionship(List<Movie> movies);

        List<Movie> OrdenarFilmes(List<Movie> movies);
        
        Champions Play(List<Movie> movies);
    }

}