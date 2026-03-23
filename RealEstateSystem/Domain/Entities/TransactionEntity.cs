using RealEstateSystem.Domain.Abstractions;
using RealEstateSystem.Domain.Enums;

namespace RealEstateSystem.Domain.Entities;

public class TransactionEntity : IEntity
{
    public Guid Id { get; set; }

    public required string Description { get; set; }

    public decimal Amount { get; set; }

    public TransactionKindEnum Kind { get; set; }

    public int CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }

    public int PersonId { get; set; }
    public PersonEntity? Person { get; set; }
}
