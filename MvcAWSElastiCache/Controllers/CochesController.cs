using Microsoft.AspNetCore.Mvc;
using MvcAWSElastiCache.Models;
using MvcAWSElastiCache.Repositories;
using MvcAWSElastiCache.Services;

namespace MvcAWSElastiCache.Controllers
{
    public class CochesController : Controller
    {
        private RepositoryCoches repo;
        private ServiceAWSCache service;

        public CochesController(RepositoryCoches repo, ServiceAWSCache service)
        {
            this.repo = repo;
            this.service = service;
        }

        public IActionResult Index()
        {
            List<Coche> cars = this.repo.GetCoches();
            return View(cars);
        }

        public IActionResult Details(int id)
        {
            Coche car = this.repo.FindCoche(id);
            return View(car);
        }

        public async Task<IActionResult> Favoritos(int id)
        {
            List<Coche> coches = await this.service.GetCochesAsync();
            return View(coches);
        }

        public async Task<IActionResult> SeleccionarFavorito(int id)
        {
            Coche favorito = this.repo.FindCoche(id);
            await this.service.AddFavoritoAsync(favorito);
            return RedirectToAction("Favoritos");
        }

        public async Task<IActionResult> DeleteFavorito(int id)
        {
            await this.service.DeleteFavoritoAsync(id);
            return RedirectToAction("Favoritos");
        }
    }
}
