using RealEstateSystem.Application.DTOs.Person;

namespace RealEstateSystem.Application.Abstractions.Services;

public interface IPersonService
{
    public Task<List<PersonDto>> GetAll();
    public Task<PersonDto> GetById(Guid id);
    public Task<PersonDto> Create(CreatePersonDto dto);
    public Task<PersonDto?> Update(Guid id, UpdatePersonDto dto);
    public Task Remove(Guid id);
}
