using RealEstateSystem.Application.Abstractions.Repositories;
using RealEstateSystem.Application.Abstractions.Services;
using RealEstateSystem.Application.DTOs.Person;
using RealEstateSystem.Domain.Entities;

namespace RealEstateSystem.Application.Services;

public class PersonService(IPersonRepository repository) : IPersonService
{
    private readonly IPersonRepository _repository = repository;

    public async Task<PersonDto> Create(CreatePersonDto dto)
    {
        dto.ValidateAndThrow();

        var person = new PersonEntity
        {
            Name = dto.Name,
            Age = dto.Age
        };

        await _repository.Create(person);

        return new PersonDto
        {
            Id = person.Id,
            Name = dto.Name,
            Age = dto.Age
        };
    }

    public async Task Remove(Guid id)
    {
        var person = await _repository.GetById(id)
            ?? throw new Exception("Pessoa não encontrada.");

        await _repository.Delete(person);
    }

    public async Task<List<PersonDto>> GetAll()
    {
        var people = await _repository.GetAll();

        return people.Select(p => new PersonDto
        {
            Id = p.Id,
            Name = p.Name,
            Age = p.Age
        }).ToList();
    }

    public async Task<PersonDto> GetById(Guid id)
    {
        var person = await _repository.GetById(id)
            ?? throw new Exception("Pessoa não encontrada.");

        return new PersonDto
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age
        };
    }

    public async Task<PersonDto?> Update(Guid id, UpdatePersonDto dto)
    {
        var person = await _repository.GetById(id)
            ?? throw new Exception("Pessoa não encontrada.");

        if (person.Name != dto.Name || person.Age != dto.Age)
        {
            person.Name = dto.Name ?? person.Name;
            person.Age = dto.Age ?? person.Age;

            await _repository.Update(person);
        }

        return new PersonDto
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age
        };
    }
}
