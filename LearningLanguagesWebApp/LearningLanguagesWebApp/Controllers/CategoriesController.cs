using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Languages.Business;
using Languages.Business.Entity;
using LanguageStudyingWebApps.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageStudyingWebApps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService m_Service;
        public CategoriesController(ICategoriesService service)
        {
            m_Service = service;
        }

        // GET api/words
        [HttpGet]
        public ActionResult<IEnumerable<CategoryModel>> Get()
        {
            return new List<CategoryModel>();
        }

        // GET api/words/5
        [HttpGet("{id}")]
        public ActionResult<Categories> Get(int id)
        {
            return m_Service.GetCategoryById(id);
        }

        // POST api/words
        [HttpPost]
        public int Post([FromBody] CategoryModel value)
        {
            var newId = m_Service.Create(value.ToDomain());
            return newId;
        }

        // PUT api/words/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryModel value)
        {
            m_Service.Update(value.ToDomain());
        }

        // DELETE api/words/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("getdata")]
        public IEnumerable<CategoryModel> GetCategoriesByFilter()
        {
            var model = m_Service.GetActiveCategories().Select(x=>new CategoryModel { Id = x.Id, Name=x.Name});
            return model;
        }
    }
}