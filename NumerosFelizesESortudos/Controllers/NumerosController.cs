
using Microsoft.AspNetCore.Mvc;
using NumerosFelizesESortudos.Models;
using System;
using System.Collections.Generic;

namespace NumerosFelizesESortudos.Controllers
{
    public class NumerosController : Controller
    {
        public IActionResult Index(string Numero)
        {
            return View();
        }
  

        public ActionResult VerificaClassificacaoNumero(string NumeroEscolhido)
        {
            string classificacaoMensagem = "";

            try
            {
                int numeroParse = Int32.Parse(NumeroEscolhido);

                Numero numero = new Numero(numeroParse);

                classificacaoMensagem = numero.Classificacao;
            }
            catch(Exception)
            {
                classificacaoMensagem = "Favor escolher um número inteiro válido";
            }
            finally
            {
                ViewData["Classificacao"] = classificacaoMensagem;
            }

            return View("Index");
        }
    }
}
