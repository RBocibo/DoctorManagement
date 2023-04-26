using AutoMapper;
using DoctorManagement.Domain.Entities;
using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Domain.UnitOfWorkInterface;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Services;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace DoctorManagement.ServiceTests.Services
{
    public class UpdatePatientServiceTest
    {
        private readonly Mock<IPatientRepository> _patientRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IMapper> _mapper;

        public UpdatePatientServiceTest()
        {
            _patientRepository = new Mock<IPatientRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task UpdatePatient_Returns_Success()
        {
            int patientId = 1;

            Patient patient = new Patient()
            {
                PatientId = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                Email = "Test@gmail.com",
            };

            UpdatePatientDTO patientDTO = new UpdatePatientDTO()
            {
                FirstName = "rose",
                LastName = "Test",
                PhoneNumber = "Test",
                Email = "Test@gmail.com",
            };

            //Arrange
            _patientRepository.Setup(x => x.GetByIsAsync(It.IsAny<Expression<Func<Patient, bool>>>()))
                .Returns(Task.FromResult(patient));
            _patientRepository.Setup(x => x.UpdateAsync(It.IsAny<Patient>()))
                .Returns(Task.FromResult(patient));
            _mapper.Setup(x => x.Map<UpdatePatientDTO>(It.Is<Patient>(m => m.Equals(patient))))
                .Returns(patientDTO);

            var service = new PatientService(_patientRepository.Object, _unitOfWork.Object, _mapper.Object);

            //Act
            var serviceResponse = service.UpdatePatientAsync(patientId, patientDTO);
            var result = serviceResponse.Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result, patientDTO);
        }
    }
}
