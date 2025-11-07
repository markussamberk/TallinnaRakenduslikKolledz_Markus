using System;

namespace Filminurk.ApplicationServices.Services
{
	public class MovieServices : IMovieServices
	{
		private readonly FilminurkTARpe24Context _context;

		public MovieServices(FilminurkTARpe24Context context)
		{
			_context = context;
		}

		public async Task<Movie> Create(MoviesDTO dto)
		{
			Movie movie = new Movie();
			movie.ID = Guid.NewGuid();
			movie.Title = dto.Title;
			movie.Description = dto.Description;
			movie.CurrentRating = dto.CurrentRating;
			movie.CountryOfOrigin = dto.CountryOfOrigin;
			movie.FirstPublished = dto.FirstPublished;
			movie.Actors = dto.Actors;
			movie.Director = dto.Director;
			movie.MovieGenre = dto.MovieGenre;
			movie.SubGenre = dto.SubGenre;
			movie.EntityCreatedAt = dto.EntityCreatedAt;
			movie.EntryModifiedAt = dto.EntryModifiedAt;


			await _context.Movies.AddAsync(movie);
			await _context.SaveChangesAsync();

			return movie;
		}
	}
}
