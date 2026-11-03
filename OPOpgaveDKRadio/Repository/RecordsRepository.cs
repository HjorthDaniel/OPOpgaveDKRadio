using OPOpgaveDKRadio.Model;

namespace OPOpgaveDKRadio.Repository;

public class RecordsRepository
{
	private readonly List<Records> _records = new List<Records>
	{
		new Records { Id = 1, Title = "Song 1", Artist = "Artist 1", Duration = 180, publicationYear = 2020 },
		new Records { Id = 2, Title = "Song 2", Artist = "Artist 2", Duration = 200, publicationYear = 2019 },
		new Records { Id = 3, Title = "Song 3", Artist = "Artist 3", Duration = 240, publicationYear = 2021 }
	};

	public List<Records> GetAllRecords(string? title = null, string? artist = null)
	{
		IEnumerable<Records> result = _records;

		if (!string.IsNullOrWhiteSpace(title))
		{
			result = result.Where(r => r.Title != null &&
				r.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
		}

		if (!string.IsNullOrWhiteSpace(artist))
		{
			result = result.Where(r => r.Artist != null &&
				r.Artist.Contains(artist, StringComparison.OrdinalIgnoreCase));
		}

		return result.ToList();
	}
}