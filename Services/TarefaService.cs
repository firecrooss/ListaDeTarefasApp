using Microsoft.EntityFrameworkCore;
using ListaTasks.Data;
using ListaTasks.Models;

namespace ListaTasks.Services
{
    public class TarefaService
    {
        private readonly ApplicationDbContext _context;

        public TarefaService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get tasks for specific user
        public async Task<List<Tarefa>> GetUserTarefasAsync(string userId)
        {
            return await _context.Tarefas
                .Where(t => t.AssignedUserId == userId)
                .OrderBy(t => t.DataLimite)
                .ToListAsync();
        }

        public async Task<List<Tarefa>> GetTarefasAsync(string userId)
{
    return await _context.Tarefas
        .Where(t => t.AssignedUserId == userId)
        .ToListAsync();
}

        public async Task<Tarefa?> GetTarefaByIdAsync(int id, string userId)
        {
            return await _context.Tarefas
                .FirstOrDefaultAsync(t => t.Id == id && t.AssignedUserId == userId);
        }

        public async Task CreateTaskAsync(Tarefa tarefa, string userId)
        {
            tarefa.AssignedUserId = userId;
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTarefaAsync(Tarefa tarefa, string userId)
        {
            var existing = await GetTarefaByIdAsync(tarefa.Id, userId);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(tarefa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTarefaAsync(int id, string userId)
        {
            var task = await GetTarefaByIdAsync(id, userId);
            if (task != null)
            {
                _context.Tarefas.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}