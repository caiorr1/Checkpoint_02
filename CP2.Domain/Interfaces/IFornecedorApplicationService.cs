using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorApplicationService
    {
        FornecedorEntity? DeletarDadosFornecedor(int id);
        FornecedorEntity? ObterFornecedorPorId(int id);
        IEnumerable<FornecedorEntity> ObterTodosFornecedores();
        FornecedorEntity? SalvarDadosFornecedor(IFornecedorDto dto);
        FornecedorEntity? EditarDadosFornecedor(int id, IFornecedorDto dto);
    }
}
