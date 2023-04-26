using DoctorManagement.API.Controllers;
using DoctorManagement.Core.CQRS.Commands.AddPatientCommands;
using DoctorManagement.Models.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DoctorManagement.APITests
{
    public class PatientControllerTest
    {
        private readonly Mock<IMediator> _mediator;

        public PatientControllerTest()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task AddPatient_Returns_Success()
        {
            var patientDTO = new PatientDTO()
            {
                PatientId = 1,
                FirstName = "Name",
                LastName = "Surname",
                PhoneNumber = "01221233654",
                Email = "Test@email.com",
            };

            //Arrange
            _mediator.Setup(x => x.Send(It.IsAny<AddPatientCommand>(), CancellationToken.None))
                .ReturnsAsync(patientDTO);

            var patientController = new PatientsController(_mediator.Object);

            //Act
            var responseController = await patientController.RegisterPatient(patientDTO);
            var result = responseController as OkObjectResult;
            var resultValue = result.Value as PatientDTO;

            //Assert

            Assert.NotNull(resultValue);
            Assert.IsType<PatientDTO>(resultValue);
            Assert.Equal(patientDTO, resultValue);
        }
    }
}
