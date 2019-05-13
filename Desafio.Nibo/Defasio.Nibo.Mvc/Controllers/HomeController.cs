using Defasio.Nibo.Application.UseCases.ExcluirTransacoes;
using Defasio.Nibo.Application.UseCases.GetTransacoes;
using Defasio.Nibo.Application.UseCases.ImportOfx;
using Defasio.Nibo.Application.UseCases.Upload;
using Defasio.Nibo.Mvc.Models;
using Desafio.Nibo.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Defasio.Nibo.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private IUploadFile _uploadFile;
        private IImportOfxFile _importoOfxFile;
        private IGetTransacoesUseCase _getTransacoesUseCase;
        private IExcluirTransacoesUseCase _excluirTransacoesUseCase;

        public HomeController(IUploadFile uploadFile, 
            IImportOfxFile importOfxFile, 
            IGetTransacoesUseCase getTransacoesUseCase,
            IExcluirTransacoesUseCase excluirTransacoesUseCase)
        {
            this._uploadFile = uploadFile;
            this._importoOfxFile = importOfxFile;
            this._getTransacoesUseCase = getTransacoesUseCase;
            this._excluirTransacoesUseCase = excluirTransacoesUseCase;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase[] files)
        {
                       
            if (ModelState.IsValid)
            {
                
                var ofxFile = _uploadFile.Upload(files, Server.MapPath("~/OfxFiles/"));

                var transacoes = _importoOfxFile.ImportWithMerge(ofxFile);

                return View("ImportedOfx", transacoes);
            }

            return View("ImportedOfx", new List<TransacaoModel>());

        }

        [HttpPost]
        public ActionResult Excluir()
        {
            this._excluirTransacoesUseCase.ExcluirTodos();

            return View("Index");

        }

        public ActionResult ImportedOfx()
        {
            return View();
        }

        public ActionResult Extrato()
        {

            var extrato = _getTransacoesUseCase.GetTransacoes();
            return View("ImportedOfx", extrato);
        }


    }
}