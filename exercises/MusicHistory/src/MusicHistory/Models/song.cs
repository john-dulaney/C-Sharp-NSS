namespace MusicHistory.models
{
    public class song
    {
        [key]
        public int SongId { get; set; }

        [required]
        [StringLength(55)]
        public string Name { get; set; }
        public int ArtistId { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
        
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}