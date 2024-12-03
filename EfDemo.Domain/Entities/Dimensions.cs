using System;

namespace EfDemo.Domain.Entities
{
    /// <summary>
    /// This entity is used as a complex type in ORM.
    /// </summary>
    /// <remarks>
    /// CONSIDER: using a record or a read-only struct instead of a class might be more appropriate from an immutability perspective.
    /// </remarks>
    public record Dimensions
    {
        public int? Height { get; init; }

        public int? Width { get; init; }

        public Dimensions() : this(null!, null!)
        { }

        public Dimensions(int? height, int? width)
        {
            Height = height;
            Width = width;
        }
    }
}
