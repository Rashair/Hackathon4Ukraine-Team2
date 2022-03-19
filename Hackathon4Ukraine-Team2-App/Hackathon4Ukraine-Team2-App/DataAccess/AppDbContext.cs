// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Net;
using System.Security.Cryptography;
using Hackathon4Ukraine_Team2_App.Domain;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Hackathon4Ukraine_Team2_App.DataAccess
{
    /// <summary>
    /// <see cref="DbContext"/> implementation for Planetary Docs.
    /// </summary>
    public sealed class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The configuration options.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {}

        public DbSet<RequestHelp> RequestHelps { get; set; }

        /// <summary>
        /// Configure the model that maps the domain to the backend.
        /// </summary>
        /// <param name="modelBuilder">The API for model configuration.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestHelp>()
                .HasNoDiscriminator()
                .ToContainer(nameof(RequestHelps))
                .HasNoDiscriminator()
                .HasPartitionKey(da => da.Id)
                .HasKey(da => da.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
