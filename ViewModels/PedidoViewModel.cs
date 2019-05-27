using System.Collections.Generic;
using Hamburgueria.MVC.Models;

namespace Hamburgueria.MVC.ViewModels
{
    public class PedidoViewModel
    {
        public List<Hamburguer> Hamburgueres { get; set;}
        public List<Shake> Shakes { get; set;}
    }
}