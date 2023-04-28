using AutoMapper;
using DoctorManagement.Domain.Entities;
using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Domain.UnitOfWorkInterface;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Services;
using Moq;
using Xunit;

namespace DoctorManagement.ServiceTests
{
    public class AddPatientServiceTest
    {
        private readonly Mock<IPatientRepository> _patientRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public AddPatientServiceTest()
        {
            _patientRepository = new Mock<IPatientRepository>();
            _mapper = new Mock<IMapper>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task AddPatient_Returns_Success()
        {
            Patient patient = new Patient()
            {
                PatientId = 1,
                FirstName = "name",
                LastName = "surname",
                PhoneNumber = "123456789",
                Email = "email@gmail.com",
            };

            PatientDTO patientDTO = new PatientDTO()
            {
                PatientId = 1,
                FirstName = "name",
                LastName = "surname",
                PhoneNumber = "123456789",
                Email = "email@gmail.com"
            };

            //Arrange
            _patientRepository.Setup(x => x.CreateAsync(It.IsAny<Patient>()))
                .Returns(Task.FromResult(patient));
            _mapper.Setup(x => x.Map<PatientDTO>(It.Is<Patient>(m => m.Equals(patient))))
                .Returns(patientDTO);

            var patientService = new PatientService(_patientRepository.Object, _unitOfWork.Object, _mapper.Object);

            //Act
            var serviceResponse = patientService.AddPatient(patientDTO);
            var result = serviceResponse.Result as PatientDTO;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(patient.FirstName, patientDTO.FirstName);
            Assert.Equal(patient.LastName, patientDTO.LastName);
            Assert.Equal(patient.Email, patientDTO.Email);
            Assert.Equal(patient.PatientId, patientDTO.PatientId);
        }
    }
}