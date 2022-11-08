using Models;
using MovieLibrary.MovieDALDBContext;

namespace MovieHander.DAL
{

    public class MovieDALData : IMovieDALData
    {

        private IMovieData movieData;

        public MovieDALData(IMovieData _movieData)
        {
            this.movieData = _movieData; 
        }
            public void AddMovie(MovieItem movie)
        {
            movieData.AddMovie(movie);
        }

        public void DeleteMovie(int id)
        {
            movieData.DeleteMovie(id);
        }

        public void EditMovie(MovieItem movie)
        {
            movieData.EditMovie(movie);
        }

        public MovieItem GetMovieById(int movieId)
        {
            return movieData.GetMovieListById(movieId);
        }

        public List<MovieItem> ShowMovieList()
        {
           return movieData.GetMovieList();
        }
    }
}
