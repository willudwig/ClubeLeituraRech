namespace ClubeLeitura.ConsoleApp
{
    public class Caixa
    {
        public int numero;
        public string cor;
        public string etiqueta;

        public Status ValidarEtiqueta()
        {
            Status validacao = (Status)0;

            if (string.IsNullOrEmpty(etiqueta))
                validacao = (Status)1;

            return validacao;
        }

        public Status ValidarCor()
        {
            Status validacao = (Status)0;

            if (string.IsNullOrEmpty(cor))
                validacao = (Status)1;

            if (cor.Contains("0") || cor.Contains("1") || cor.Contains("2") || cor.Contains("3") || cor.Contains("4") || cor.Contains("5") || cor.Contains("6") || cor.Contains("7") || cor.Contains("8") || cor.Contains("9"))
                validacao = (Status)1;

            return validacao;
        }

        public enum Status { válido, inválido }
    }
}
