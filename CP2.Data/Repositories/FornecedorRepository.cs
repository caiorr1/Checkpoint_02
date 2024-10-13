using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly ApplicationContext _context;

    public FornecedorRepository(ApplicationContext context)
    {
        _context = context;
    }

    public FornecedorEntity? ObterPorId(int id)
    {
        // Verifica se o fornecedor existe pelo ID
        return _context.Fornecedor
                       .AsNoTracking() // Melhor para leitura, pois não faz tracking da entidade
                       .FirstOrDefault(f => f.Id == id);
    }

    public IEnumerable<FornecedorEntity> ObterTodos()
    {
        // Retorna todos os fornecedores sem tracking
        return _context.Fornecedor
                       .AsNoTracking()
                       .ToList();
    }

    public void Adicionar(FornecedorEntity entity)
    {
        // Adiciona o fornecedor e salva as mudanças
        _context.Fornecedor.Add(entity);
        _context.SaveChanges();
    }

    public void Atualizar(FornecedorEntity entity)
    {
        // Atualiza o fornecedor
        _context.Fornecedor.Update(entity);
        _context.SaveChanges();
    }

    public FornecedorEntity? DeletarDados(int id)
    {
        var entity = _context.Fornecedor.Find(id);
        if (entity != null)
        {
            _context.Fornecedor.Remove(entity);
            _context.SaveChanges();
        }
        return entity;
    }
}
