namespace TTAG.Domain.Model
{
    using System;
    using TTAG.Common;

    public class Art : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Dimensions { get; set; }

        public int ReleaseYear { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal Price { get; set; }

        public string ReferenceUrl { get; set; }

        public string ArtistId { get; set; } = Guid.NewGuid().ToString();

        public ArtCategory Category { get; set; }

        public Address Address { get; set; } = new Address();
    }
}
