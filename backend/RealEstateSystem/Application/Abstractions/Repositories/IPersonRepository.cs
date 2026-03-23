using RealEstateSystem.Domain.Entities;

namespace RealEstateSystem.Application.Abstractions.Repositories;

public interface IPersonRepository
{
    Task<List<PersonEntity>> GetAll();
    Task<PersonEntity> GetById(Guid id);
    Task<PersonEntity> Create(PersonEntity entity);
    Task Update(PersonEntity entity);
    Task Delete(PersonEntity entity);
}
