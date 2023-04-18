using CarWorkshop.Application.DTO;

namespace CarWorkshop.Application.Services
{
    public interface ICarWorkshopService
    {
        Task Create(CarWorkshopDto carWorkshopDto);
        Task<IEnumerable<CarWorkshopDto>> GetAll();
    }
}