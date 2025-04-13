using Microsoft.AspNetCore.Mvc;
using RoomBookingApp.Core;
using RoomBookingApp.Core.Enum;

namespace RoomBookingTestProject.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBookingController : ControllerBase
    {
        private IRoomBookingRequestProcessor _requestProcessor;
        public RoomBookingController(IRoomBookingRequestProcessor requestProcessor)
        {
            _requestProcessor = requestProcessor;
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom(RoomBookingRequest request)
        {
            if(ModelState.IsValid)
            {
                var result = _requestProcessor.BookRoom(request);
                if(result.Flag == BookingResultFlag.Success)
                {
                    return Ok(result);
                }
                ModelState.AddModelError(nameof(RoomBookingRequest.Date),"No Rooms Available For Given Date"); //AdHoc
            }
            return BadRequest(ModelState);
        }
    }
}
