using Filminurk.Core.Domain;

namespace Filminurk.Models.Movies
{
    public class MoviesCreateViewModel
    {
        public Guid? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? FirstPublished { get; set; }
        public string? Director { get; set; }
        public List<string>? Actors { get; set; }
        public double? CurrentRating { get; set; }
        //public List<UserComment>? Reviews { get; set; }

        /* 3 õpilase valitud andmetüüpi */
        public string? CountryOfOrigin { get; set; }
        public Genre? MovieGenre { get; set; }
        public Genre? SubGenre { get; set; }

        /* andmebaasi jaoks vajalikud */
        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }
    }
}