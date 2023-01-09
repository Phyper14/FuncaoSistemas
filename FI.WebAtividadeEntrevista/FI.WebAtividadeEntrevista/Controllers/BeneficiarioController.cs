using FI.AtividadeEntrevista.BLL;
using WebAtividadeEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FI.AtividadeEntrevista.DML;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        private List<BeneficiarioModel> Beneficiarios = new List<BeneficiarioModel>();

        [HttpPost]
        public JsonResult Incluir(BeneficiarioModel model)
        {
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                Beneficiarios.Add(model);
                return Json("Cadastro efetuado com sucesso");
            }
        }

        [HttpPost]
        public JsonResult Alterar(BeneficiarioModel model)
        {
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                var beneficiarioAntigo = Beneficiarios.Find(x => x.Id == model.Id);
                beneficiarioAntigo.CPF = model.CPF;
                beneficiarioAntigo.Nome = model.Nome;
                beneficiarioAntigo.IdCliente = model.IdCliente;
                return Json("Cadastro alterado com sucesso");
            }
        }
        [HttpPost]
        public JsonResult BeneficiarioList()
        {
            try
            {
               //Return result to jTable
                return Json(new { Result = "OK", Records = Beneficiarios, TotalRecordCount = Beneficiarios.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}