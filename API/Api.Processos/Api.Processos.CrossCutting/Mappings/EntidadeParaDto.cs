using Api.Processos.Domain.Dtos;
using Api.Processos.Domain.Entities;
using AutoMapper;

namespace Api.Processos.CrossCutting.Mappings
{
    public class EntidadeParaDto : Profile
    {
        public EntidadeParaDto()
        {
            CreateMap<ProcessoRetornoDto, Processo>().ReverseMap();
        }
    }
}
