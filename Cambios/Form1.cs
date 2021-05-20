

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

        private List<Rate> Rates;

        private NetworkService networkService;

        private ApiService apiService;

        private DialogService dialogService;

        private DataService dataService;


        #endregion

        public Form1()
        {
            InitializeComponent();
            networkService = new NetworkService(); // já instanciamos o nosso atributo
            apiService = new ApiService();
            dialogService = new DialogService();
            dataService = new DataService();
            LoadRates();
        }

        private async void LoadRates()
        {
            bool load; // variável que controla se o load foi feito ou não

            LabelResultado.Text = "A atualizar taxas...";

            var connection = networkService.CheckConection(); // aqui vamos testar a conexão

            if (!connection.IsSucess) // se esta resposta não teve sucesso
            {
                LoadLocalRates();  //são as rates que vão estar na base de dados
                load = false;
            }
            else
            {
                await LoadApiRates();
                load = true;
            }

            //Se nos ligarmos a primeira vez e ele não se conseguir ligar à API a base de dados não vai ter nada e então na prática deteta-se que a lista não tem rates
 
            if (Rates.Count == 0) // se a lista das rates nao for carregada tanto localmente como da API
            {
                LabelResultado.Text = "Não há ligação à internet" + Environment.NewLine +
                                      "e não foram previamente carregadas as taxas." + Environment.NewLine +
                                      "Tente mais tarde";

                LabelStatuts.Text = "Primeira inicialização deverá ter ligação à internet";

                return;
            }

            ComboBoxOrigem.DataSource = Rates; // Dizemos para a combobox ir buscar os dados a rates
            ComboBoxOrigem.DisplayMember = "Name";  // Assim mostramos o nome das moedas

            ComboBoxDestino.BindingContext = new BindingContext(); // Para corrigir o bug das combobox que cada vez que se seleciona um item numa fica automaticamente selecionado na outra
            // assim com esta classe dizemos que a combobox destino tem um biding diferente da de origem

            ComboBoxDestino.DataSource = Rates; // Dizemos para a combobox ir buscar os dados a rates
            ComboBoxDestino.DisplayMember = "Name"; // Assim mostramos o nome das moedas


            LabelResultado.Text = "Taxas atualizadas...";

            if (load) // por defaul se o load for true
            {
                LabelStatuts.Text = string.Format("Taxas carregadas da internet em {0:F}", DateTime.Now);
            }
            else
            {
                LabelStatuts.Text = string.Format("Taxas carregadas da Base de Dados.");
            }


            ProgressBar1.Value = 100; // depois de todo o processo a progress bar carrega-se

            ButtonConverter.Enabled = true;
            buttonTrocar.Enabled = true;

        }

        /// <summary>
        /// Carrega as taxas da base de dados local
        /// </summary>
        private void LoadLocalRates()
        {
            Rates = dataService.GetData();
            // Como retorna uma lista vamos ter de adaptar
            // Fazendo Rates =, carregamos diretamente a lista deste lado
        }

        /// <summary>
        /// Carrega as taxas da Api quando temos ligação à internet
        /// </summary>
        /// <returns></returns>
        private async Task LoadApiRates()
        {
            ProgressBar1.Value = 0;

            var response = await apiService.GetRates("http://cambios.somee.com", "/api/rates");

            Rates = (List<Rate>)response.Result;

            dataService.DeleteData(); // Primeiro apaga e depois é que grava as taxas por cima

            dataService.SaveDate(Rates);
        }

        private void ButtonConverter_Click(object sender, EventArgs e)
        {
            Converter();
        }

        private void Converter()
        {
            //Validamos se está um valor escrito na textbox
            if (string.IsNullOrEmpty(TextBoxValor.Text))
            {
                dialogService.ShowMessage("Erro", "Insira um valor a converter");
                return;
            }

            decimal valor;

            //Validamos se está um valor numérico escrito na textbox
            if (!decimal.TryParse(TextBoxValor.Text, out valor))
            {
                dialogService.ShowMessage("Erro de conversão", "Valor terá de ser numérico");
                return;
            }

            if (ComboBoxOrigem.SelectedItem == null)
            {
                dialogService.ShowMessage("Erro", "Tem que escolher uma moeda a converter");
                return;
            }

            if (ComboBoxDestino.SelectedItem == null)
            {
                dialogService.ShowMessage("Erro", "Tem que escolher uma moeda de destino a converter");
                return;
            }

            var taxaOrigem = (Rate) ComboBoxOrigem.SelectedItem;
             
            var taxaDestino = (Rate) ComboBoxDestino.SelectedItem;

            var valorConvertido = valor / (decimal)taxaOrigem.TaxRate * (decimal)taxaDestino.TaxRate;

            LabelResultado.Text = string.Format("{0} {1:C2} = {2} {3:C2}", taxaOrigem.Code, valor, taxaDestino.Code, valorConvertido);


        }

        private void Trocar()
        {
            var aux = ComboBoxOrigem.SelectedItem;

            ComboBoxOrigem.SelectedItem = ComboBoxDestino.SelectedItem;
            ComboBoxDestino.SelectedItem = aux;
            Converter();
        }

        private void buttonTrocar_Click(object sender, EventArgs e)
        {
            Trocar();
        }
    }
}
