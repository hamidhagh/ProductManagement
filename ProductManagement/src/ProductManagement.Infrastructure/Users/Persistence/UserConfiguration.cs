using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Common.Interfaces;
using ProductManagement.Domain.Users;
using ProductManagement.Infrastructure.Authentication.PasswordHasher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Users.Persistence
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly IPasswordHasher _passwordHasher;

        public UserConfiguration(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired();

            builder.Property(u => u.LastName)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Phone)
                .IsRequired();

            builder.Property("PasswordHash");

            
        }
    }
}
