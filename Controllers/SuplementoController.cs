using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using NatuViva.Data;
using NatuViva.Models;

namespace NatuViva.Controllers
{
    public class SuplementoController : Controller
    {
        private readonly AppDbContext _context;
        public SuplementoController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult ListarSuplementos()
        {
            var suplementos = _context.Suplementos.ToList();
            return View("Suplementos", suplementos);
        }

        [HttpGet]
        public IActionResult CadastrarSuplemento()
        {
            return View("CadastrarSuplementos");
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarSuplemento(Suplemento suplemento)
        {

            if (ModelState.IsValid)
            {
                var novoProduto = new Suplemento()
                {
                    Nome = suplemento.Nome,
                    Beneficios = suplemento.Beneficios,
                    ImagemUrl = suplemento.ImagemUrl,
                    Preco = suplemento.Preco
                };

                await _context.Suplementos.AddAsync(novoProduto);
                await _context.SaveChangesAsync();
            }
            ;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EditarSuplementos()
        {
            var suplementos = await _context.Suplementos.ToListAsync();

            return View(suplementos);
        }

        [HttpGet]
        public async Task<IActionResult> ExibirFormularioEdicao(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var produto = await _context.Suplementos.FirstOrDefaultAsync(s => s.SuplementoId == id);

            return View(produto);
        }

        [HttpPost]

        public async Task<IActionResult> Editar(Suplemento suplemento)
        {
            if (ModelState.IsValid)
            {
                var suplementoRecebido = await _context.Suplementos.FirstOrDefaultAsync(s => s.SuplementoId == suplemento.SuplementoId);
                if (suplementoRecebido == null)
                {
                    return NotFound("Produto não encontrado!");
                }

                suplementoRecebido.Nome = suplemento.Nome;
                suplementoRecebido.ImagemUrl = suplemento.ImagemUrl;
                suplementoRecebido.Beneficios = suplemento.Beneficios;
                suplementoRecebido.Preco = suplemento.Preco;


                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");


            }

            return View(suplemento);
        }
        // METODO DE EXCLUSÃO
        [HttpGet]
        public async Task<IActionResult>ConfirmarExclusao(int id)
        {
            var produto = await _context.Suplementos.FirstOrDefaultAsync(s => s.SuplementoId == id);
            if (produto == null)
                return NotFound("Produto não encontrado");

           
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var paraExcluir = await _context.Suplementos.FirstOrDefaultAsync(s => s.SuplementoId == id);

            if (paraExcluir == null)
                return NotFound("Produto não encontrado!");

             _context.Remove(paraExcluir);
           await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Cancelar()
        {
            return RedirectToAction("index", "home");
        }



    }




}




