using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula1.Controllers
{
    public class HomeController : Controller
    {

        DBModel db = new DBModel();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Candidatos()
        {

            List<Candidato> candidatos = db.Candidato.ToList();

            return Json( new { data = candidatos }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult buscaCandidatos(int id)
        {

            //List<Candidato> candidato = db.Candidato.ToList();
            String json = "{ 'Nome':'allan', 'CPF':'00000000', 'Telefone':'212121212', 'Ativo': 'true'}";
            //return Json(new { data = candidato }, JsonRequestBehavior.AllowGet);
            return Json(new { data = json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CadastrarCandidato()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CadastrarCandidato(Candidato candidato)
        {

            db.Candidato.Add(candidato);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult VisualizarCandidato(int Id)
        {
            Candidato candidato = db.Candidato.Find(Id);
            return View(candidato);
        }

        //public ActionResult VisualizarCandidato()
        //{
        //    return View();
        //}
    }
}