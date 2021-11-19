using System.Collections.Generic;
using EntityFrameworkCore.Examples.Application.Models;

namespace EntityFramework.Examples.Web.Models
{
    public class PersonModel
    {
        public List<Person> Persons { get; }
        public string ConnectionString { get; }

        public PersonModel(List<Person> persons, string connectionString)
        {
            Persons = persons;
            ConnectionString = connectionString;
        }   
    }
}