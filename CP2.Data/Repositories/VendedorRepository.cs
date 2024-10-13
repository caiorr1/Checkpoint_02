using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class VendedorRepository : IVendedorRepository
{
    private readonly ApplicationContext _context;

    public VendedorRepository(ApplicationContext context)
    {
        _context = context;
    }

    public VendedorEntity? ObterPorId(int id)
    {
        // Consulta o vendedor pelo ID e usa AsNoTracking para melhorar o desempenho em consultas de leitura
        return _context.Vendedor
                       .AsNoTracking() // Não rastreia as alterações, melhor para leitura
                       .FirstOrDefault(v => v.Id == id);
    }

    public IEnumerable<VendedorEntity> ObterTodos()
    {
        // Retorna todos os vendedores sem tracking para melhorar o desempenho
        return _context.Vendedor
                       .AsNoTracking()
                       .ToList();
    }

    public void Adicionar(VendedorEntity entity)
    {
        // Adiciona o novo vendedor e salva as mudanças
        _context.Vendedor.Add(entity);
        _context.SaveChanges();
    }

    public void Atualizar(VendedorEntity entity)
    {
        // Atualiza o vendedor existente
        _context.Vendedor.Update(entity);
        _context.SaveChanges();
    }

    public VendedorEntity? DeletarDados(int id)
    {
        var entity = _context.Vendedor.Find(id);
        if (entity != null)
        {
            _context.Vendedor.Remove(entity);
            _context.SaveChanges();
        }
        return entity;
    }
}
