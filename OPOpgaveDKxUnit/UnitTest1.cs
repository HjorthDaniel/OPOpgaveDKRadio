using OPOpgaveDKRadio.Model;
using OPOpgaveDKRadio.Repository;

namespace OPOpgaveDKRadio.Tests
{
	public class RecordsRepositoryTests
	{
		[Fact]
		public void GetAllRecords_ReturnsThreeRecords()
		{
			// Arrange
			RecordsRepository repository = new RecordsRepository();

			// Act
			List<Records> records = repository.GetAllRecords();

			// Assert
			Assert.Equal(3, records.Count);
		}

		[Fact]
		public void GetAllRecords_FirstRecordHasCorrectTitle()
		{
			// Arrange
			RecordsRepository repository = new RecordsRepository();

			// Act
			List<Records> records = repository.GetAllRecords();

			// Assert
			Assert.Equal("Song 1", records[0].Title);
		}
	}
}