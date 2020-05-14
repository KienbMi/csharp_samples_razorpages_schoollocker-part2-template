
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolLocker.Core.Contracts;
using System.Threading.Tasks;

namespace SchoolLocker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LockersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Liefert alle existierenden Spinde
        /// </summary>
        /// <response code="200">Die Abfrage war erfolgreich.</response>
        // GET: api/Categories
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int[]>> GetLockerNumbers()
          => await _unitOfWork.LockerRepository.GetLockerNumbersAsync();

    }
}
