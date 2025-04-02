using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ListaTasks.Models;

namespace ListaTasks.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Construtor Runtime
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Construtor sem parâmetro para o design-time !!! Importante !!!
        public ApplicationDbContext() : base() { }

        // Declaração das Tarefas
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}