using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using System;
using SchoolLocker.Core.DataTransferObjects;
using System.Threading.Tasks;

namespace SchoolLocker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Liefert alle überlappenden Buchungen
        /// </summary>
        /// <param name="lockerNumber"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <response code="200">Die Abfrage war erfolgreich.</response>
        /// <response code="404">Zu dieser Nummer gibt es keinen Spint!</response>
        // GET: api/Bookings/104;2013-07-29T21:58:39;2013-07-29T21:58:39
        [HttpGet("/GetOverlappingBookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookingDto[]>> GetOverlappingBookings(int lockerNumber, DateTime from, DateTime to)
        {
            if (await _unitOfWork
                    .LockerRepository
                    .GetByLockerNrAsync(lockerNumber) == null)
            {
                return NotFound();
            }

            var bookings = await _unitOfWork.BookingRepository.GetOverlappingBookingsAsync(lockerNumber, from, to);
            return bookings;
            // 2020-07-01  2020-07-20  ==> 0
            // 2020-07-01  2020-07-21  ==> 1
            // 2020-06-29  2020-07-20  ==> 1
            // 2020-07-20  2020-08-08  ==> 1
            // 2019-10-21  2020-09-03  ==> 3
            // 2020-06-29  2020-08-16  ==> 3
        }

    }
}