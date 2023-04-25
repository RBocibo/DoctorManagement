using AutoMapper;
using DoctorManagement.Domain.UnitOfWorkInterface;

namespace DoctorManagement.Services.Services
{
    public class BaseRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseRepository(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
