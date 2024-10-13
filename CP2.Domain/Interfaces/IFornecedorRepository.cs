using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        FornecedorEntity? ObterPorId(int id);
        IEnumerable<FornecedorEntity> ObterTodos();
        void Adicionar(FornecedorEntity entity);
        void Atualizar(FornecedorEntity entity);
        FornecedorEntity? DeletarDados(int id);
    }
}
