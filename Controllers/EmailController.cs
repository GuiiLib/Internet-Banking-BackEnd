using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InternetBanking.Models;
using InternetBanking.Repositorio;
using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;



namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class EmailController : Controller
    {



        // private readonly IFamiliaresRepositorio _FamiliaresRepositorio;
        // public FamiliaresController(IFamiliaresRepositorio familiaresRepo)
        // {
        //     _FamiliaresRepositorio = familiaresRepo;
        // }

        // [HttpGet]
        // public IEnumerable<Familiares> GetAll()
        // {
        //     return _FamiliaresRepositorio.GetAll();
        // }

        // [HttpGet("{fam}", Name = "GetFamiliares")]
        // public IActionResult GetByFamiliares(int fam)
        // {
        //     var familiares = _FamiliaresRepositorio.FindByFam(fam);
        //     if (familiares == null) return NotFound();
        //     return new ObjectResult(familiares);
        // }

        [HttpPost]
        public IActionResult Create()
        {
           Execute().Wait();
            return new NoContentResult();
        }

        static async Task Execute(){
            
            
            var apiKey = Environment.GetEnvironmentVariable("TESTEIBENVIAR");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("liberalino50@gmail.com", "Guilherme");
            var to = new EmailAddress("liberalino50@gmail.com", "Guilherme");
            var subject = "Abra o email urgente";
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>Lucas o  email ta indo</strong>";
            var msg = MailHelper.CreateSingleEmail(from,to,subject,plainTextContent,htmlContent);

            var response = await client.SendEmailAsync(msg);
        }

        // [HttpPut("{cpf}")]
        // public IActionResult Update([FromBody] Familiares familiares, string cpf)
        // {
        //     if (familiares == null) return NotFound();

        //     int idCliente = _FamiliaresRepositorio.FindByIdCliente(cpf);
        //     var _familiares = _FamiliaresRepositorio.FindByFam(idCliente);

        //     _FamiliaresRepositorio.Update(familiares,_familiares);
        //     return new NoContentResult();
        // }
    }
}