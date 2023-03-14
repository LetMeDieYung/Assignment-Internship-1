﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Persistence.EntityTypeConfigurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(newEvent => newEvent.Id);
            builder.HasIndex(newEvent => newEvent.Id).IsUnique();
            builder.Property(newEvent => newEvent.Title).HasMaxLength(250);
        }
    }
}
