using AssessmentApp.Data.Context;
using AssessmentApp.Domain.Domain;
using AssessmentApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssessmentApp.Data.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly AppDbContext _context;

        public VeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Veiculo> BuscarPorId(long id)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Veiculo>> ListarVeiculos()
        {
            return await _context.Veiculos
                .AsNoTracking()
                .Select(v => new Veiculo
                {
                    Id = v.Id,
                    Placa = v.Placa,
                    Marca = v.Marca,
                    Modelo = v.Modelo,
                    AnoFabricacao = v.AnoFabricacao,
                    AnoModelo = v.AnoModelo,
                    ValorTabelaFipe = v.ValorTabelaFipe,
                    ValorVenda = v.ValorVenda
                })
                .ToListAsync();
        }


        public async Task<bool> Adicionar(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Editar(Veiculo veiculo)
        {
            var entity = await _context.Veiculos.FindAsync(veiculo.Id);

            if (entity != null)
            {
                // Desanexa a entidade original para evitar o erro de instância duplicada
                _context.Entry(entity).State = EntityState.Detached;
            }

            _context.Veiculos.Attach(veiculo);
            _context.Entry(veiculo).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Deletar(long id)
        {
            var veiculo = await _context.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
            _context.Veiculos.Remove(veiculo);
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
