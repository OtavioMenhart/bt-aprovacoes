using Api.Processos.Domain.Dtos;
using FluentValidation;
using System.Linq;

namespace Api.Processos.Service.Validacoes
{
    public class ProcessoValidacao : AbstractValidator<ProcessoDto>
    {
        public ProcessoValidacao()
        {
            RuleFor(x => x.NumeroProcesso).Cascade(CascadeMode.Stop).NotNull().WithMessage(ConstantesProcesso.erroNumeroProcessoVazio).NotEmpty().WithMessage(ConstantesProcesso.erroNumeroProcessoVazio);
            RuleFor(x => x.NumeroProcesso).Cascade(CascadeMode.Stop).NotNull().Must(ValidacaoNumeroProcesso).WithMessage(ConstantesProcesso.erroCaracteresNumeroProcesso);
            RuleFor(x => x.NumeroProcesso).Cascade(CascadeMode.Stop).NotNull().Length(ConstantesProcesso.parametroTamanhoCaracteresNumeroProcesso).WithMessage(ConstantesProcesso.erroTamanhoCaracteresNumeroProcesso);

            RuleFor(x => x.ValorCausa).Cascade(CascadeMode.Stop).NotNull().WithMessage(ConstantesProcesso.erroValorCausaVazio).NotEmpty().WithMessage(ConstantesProcesso.erroValorCausaVazio);
            RuleFor(x => x.ValorCausa).Cascade(CascadeMode.Stop).GreaterThan(ConstantesProcesso.paramatroMinimoValor).WithMessage(ConstantesProcesso.erroValorCausaMinimo);

            RuleFor(x => x.Escritorio).Cascade(CascadeMode.Stop).NotNull().WithMessage(ConstantesProcesso.erroEscritorioVazio).NotEmpty().WithMessage(ConstantesProcesso.erroEscritorioVazio);
            RuleFor(x => x.Escritorio).Cascade(CascadeMode.Stop).Length(ConstantesProcesso.parametroMinimoEscritorio, ConstantesProcesso.parametroMaximoEscritorio).WithMessage(ConstantesProcesso.erroTamanhoCaracteresEscritorio);

            RuleFor(x => x.NomeReclamante).Cascade(CascadeMode.Stop).NotNull().WithMessage(ConstantesProcesso.erroReclamanteVazio).NotEmpty().WithMessage(ConstantesProcesso.erroReclamanteVazio);
            RuleFor(x => x.NomeReclamante).Cascade(CascadeMode.Stop).Length(ConstantesProcesso.parametroMinimoReclamante, ConstantesProcesso.parametroMaximoReclamante).WithMessage(ConstantesProcesso.erroTamanhoCaracteresReclamante);
        }

        private static bool ValidacaoNumeroProcesso(string processo)
        {
            return processo.Where(x => char.IsLetter(x)).Count() == 0;
        }
    }
}
