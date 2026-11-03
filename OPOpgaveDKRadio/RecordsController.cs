using Microsoft.AspNetCore.Mvc;
using OPOpgaveDKRadio.Model;
using OPOpgaveDKRadio.Repository;

namespace OPOpgaveDKRadio
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecordsController : ControllerBase
	{
		private readonly RecordsRepository _repository = new RecordsRepository();

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<IEnumerable<Records>> GetAllRecords()
		{
			List<Records> records = _repository.GetAllRecords();

			if (records.Count == 0)
			{
				return NoContent();
			}

			return Ok(records);


		}
	}
}
