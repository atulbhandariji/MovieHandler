using Models;
using System.Data;
using System.Data.SqlClient;

namespace MovieLibrary.MovieDALDBContext
{
    public class MovieData : IMovieData
    {
        public SqlConnection sqlConnection;
        string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog = MovieDatabase; Integrated Security = True";
        List<MovieItem> movieList = new List<MovieItem>();
        List<MovieItem> newMovieList = new List<MovieItem>();
        MovieItem movieItem = new MovieItem();
        public List<MovieItem> GetMovieList()
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from MovieListTable", sqlConnection);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                movieItem.MovieId = Convert.ToInt32(dataTable.Rows[i]["MovieId"].ToString());
                movieItem.MovieName = dataTable.Rows[i]["MovieName"].ToString();
                movieItem.ReleaseYear = dataTable.Rows[i]["ReleaseYear"].ToString();
                movieItem.ReleaseDate = dataTable.Rows[i]["ReleaseDate"].ToString();
                movieItem.Genre = dataTable.Rows[i]["Genre"].ToString();
                movieList.Add(movieItem);
            }
            sqlConnection.Close();
            return movieList;
        }
        public void AddMovie(MovieItem movieItem)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("[sp_InsertMovie]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@MovieName", SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@Genre", SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@ReleaseYear", SqlDbType.VarChar);


                sqlCommand.Parameters["@MovieName"].Value = movieItem.MovieName;
                sqlCommand.Parameters["@Genre"].Value = movieItem.Genre;
                sqlCommand.Parameters["@ReleaseYear"].Value = movieItem.ReleaseYear;
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void DeleteMovie(int movieId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("spDeleteMovie", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@MovieId";
            sqlParameter.Value = movieId;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public void EditMovie(MovieItem movieItem)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("usp_UpdateMovie", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameterMovieId = new SqlParameter();
            sqlParameterMovieId.ParameterName = "@MovieId";
            sqlParameterMovieId.Value = movieItem.MovieId;
            sqlCommand.Parameters.Add(sqlParameterMovieId);
            SqlParameter sqlParameterMovieName = new SqlParameter();
            sqlParameterMovieName.ParameterName = "@MovieName";
            sqlParameterMovieName.Value = movieItem.MovieName;
            sqlCommand.Parameters.Add(sqlParameterMovieName);
            SqlParameter sqlParameterYear = new SqlParameter();
            sqlParameterYear.ParameterName = "@ReleaseYear";
            sqlParameterYear.Value = movieItem.ReleaseYear;
            sqlCommand.Parameters.Add(sqlParameterYear);
            SqlParameter sqlParameterGenre = new SqlParameter();
            sqlParameterGenre.ParameterName = "@Genre";
            sqlParameterGenre.Value = movieItem.Genre;
            SqlParameter sqlParameterReleaseDate = new SqlParameter();
            sqlParameterReleaseDate.ParameterName = "@ReleaseDate";
            sqlParameterReleaseDate.Value = movieItem.ReleaseDate;
            sqlCommand.Parameters.Add(sqlParameterGenre);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


        public List<MovieItem> GetFetchMovieList(int pageNumber)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("usp_FetchDataByIndex", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameterId = new SqlParameter();
            sqlParameterId.ParameterName = "@Index";
            sqlParameterId.Value = pageNumber;
            sqlCommand.Parameters.Add(sqlParameterId);
            DataTable dataTable = new DataTable();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                movieItem.MovieId = Convert.ToInt32(dataTable.Rows[i]["movieId"].ToString());
                movieItem.MovieName = dataTable.Rows[i]["movieName"].ToString();
                movieItem.ReleaseYear = dataTable.Rows[i]["releaseYear"].ToString();
                movieItem.ReleaseDate = dataTable.Rows[i]["ReleaseDate"].ToString();
                movieItem.Genre = dataTable.Rows[i]["genre"].ToString();
                newMovieList.Add(movieItem);
            }

            sqlConnection.Close();
            return newMovieList;
        }
    }
}