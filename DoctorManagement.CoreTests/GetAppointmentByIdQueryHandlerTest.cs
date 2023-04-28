using DoctorManagement.Core.CQRS.Queries.GetAppointmentByIdHandlers;
using DoctorManagement.Domain.Entities.Enums;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;
using Moq;
using Xunit;

namespace DoctorManagement.CoreTests
{
    public class GetAppointmentByIdQueryHandlerTest
    {
        private readonly Mock<IAppointmentService> _appointmentService;

        public GetAppointmentByIdQueryHandlerTest()
        {
            _appointmentService = new Mock<IAppointmentService>();
        }

        [Fact]
        public async Task GetAppointmentById_Returns_Success()
        {
            AppointmentDTO appointmentDTO = new AppointmentDTO()
            {
                AppointmentId = 1,
                StartTime = DateTime.UtcNow,
                AppointmentStatus = AppointmentStatus.Active,
                OfficeId = 1,
                PatientId = 1,
            };

            //Arrange
            _appointmentService.Setup(x => x.GetAppointmentByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(appointmentDTO));

            var queryHandler = new GetAppointmentByIdQueryHandler(_appointmentService.Object);

            //Act
            var queryHandlerResponse = queryHandler.Handle(new GetAppointmentByIdQuery(appointmentDTO.AppointmentId), CancellationToken.None);
            var result = queryHandlerResponse.Result as AppointmentDTO;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<AppointmentDTO>(result);
            Assert.Equal(result, appointmentDTO);
        }
    }
}
