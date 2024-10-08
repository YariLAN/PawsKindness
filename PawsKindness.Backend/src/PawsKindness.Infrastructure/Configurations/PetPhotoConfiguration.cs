﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsKindness.Domain.Models.PetControl.Entities;
using PawsKindness.Domain.Models.PetControl.ValueObjects.Ids;

namespace PawsKindness.Infrastructure.Configurations
{
    public class PetPhotoConfiguration : IEntityTypeConfiguration<PetPhoto>
    {
        public void Configure(EntityTypeBuilder<PetPhoto> builder)
        {
            builder.ToTable("pet_photos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                    id => id.Value, 
                    id => PetPhotoId.Create(id));

            builder.Property(x => x.Path)
                .IsRequired();

            builder.Property(x => x.IsMain)
                .IsRequired();
        }
    }
}
