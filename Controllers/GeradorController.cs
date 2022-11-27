using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerador_de_senhas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace gerador_de_senhas.Controllers
{
    public class GeradorController : Controller
    {
        public IActionResult Gerador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Gerador(GeradorDeSenha geradorDeSenha)
        {
            ModelState.Clear();
            string caracteresPossiveis = 
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + 
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower() + 
                "0123456789" + "%$#@!";
            
            Random sorteio = new Random();
            int numeroSorteado = 0;
            StringBuilder password = new StringBuilder();
            for (int i = 0; i < geradorDeSenha.Quantidade; i++)
            {
                numeroSorteado = sorteio.Next(0, caracteresPossiveis.Length - 1);
                password.Append(caracteresPossiveis[numeroSorteado]);
            }
            geradorDeSenha.Password = password.ToString();
            return View(geradorDeSenha);
        }
    }
}