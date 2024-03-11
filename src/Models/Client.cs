using CodeChallenge.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeChallenge.Models
{
    public class Client
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Fone { get; set; }
        public DateTime DataRegistro { get; set; }
        [Required]
        public Tipo Tipo { get; set; }
        [Required]
        public string CpfOuCnpj { get; set; }
        public bool Isento { get; set; }
        public string? Inscricao { get; set; }
        public Genero? Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool ClientBlocked { get; set; }
        [StringLength(12, ErrorMessage = "A senha deve ter entre 8 e 12 caracteres!", MinimumLength = 8)]
        public string? Senha { get; set; }        
        [NotMapped]
        public string? ConfirmacaoSenha { get; set; }

        public Client()
        {
        }

        public Client(string nome, string email, string fone, Tipo tipo,
            string cpfOuCnpj, bool isento, string inscricao)
        {
            Nome = nome;
            Email = email;
            Fone = fone;
            DataRegistro = DateTime.Today;
            Tipo = tipo;
            CpfOuCnpj = cpfOuCnpj;
            Isento = isento;
            Inscricao = inscricao;
            ClientBlocked = false;
        }

        public Client(string nome, string email, string fone, Tipo tipo,
            string cpfOuCnpj, bool isento)
        {
            Nome = nome;
            Email = email;
            Fone = fone;
            DataRegistro = DateTime.Today;
            Tipo = tipo;
            CpfOuCnpj = cpfOuCnpj;
            Isento = isento;
            ClientBlocked = false;
        }

        public Client(string nome, string email, string fone, Tipo tipo,
            string cpfOuCnpj, bool isento, Genero? genero, DateTime? dataNascimento,
            bool clientBlocked, string senha)
        {
            Nome = nome;
            Email = email;
            Fone = fone;
            DataRegistro = DateTime.Today;
            Tipo = tipo;
            CpfOuCnpj = cpfOuCnpj;
            Isento = isento;
            Genero = genero;
            DataNascimento = dataNascimento;
            ClientBlocked = clientBlocked;                        
            Senha = senha;
        }

        public Client(string nome, string email, string fone, Tipo tipo,
            string cpfOuCnpj, bool isento, string inscricao, Genero? genero,
            DateTime? dataNascimento, bool clientBlocked, string senha)
        {
            Nome = nome;
            Email = email;
            Fone = fone;
            DataRegistro = DateTime.Today;
            Tipo = tipo;
            CpfOuCnpj = cpfOuCnpj;
            Isento = isento;
            Inscricao = inscricao;
            Genero = genero;
            DataNascimento = dataNascimento;
            ClientBlocked = clientBlocked;
            Senha = senha;
        }        
    }    
}