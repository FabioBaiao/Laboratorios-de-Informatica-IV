using System;

namespace Mnham_Mnham
{
    public class Preferencia
    {
        private string designacaoIngrediente;
        private string designacaoAlimento;

        public string DesignacaoIngrediente { get; }
        public string DesignacaoAlimento { get; }

        private Preferencia() { }

        public Preferencia(string designacaoIngrediente) : this(designacaoIngrediente, "")
        {

        }

        public Preferencia(string designacaoIngrediente, string designacaoAlimento)
        {
            this.designacaoIngrediente = designacaoIngrediente;
            this.designacaoAlimento = designacaoAlimento;
        }

        public override bool Equals(object obj)
        {
            Preferencia pref = obj as Preferencia;
            if (obj != null)
            {
                return designacaoIngrediente.Equals(pref.designacaoIngrediente)
                    && designacaoAlimento.Equals(pref.designacaoAlimento);
            }
            else
                throw new ArgumentException("O objeto passado como argumento n�o � uma Preferencia.");
        }
    }
}