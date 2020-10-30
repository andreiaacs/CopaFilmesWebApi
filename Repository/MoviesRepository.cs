using RestSharp;
using CopaFilmesWebApi.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
    REPOSITORY PARA CONSUMIR API DE FILMES E AVALIAÇÕES
*/
namespace CopaFilmesWebApi.Repository
{
    public class MoviesRepository
    {
        public List<Movie> GetMovies()
        {
            var client = new RestClient($"{Config.baseUrl}/api/filmes");

            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);

            var content = response.Content;

            return JsonConvert.DeserializeObject<List<Movie>>(content);

        }
    }
}