using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OpenTicket.Domain.Commands.PessoaCommad;

namespace OpenTicket.Api.Controllers
{
    public class PessoaController : BaseController
    {


        private readonly IPessoaApplicationService _service;

        public PessoaController(IPessoaApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/pessoa")]
        public Task<HttpResponseMessage> Get()
        {
            var funcionario = _service.List();
            return CreateResponse(HttpStatusCode.OK, funcionario);
        }

        [HttpPost]
        [Route("api/pessoa")]
      //  [Authorize(Roles = "admin")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new Pessoa(
                nomePessoa: (string)body.nomePessoa,
                cpf: (string)body.cpf,
                dataNascimento: ((DateTime)body.dataNascimento),
                email: (string)body.email,
                dataCadastro: ((DateTime)body.dataCadastro)

            );
            var pessoa = _service.Register(command);
            return CreateResponse(HttpStatusCode.Created, pessoa);

        }


        [HttpGet]
        //[Authorize]
        [Route("api/pessoa/{Id:int}")]
        public Task<HttpResponseMessage> GetById(int Id)
        {
            var funcionario = _service.GetId(Id);
            return CreateResponse(HttpStatusCode.OK, funcionario);
        }


        [HttpGet]
        //[Authorize]
        [Route("api/pessoa/{Cpf}")]
        public Task<HttpResponseMessage> GetByCnpj(string cpf)
        {
            var funcionario = _service.GetCpf(cpf);
            return CreateResponse(HttpStatusCode.OK, funcionario);
        }
        [HttpPut]
     //   [Authorize(Roles = "admin")]
        [Route("api/pessoa/{id:int}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            
            var command = new UpdatePessoaCommand(
                nomePessoa: (string)body.nomePessoa,
                cpf: (string)body.cpf,
                dataNascimento: (DateTime)body.dataNascimento,
                email: (string)body.email,
                dataCadastro: DateTime.Now
                );
            
            var pessoa = _service.Update(command,id);
            return CreateResponse(HttpStatusCode.OK, pessoa);

        }
    }
}