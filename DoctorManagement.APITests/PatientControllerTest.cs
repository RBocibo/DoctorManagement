using DoctorManagement.API.Controllers;
using DoctorManagement.Core.CQRS.Commands.AddPatientCommands;
using DoctorManagement.Core.CQRS.Commands.UpdatePatientCommands;
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

        [Fact]
        public async Task UpdatePatient_Returns_Success()
        {
            int patientId = 1;
            var patientDTO = new UpdatePatientDTO()
            {
                FirstName = "Name",
                LastName = "surname",
                PhoneNumber = "0123456789",
                Email = "email@gmail.com",
            };

            //Arrange
            _mediator.Setup(x => x.Send(It.IsAny<UpdatePatientCommand>(), CancellationToken.None))
                .ReturnsAsync(patientDTO);

            var patientController = new PatientsController(_mediator.Object);

            //Act
            var patientResponse = await patientController.UpdatePatient(patientId, patientDTO);
            var result = patientResponse as OkObjectResult;
            var resultValue = result.Value as UpdatePatientDTO;

            //Assert
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue, patientDTO);
        }
    }
}
