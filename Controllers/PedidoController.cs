using Hamburgueria.MVC.Models;
using Hamburgueria.MVC.Repositorios;
using Hamburgueria.MVC.ViewModels;
using HamburgueriaMVC.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hamburgueria.MVC.Controllers
{
    public class PedidoController : Controller 
    {
        private PedidoRepositorio Repositorio = new PedidoRepositorio();
        private HamburguerRepositorio hamburguerRepositorio = new HamburguerRepositorio();
        private ShakeRepositorio shakeRepositorio = new ShakeRepositorio();

        [HttpGet]
        public IActionResult Index()
        {
            var hamburgueres = hamburguerRepositorio.Listar();
            var shakes = shakeRepositorio.Listar();

            PedidoViewModel pedido = new PedidoViewModel();
            pedido.Hamburgueres = hamburgueres;
            pedido.Shakes = shakes;
            
            return View(pedido);
        }

        [HttpPost]
        public IActionResult RegistarPedido(IFormCollection form) 
        {
            System.Console.WriteLine(form["nome"]);
            System.Console.WriteLine(form["endereco"]);
            System.Console.WriteLine(form["telefone"]);
            System.Console.WriteLine(form["email"]);
            System.Console.WriteLine(form["hamburguer"]);
            System.Console.WriteLine(form["shake"]);

            Pedido pedido = new Pedido();

            // Forma 1 - Mais comum
            Cliente cliente = new Cliente();
            cliente.Nome = form["nome"];
            cliente.Endereco = form["endereco"];
            cliente.Telefone = form["telefone"];
            cliente.Email = form["email"];

            pedido.Cliente = cliente;

            // Forma 2 - Usa parâmetros nos construtores
            Hamburguer hamburguer = new Hamburguer(
                Nome: form["hamburguer"],
                Preco: hamburguerRepositorio.ObterPrecoDe(form["hamburguer"])
            );

            pedido.Hamburguer = hamburguer;

            // Forma 3 - Resumo da forma 1
            Shake shake = new Shake() {
                Nome = form["shake"],
                Preco = shakeRepositorio.ObterPrecoDe(form["shake"])
            };

            pedido.Shake = shake;

            pedido.PrecoTotal = pedido.Hamburguer.Preco + pedido.Shake.Preco;
            
            Repositorio.Inserir(pedido);
            ViewData["NomeVIew"] = "Pedido";
            
            return View("Sucesso");
        }
    }
}