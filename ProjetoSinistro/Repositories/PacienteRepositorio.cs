using Microsoft.EntityFrameworkCore;
using ProjetoSinistro.Data;
using ProjetoSinistro.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoSinistro.Repositories
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly AppDbContext _context;

        public PacienteRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> ObterTodosAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente> ObterPorIdAsync(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task AdicionarAsync(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var paciente = await ObterPorIdAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
