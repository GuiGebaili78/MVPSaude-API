using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Api.MVPSaude.Model
{

    [Table("MEDICO")]
    public class MedicoModel
    {
        [HiddenInput]
        [Key]
        [Column("MEDICOID")]
        public int MedicoId { get; set; }

        [Column("NOMEMEDICO")]
        [Required(ErrorMessage = "Nome do médico é obrigatório!")]
        [StringLength(80,
            MinimumLength = 2,
            ErrorMessage = "O nome deve ter, no mínimo, 2 e, no máximo, 80 caracteres")]
        [Display(Name = "Nome do Médico")]
        public string? NomeMedico { get; set; }

        [Column("CRM")]
        [Required(ErrorMessage = "CRM é obrigatório!")]
        [Display(Name = "CRM")]
        public string? Crm { get; set; }

       
        [Column("ESPECIALIDADE")]
        [Required(ErrorMessage = "Especialidade é obrigatório!")]
        [StringLength(100,
          MinimumLength = 1,
          ErrorMessage = "A especialidade deve ter, no mínimo, 1 e, no máximo, 100 caracteres")]
        [Display(Name = "Especialidade")]
        public string? Especialidade { get; set; }

       
        [Column("CONTATO")]
        [StringLength(200,
          MinimumLength = 1,
          ErrorMessage = "O contato deve ter, no mínimo, 1 e, no máximo, 200 caracteres")]
        [Display(Name = "Contato")]
        public string? Contato { get; set; }






        public MedicoModel()
        {

        }

        public MedicoModel(int medicoId, string? nomeMedico)
        {
            MedicoId = medicoId;
            NomeMedico = nomeMedico;
        }
    }
}