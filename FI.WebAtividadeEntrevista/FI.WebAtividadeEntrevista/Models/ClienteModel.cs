﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAtividadeEntrevista.Models.Validations;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Cliente
    /// </summary>
    public class ClienteModel
    {
        public long Id { get; set; }
        
        /// <summary>
        /// CEP
        /// </summary>
        [Required]
        public string CEP { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [Required]
        public string Cidade { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [Required]
        [CpfValidation(ErrorMessage = "Insira um CPF válido")]
        [CpfReplicadoValidationAttirbute(ErrorMessage = "O CPF inserido já está cadastrado")]
        [RegularExpression(@"([0-9]{3}[\.][0-9]{3}[\.][0-9]{3}[\-][0-9]{2})", ErrorMessage = "Digite o cpf conforme o exemplo, por favor")]
        public string CPF { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        [Required]
        public string Logradouro { get; set; }

        /// <summary>
        /// Nacionalidade
        /// </summary>
        [Required]
        public string Nacionalidade { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome
        /// </summary>
        [Required]
        public string Sobrenome { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone { get; set; }

    }    
}