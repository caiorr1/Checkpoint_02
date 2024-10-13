using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public string? Nome { get; set; }
        public string? Regiao { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            // Nome não pode ser vazio e deve ter no mínimo 2 caracteres
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("O nome do vendedor é obrigatório.")
                .MinimumLength(2).WithMessage("O nome do vendedor deve ter no mínimo 2 caracteres.");

            // Região não pode ser vazia
            RuleFor(v => v.Regiao)
                .NotEmpty().WithMessage("A região é obrigatória.");

            // Email deve ser um endereço de email válido
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email deve ser um endereço válido.");

            // Telefone não pode ser vazio e deve ter 10 ou 11 dígitos (com DDD)
            RuleFor(v => v.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve ter 10 ou 11 dígitos, incluindo o DDD.");

            // Data de nascimento deve ser uma data válida e a pessoa deve ter pelo menos 18 anos
            RuleFor(v => v.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("O vendedor deve ter no mínimo 18 anos.");

            // Endereço não pode ser vazio
            RuleFor(v => v.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório.");

            // Data de contratação deve ser válida e não pode ser no futuro
            RuleFor(v => v.DataContratacao)
                .NotEmpty().WithMessage("A data de contratação é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de contratação não pode estar no futuro.");

            // Comissão deve ser um valor entre 0 e 100%
            RuleFor(v => v.ComissaoPercentual)
                .InclusiveBetween(0, 100).WithMessage("A comissão deve ser entre 0 e 100%.");

            // Meta mensal deve ser um valor positivo
            RuleFor(v => v.MetaMensal)
                .GreaterThan(0).WithMessage("A meta mensal deve ser um valor positivo.");

            // CriadoEm deve ser uma data válida e não pode ser no futuro
            RuleFor(v => v.CriadoEm)
                .NotEmpty().WithMessage("A data de criação é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de criação não pode estar no futuro.");
        }
    }
}
