using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sigo.Business.Intefaces;
using Sigo.Business.Models;
using Sigo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sigo.Controllers
{
    [Authorize]
    public class ConsultoriaAcessoriaController : Controller
    {
        private static string _urlBase;
        private readonly IConsultoriaAcessoriaRepository _consultoriaAcessoriaRepository;
        private readonly IConsultoriaAcessoriaService _consultoriaAcessoriaService;
        private readonly IMapper _mapper;

        public ConsultoriaAcessoriaController(IConsultoriaAcessoriaService consultoriaAcessoriaService,
                                            IConsultoriaAcessoriaRepository consultoriaAcessoriaRepository,
                                            IMapper mapper)
        {
            _consultoriaAcessoriaService = consultoriaAcessoriaService;
            _consultoriaAcessoriaRepository = consultoriaAcessoriaRepository;
            _mapper = mapper;
        }

        #region Métodos públicos

        // GET: ConsultoriaAcessoria
        public async Task<IActionResult> Index()
        {
            return View(await ObterTodos());
        }

        // GET: ConsultoriaAcessoria/Create
        public async Task<IActionResult> Create()
        {
            var consultoriaAcessoria = new ConsultoriaAcessoriaViewModel()
            {
                TipoNormaExterna = await DropDownNormaExterna()
            };

            return View(consultoriaAcessoria);
        }

        // POST: ConsultoriaAcessoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConsultoriaAcessoriaViewModel consultoriaAcessoria)
        {
            if (ModelState.IsValid)
            {
                await _consultoriaAcessoriaService.Adicionar(_mapper.Map<ConsultoriaAcessoria>(consultoriaAcessoria));

                return RedirectToAction(nameof(Index));
            }
            return View(consultoriaAcessoria);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var consultoriaAcessoria = _mapper.Map<ConsultoriaAcessoriaViewModel>(await _consultoriaAcessoriaRepository.ObterPorId(id));

            if (consultoriaAcessoria == null) return NotFound();

            consultoriaAcessoria.TipoNormaExterna = await DropDownNormaExterna();

            return View(consultoriaAcessoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ConsultoriaAcessoriaViewModel consultoriaAcessoria)
        {
            if (id != consultoriaAcessoria.Id) return NotFound();

            var consultoriaAcessoriaAtualizacao = await _consultoriaAcessoriaRepository.ObterPorId(id);

            consultoriaAcessoriaAtualizacao.RazaoSocial = consultoriaAcessoria.RazaoSocial;
            consultoriaAcessoriaAtualizacao.Cnpj = consultoriaAcessoria.Cnpj;
            consultoriaAcessoriaAtualizacao.DataInicio = consultoriaAcessoria.DataInicio;
            consultoriaAcessoriaAtualizacao.Ativo = consultoriaAcessoria.Ativo;
            consultoriaAcessoriaAtualizacao.NomeFantasia = consultoriaAcessoria.NomeFantasia;
            consultoriaAcessoriaAtualizacao.Periodo = consultoriaAcessoria.Periodo;
            consultoriaAcessoriaAtualizacao.DataFim = consultoriaAcessoria.DataFim;
            consultoriaAcessoriaAtualizacao.IdTipoNormaExterna = consultoriaAcessoria.IdTipoNormaExterna;
            consultoriaAcessoriaAtualizacao.Descricao = consultoriaAcessoria.Descricao;

            if (!ModelState.IsValid) return View(consultoriaAcessoriaAtualizacao);

            await _consultoriaAcessoriaService.Atualizar(consultoriaAcessoriaAtualizacao);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            // Obtem consultoria acessoria pelo id. 
            var consultoriaAcessoria = _mapper.Map<ConsultoriaAcessoriaViewModel>(await _consultoriaAcessoriaRepository.ObterPorId(id));

            if (consultoriaAcessoria == null) return NotFound();

            consultoriaAcessoria.TipoNormaExterna = await DropDownNormaExterna();

            return View(consultoriaAcessoria);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<JsonResult> Delete(string id)
        {
            string idString = id.Split(' ').FirstOrDefault();

            if (Guid.TryParse(idString, out Guid idGuid))
            {
                var consultoriaAcessoriaDeletar = await _consultoriaAcessoriaRepository.ObterPorId(idGuid);
                await _consultoriaAcessoriaService.Remover(_mapper.Map<ConsultoriaAcessoria>(consultoriaAcessoriaDeletar));
            }
            else
                return null;

            return Json(null);
        }

        #endregion

        #region Métodos privados

        private async Task<IEnumerable<SelectListItem>> DropDownNormaExterna()
        {
            List<SelectListItem> listaNormas = new List<SelectListItem>();
            List<NormaExternaViewModel> lstNormasExternas = await ConsultarNormasExternas();

            foreach (var item in lstNormasExternas)
            {
                listaNormas.Add(new SelectListItem()
                {
                    Text = item.Codigo.ToString(),
                    Value = item.Id.ToString()
                });
            }

            return listaNormas;
        }

        private async Task<List<NormaExternaViewModel>> ConsultarNormasExternas()
        {
            var _uri = ConfiguraUrl() + "v1/normasExternas/";

            using (var client = new HttpClient())
            {
                // Limpa o header
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = ObterTokenApi().DefaultRequestHeaders.Authorization;

                // Incluir o cabeçalho Accept que será envia na requisição             
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(_uri);

                string conteudo = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<List<NormaExternaViewModel>>(conteudo);

                return new List<NormaExternaViewModel>();
            }
        }

        private string ConfiguraUrl()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile($"appsettings.json");
            var config = builder.Build();

            return _urlBase = config.GetSection("API_Access:UrlBase").Value;
        }

        public HttpClient ObterTokenApi()
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile($"appsettings.json");
            var config = builder.Build();

            _urlBase = config.GetSection("API_Access:UrlBase").Value;

            var _uri = _urlBase + "v1/entrar/";
            var _email = config.GetSection("API_Access:email").Value;
            var _password = config.GetSection("API_Access:password").Value;

            Console.WriteLine("Dados: uri - email e senha");
            Console.WriteLine($"{_uri} -  {_email} - {_password} \n");

            using (var client = new HttpClient())
            {
                //limpa o header
                client.DefaultRequestHeaders.Accept.Clear();

                //incluir o cabeçalho Accept que será envia na requisição             
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                // Envio da requisição a fim de autenticar e obter o token de acesso
                HttpResponseMessage respToken = client.PostAsync(_uri, new StringContent(
                        JsonConvert.SerializeObject(new
                        {
                            email = _email,
                            password = _password
                        }), Encoding.UTF8, "application/json")).Result;

                // Obtem o token gerado
                string conteudo = respToken.Content.ReadAsStringAsync().Result;

                if (respToken.StatusCode == HttpStatusCode.OK)
                {
                    // Deserializa o token e data de expiração para o objeto Token
                    ResponseViewModel token = JsonConvert.DeserializeObject<ResponseViewModel>(conteudo);

                    // Associar o token aos headers do objeto do tipo HttpClient
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Data.AccessToken);

                    return client;
                }
            }

            return null;
        }

        #endregion

        #region Métodos privados

        public async Task<IEnumerable<ConsultoriaAcessoriaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ConsultoriaAcessoriaViewModel>>(await _consultoriaAcessoriaRepository.ObterTodos());
        }

        #endregion
    }
}
