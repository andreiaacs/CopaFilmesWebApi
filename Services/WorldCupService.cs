using System;
using System.Linq;
using System.Collections.Generic;
using CopaFilmesWebApi.Models;
using CopaFilmesWebApi.Repository;

namespace CopaFilmesWebApi.Services
{
    public class WorldCupService : IWorldCupService
    {

        public Champions PlayChampionship(List<Movie> movies)
        {
            // Ordenar os filmes alfabeticamente;
            var filmesOrdenados = this.OrdenarFilmes(movies);

            // Fazer com que os filmes disputem em eliminatórias da seguinte forma: 
            // o filme na primeira posição disputará contra o da última posição, 
            // o segundo com o penúltimo, e assim por diante
            var champions = this.Play(filmesOrdenados);

            return champions;
        }

        public List<Movie> OrdenarFilmes(List<Movie> movies)
        {
            return movies.OrderBy(c => c.Titulo).ToList();
        }

        public Champions Play(List<Movie> movies)
        {

            var quarterFinalResult = this.QuarterFinal(movies);
            var semiFinalResult = this.SemiFinal(quarterFinalResult);
            var finalResult = this.Final(semiFinalResult);

            return finalResult;
        }

        public List<Movie> QuarterFinal(List<Movie> movies)
        {
            var j = movies.Count - 1;
            var semiFinal = new List<Movie>();
            var i = 0;
            while (i < j)
            {
                if (movies[i].Nota > movies[j].Nota)
                {
                    semiFinal.Add(movies[i]);
                    i++;
                    j--;
                }
                if (movies[j].Nota > movies[i].Nota)
                {
                    semiFinal.Add(movies[j]);
                    i++;
                    j--;
                }
                // Caso dois filmes tenham a mesma nota, o vencedor será definido pela ordem alfabética. 
                // Exemplo: "Filme A" e "Filme B" possuem a mesma nota, portanto em uma disputa entre eles o 
                // vencedor será o "Filme A".
                if (movies[i].Nota == movies[j].Nota)
                {
                    semiFinal.Add(movies[i]); // Como desempate é por ordem alfabetica e a lista ta ordenada
                    i++;
                    j--;
                }
            }
            return semiFinal;
        }

        public List<Movie> SemiFinal(List<Movie> semiFinal)
        {
            var k = 1;
            var final = new List<Movie>();
            var l = 0;
            while (k < semiFinal.Count)
            {
                if (semiFinal[l].Nota > semiFinal[k].Nota)
                {
                    final.Add(semiFinal[l]);
                    k++;
                    l++;
                }
                if (semiFinal[k].Nota > semiFinal[l].Nota)
                {
                    final.Add(semiFinal[k]);
                    k++;
                    l++;
                }
                // Caso dois filmes tenham a mesma nota, o vencedor será definido pela ordem alfabética. 
                // Exemplo: "Filme A" e "Filme B" possuem a mesma nota, portanto em uma disputa entre eles o 
                // vencedor será o "Filme A".
                if (semiFinal[l].Nota == semiFinal[k].Nota)
                {
                    final.Add(semiFinal[l]); // Como desempate é por ordem alfabetica e a lista ta ordenada
                    k++;
                    l++;
                }
            }
            return final;
        }

        public Champions Final(List<Movie> final)
        {
            var champions = new Champions();

            if (final[0].Nota > final[1].Nota)
            {
                champions.First = final[0];
                champions.Second = final[1];
            }
            else
            if (final[1].Nota > final[0].Nota)
            {
                champions.First = final[1];
                champions.Second = final[0];
            }
            else
            {
                var ordemAlfabetica = this.OrdenarFilmes(final);
                champions.First = ordemAlfabetica[0];
                champions.Second = ordemAlfabetica[1];
            }
            return champions;
        }


    }
}
