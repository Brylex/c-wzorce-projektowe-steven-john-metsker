using System; 
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Definiuje standardow¹ us³ugê polecania klientowi dostêpnego produktu.
    /// </summary>
    public interface Advisor 
    {
        Firework Recommend(Customer c);
    }
}
 