namespace EntityFrameworkCore.Examples.Application.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()
        {
            
        }
        public Person(int personId, string firstName, string lastName)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}