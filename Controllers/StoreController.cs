using Microsoft.AspNetCore.Mvc;
using StoresManager.ViewModels;

namespace StoresManager.Controllers;

public class StoreController : Controller
{
    private static List<StoreViewModel> stores = new List<StoreViewModel> {
        new StoreViewModel(32, "Piso 2", "Camisetas", "Aqui você encontra as melhores camisetas personalizadas.", "Loja", "camisas@email.com"),
        new StoreViewModel(33, "Piso 3", "Livraria Sorriso", "Livros de fantasia, drama, romance e muito mais.", "Quiosque", "livros@email.com"),
        new StoreViewModel(12, "Piso 1", "Sorvetinho Gelado", "Melhores sabores de sorvete é aqui na Sorvetinho Gelado.", "Quiosque", "sorvete@email.com")
    };

    public IActionResult Index()
    {
        // var storesEmpty = new List<StoreViewModel>();
        return View(stores);
    }

    public IActionResult IndexAdmin()
    {
        // var storesEmpty = new List<StoreViewModel>();
        return View(stores);
    }

    public IActionResult Show(int id)
    {
        foreach(var store in stores)
        {
            if(store.Id == id)
                return View(store);
        }

        return RedirectToAction("IndexAdmin");
    }

    public IActionResult Form()
    {
        return View();
    }

    public IActionResult Create([FromForm] int id, [FromForm] string floor, [FromForm] string name, [FromForm] string description, [FromForm] string type, [FromForm] string email)
    {
        foreach(var store in stores)
        {
            if((store.Id == id) || (store.Name == name))
                return RedirectToAction("Form");
        }

        stores.Add(new StoreViewModel(id, floor, name, description, type, email));
        return RedirectToAction("Show", new { id = id });
    }

    public IActionResult Delete(int id)
    {
        foreach(var store in stores.ToList())
        {
            if(store.Id == id)
                stores.Remove(store);
        }

        return RedirectToAction("IndexAdmin");
    }
}