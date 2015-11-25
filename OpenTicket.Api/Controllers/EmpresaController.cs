using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OpenTicket.Domain.Commands.EmpresaCommand;

namespace OpenTicket.Api.Controllers
{
    public class EmpresaController : BaseController
    {
        private readonly IEmpresaApplicationService _service;

        public EmpresaController(IEmpresaApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/empresa")]
        // [Authorize(Roles = "admin")]
        public Task<HttpResponseMessage> Get()
        {
            var users = _service.List();
            return CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpPost]
        [Route("api/empresa")]
      //  [Authorize(Roles = "admin")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new Empresa(
                nomeEmpresa: (string)body.nomeEmpresa,
                cnpj: (string)body.cnpj,
                datacadastro: (DateTime)DateTime.Now



            );
            var empresa = _service.Register(command);
            return CreateResponse(HttpStatusCode.Created, empresa);

        }

        [HttpGet]
       // [Authorize(Roles = "admin")]
        [Route("api/empresa/{Id:int}")]
        public Task<HttpResponseMessage> GetById(int Id)
        {
            var empresa = _service.GetId(Id);
            return CreateResponse(HttpStatusCode.OK, empresa);
        }


        [HttpGet]
       // [Authorize(Roles = "admin")]
        [Route("api/empresa/{Cnpj}")]
        public Task<HttpResponseMessage> GetByCnpj(string Cnpj)
        {
            var empresa = _service.GetCnpj(Cnpj);
            return CreateResponse(HttpStatusCode.OK, empresa);
        }
        [HttpPut]
        //[Authorize(Roles = "admin")]
        [Route("api/empresa/{id:int}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateEmpresaCommand(
               nomeEmpresa: (string)body.nomeEmpresa,
               cnpj: (string)body.cnpj,
               datacadastro: (DateTime)body.dataCadastro
               );
 
           var empresa = _service.Update(command, id);
           return CreateResponse(HttpStatusCode.OK, empresa);
        }
    }
 }