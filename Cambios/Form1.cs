

namespace Cambios
{

    using System;
    using System.Net.Http;
    using System.Windows.Forms;
    using Newtonsoft.Json;
    using Modelos;
    using System.Collections.Generic;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadRates();
        }

        private async void LoadRates()
        {
            //bool load; // variável que controla se o load foi feito ou não

            // Para carregar a API vamos ter que criar uma variável
            var client = new HttpClient();
            // primeira cois a fazer é criar a conexão via Http
            client.BaseAddress = new Uri("http://cambios.somee.com");
            // aqui em cima colocamos o nosso endereço base da API

            // agora vamos buscar o controlador
            var response = await client.GetAsync("/api/rates");
            // enquanto estamos a carregar as taxas queremos que o progrma esteja a correr então colocamos await à frente e async
            // fazemos isto pois queremos que a aplicação não pare de correr enquanto carrega as taxas
            // ele quando devolve vai devolver algo para dentro do objeto (response)

            var result = await response.Content.ReadAsStringAsync();
            // variável que vai ficar à espera da resposta que vem de cima, queremos o seu conteúdo lido como uma string
            // carregamos os resultados no formato de uma string para dentro do objeto (result)

            if (!response.IsSuccessStatusCode) // se algo correr mal
            {
                MessageBox.Show(response.ReasonPhrase); // aqui aparece o erro que se terá passado
                return;
            }

            // se ele passar é porque correu bem

            var rates = JsonConvert.DeserializeObject<List<Rate>>(result);
            //Colocamos o jason numa lista que vai guardar os dados do tipo Rate

            ComboBoxOrigem.DataSource = rates;






        }
    }
}
