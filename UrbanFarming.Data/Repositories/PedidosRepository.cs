using Microsoft.EntityFrameworkCore;
using UrbanFarming.Data.Context;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UrbanFarming.Data.Repositories
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly UrbanContext _context;

        public PedidosRepository(UrbanContext context)
        {
            _context = context;
        }

        public async Task<Pedido> GetByCodigo(int codigo) 
        {
            return await _context.Pedidos.Include(p => p.Itens) 
                .FirstOrDefaultAsync(u => u.CodigoPedido == codigo);
        }

        public async Task<List<Pedido>> GetAllPedidos()
        {
            return await _context.Pedidos.Include(p => p.Itens)
                .ToListAsync();
        }

        public async Task<bool> PostPedido(Pedido pedido)
        {
            try
            {
                await _context.Pedidos.AddAsync(pedido);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<bool> PutPedido(Pedido pedido)
        {
            try
            {
                var existingPedido = await _context.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(p => p.CodigoPedido == pedido.CodigoPedido);

                if (existingPedido == null)
                {
                    return false;
                }

                existingPedido.ValorTotal = pedido.ValorTotal;
                existingPedido.Usuario = pedido.Usuario;
                existingPedido.Data = pedido.Data;

                _context.ItensPedido.RemoveRange(existingPedido.Itens); 
                existingPedido.Itens = pedido.Itens; 

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<bool> DeletePedido(int codigo) 
        {
            try
            {
                var pedido = await _context.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(p => p.CodigoPedido == codigo);

                if (pedido == null)
                    return false;

                _context.ItensPedido.RemoveRange(pedido.Itens); 
                _context.Pedidos.Remove(pedido);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
