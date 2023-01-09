using FI.AtividadeEntrevista.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAtividadeEntrevista.Models.Validations
{
    public class CpfReplicadoValidationAttirbute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return CpfIsReplicado(value.ToString());
        }

        private bool CpfIsReplicado(string cpf)
        {
            BoCliente bo = new BoCliente();
            return !bo.VerificarExistencia(cpf);
        }
    }
}