using Api.Processos.Domain.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Processos.Service.Validacoes
{
    public class ProcessoValidacao : AbstractValidator<ProcessoDto>
    {
        public ProcessoValidacao()
        {
            RuleFor(x => x.NumeroProcesso).Cascade(CascadeMode.Stop).NotNull().WithMessage("Número do processo é um campo obrigatório").NotEmpty().WithMessage("Número do processo é um campo obrigatório");
            RuleFor(x => x.NumeroProcesso).Cascade(CascadeMode.Stop).NotNull().Must(ValidacaoNumeroProcesso).WithMessage("Número do processo deve ser um campo somente númerico");
            RuleFor(x => x.NumeroProcesso).Cascade(CascadeMode.Stop).NotNull().Length(12).WithMessage("Número do processo deve ser um campo de 12 caracteres, somente números");

            RuleFor(x => x.ValorCausa).Cascade(CascadeMode.Stop).NotNull().WithMessage("Valor da causa é um campo obrigatório").NotEmpty().WithMessage("Valor da causa é um campo obrigatório");
            RuleFor(x => x.ValorCausa).Cascade(CascadeMode.Stop).GreaterThan(30000).WithMessage("O valor da causa deve ser superior a R$ 30.000");

            RuleFor(x => x.Escritorio).Cascade(CascadeMode.Stop).NotNull().WithMessage("Escritório é um campo obrigatório").NotEmpty().WithMessage("Escritório é um campo obrigatório");
            RuleFor(x => x.Escritorio).Cascade(CascadeMode.Stop).Length(1, 50).WithMessage("O escritório tem como limite 50 caracteres, somente letras");

            RuleFor(x => x.NomeReclamante).Cascade(CascadeMode.Stop).NotNull().WithMessage("Nome do reclamante é um campo obrigatório").NotEmpty().WithMessage("Nome do reclamante é um campo obrigatório");
            RuleFor(x => x.NomeReclamante).Cascade(CascadeMode.Stop).Length(1, 100).WithMessage("O nome do reclamante tem como limite 100 caracteres, somente letras");
        }

        private static bool ValidacaoNumeroProcesso(string processo)
        {
            return processo.Where(x => char.IsLetter(x)).Count() == 0;
        }
    }
}
