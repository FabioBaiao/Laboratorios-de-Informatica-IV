using System;
using System.Collections.Generic;

namespace Mnham_Mnham
{
    public class Cliente
    {
        private int id;
        private char genero;
        private string email;
        private string nome;
        private string palavraPasse;
        private ISet<Preferencia> preferencias;
        private ISet<Preferencia> naoPreferencias;

        public int Id { get { return id; } set { id = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string PalavraPasse { get { return palavraPasse; } set { palavraPasse = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public char Genero { get { return genero; } set { genero = value; } }
        public ISet<Preferencia> Preferencias { get { return preferencias; } set { preferencias = value; } }
        public ISet<Preferencia> NaoPreferencias { get { return naoPreferencias; } set { naoPreferencias = value; } }

        public Cliente(int id, char genero, string email, string nome, string palavraPasse)
        {
            if (genero != 'M' && genero != 'F')
                throw new ArgumentException("O g�nero tem de ser 'M' ou 'F'.");

            this.id = id;
            this.genero = genero;
            this.email = email;
            this.nome = nome;
            this.palavraPasse = palavraPasse;
            this.preferencias = new HashSet<Preferencia>();
            this.naoPreferencias = new HashSet<Preferencia>();
        }

        public Cliente(char genero, string email, string nome, string palavraPasse) :
            this(-1, genero, email, nome, palavraPasse)
        {

        }

        public ISet<string> ObterNaoPreferencias(string nomeAlimento)
        {
            ISet<string> naoPrefsAlimento = new HashSet<string>();

            foreach (var naoPref in naoPreferencias)
            {
                if (nomeAlimento.Contains(naoPref.DesignacaoAlimento))
                {
                    naoPrefsAlimento.Add(naoPref.DesignacaoIngrediente);
                }
            }
            return naoPrefsAlimento;
        }

        public ISet<string> ObterPreferencias(string nomeAlimento)
        {
            ISet<string> prefsAlimento = new HashSet<string>();

            foreach (var pref in preferencias)
            {
                if (nomeAlimento.Contains(pref.DesignacaoAlimento))
                {
                    prefsAlimento.Add(pref.DesignacaoIngrediente);
                }
            }
            return prefsAlimento;
        }

        public bool RegistarPreferenciaGeral(string designacaoIngrediente)
        {
            return preferencias.Add(new Preferencia(designacaoIngrediente));
        }

        public bool RegistarPreferenciaAlimento(string designacaoIngrediente, string designacaoAlimento)
        {
            return preferencias.Add(new Preferencia(designacaoIngrediente, designacaoAlimento));
        }

        public bool RegistarNaoPreferenciaGeral(String designacaoPreferencia)
        {
            return naoPreferencias.Add(new Preferencia(designacaoPreferencia));
        }

        public bool RegistarNaoPreferenciaAlimento(string designacaoPreferencia, string designacaoAlimento)
        {
            return naoPreferencias.Add(new Preferencia(designacaoPreferencia, designacaoAlimento));
        }

        public bool RemovePreferenciaGeral(string designacaoIngrediente)
        {
            // O m�todo Remove recebe uma Preferencia, logo � preciso criar uma igual � que se pretende remover.
            return preferencias.Remove(new Preferencia(designacaoIngrediente));
        }

        public bool RemovePreferencia(string designacaoIngrediente, string designacaoAlimento)
        {
            return preferencias.Remove(new Preferencia(designacaoIngrediente, designacaoAlimento));
        }

        public bool RemoverNaoPreferenciaGeral(string designacaoIngrediente)
        {
            return naoPreferencias.Remove(new Preferencia(designacaoIngrediente));
        }

        public bool RemoveNaoPreferencia(string designacaoIngrediente, string designacaoAlimento)
        {
            return naoPreferencias.Remove(new Preferencia(designacaoIngrediente, designacaoAlimento));
        }
    }
}
