﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class ShowGenreEntityConfig
    {
        public static void SetShowGenreEntityConfig(EntityTypeBuilder<ShowGenre> entityBuilder)
        {
            entityBuilder.HasKey( x => x.Id_key);
            entityBuilder.Property(x => x.Id_key)
                 .ValueGeneratedOnAdd()  // Indica que la columna es autonumérica
                 .IsRequired();          // Asegura que la clave primaria no sea nula
        }
    }
}
