using DoctorManagement.Core.CQRS.Commands.AddPatientCommands;
using System.Reflection;
using MediatR;

namespace DoctorManagement.API.Extensions
{
    public static class CQRSHandlerConfigurations
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            var command = typeof(AddPatientCommand).GetTypeInfo().Assembly;

            services.AddMediatR(command);
        }
    }
}
