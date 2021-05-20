namespace Cambios.Servicos
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;
    using Modelos;

    public class DataService
    {
        private SQLiteConnection connection;

        private SQLiteCommand command;

        private DialogService dialogService;

        /// <summary>
        /// Construtor
        /// </summary>
        public DataService()
        {
            dialogService = new DialogService();

            if (!Directory.Exists("DAta"))
            {
                Directory.CreateDirectory("Data");
            }

            var path = @"Data\Rates.sqLite";

            try
            {
                connection = new SQLiteConnection("Data Source=" + path);
                //É a connection string, vai ser a conexão à base de dados, o caminho é dado pelo path
                connection.Open();

                string sqlcommand = "create table if not exists rates(RateId int, Code varchar(5), TaxRate real, Name varchar(250))";
                // se não existir vai criar a tabela

                command = new SQLiteCommand(sqlcommand, connection);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                dialogService.ShowMessage("Erro", e.Message);
            }
        }

        /// <summary>
        /// Metodo que salva os valores na base de dados local
        /// </summary>
        /// <param name="Rates"></param>
        public void SaveDate(List<Rate> Rates)
        {
            try
            {
                foreach (var rate in Rates)
                {
                    string sql = string.Format("insert into Rates (RateId, Code, TaxRate, Name) values ({0},'{1}','{2}','{3}')", rate.RateId, rate.Code, rate.TaxRate, rate.Name);
                    //Quando são varchar temos de colocar entre plicas
                    // Na prática estamos a guardar uma string que é o comando que depois vamos usar em sql, vamos inserir na tabela rates os values 0,1,2,3 e que vamos busca-los
                    // ao objeto rate

                    //agora executamos o comando
                    command = new SQLiteCommand(sql, connection); // aqui mandamos a string e a conexão

                    command.ExecuteNonQuery(); // este é o comando que executa a string deste lado

                }

                connection.Close();

            }
            catch (Exception e)
            {

                dialogService.ShowMessage("Erro", e.Message);
            }
        }

        /// <summary>
        /// Metodo que lê os valores dentro da base de dados
        /// </summary>
        public List<Rate> GetData()
        {
            //Vai buscar e retorna uma lista

            List<Rate> rates = new List<Rate>();

            try
            {
                string sql = "select RateId, Code, TaxRate, Name from Rates";

                command = new SQLiteCommand(sql, connection);

                // Lê cada registo, cada linha
                SQLiteDataReader reader = command.ExecuteReader();

                //Quando não houver mais nada para ler isto passa a falso, é como um booleano enquanto tiver registos para ler está a true quando não tiver passa a false
                while (reader.Read())
                {
                    // O while vai à tabela ler de registo a registo

                    rates.Add(new Rate
                    {
                        RateId = (int)reader["RateId"],
                        Code = (string)reader["Code"],
                        Name = (string)reader["Name"],
                        TaxRate = (double)reader["TaxRate"]
                    });
                }

                connection.Close();

                return rates;
            }
            catch (Exception e)
            {
                dialogService.ShowMessage("Erro", e.Message);
                return null;
                // não retorna nada, retorna null pois tem sempre de retornar alguma coisa pois o getdata está a retornar as listas
            }
        }

        /// <summary>
        /// Na prática limpa os dados das tabelas e carrega com dados atualizados
        /// </summary>
        public void DeleteData()
        {
            try
            {
                string sql = "Delete from Rates";

                command = new SQLiteCommand(sql, connection);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                dialogService.ShowMessage("Erro", e.Message);
            }
        }
    }
}
