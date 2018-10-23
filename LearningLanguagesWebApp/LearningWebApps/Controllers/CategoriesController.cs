using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Languages.Business;
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
        public ActionResult<CategoryModel> Get(int id)
        {
            return new CategoryModel();
        }

        // POST api/words
        [HttpPost]
        public void Post([FromBody] CategoryModel value)
        {
            var update = value;
            m_Service.Create(value.ToDomain());
        }

        // PUT api/words/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryModel value)
        {
        }

        // DELETE api/words/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("getdata")]
        public ActionResult<IEnumerable<CategoryModel>> GetCategoriesByFilter()
        {
            var x = 1;
            return new List<CategoryModel>();
        }
    }
}