using Aula02ProjetoCompleto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula02ProjetoCompleto.Controllers
{
    public class TarefaController : Controller
    {

        private static List<Tarefa> tarefas = new List<Tarefa>();

        // GET: TarefaController
        public ActionResult Index()
        {
            return View(tarefas);
        }

        // GET: TarefaController/Details/5
        public ActionResult Details(int id)
        {
            Tarefa tarefa = tarefas.Find(t => t.Id == id);
            return View(tarefa);
        }

        // GET: TarefaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarefaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarefa tarefa)
        {
            tarefa.Id = tarefas.Count + 1;
            tarefas.Add(tarefa);
            return RedirectToAction("Index");

        }

        // GET: TarefaController/Edit/5
        public ActionResult Edit(int id)
        {
            Tarefa tarefa = tarefas.Find(t => t.Id == id);
            return View(tarefa);
        }

        // POST: TarefaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tarefa tarefa)
        {
            Tarefa tarefaExistente = tarefas.Find(t => t.Id == tarefa.Id);
            tarefaExistente.Titulo = tarefa.Titulo;
            tarefaExistente.Concluida = tarefa.Concluida;
            return RedirectToAction("Index");
        }

        // GET: TarefaController/Delete/5
        public ActionResult Delete(int id)
        {
            Tarefa tarefa = tarefas.Find(t => t.Id == id);
            return View(tarefa);
        }

        // POST: TarefaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {

            Tarefa tarefa = tarefas.Find(t => t.Id == id);
            tarefas.Remove(tarefa);
            return RedirectToAction("Index");
        }
    }
}
