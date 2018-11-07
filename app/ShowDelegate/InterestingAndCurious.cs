using System;

public delegate void ChangeHandler();

/// <summary>
/// Klasa wykorzystywana w rozdziale Observer, posiadaj¹ca metodê Wiggle().
/// </summary>
class Interesting
{
    // Warto zauwa¿yæ, ¿e Change i Change2 obie s¹ zmiennymi instancji typu
    // delegowanego ChangeHandler. Jedyna ró¿nica miêdzy nimi polega na tym,
    // ¿e Change2 jest dodatkowo oznaczona jako zdarzenie.
    public ChangeHandler Change;
    public event ChangeHandler Change2;
    public void Wiggle()
    {
        if (Change != null) Change();
        if (Change2 != null) Change2();
    }
}
/// <summary>
/// Klasa ta jest w rozdziale Observer u¿ywana do pokazania sposobu
/// rejestrowania klienta do wywo³añ zwrotnych w momencie wprowadzenia 
/// zmian w interesuj¹cej klasie.
/// </summary>
class Curious
{
    public Curious(Interesting i)
    {
        i.Change += new ChangeHandler(React);
    }
    public void React()
    {
        Console.WriteLine("Coœ siê sta³o!");
    }
}