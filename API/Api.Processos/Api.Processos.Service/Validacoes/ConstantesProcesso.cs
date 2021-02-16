namespace Api.Processos.Service.Validacoes
{
    public static class ConstantesProcesso
    {
        public const string erroNumeroProcessoVazio = "Número do processo é um campo obrigatório";
        public const string erroCaracteresNumeroProcesso = "Número do processo deve ser um campo somente númerico";
        public const string erroTamanhoCaracteresNumeroProcesso = "Número do processo deve ser um campo de 12 caracteres, somente números";
        public const int parametroTamanhoCaracteresNumeroProcesso = 12;

        public const string erroValorCausaVazio = "Valor da causa é um campo obrigatório";
        public const int paramatroMinimoValor = 30000;
        public const string erroValorCausaMinimo = "O valor da causa deve ser superior a R$ 30.000";

        public const string erroEscritorioVazio = "Escritório é um campo obrigatório";
        public const string erroTamanhoCaracteresEscritorio = "O escritório tem como limite 50 caracteres, somente letras";
        public const int parametroMinimoEscritorio = 1;
        public const int parametroMaximoEscritorio = 50;

        public const string erroReclamanteVazio = "Nome do reclamante é um campo obrigatório";
        public const string erroTamanhoCaracteresReclamante = "O nome do reclamante tem como limite 100 caracteres, somente letras";
        public const int parametroMinimoReclamante = 1;
        public const int parametroMaximoReclamante = 100;

    }
}
