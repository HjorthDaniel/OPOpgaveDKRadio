using OPOpgaveDKRadio.Model;

namespace OPOpgaveDKRadio.Repository;

public class RecordsRepository
{
	public List<Records> GetAllRecords()
	{
		return new List<Records>
		{
			new Records { Title = "Song 1", Artist = "Artist 1", Duration = 180, publicationYear = 2020 },
			new Records { Title = "Song 2", Artist = "Artist 2", Duration = 200, publicationYear = 2019 },
			new Records { Title = "Song 3", Artist = "Artist 3", Duration = 240, publicationYear = 2021 }
		};
	}
}