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
		public ActionResult<IEnumerable<Records>> GetAll()
		{
			return Ok(_repository.GetAllRecords());
		}
	}
}
