using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace CP2.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<FornecedorEntity> ObterTodosFornecedores()
        {
            return _repository.ObterTodos();
        }

        public FornecedorEntity? SalvarDadosFornecedor(IFornecedorDto dto)  // Interface usada aqui
        {
            // Valida o DTO antes de processar
            dto.Validate();

            var entity = new FornecedorEntity
            {
                Nome = dto.Nome,
                CNPJ = dto.CNPJ,
                Endereco = dto.Endereco,
                Telefone = dto.Telefone,
                Email = dto.Email,
                CriadoEm = dto.CriadoEm
            };

            _repository.Adicionar(entity);
            return entity;
        }

        public FornecedorEntity? EditarDadosFornecedor(int id, IFornecedorDto dto)  // Interface usada aqui
        {
            // Valida o DTO antes de processar
            dto.Validate();

            var entity = _repository.ObterPorId(id);
            if (entity == null) return null;

            entity.Nome = dto.Nome;
            entity.CNPJ = dto.CNPJ;
            entity.Endereco = dto.Endereco;
            entity.Telefone = dto.Telefone;
            entity.Email = dto.Email;
            entity.CriadoEm = dto.CriadoEm;

            _repository.Atualizar(entity);
            return entity;
        }
    }
}
