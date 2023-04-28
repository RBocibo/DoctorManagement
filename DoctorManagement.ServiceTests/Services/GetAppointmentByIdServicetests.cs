using AutoMapper;
using DoctorManagement.Domain.Entities;
using DoctorManagement.Domain.Entities.Enums;
using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Domain.UnitOfWorkInterface;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Services;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace DoctorManagement.ServiceTests.Services
{
    public class GetAppointmentByIdServicetests
    {
        private readonly Mock<IAppointmentRepository> _appointmentRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IMapper> _mapper;

        public GetAppointmentByIdServicetests()
        {
            _appointmentRepository = new Mock<IAppointmentRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
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

            Appointment appointment = new Appointment()
            {
                AppointmentId = 1,
                StartTime = DateTime.UtcNow,
                AppointmentStatus = AppointmentStatus.Active,
                OfficeId = 1,
                PatientId = 1,
            };

            //Arrange
            _appointmentRepository.Setup(x => x.GetByIsAsync(It.IsAny<Expression<Func<Appointment, bool>>>()))
                .Returns(Task.FromResult(appointment));
            _mapper.Setup(x => x.Map<AppointmentDTO>(It.Is<Appointment>(s => s.Equals(appointment))))
                .Returns(appointmentDTO);

            var service = new AppointmentService(_unitOfWork.Object, _mapper.Object, _appointmentRepository.Object);

            //Act
            var ServiceResponse = service.GetAppointmentByIdAsync(appointmentDTO.AppointmentId);
            var result = ServiceResponse.Result as AppointmentDTO;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<AppointmentDTO>(result);
            Assert.Equal(result, appointmentDTO);
        }
    }
}
