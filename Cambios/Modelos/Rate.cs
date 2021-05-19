namespace Cambios.Modelos
{
    public class Rate
    {
        public int RateId { get; set; }

        public string Code { get; set; }

        public double TaxRate { get; set; }

        public string Name { get; set; }

        //public override string ToString()   -> Outra forma de mostrar o nome das moedas
        //{
        //    return $"{Name}";
        //    // Assim vamos mostrar o nome de todos os objetos rate
        //    // Neste caso vai mostrar o nome de todas as moedas
        //}
    }
}
