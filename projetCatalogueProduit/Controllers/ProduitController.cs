using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using projetCatalogueProduit.Models;
using System.IO;

namespace projetCatalogueProduit.Controllers
{
    public class ProduitController : Controller
    {
        BD_CATALOGUE_PRODUITContext db = new BD_CATALOGUE_PRODUITContext();

        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProduitController(IWebHostEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AjoutProduit()
        {
            try
            {
                ViewBag.listeProduit = db.CatProduits.ToList();
                ViewBag.listeCategorie = db.CatCategories.ToList();

                return View();
            }catch(Exception e)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AjoutProduit(CatProduit produit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.Form.Files.Count > 0)
                    {
                        var file = Request.Form.Files[0];
                        if(file != null && file.Length > 0)
                        {
                            // Save image to wwwroot/image
                            string wwwRootPath = _hostingEnvironment.WebRootPath;
                            string fileName = Path.GetFileName(file.FileName);
                            string path = Path.Combine(wwwRootPath + "/Image", fileName);
                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                file.CopyTo(fileStream);

                            }
                            produit.ImageProduit = fileName;
                            produit.UrlImageProduit = "/Image";
                        }

                    }
                    
                    produit.DateSaisie = DateTime.Now;
                    db.CatProduits.Add(produit);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutProduit");
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        public IActionResult SupprimerProduit(int id)
        {
            try
            {
                CatProduit produit = db.CatProduits.Find(id); // recherche la categorie
                if (produit != null)
                {
                    db.CatProduits.Remove(produit); // supprimer la categorie
                    db.SaveChanges(); // enregistrer le resultat

                }
                return RedirectToAction("AjoutProduit");
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }


        public IActionResult ModifierProduit(int id)
        {
            try
            {
                ViewBag.listeCategorie = db.CatCategories.ToList();
                ViewBag.listeProduit = db.CatProduits.ToList();

                CatProduit produit = db.CatProduits.Find(id);
                if (produit != null)
                {
                    return View("AjoutProduit", produit);
                }
                return RedirectToAction("AjoutProduit");
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult ModifierProduit(CatProduit produit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //categorie.DateSaisie = DateTime.Now;
                    db.CatProduits.Update(produit);
                    db.SaveChanges();

                }
                return RedirectToAction("AjoutProduit");
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

    }
}
