using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sigo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sigo.Controllers
{
    [Authorize]
    public class GestaoNormaExternaController : Controller
    {
        private static string _urlBase;

        #region Métodos públicos

        public async Task<IActionResult> Index()
        {
            return View(await ConsultarNormasExternas());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return View(await ConsultarNormasExternasPorId(id));
        }

        public async Task<FileResult> Download(Guid id)
        {
            return await DownloadPorId(id);
        }

        #endregion

        #region Métodos privados

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

        private async Task<NormaExternaViewModel> ConsultarNormasExternasPorId(Guid id)
        {
            var _uri = ConfiguraUrl() + "v1/normasExternas/" + id;

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
                    return JsonConvert.DeserializeObject<NormaExternaViewModel>(conteudo);

                return new NormaExternaViewModel();
            }
        }

        private async Task<FileResult> DownloadPorId(Guid id)
        {
            var _uri = ConfiguraUrl() + "v1/arquivos/" + id;

            using (var client = new HttpClient())
            {
                // Limpa o header
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = ObterTokenApi().DefaultRequestHeaders.Authorization;

                // Incluir o cabeçalho Accept que será envia na requisição             
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(_uri);

                string conteudo = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    ResponseArquivoViewModel retorno = JsonConvert.DeserializeObject<ResponseArquivoViewModel>(conteudo);

                    foreach (var item in retorno.Data)
                    {
                        byte[] fileBytes = System.IO.File.ReadAllBytes(item.CaminhoArquivo);
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, item.Nome);
                    }
                }

                return null;
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
    }
}
