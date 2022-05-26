using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Norma.Business.Intefaces;
using Norma.Business.Models;
using Sigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sigo.Controllers
{
    [Authorize]
    public class GestaoNormaInternaController : Controller
    {
        private readonly INormaInternaRepository _normaInternaRepository;
        private readonly INormaInternaService _normaInternaService;
        private readonly IMapper _mapper;

        public GestaoNormaInternaController(INormaInternaService normaInternaService, 
                                            INormaInternaRepository normaInternaRepository, 
                                            IMapper mapper)
        {
            _normaInternaService = normaInternaService;
            _normaInternaRepository = normaInternaRepository;
            _mapper = mapper;
        }

        #region Métodos públicos

        // GET: GestaoNormaInterna/Index
        public async Task<IActionResult> Index()
        {
            return View(await ObterTodos());
        }

        // GET: GestaoNormaInterna/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GestaoNormaInterna/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NormaInternaViewModel normaInterna)
        {
            if (ModelState.IsValid)
            {
                await _normaInternaService.Adicionar(_mapper.Map<NormaInterna>(normaInterna));

                return RedirectToAction(nameof(Index));
            }
            return View(normaInterna);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var normasAtualizar = _mapper.Map<NormaInternaViewModel>(await _normaInternaRepository.ObterPorId(id));

            if (normasAtualizar == null) return NotFound();

            return View(normasAtualizar);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, NormaInternaViewModel normas)
        {
            if (id != normas.Id) return NotFound();

            var normaAtualizacao = await _normaInternaRepository.ObterPorId(id);

            normaAtualizacao.Codigo = normas.Codigo;
            normaAtualizacao.Titulo = normas.Titulo;
            normaAtualizacao.Autor = normas.Autor;
            normaAtualizacao.TipoNorma = (int)normas.TipoNorma;
            normaAtualizacao.Ativo = normas.Ativo;

            if (!ModelState.IsValid) return View(normaAtualizacao);

            await _normaInternaService.Atualizar(normaAtualizacao);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var normaInternaDetalhe = _mapper.Map<NormaInternaViewModel>(await _normaInternaRepository.ObterPorId(id));

            if (normaInternaDetalhe == null) return NotFound();

            return View(normaInternaDetalhe);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<JsonResult> Delete(string id)
        {
            string idString = id.Split(' ').FirstOrDefault();

            if (Guid.TryParse(idString, out Guid idGuid))
            {
                var normaDeletar = await _normaInternaRepository.ObterPorId(idGuid);
                await _normaInternaService.Remover(_mapper.Map<NormaInterna>(normaDeletar));
            }
            else
                return null;

            return Json(null);
        }

        #endregion

        #region Métodos privados

        public async Task<IEnumerable<NormaInternaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<NormaInternaViewModel>>(await _normaInternaRepository.ObterTodos());
        }

        #endregion
    }
}
