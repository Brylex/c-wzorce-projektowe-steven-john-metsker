using System;
using System.Collections;

	/// <summary>
	/// Klasa zastêpuj¹ca bazê danych dla przyk³adów ShowMediator.
	/// </summary>
public class NameBase
{
    private static Hashtable _tubMachine;
    // lista nazw maszyn
    internal static IList MachineNames()
    {
        return new string[]{
                               "Mixer-2201",
                               "Mixer-2202",
                               "StarPress-2401",
                               "StarPress-2402",
                               "Assembler-2301",
                               "Fuser-2101"};
    }
    // tabela przypisañ pojemników do maszyn
    internal static Hashtable TubMachine()
    {
        if (_tubMachine == null) 
        {
            _tubMachine = new Hashtable();
            _tubMachine["T502"] = "Mixer-2201";
            _tubMachine["T503"] = "Mixer-2201";
            _tubMachine["T504"] = "Mixer-2201";
            _tubMachine["T101"] = "StarPress-2402";
            _tubMachine["T102"] = "StarPress-2402";
        }
        return _tubMachine;
    } 
    // zwraca maszynê dla zadanego pojemnika
    internal static string Machine(string tubName)
    {
        return (string) _tubMachine[tubName];
    }
    // zwraca listê pojemników przy danej maszynie
    internal static IList TubNames(string machineName)
    {
        ArrayList al = new ArrayList();
        IDictionaryEnumerator e = TubMachine().GetEnumerator();
        while (e.MoveNext()) 
        {
            if(e.Value.Equals(machineName))
            {
                al.Add(e.Key);
            }
        }
        return al;
    }
}