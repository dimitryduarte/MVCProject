using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Helper;

namespace ProvaCandidato.Controllers
{
    //[Route("api/[controller]")]
    public class BaseController : Controller // PARA TORNAR GENÉRICO: BaseController<T> : Controller where T : class
    {
        //IMPLEMENTAÇÃO DE MÉTODOS GENÉRICOS.
        
        //EXEMPLO:

        //private Repository<T> _repository;

        //public BaseController(Storage<T> repository)
        //{
        //    _repository = repository;
        //}

        //[HttpGet]
        //public IEnumerable<T> Get()
        //{
        //    return _repository.GetAll();
        //}

        //[HttpGet("{id}")]
        //public T Get(Guid id)
        //{
        //    return _repository.GetById(id);
        //}

        //[HttpPost("{id}")]
        //public void Post(Guid id, [FromBody]T value)
        //{
        //    _repository.Add(id, value);
        //}

    }
}