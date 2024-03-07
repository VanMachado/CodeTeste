using CodeChallenge.Models.Base;

namespace CodeChallenge.Models
{
    public class Enterprise : BaseEntity
    {
        public string CompanyName { get; set; }

        public Enterprise(string companyName, string email, 
            string phone, DateTime registrationDate, bool clientBlocked) 
            : base(email, phone, registrationDate, clientBlocked)
        {
            CompanyName = companyName;
        }
    }
}
