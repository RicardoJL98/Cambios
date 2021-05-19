namespace Cambios.Modelos
{
    public class Response
    {
        /// <summary>
        /// Vai servir para nos dizer se as coisas correram bem ou nao, se temos internet ou nao, se a API carregou bem ou nao, se gravou bem na base de dados ou nao
        /// </summary>
        public bool IsSucess { get; set; }

        /// <summary>
        /// Caso as coisas corram mal o que se passou, devolve uma mensagem 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Caso a API carregue bem vai guardar um objeto chamado Result
        /// </summary>
        public object Result { get; set; }
    }
}
