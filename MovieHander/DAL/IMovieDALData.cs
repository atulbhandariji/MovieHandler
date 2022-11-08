using Models;

namespace MovieHander.DAL
{
    public interface IMovieDALData
    {
        public List<MovieItem> ShowMovieList();

        public void AddMovie(MovieItem movie); 
        
        public void EditMovie(MovieItem movie);

        public void DeleteMovie(int id);

        public MovieItem GetMovieById(int movieId);
        
    }
}
