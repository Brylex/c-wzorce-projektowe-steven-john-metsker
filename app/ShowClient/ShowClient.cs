using System;
/// <summary>
/// Demonstruje wykorzystanie us�ugi sieciowej z rozdzia�u Proxy.
/// </summary>
class ShowClient
{
    static void Main()
    {
        Rocket r = new DataWebService().RocketHome("jsquirrel");
        Console.WriteLine(
            "Rocket {0}, Thrust: {1} Price: {2:C}", 
            r.Name, r.Thrust, r.Price);
    }
}