using System; 
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Definiuje standardow� us�ug� polecania klientowi dost�pnego produktu.
    /// </summary>
    public interface Advisor 
    {
        Firework Recommend(Customer c);
    }
}
 