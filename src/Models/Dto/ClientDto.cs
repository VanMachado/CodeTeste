using CodeChallenge.Models.Dto.EnumsDto;

namespace CodeChallenge.Models.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }        
        public string Nome { get; set; }        
        public string Email { get; set; }        
        public string Fone { get; set; }
        public DateTime DataRegistro { get; set; }        
        public TipoDto Tipo { get; set; }        
        public string CpfOuCnpj { get; set; }
        public bool Insento { get; set; }
        public string? Inscricao { get; set; }
        public GeneroDto? Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool ClientBlocked { get; set; }
        public string? Senha { get; set; }        
        public string? ConfirmacaoSenha { get; set; }
    }
}
