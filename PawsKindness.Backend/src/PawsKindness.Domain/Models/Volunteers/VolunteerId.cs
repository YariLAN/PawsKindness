﻿namespace PawsKindness.Domain.Models.Volunteers;

public record VolunteerId
{
    public Guid Value { get; }

    private VolunteerId(Guid id)
    {
        Value = id;
    }

    public static VolunteerId NewVolunteerId() => new VolunteerId(Guid.NewGuid());

    public static VolunteerId Empty() => new VolunteerId(Guid.Empty);

    public static VolunteerId Create(Guid id) => new VolunteerId(id);
}
