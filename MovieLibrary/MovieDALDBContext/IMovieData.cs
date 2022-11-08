using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.MovieDALDBContext
{
    public interface IMovieData
    {
        List<MovieItem> GetMovieList();

        void AddMovie(MovieItem movieItem);

        public void DeleteMovie(int movieId);

        public void EditMovie(MovieItem movieItem);

        public List<MovieItem> GetFetchMovieList(int pageNumber);


    }
}
