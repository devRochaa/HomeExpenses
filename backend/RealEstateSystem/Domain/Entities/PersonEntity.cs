using RealEstateSystem.Domain.Abstractions;

namespace RealEstateSystem.Domain.Entities;

public sealed class PersonEntity : IEntity
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public int Age { get; set; }
    public List<TransactionEntity>? Transactions { get; set; }
}
