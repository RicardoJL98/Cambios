

namespace Cambios
{

    using System;
    using System.Net.Http;
    using System.Windows.Forms;
    using Newtonsoft.Json;
    using Modelos;
    using System.Collections.Generic;
    using Cambios.Servicos;
    using System.Threading.Tasks;

    public partial class Form1 : Form
    {
        #region Atributos


        private NetworkService networkService;

        private ApiService apiService;


        #endregion

        public List<Rate> Rates { get; set; } = new List<Rate>();


        public Form1()
        {
            InitializeComponent();
            networkService = new NetworkService(); // já instanciamos o nosso atributo
            apiService = new ApiService();
            LoadRates();
        }

        private async void LoadRates()
        {
            //bool load; // variável que controla se o load foi feito ou não

            LabelResultado.Text = "A atualizar taxas...";

            var connection = networkService.CheckConection(); // aqui vamos testar a conexão

            if (!connection.IsSucess) // se esta resposta não teve sucesso
            {
                MessageBox.Show(connection.Message);
                return;
            }
            else
            {
                await LoadApiRates();
            }


            ComboBoxOrigem.DataSource = Rates; // Dizemos para a combobox ir buscar os dados a rates
            ComboBoxOrigem.DisplayMember = "Name";  // Assim mostramos o nome das moedas

            ComboBoxDestino.BindingContext = new BindingContext(); // Para corrigir o bug das combobox que cada vez que se seleciona um item numa fica automaticamente selecionado na outra
            // assim com esta classe dizemos que a combobox destino tem um biding diferente da de origem

            ComboBoxDestino.DataSource = Rates; // Dizemos para a combobox ir buscar os dados a rates
            ComboBoxDestino.DisplayMember = "Name"; // Assim mostramos o nome das moedas

            ProgressBar1.Value = 100; // depois de todo o processo a progress bar carrega-se

            LabelResultado.Text = "Taxas carregadas...";

        }

        private async Task LoadApiRates()
        {
            ProgressBar1.Value = 0;

            var response = await apiService.GetRates("http://cambios.somee.com", "/api/rates");

            Rates = (List<Rate>)response.Result;
        }
    }
}
