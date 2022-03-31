namespace ClubeLeitura.ConsoleApp
{
    public class Caixa
    {
        static int contadorCaixa;
        
        public int numero;
        string _cor;
        string _etiqueta;

        public int Numero { get { return numero; } }
        public string Cor { get { return _cor; } }
        public string Etiqueta { get { return _etiqueta; } }

        public Caixa(string cor, string etiqueta)
        {
            numero = ++contadorCaixa;

            _cor = cor;
            _etiqueta = etiqueta;
        }

        #region validações
        public Status ValidarEtiqueta()
        {
            Status validacao = (Status)0;

            if (string.IsNullOrEmpty(_etiqueta))
                validacao = (Status)1;

            return validacao;
        }

        public Status ValidarCor()
        {
            Status validacao = (Status)0;

            if (string.IsNullOrEmpty(_cor))
                validacao = (Status)1;

            if (_cor.Contains("0") || _cor.Contains("1") || _cor.Contains("2") || _cor.Contains("3") || _cor.Contains("4") || _cor.Contains("5") || _cor.Contains("6") || _cor.Contains("7") || _cor.Contains("8") || _cor.Contains("9"))
                validacao = (Status)1;

            return validacao;
        }

        public enum Status { válido, inválido }
        #endregion
    }
}
