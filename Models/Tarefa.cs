namespace ListaTasks.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLimite { get; set; }
        public string AssignedUserId { get; set; } // Links to Identity User
        public string Dificuldade { get; set; } // Could be an enum or separate table
        public bool Completa { get; set; } = false;
    }
}
