using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeChallenge.Models.Base
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool ClientBlocked { get; set; }

        public BaseEntity(string email, string phone, DateTime registrationDate, bool clientBlocked)
        {            
            Email = email;
            Phone = phone;
            RegistrationDate = registrationDate;
            ClientBlocked = clientBlocked;
        }
    }
}
