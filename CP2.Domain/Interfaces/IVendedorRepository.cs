using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        VendedorEntity? ObterPorId(int id);
        IEnumerable<VendedorEntity> ObterTodos();
        void Adicionar(VendedorEntity entity);
        void Atualizar(VendedorEntity entity);
        VendedorEntity? DeletarDados(int id);
    }
}
