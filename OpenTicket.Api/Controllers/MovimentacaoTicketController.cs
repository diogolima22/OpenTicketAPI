

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OpenTicket.Domain.Commands.MovimentacaoTicketCommand;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Services;

namespace OpenTicket.Api.Controllers
{
    public class MovimentacaoTicketController : BaseController
    {


        private readonly IMovimentacaoTicketApplicationService _service;

        public MovimentacaoTicketController(IMovimentacaoTicketApplicationService service)
        {
            this._service = service;
        }

        [HttpPost]
      //  [Authorize(Roles = "admin")]
        [Route("api/movimentacao")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new MovimentacaoTicket(
                idTicket: (int)body.idTicket,
                idUsuario: (int)body.idUsuario,
                resposta:(string)body.resposta,
                datacadastro: (DateTime)DateTime.Now

            );
            var movimentacao = _service.Register(command);
            return CreateResponse(HttpStatusCode.Created, movimentacao);

        }


        [HttpGet]
        //[Authorize]
        [Route("api/movimentacao/{Id:int}")]
        public Task<HttpResponseMessage> GetByIdTicket(int Id)
        {
            var movimentacao = _service.GetByIdTicket(Id);
            return CreateResponse(HttpStatusCode.OK, movimentacao);
        }


        [HttpPut]
       // [Authorize(Roles = "admin")]
        [Route("api/movimentacao/{id:int}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
        
            var command = new UpdateMovimentacaoTicketCommand(
                idTicket: (int) body.idTicket,
                idUsuario: (int) body.idUsuario,
                resposta: (string) body.resposta,
                datacadastro: (DateTime) DateTime.Now
                );

           var setor = _service.Update(command,id);
            return CreateResponse(HttpStatusCode.OK, setor);
        }
    }
}