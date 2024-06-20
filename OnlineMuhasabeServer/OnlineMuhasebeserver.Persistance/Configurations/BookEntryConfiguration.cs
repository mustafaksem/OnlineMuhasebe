using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Persistance.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistance.Configurations
{
    public sealed class BookEntryConfiguration : IEntityTypeConfiguration<BookEntry>
    {
        public void Configure(EntityTypeBuilder<BookEntry> builder)
        {
            builder.ToTable(TableNames.BookEntries);
            builder.HasKey(t => t.Id);
        }
    }
}
