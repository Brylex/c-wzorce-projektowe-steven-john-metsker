using System;
using Aster;
using BusinessCore;

public class OzAsterStarPress : AsterStarPress
{
    /// <summary>
    /// Przes³ania nadklasê, by robot móg³ zebraæ pastê wyrzucon¹ przez
    /// maszynê przed zlaniem maszyny wod¹.
    /// </summary>
    public override void DischargePaste()
    {
        base.DischargePaste();
        GetFactory().CollectPaste();
    }

    /// <summary>
    /// Pobiera singleton mened¿era materia³u.
    /// </summary>
    /// <returns>singleton mened¿era materia³u</returns>
    public MaterialManager GetManager()
    {
        return MaterialManager.GetManager();
    }

    /// <summary>
    /// Powiadomienie mened¿era materia³u Oozinoz, ¿e dana forma zosta³a
    /// niekompletnie przetworzona.
    /// </summary>
    /// <param name="id">identyfikator formy</param>
    public override void MarkMoldIncomplete(int id)
    {
        GetManager().SetMoldIncomplete(id);
    }

    /// <summary>
    /// Pobiera singleton fabryki.
    /// </summary>
    /// <returns>singleton fabryki; metoda nieimplementowana</returns>
    public Factory GetFactory()
    {
        return null;
    }
}