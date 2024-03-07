using CodeChallenge.Models.Base;

namespace CodeChallenge.Models
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }

        public Person(string name, string email,
            string phone, DateTime registrationDate, bool clientBlocked)
            : base(email, phone, registrationDate, clientBlocked)
        {
            Name = name;
        }
    }
}
