namespace Models
{
    public class MovieItem
    {
        public int MovieId { get; set; }
        // [DisplayName("Movie Name")]
        public string MovieName { get; set; }
        public string ReleaseYear { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }

    }
}