

using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OpenTicket.Domain.Commands.SetorCommand;

namespace OpenTicket.Api.Controllers
{
    public class SetorController: BaseController
    {
        private readonly ISetorApplicationService _service;

        public SetorController(ISetorApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/setor")]
        //[Authorize(Roles = "all")]
        public Task<HttpResponseMessage> Get()
        {
            var funcionario = _service.List();
            return CreateResponse(HttpStatusCode.OK, funcionario);
        }

        [HttpPost]
       //  [Authorize(Roles = "admin")]
        [Route("api/setor")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new Setor(
                nomeSetor: (string)body.nomeSetor
             
            );
            var setor = _service.Register(command);
            return CreateResponse(HttpStatusCode.Created, setor);

        }
        

        [HttpGet]
        //[Authorize]
        [Route("api/setor/{Id:int}")]
        public Task<HttpResponseMessage> GetById(int Id)
        {
            var setor = _service.GetId(Id);
            return CreateResponse(HttpStatusCode.OK, setor);
        }


        [HttpPut]
    //    [Authorize(Roles = "admin")]
        [Route("api/setor/{id:int}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            

            var command = new UpdateSetorCommand(
                          nomeSetor: (string)body.nomeSetor
                  );

            var setor = _service.Update(command, id);
            return CreateResponse(HttpStatusCode.OK, setor);
        }
    }
}