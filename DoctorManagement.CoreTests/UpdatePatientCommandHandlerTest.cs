using DoctorManagement.Core.CQRS.Commands.UpdatePatientCommands;
using DoctorManagement.Domain.Entities;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;
using Moq;
using Xunit;

namespace DoctorManagement.CoreTests
{
    public class UpdatePatientCommandHandlerTest
    {
        private readonly Mock<IPatientService> _patientService;

        public UpdatePatientCommandHandlerTest()
        {
            _patientService = new Mock<IPatientService>();
        }

        [Fact]
        public async Task UpdatePatient_Returns_Success()
        {
            int patientId = 1;
            UpdatePatientDTO patient = new UpdatePatientDTO()
            {
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                Email = "email@gmail.com"
            };

            //Arrange
            _patientService.Setup(x => x.UpdatePatientAsync(patientId, patient))
                .Returns(Task.FromResult(patient));

            var handler = new UpdatePatientCommandHandler(_patientService.Object);

            //Act
            var handlerResponse = await handler.Handle(new UpdatePatientCommand(patientId, patient), CancellationToken.None);
            
            //Assert
            Assert.NotNull(handlerResponse);
            Assert.Equal(handlerResponse.FirstName, patient.FirstName);
            Assert.Equal(handlerResponse.LastName, patient.LastName);
            Assert.Equal(handlerResponse.PhoneNumber, patient.PhoneNumber);
            Assert.Equal(handlerResponse.Email, patient.Email);
        }
    }
}
