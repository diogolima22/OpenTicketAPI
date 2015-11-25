using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OpenTicket.SharedKernel.Helpers;

namespace OpenTicket.Api.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioApplicationService _service;

        public UsuarioController(IUsuarioApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/users")]
        public Task<HttpResponseMessage> Get()
        {
            var users = _service.List();
            return CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpPost]
        [Route("api/users")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new Usuario(
                idPessoa: (int)body.idPessoa,
                login: (string)body.login,
                senha: (string)body.senha,
                dataCadastro: (DateTime)DateTime.Now,
                idEmpresa: (int)body.idEmpresa, 
                isAdmin: (bool)body.isAdmin


            );


            var usuario = _service.Register(command);

            return CreateResponse(HttpStatusCode.Created, usuario);
        }

        [HttpGet]
        [Route("api/login/{email}/{senha}")]
        public Task<HttpResponseMessage> Login(string email, string senha)
        {
 
            var user = _service.Authenticate(email, senha);
           
            if (user == null)
            {
                return CreateResponse(HttpStatusCode.Created, user);
            }
            return CreateResponse(HttpStatusCode.Created, user);

        }
    }
}