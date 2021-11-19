using System;
using System.Data.Common;
using System.Linq;
using EntityFrameworkCore.Examples.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Examples.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        private readonly IHttpContextAccessor _contextAccessor;

        private const string ConnectionStringQueryParameter = "dataSource";

        public string ConnectionString { get; private set; }
        
        public ApplicationDbContext()
        {
            
        }

        /// <summary>
        /// Used for initial migrations
        /// Multiple databases need to be created.
        /// </summary>
        /// <param name="cs">The connectionstring to use</param>
        public void SetConnectionString(string cs)
        {
            this.ConnectionString = cs;
        }
        
        public ApplicationDbContext(IHttpContextAccessor contextAccessor)
        {
            // We will use the context accessor to extract the connectionstring
            _contextAccessor = contextAccessor;
        }
        
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set the connectionstring, based on parameter in request query string
            this.ConnectionString ??= GetConnectionStringFromDataSource(GetDataSourceFromRequest());
            optionsBuilder
                .UseSqlite(this.ConnectionString);

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Person>().HasData(new Person(1, "John", "Doe"));
            modelBuilder.Entity<Person>().HasData(new Person(2, "Allan", "Seth"));
        }
        

        /// <summary>
        /// Fetches the datasource from request query string
        /// Throws exception when datasource is not found
        /// </summary>
        /// <returns>Datasource</returns>
        private string GetDataSourceFromRequest()
        {
            var queryParam = _contextAccessor?.HttpContext?.Request?.Query[ConnectionStringQueryParameter].SingleOrDefault();
            return queryParam;
        }

        /// <summary>
        /// Fetches connectionstring based on datasource
        /// Throws exception when datasource is unknown
        /// </summary>
        /// <param name="dataSource">datasource, as fetched from request query string</param>
        /// <returns>Connectionstring</returns>
        private string GetConnectionStringFromDataSource(string dataSource)
        {
            return dataSource switch
            {
                "data_1" => ConnectionStrings.Cs_1,
                "data_2" => ConnectionStrings.Cs_2,
                _ => ConnectionStrings.Cs_Default
            };
        }
    }
}