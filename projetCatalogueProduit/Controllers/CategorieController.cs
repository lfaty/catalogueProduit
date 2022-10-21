using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Entity;
using projetCatalogueProduit.Models;
using Microsoft.EntityFrameworkCore;


namespace projetCatalogueProduit.Controllers
{
    public class CategorieController : Controller
    {
        BD_CATALOGUE_PRODUITContext db = new BD_CATALOGUE_PRODUITContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AjoutCategorie()
        {
            try
            {
                ViewBag.listeCategorie = db.CatCategories.ToList();
                return View();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AjoutCategorie(CatCategorie categorie) //Enregistrer categorie
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categorie.DateSaisie = DateTime.Now;
                    db.CatCategories.Add(categorie);
                    db.SaveChanges();

                }
                return RedirectToAction("AjoutCategorie");
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        public IActionResult SupprimerCategorie(int id)
        {
            try
            {
                CatCategorie categorie = db.CatCategories.Find(id); // recherche la categorie
                if(categorie != null)
                {
                    db.CatCategories.Remove(categorie); // supprimer la categorie
                    db.SaveChanges(); // enregistrer le resultat

                }
                return RedirectToAction("AjoutCategorie");
            }
            catch (Exception e) 
            {
                return NotFound();
            }
        }

        public IActionResult ModifierCategorie(int id)
        {
            try
            {
                ViewBag.listeCategorie = db.CatCategories.ToList();

                CatCategorie categorie = db.CatCategories.Find(id);
                if(categorie != null)
                {
                    return View("AjoutCategorie", categorie);
                }
                return RedirectToAction("AjoutCategorie");
            }catch(Exception e)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult ModifierCategorie(CatCategorie categorie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //categorie.DateSaisie = DateTime.Now;
                    db.CatCategories.Update(categorie);
                    db.SaveChanges();

                }
                return RedirectToAction("AjoutCategorie");
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }

}
