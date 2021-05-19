namespace Cambios.Servicos
{

    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Modelos;
    using Newtonsoft.Json;


    public class ApiService
    {
        /// <summary>
        /// Este metodo serve apenas para ir buscar as taxas
        /// Este metodo é async e a unica tarefa é o Task que ele tem de fazer e no fim vai ter que ter que devolver um objeto do tipo Response
        /// </summary>
        /// <param name="urlBase"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        public async Task<Response> GetRates(string urlBase, string controller)
        {
            try
            {
                // Para carregar a API vamos ter que criar uma variável
                var client = new HttpClient();
                // primeira coisa a fazer é criar a conexão via Http
                client.BaseAddress = new Uri(urlBase);
                // aqui em cima colocamos o nosso endereço base da API

                // agora vamos buscar o controlador
                var response = await client.GetAsync(controller);
                // enquanto estamos a carregar as taxas queremos que o progrma esteja a correr então colocamos await à frente e async
                // fazemos isto pois queremos que a aplicação não pare de correr enquanto carrega as taxas
                // ele quando devolve vai devolver algo para dentro do objeto (response)

                var result = await response.Content.ReadAsStringAsync();
                // variável que vai ficar à espera da resposta que vem de cima, queremos o seu conteúdo lido como uma string
                // carregamos os resultados no formato de uma string para dentro do objeto (result)

                if (!response.IsSuccessStatusCode) // se algo correr mal
                {
                    return new Response()
                    {
                        IsSucess = false,
                        Message = result // que vem de cima
                    };
                }
                // se ele passar é porque correu bem

                var rates = JsonConvert.DeserializeObject<List<Rate>>(result);
                //Colocamos o jason numa lista que vai guardar os dados do tipo Rate

                return new Response
                {
                    IsSucess = true,
                    Result = rates
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSucess = false,
                    Message = ex.Message
                };

            }
        }

        internal static Task GetRates()
        {
            throw new NotImplementedException();
        }
    }
}
