using DoctorManagement.Core.CQRS.Commands.AddPatientCommands;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;
using Moq;
using System.Reflection.Metadata;
using Xunit;

namespace DoctorManagement.CoreTests
{
    public class AddPatientCommandHandlerTest
    {
        private readonly Mock<IPatientService> _patientService;

        public AddPatientCommandHandlerTest()
        {
            _patientService = new Mock<IPatientService>();
        }

        [Fact]
        public async Task AddPatientCommandHandler_Returns_Success()
        {
            var patientDTO = new PatientDTO()
            {
                PatientId = 1,
                FirstName = "name",
                LastName = "surname",
                PhoneNumber = "0123456789",
                Email = "email@gmail.com",
            };

            _patientService.Setup(x => x.AddPatient(It.IsAny<PatientDTO>()))
                .Returns(Task.FromResult(patientDTO));

            var handler = new AddPatientCommandHandler(_patientService.Object);

            //Act
            var handlerResponse = handler.Handle(new AddPatientCommand(patientDTO), CancellationToken.None);
            var result = handlerResponse.Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result, patientDTO);
            
        }
    }
}
