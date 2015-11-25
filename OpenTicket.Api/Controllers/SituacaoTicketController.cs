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

namespace OpenTicket.Api.Controllers
{
    public class SituacaoTicketController : BaseController
    {

        private readonly ISituacaoTicketApplicationService _service;

        public  SituacaoTicketController(ISituacaoTicketApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/situacao")]
        public Task<HttpResponseMessage> Get()
        {
            var funcionario = _service.List();
            return CreateResponse(HttpStatusCode.OK, funcionario);
        }

        [HttpPost]
     //   [Authorize(Roles = "admin")]
        [Route("api/situacao")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new SituacaoTicket(
                nomeSituacao: (string)body.nomeSituacao
            );
            var situacao = _service.Register(command);
            return CreateResponse(HttpStatusCode.Created, situacao);

        }

        [HttpPut]
      //  [Authorize(Roles = "admin")]
        [Route("api/situacao/{id:int}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new SituacaoTicket(
                 nomeSituacao: (string)body.nomeSituacao
               );

            var situacao = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, situacao);
        }
    }
}