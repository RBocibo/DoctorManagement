using AutoMapper;
using DoctorManagement.Domain.Entities;
using DoctorManagement.Models.DTOs;

namespace DoctorManagement.Models.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
        }
    }
}
