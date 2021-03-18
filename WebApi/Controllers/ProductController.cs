using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ProductController(IProductRepo productRepo, IWebHostEnvironment hostingEnvironment)
        {
            _productRepo = productRepo;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/ProductController
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_productRepo.GetAll());
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/ProductController/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _productRepo.Get(id);
                if (product == null)
                    return NotFound();
                return Ok(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/ProductController
        [HttpPost]
        public IActionResult PostProduct(ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var fileName = Path.GetFileName(model.FormFile.FileName.Replace(" ","_"));
                var uniqueFileName = GetUniqueFileName(fileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                model.FormFile.CopyTo(new FileStream(filePath, FileMode.Create));
                model.Image = filePath;

                _productRepo.Save(model);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/ProductController/5
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, ProductViewModel model)
        {
            try
            {
                if (id != model.Id || !ModelState.IsValid)
                    return BadRequest();

                if(model.UpdateFormFile != null)
                {
                    var oldImage = model.Image;
                    var fileName = Path.GetFileName(model.UpdateFormFile.FileName.Replace(" ", "_"));
                    var uniqueFileName = GetUniqueFileName(fileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    model.FormFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    model.Image = filePath;

                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }
                _productRepo.Update(model);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/ProductController/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _productRepo.Get(id);
                if (product == null)
                    return NotFound();
                _productRepo.Delete(id);

                if (System.IO.File.Exists(product.Image))
                {
                    System.IO.File.Delete(product.Image);
                }
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
