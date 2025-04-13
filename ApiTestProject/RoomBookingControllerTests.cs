using IntegrationTestProject.App.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RoomBookingApp.Core;
using RoomBookingApp.Core.Enum;
using RoomBookingTestProject.App.Controllers;
using Shouldly;

namespace ApiTestProject
{
    public class RoomBookingControllerTests
    {
        private Mock<IRoomBookingRequestProcessor> _roomBookingProcessor;
        private RoomBookingController _controller;
        private RoomBookingRequest _request;
        private RoomBookingResult _result;
        public RoomBookingControllerTests()
        {
            _roomBookingProcessor = new Mock<IRoomBookingRequestProcessor>();
            _controller = new RoomBookingController(_roomBookingProcessor.Object);
            _request = new RoomBookingRequest();
            _result = new RoomBookingResult();
            _roomBookingProcessor.Setup(x=>x.BookRoom(_request)).Returns(_result);
        }
        [Fact]
        public void Should_Return_Forcast_Result()
        {
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);
            var result = controller.Get();
            result.Count().ShouldBeGreaterThan(1);
            result.ShouldNotBeNull();

        }

        [Theory]
        [InlineData(1,true,typeof(OkObjectResult),BookingResultFlag.Success)]
        [InlineData(0,false,typeof(BadRequestObjectResult), BookingResultFlag.Failure)]
        public async Task Should_Call_Booking_Method_When_Valid(int expectedMethodCalls , bool isModelValid ,
            Type expectedActionResultType, BookingResultFlag bookingResultFlag)
        {
            //Arrange
            if(!isModelValid)
            {
                _controller.ModelState.AddModelError("Key","ErrorMessage");
            }
            _result.Flag = bookingResultFlag;

            //Act
            var result = await _controller.BookRoom(_request);

            //Assert
            result.ShouldBeOfType(expectedActionResultType);
            _roomBookingProcessor.Verify(x=>x.BookRoom(_request) , Times.Exactly(expectedMethodCalls));
        }
    }
}
