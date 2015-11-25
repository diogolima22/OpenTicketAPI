using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using OpenTicket.Domain.Commands.FuncionarioCommand;

namespace OpenTicket.Api.Controllers
{
    public class FuncionarioController : BaseController
    {
        private readonly IFuncionarioApplicationService _service;

        public FuncionarioController(IFuncionarioApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/funcionario")]
       // [Authorize(Roles = "admin")]
        public Task<HttpResponseMessage> Get()
        {
            var funcionario = _service.List();
            return CreateResponse(HttpStatusCode.OK, funcionario);
        }

        [HttpPost]
        [Route("api/funcionario")]
     //   [Authorize(Roles = "admin")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new Funcionario(
                idPessoa: (int)body.idPessoa,
                idSetor: (int)body.idSetor



            );
            var funcionario = _service.Register(command);
            return CreateResponse(HttpStatusCode.Created, funcionario);

        }


        [HttpGet]
     //   [Authorize(Roles = "admin")]
        [Route("api/funcionario/{Id:int}")]
        public Task<HttpResponseMessage> GetById(int Id)
        {
            var funcionario = _service.GetId(Id);
            return CreateResponse(HttpStatusCode.OK, funcionario);
        }


        [HttpGet]
       // [Authorize(Roles = "admin")]
        [Route("api/funcionario/{Cpf}")]
        public Task<HttpResponseMessage> GetByCnpj(string cpf)
        {
            var funcionario = _service.GetCpf(cpf);
            return CreateResponse(HttpStatusCode.OK, funcionario);
        }


        [HttpPut]
        [Route("api/funcionario/{id:int}")]
       // [Authorize(Roles = "admin")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            
            var command = new UpdateFuncionarioCommad(
                         idPessoa: (int)body.idPessoa,
                         idSetor: (int)body.idSetor
              );

            var funcionario = _service.Update(command,id);
            return CreateResponse(HttpStatusCode.OK, funcionario);
        }
    }
}