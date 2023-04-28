using AutoMapper;
using DoctorManagement.Domain.Entities;
using DoctorManagement.Domain.Entities.Enums;
using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Domain.UnitOfWorkInterface;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Services;
using Moq;
using Xunit;

namespace DoctorManagement.ServiceTests.Services
{
    public class AppointmentServiceTests
    {
        private readonly Mock<IAppointmentRepository> _appointmentRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IMapper> _mapper;

        public AppointmentServiceTests()
        {
            _appointmentRepository = new Mock<IAppointmentRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetAllAppointments_Returns_Success()
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

            IEnumerable<Appointment> appointments = new List<Appointment>()
            {
                new Appointment
                {
                    AppointmentId = 1,
                    StartTime = DateTime.Now,
                    AppointmentStatus = AppointmentStatus.Active,
                    OfficeId = 1,
                    PatientId = 1,
                },

                new Appointment
                {
                    AppointmentId = 2,
                    StartTime = DateTime.Now,
                    AppointmentStatus = AppointmentStatus.Active,
                    OfficeId = 1,
                    PatientId = 2,
                },
            };

            //Arrange
            _appointmentRepository.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(appointments));

            _mapper.Setup(x => x.Map<IEnumerable<AppointmentDTO>>(It.Is<IEnumerable<Appointment>>(x => x.Equals(appointments))))
                .Returns(appointmentDTOs);

            var appointmentService = new AppointmentService(_unitOfWork.Object, _mapper.Object, _appointmentRepository.Object);

            //Act
            var serviceResponse = appointmentService.ListAppointmentAsync();
            var result = serviceResponse.Result as List<AppointmentDTO>;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<AppointmentDTO>>(result);
            Assert.Equal(result, appointmentDTOs);
        }
    }
}
