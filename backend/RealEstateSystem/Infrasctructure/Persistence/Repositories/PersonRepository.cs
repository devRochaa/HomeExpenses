using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Application.Abstractions.Repositories;
using RealEstateSystem.Domain.Entities;

namespace RealEstateSystem.Infrasctructure.Persistence.Repositories;

public class PersonRepository(AppDbContext context) : IPersonRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<PersonEntity>> GetAll()
    {
        return await _context
            .Persons
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<PersonEntity?> GetById(Guid id)
    {
        return await _context.Persons.FindAsync(id);
    }

    public async Task<PersonEntity> Create(PersonEntity entity)
    {
        _context.Persons.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Update(PersonEntity entity)
    {
        await _context.SaveChangesAsync();
    }

    public async Task Delete(PersonEntity entity)
    {
        _context.Persons.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
