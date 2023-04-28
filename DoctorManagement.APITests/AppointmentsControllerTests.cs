using DoctorManagement.API.Controllers;
using DoctorManagement.Core.CQRS.Queries.GetAllAppointmentsQueryHandlers;
using DoctorManagement.Core.CQRS.Queries.GetAppointmentByIdHandlers;
using DoctorManagement.Domain.Entities.Enums;
using DoctorManagement.Models.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DoctorManagement.APITests
{
    public class AppointmentsControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;

        public AppointmentsControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task GetAllAppointments_Return_Success()
        {
            IEnumerable<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>()
            {
                new AppointmentDTO
                {
                    AppointmentId = 1,
                    StartTime = DateTime.Now,
                    AppointmentStatus = AppointmentStatus.Active,
                    OfficeId = 1,
                    PatientId = 1,
                },

                new AppointmentDTO
                {
                    AppointmentId = 2,
                    StartTime = DateTime.Now,
                    AppointmentStatus = AppointmentStatus.Active,
                    OfficeId = 1,
                    PatientId = 2,
                },
            };

            //Arrange
            _mockMediator.Setup(x => x.Send(It.IsAny<GetAllAppointmentsQuery>(), CancellationToken.None))
                .Returns(Task.FromResult(appointmentDTOs));

            var controller = new AppointmentsController(_mockMediator.Object);

            //Act
            var controllerResponse = controller.GetAllAppointments();
            var result = controllerResponse.Result as OkObjectResult;
            var resultValue = result.Value as List<AppointmentDTO>;

            //Assert
            Assert.NotNull(resultValue);
            //Assert.IsType<OkObjectResult>(resultValue);
            Assert.Equal(resultValue, appointmentDTOs);
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
                PatientId= 1,
            };

            //Arrange
            _mockMediator.Setup(x => x.Send(It.IsAny<GetAppointmentByIdQuery>(), CancellationToken.None))
                .Returns(Task.FromResult(appointmentDTO));

            var controller = new AppointmentsController(_mockMediator.Object);

            //Act
            var constrollerResponse = controller.GetAppointmentById(appointmentDTO.AppointmentId);
            var result = constrollerResponse.Result as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<AppointmentDTO>(result.Value);
            Assert.Equal(result.Value, appointmentDTO);
        }
    }
}
