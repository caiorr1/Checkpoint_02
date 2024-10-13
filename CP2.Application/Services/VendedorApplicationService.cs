using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace CP2.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        public VendedorEntity? DeletarDadosVendedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public IEnumerable<VendedorEntity> ObterTodosVendedores()
        {
            return _repository.ObterTodos();
        }

        public VendedorEntity? ObterVendedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public VendedorEntity? SalvarDadosVendedor(IVendedorDto dto)  // Interface corrigida aqui
        {
            // Valida o DTO antes de processar
            dto.Validate();

            var entity = new VendedorEntity
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                DataNascimento = dto.DataNascimento,
                Endereco = dto.Endereco,
                DataContratacao = dto.DataContratacao,
                ComissaoPercentual = dto.ComissaoPercentual,
                MetaMensal = dto.MetaMensal,
                CriadoEm = dto.CriadoEm
            };

            _repository.Adicionar(entity);
            return entity;
        }

        public VendedorEntity? EditarDadosVendedor(int id, IVendedorDto dto)  // Interface corrigida aqui
        {
            // Valida o DTO antes de processar
            dto.Validate();

            var entity = _repository.ObterPorId(id);
            if (entity == null) return null;

            entity.Nome = dto.Nome;
            entity.Email = dto.Email;
            entity.Telefone = dto.Telefone;
            entity.DataNascimento = dto.DataNascimento;
            entity.Endereco = dto.Endereco;
            entity.DataContratacao = dto.DataContratacao;
            entity.ComissaoPercentual = dto.ComissaoPercentual;
            entity.MetaMensal = dto.MetaMensal;
            entity.CriadoEm = dto.CriadoEm;

            _repository.Atualizar(entity);
            return entity;
        }
    }
}
