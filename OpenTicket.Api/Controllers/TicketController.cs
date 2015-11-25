

using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OpenTicket.Domain.Commands.TicketCommand;

namespace OpenTicket.Api.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketApplicationService _service;

        public TicketController(ITicketApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/ticket/{idUsuario:int}")]
        public Task<HttpResponseMessage> Get(int idUsuario)
        {
            var ticket = _service.List(idUsuario);
            return CreateResponse(HttpStatusCode.OK, ticket);
        }

        [HttpPost]
        [Route("api/ticket")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new Ticket(
                assunto: (string)body.assunto,
                prioridade: (string)body.prioridade,
                idempresa: (int)body.idempresa,
                descricao: (string)body.descricao,
                idSituacao: (int)body.idSituacao,
                idSetor: (int)body.idSetor,
                idUsuario: (int)body.idUsuario,
                dataCadastro:(DateTime) DateTime.Now




            );
            var ticket = _service.Register(command);
            return CreateResponse(HttpStatusCode.Created, ticket);

        }


        [HttpGet]
        //[Authorize]
        [Route("api/ticketid/{Id:int}")]
        public Task<HttpResponseMessage> GetById(int Id)
        {
            var ticket = _service.GetId(Id);
            return CreateResponse(HttpStatusCode.OK, ticket);
        }



        [HttpPut]
        //[Authorize]
        [Route("api/ticketS/{id:int}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new Ticket(
                         assunto: (string)body.assunto,
                         prioridade: (string)body.prioridade,
                         idempresa: (int)body.idempresa,
                         descricao: (string)body.descricao,
                         idSituacao: (int)body.idSetuacao,
                         idSetor: (int)body.idSetor,
                         idUsuario: (int)body.idUsuario,
                         dataCadastro: (DateTime)body.dataCdastro
                       
                         );

            var ticket = _service.Update(command,id);
            return CreateResponse(HttpStatusCode.OK, ticket);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/ticketFechamento/{id:int}")]
        public Task<HttpResponseMessage> PutFechamento(int id, [FromBody]dynamic body)
        {
            var command = new UpdateTicketFechamentoCommand(
                 dataFechamento: (DateTime)DateTime.Now,
                 idSituacao: (int)2);

            var ticket = _service.UpdateFechamento(command, id);
            return CreateResponse(HttpStatusCode.OK, ticket);
        }


        [HttpGet]
        [Route("api/TicketAll")]
        public Task<HttpResponseMessage> GetAll()
        {
            var Ticket = _service.GetlAll();
            return CreateResponse(HttpStatusCode.OK, Ticket);
        }

    }
}