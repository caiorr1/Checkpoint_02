using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            // Nome não pode ser vazio e deve ter no mínimo 2 caracteres
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O nome do fornecedor é obrigatório.")
                .MinimumLength(2).WithMessage("O nome do fornecedor deve ter no mínimo 2 caracteres.");

            // CNPJ deve ter 14 caracteres e não pode ser vazio
            RuleFor(f => f.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Length(14).WithMessage("O CNPJ deve ter 14 caracteres.");

            // Telefone não pode ser vazio e deve ter no mínimo 10 dígitos (com DDD)
            RuleFor(f => f.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve ter 10 ou 11 dígitos, incluindo o DDD.");

            // Email deve ser um endereço de email válido
            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email deve ser um endereço válido.");

            // Endereço não pode ser vazio
            RuleFor(f => f.Endereco)
                .NotEmpty().WithMessage("O endereço do fornecedor é obrigatório.");

            // CriadoEm deve ser uma data válida e não pode ser no futuro
            RuleFor(f => f.CriadoEm)
                .NotEmpty().WithMessage("A data de criação é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de criação não pode estar no futuro.");
        }
    }
}
