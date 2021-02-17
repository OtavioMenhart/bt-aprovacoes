using Api.Processos.Domain.Dtos;
using Api.Processos.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Teste.Processos
{
    public class QuandoRequisitarProcessos : BaseIntegration
    {
        private string _nomeReclamante { get; set; }
        private string _numeroProcesso { get; set; }

        [Fact]
        public async Task E_Possivel_Realizar_Requisicoes_Processos()
        {
            _nomeReclamante = Faker.Name.FullName();
            _numeroProcesso = new Random().Next().ToString().PadLeft(12, '0');

            ProcessoDto entity = new ProcessoDto
            {
                Escritorio = Faker.Company.Name(),
                NomeReclamante = _nomeReclamante,
                NumeroProcesso = _numeroProcesso,
                ValorCausa = Faker.RandomNumber.Next()
            };

            //CriarProcesso
            var response = await PostJsonAsync(entity, $"{hostApi}Processos/CriarProcesso", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<ProcessoResultadoDto>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_nomeReclamante, registroPost.processo.NomeReclamante);
            Assert.Equal(_numeroProcesso, registroPost.processo.NumeroProcesso);

            string jsonResult = "";
            Processo registroSelecionado = null;

            //ObterPorId
            response = await client.GetAsync($"{hostApi}Processos/ObterPorId/{registroPost.processo.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            registroSelecionado = JsonConvert.DeserializeObject<Processo>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.NumeroProcesso, registroPost.processo.NumeroProcesso);
            Assert.Equal(registroSelecionado.NomeReclamante, registroPost.processo.NomeReclamante);

            //ObterPorId - no content
            response = await client.GetAsync($"{hostApi}Processos/ObterPorId/{Faker.RandomNumber.Next()}");
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            //ObterPorNumeroProcesso
            response = await client.GetAsync($"{hostApi}Processos/ObterPorNumeroProcesso/{registroPost.processo.NumeroProcesso}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            registroSelecionado = JsonConvert.DeserializeObject<Processo>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.NumeroProcesso, registroPost.processo.NumeroProcesso);
            Assert.Equal(registroSelecionado.NomeReclamante, registroPost.processo.NomeReclamante);

            //ObterPorNumeroProcesso - no content
            response = await client.GetAsync($"{hostApi}Processos/ObterPorNumeroProcesso/{Faker.RandomNumber.Next().ToString()}");
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            //ObterTodosProcessos
            response = await client.GetAsync($"{hostApi}Processos/ObterTodosProcessos");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registros = JsonConvert.DeserializeObject<List<Processo>>(jsonResult);
            Assert.NotNull(registros);
            Assert.True(registros.Count > 0);

            ProcessoDto entityUpdate = new ProcessoDto
            {
                Escritorio = Faker.Company.Name(),
                NomeReclamante = _nomeReclamante,
                NumeroProcesso = _numeroProcesso,
                ValorCausa = Faker.RandomNumber.Next()
            };

            StringContent stringContent;

            //EditarProcesso
            stringContent = new StringContent(JsonConvert.SerializeObject(entityUpdate),
                                    Encoding.UTF8, "application/json");
            response = await client.PatchAsync($"{hostApi}Processos/EditarProcesso", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<ProcessoResultadoDto>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPost.processo.Escritorio, registroAtualizado.processo.Escritorio);
            Assert.NotEqual(registroPost.processo.ValorCausa, registroAtualizado.processo.ValorCausa);

            ProcessoResultadoDto registroAtualizadoStatus;
            //AlterarStatusProcesso - inativar
            stringContent = new StringContent(JsonConvert.SerializeObject(new StatusProcessoDto { NumeroProcesso = _numeroProcesso, Status = false }),
                                    Encoding.UTF8, "application/json");
            response = await client.PatchAsync($"{hostApi}Processos/AlterarStatusProcesso", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            registroAtualizadoStatus = JsonConvert.DeserializeObject<ProcessoResultadoDto>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPost.processo.FlgAtivo, registroAtualizadoStatus.processo.FlgAtivo);

            //AlterarStatusProcesso - ativar
            stringContent = new StringContent(JsonConvert.SerializeObject(new StatusProcessoDto { NumeroProcesso = _numeroProcesso, Status = true }),
                                    Encoding.UTF8, "application/json");
            response = await client.PatchAsync($"{hostApi}Processos/AlterarStatusProcesso", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            registroAtualizadoStatus = JsonConvert.DeserializeObject<ProcessoResultadoDto>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(registroAtualizadoStatus.processo.FlgAtivo);

            //AprovarCompra
            stringContent = new StringContent(JsonConvert.SerializeObject(new CompraProcessoDto { NumeroProcesso = _numeroProcesso, StatusCompra = true }),
                                    Encoding.UTF8, "application/json");
            response = await client.PatchAsync($"{hostApi}Processos/AprovarCompra", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            registroAtualizadoStatus = JsonConvert.DeserializeObject<ProcessoResultadoDto>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(registroAtualizadoStatus.processo.FlgAprovado);
            Assert.NotNull(registroAtualizadoStatus.processo.DataCompra);
        }
    }
}
