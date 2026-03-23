using RealEstateSystem.Domain.Abstractions;
using RealEstateSystem.Domain.Enums;

namespace RealEstateSystem.Domain.Entities;

public class CategoryEntity : IEntity
{
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public CategoryPurposeEnum Purpose { get; set; }
}
