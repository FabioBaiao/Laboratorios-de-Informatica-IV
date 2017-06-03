using System;

public class Cliente
{
    private int id;
    private char genero;
    private string email;
    private string nome;
    private string palavraPasse;
    private ISet<Preferencia> preferencias;
    private ISet<Preferencia> naoPreferencias;

    public Cliente(int id, char genero, string email, string nome)
    {
        if (genero != 'M' && genero != 'F')
            throw new ArgumentException("O g�nero tem de ser 'M' ou 'F'.");

        this.id = id;
        this.genero = genero;
        this.email = email;
        this.nome = nome;
        this.preferencias = new HashSet<Preferencia>();
        this.naoPreferencias = new HashSet<Preferencia>();
    }

    public List<string> ObterNaoPreferencias(string nomeAlimento)
    {
        List<string> naoPrefsAlimento = new List<string>();

        foreach (var naoPref in naoPreferencias)
        {
            if (nomeAlimento.Contains(naoPref.DesignacaoAlimento))
            {
                naoPrefsAlimento.Add(naoPref.DesignacaoIngrediente);
            }
        }
        return naoPrefs;
    }

    public List<string> ObterPreferencias(string nomeAlimento)
    {
        List<string> prefsAlimento = new List<string>();

        foreach (var pref in preferencias)
        {
            if (nomeAlimento.Contains(pref.DesignacaoAlimento))
            {
                prefsAlimento.Add(pref.DesignacaoIngrediente);
            }
        }
        return prefs;
    }

    public bool RegistarPreferenciaGeral(String designacaoIngrediente)
    {
        return preferencias.Add(new Preferencia(designacaoIngrediente));
    }

    public bool RegistarPreferenciaAlimento(string designacaoIngrediente, string designacaoAlimento)
    {
        return preferencias.Add(new Preferencia(designacaoIngrediente, designacaoAlimento));
    }

    public void RegistarNaoPreferenciaGeral(String designacaoPreferencia)
    {
        return naoPreferencias.Add(new Preferencia(designacaoPreferencia));
    }

    public void RegistarNaoPreferenciaAlimento(string designacaoPreferencia, string designacaoAlimento)
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

    public void RemoveNaoPreferencia(string designacaoIngrediente, string designacaoAlimento)
    {
        return naoPreferencias.Remove(new Preferencia(designacaoIngrediente, designacaoAlimento));
    }
}
