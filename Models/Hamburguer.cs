using HamburgueriaMVC.Models;
using Microsoft.Extensions.Primitives;

namespace Hamburgueria.MVC.Models
{
    public class Hamburguer : Produto 
    {

        public Hamburguer()
        {
            
        }

        public Hamburguer(StringValues Nome, double Preco)
        {
            this.Nome = Nome;
            this.Preco = Preco;
        }

    }
}