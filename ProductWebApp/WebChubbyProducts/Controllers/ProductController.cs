namespace WebChubbyProducts.Controllers
{

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebChubbyProducts.Models;
    using WebChubbyProducts.DTO;
    using WebChubbyProducts.Helpers;

    public class ProductController : Controller
    {
        private readonly string chubbyServiceUri = "https://localhost:44393/api/";
        private readonly string productPath = "products";

        // GET: ProductController
        public ActionResult Index(string filterProduct)
        {
            //Buscar la lista de productos a mostrar.
            List<ProductModel> model = new List<ProductModel>();
            try
            {
                var client = new HttpClientWrapper<ProductRequestDto, ProductListResponseDto>();
                var response = client.GetJsonAsync( new Uri(chubbyServiceUri), productPath).Result;

                if (!ReferenceEquals(null, response)) 
                {
                    foreach (ProductDto prod in response) {
                        model.Add(new ProductModel
                        {
                            Id = prod.Id, 
                            Category = prod.Category, 
                            Description = prod.Description, 
                            Name = prod.Name, 
                            Price = prod.Price, 
                            Quantity = prod.Quantity
                        });
                    }
                }

                if (!string.IsNullOrEmpty(filterProduct))
                {
                    TempData["Search"] = filterProduct;
                    model = model.Where(x => x.Name.Contains(filterProduct)).ToList();
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    //Guardar el producto
                    var client = new HttpClientWrapper<ProductItemResponsetDto, ProductRequestDto>();
                    var response = client.PostJsonAsync(chubbyServiceUri, productPath, new ProductItemResponsetDto
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Category = model.Category,
                        Price = model.Price,
                        Quantity = model.Quantity
                    }).Result;

                    if (response.Id > 0)
                    {
                        //Se guardo de forma correcta
                        return RedirectToAction(nameof(Index));
                    }
                    else {
                        //Mandar mensaje de error
                        ViewData["Error"] = "Ocurrio un error al guardar el producto";
                        return View(model);
                    }
                }
                else {
                    return View(model);
                }
            }
            catch
            {
                ViewData["Error"] = "Ocurrio un error al guardar el producto";
                return View(model);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductModel model = new ProductModel();
            try
            {
                var client = new HttpClientWrapper<ProductRequestDto, ProductItemResponsetDto>();
                var response = client.GetJsonAsync(new Uri(chubbyServiceUri), productPath + "/" + id ).Result;

                if (!ReferenceEquals(null, response))
                {
                    model = new ProductModel
                    {
                        Id = response.Id,
                        Category = response.Category,
                        Description = response.Description,
                        Name = response.Name,
                        Price = response.Price,
                        Quantity = response.Quantity
                    };
                }
                else {
                    ViewData["Error"] = "No se pudo recuperar producto " + id;
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                ViewData["Error"] = "No se pudo recuperar producto " + id;
            }
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    //Guardar el producto
                    var client = new HttpClientWrapper<ProductItemResponsetDto, ProductRequestDto>();
                    var response = client.PutJsonAsync( new Uri(chubbyServiceUri), productPath + "/"+id, new ProductItemResponsetDto
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Description = model.Description,
                        Category = model.Category,
                        Price = model.Price,
                        Quantity = model.Quantity
                    }).Result;

                    if (response.Id > 0)
                    {
                        //Se guardo de forma correcta
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        //Mandar mensaje de error
                        ViewData["Error"] = "Ocurrio un error al guardar el producto";
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                ViewData["Error"] = "Ocurrio un error al guardar el producto";
                return View(model);
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductModel model = new ProductModel();
            try
            {
                var client = new HttpClientWrapper<ProductRequestDto, ProductItemResponsetDto>();
                var response = client.GetJsonAsync(new Uri(chubbyServiceUri), productPath + "/" + id).Result;

                if (!ReferenceEquals(null, response))
                {
                    model = new ProductModel
                    {
                        Id = response.Id,
                        Category = response.Category,
                        Description = response.Description,
                        Name = response.Name,
                        Price = response.Price,
                        Quantity = response.Quantity
                    };
                }
                else
                {
                    ViewData["Error"] = "No se pudo recuperar producto " + id;
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                ViewData["Error"] = "No se pudo recuperar producto " + id;
            }
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductModel model)
        {
            try
            {
                //eliminar el producto
                var client = new HttpClientWrapper<ProductItemResponsetDto, ProductRequestDto>();
                var response = client.DeleteJsonAsync(new Uri(chubbyServiceUri), productPath + "/" + id).Result;

                if (response.Id > 0)
                {
                    //Se guardo de forma correcta
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Mandar mensaje de error
                    ViewData["Error"] = "Ocurrio un error al guardar el producto";
                    return View(model);
                }
            }
            catch
            {
                ViewData["Error"] = "Ocurrio un error al guardar el producto";
                return View(model);
            }
        }
    }
}
