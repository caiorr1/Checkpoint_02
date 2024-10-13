using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorApplicationService
    {
        VendedorEntity? DeletarDadosVendedor(int id);
        VendedorEntity? ObterVendedorPorId(int id);
        IEnumerable<VendedorEntity> ObterTodosVendedores();
        VendedorEntity? SalvarDadosVendedor(IVendedorDto dto);
        VendedorEntity? EditarDadosVendedor(int id, IVendedorDto dto);
    }
}
