using FormularioAspNetMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FormularioAspNetMvc.Controllers
{
    public class PessoasController : Controller
    {
		private CadastroContext db = new CadastroContext();

        private List<object> estados = new List<object>
        {
                new {Sigla = "AC", Nome = "Acre" },
                new {Sigla = "AL", Nome = "Alagoas" },
                new {Sigla = "AP", Nome = "Amapá" },
                new {Sigla = "AM", Nome = "Amazonas" },
                new {Sigla = "BA", Nome = "Bahia" },
                new {Sigla = "CE", Nome = "Ceará" },
                new {Sigla = "DF", Nome = "Distrito Federal" },
                new {Sigla = "ES", Nome = "Espírito Santo" },
                new {Sigla = "GO", Nome = "Goiás" },
                new {Sigla = "MA", Nome = "Maranhão" },
                new {Sigla = "MT", Nome = "Mato Grosso" },
                new {Sigla = "MS", Nome = "Mato Grosso do Sul" },
                new {Sigla = "MG", Nome = "Minas Gerais" },
                new {Sigla = "PA", Nome = "Pará" },
                new {Sigla = "PB", Nome = "Paraíba" },
                new {Sigla = "PR", Nome = "Paraná" },
                new {Sigla = "PE", Nome = "Pernambuco" },
                new {Sigla = "PI", Nome = "Piauí" },
                new {Sigla = "RJ", Nome = "Rio de Janeiro" },
                new {Sigla = "RN", Nome = "Rio Grande do Norte" },
                new {Sigla = "RS", Nome = "Rio Grande do Sul" },
                new {Sigla = "RO", Nome = "Rondônia" },
                new {Sigla = "RR", Nome = "Roraima" },
                new {Sigla = "SC", Nome = "Santa Catarina" },
                new {Sigla = "SP", Nome = "São Paulo" },
                new {Sigla = "SE", Nome = "Sergipe" },
                new {Sigla = "TO", Nome = "Tocantins" }
         };

        public ActionResult Cadastro()
        {
			ViewBag.Estados = new SelectList(estados, "Sigla", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarPessoa(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Estados = new SelectList(estados, "Sigla", "Nome");
                return View("Cadastro", pessoa);
            }

			db.Pessoas.Add(pessoa);
			db.SaveChanges();

			return RedirectToAction("Sucesso");
        }

		public ActionResult Sucesso()
		{
			return View();
		}

		public JsonResult ValidarCPF(string cpf)
		{
			var pessoa = db.Pessoas.Find(cpf);
			return Json(pessoa == null, JsonRequestBehavior.AllowGet);
		}
    }
}