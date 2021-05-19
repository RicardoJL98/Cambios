namespace Cambios.Servicos
{
    using System.Net;
    using Modelos;


    public class NetworkService
    {
        // É esta classe que vai ver se temos ligação à internet ou não para irmos buscar a API

        // Nesta classe apenas definimos um método que vai testar se existe conexão à internet ou não

        /// <summary>
        /// Este metodo vai retornar um objeto do tipo Response que definimos na class response
        /// Na prática vai ser o metodo que vamos utilizar para ver se temos ligação à net
        /// </summary>
        /// <returns></returns>
        public Response CheckConection()
        {
            var client = new WebClient();

            try
            {
                using (client.OpenRead("http://clients3.google.com/generate_204")) // este é o ping do servidor da google para testar-mos se temos ligação ou não
                {
                    //se isto correr bem
                    return new Response
                    {
                        IsSucess = true // dizemos que esta propriedade do Response passa a true
                    };
                }
            }
            catch (System.Exception)
            {

                return new Response
                {
                    IsSucess = false,
                    Message = "Configure a sua ligação à internet."
                };
            }
        }

    }
}
