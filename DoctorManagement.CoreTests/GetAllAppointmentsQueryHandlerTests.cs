using DoctorManagement.Core.CQRS.Queries.GetAllAppointmentsQueryHandlers;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;
using Moq;
using Xunit;

namespace DoctorManagement.CoreTests
{
    public class GetAllAppointmentsQueryHandlerTests
    {
        private readonly Mock<IAppointmentService> _appointmentsServiceMock;

        public GetAllAppointmentsQueryHandlerTests()
        {
            _appointmentsServiceMock = new Mock<IAppointmentService>();
        }

        [Fact]
        public async Task GetAllAppointments_Returns_Success()
        {
            IEnumerable<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>()
            {
                new AppointmentDTO()
                {
                    AppointmentId = 1,
                    StartTime = DateTime.Now,
                    OfficeId = 1,
                    PatientId = 1,
                    AppointmentStatus = Domain.Entities.Enums.AppointmentStatus.Active
                },
                new AppointmentDTO()
                {
                    AppointmentId = 2,
                    StartTime = DateTime.Now,
                    OfficeId = 1,
                    PatientId = 2,
                    AppointmentStatus = Domain.Entities.Enums.AppointmentStatus.Active
                },
            };

            //Arrange
            _appointmentsServiceMock.Setup(x => x.ListAppointmentAsync())
                .Returns(Task.FromResult(appointmentDTOs));

            var appointmentQuery = new GetAllAppointmentsQueryHandler(_appointmentsServiceMock.Object);

            //Act

            var queryresponse = appointmentQuery.Handle(new GetAllAppointmentsQuery(), CancellationToken.None);
            var result = queryresponse.Result as List<AppointmentDTO>;

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<List<AppointmentDTO>>(result);
            Assert.Equal(result, appointmentDTOs);
        }
    }
}
