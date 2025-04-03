using Microsoft.AspNetCore.Identity;

namespace ListaTasks.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataLimite { get; set; }
        public string? AssignedUserId { get; set; } // Link para User Identitário

        public IdentityUser? AssignedUser { get; set; }
        public string? Dificuldade { get; set; }
        public bool Completa { get; set; } = false;
    }
}
