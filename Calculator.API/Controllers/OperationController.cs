using Calculator.Domain;
using Calculator.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Calculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public OperationController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<OperationController>
        [HttpGet]
        public IEnumerable<Operation> Get()
        {
            return unitOfWork.OperationRepository.GetAll();
        }

        // GET api/<OperationController>/5
        [HttpGet("{id}")]
        public Operation Get(int id)
        {
            var op = unitOfWork.OperationRepository.GetById(id);
            if (op.HasValue)
                return op.Value;
            return null;
        }

        // POST api/<OperationController>
        [HttpPost]
        public void Post([FromBody] Operation value)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.OperationRepository.Add(value);
                unitOfWork.SaveChanges();
            }
        }

        // DELETE api/<OperationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var op = unitOfWork.OperationRepository.GetById(id);
            if (op.HasValue)
            {
                unitOfWork.OperationRepository.Remove(op.Value);
                unitOfWork.SaveChanges();
            }
        }
    }
}
