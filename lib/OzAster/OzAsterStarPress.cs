using System;
using Aster;
using BusinessCore;

public class OzAsterStarPress : AsterStarPress
{
    /// <summary>
    /// Przes�ania nadklas�, by robot m�g� zebra� past� wyrzucon� przez
    /// maszyn� przed zlaniem maszyny wod�.
    /// </summary>
    public override void DischargePaste()
    {
        base.DischargePaste();
        GetFactory().CollectPaste();
    }

    /// <summary>
    /// Pobiera singleton mened�era materia�u.
    /// </summary>
    /// <returns>singleton mened�era materia�u</returns>
    public MaterialManager GetManager()
    {
        return MaterialManager.GetManager();
    }

    /// <summary>
    /// Powiadomienie mened�era materia�u Oozinoz, �e dana forma zosta�a
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