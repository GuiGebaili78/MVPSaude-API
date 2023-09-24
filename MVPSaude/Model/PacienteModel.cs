using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Api.MVPSaude.Model
{

    [Table("PACIENTE")]
    public class PacienteModel
    {
        [HiddenInput]
        [Key]
        [Column("PACIENTEID")]
        public int PacienteId { get; set; }

        [Column("NOMEPACIENTE")]
        [Required(ErrorMessage = "Nome do paciente é obrigatório!")]
        [StringLength(80,
            MinimumLength = 2,
            ErrorMessage = "O nome deve ter, no mínimo, 2 e, no máximo, 80 caracteres")]
        [Display(Name = "Nome do Paciente")]
        public string? NomePaciente { get; set; }

        [Column("CPF")]
        [Required(ErrorMessage = "CPF é obrigatório!")]
        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento incorreta")]
        [Column("DATANASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("GENERO")]
        [Required(ErrorMessage = "Gênero é obrigatório!")]
        [StringLength(50,
          MinimumLength = 1,
          ErrorMessage = "O gênero deve ter, no mínimo, 1 e, no máximo, 50 caracteres")]
        [Display(Name = "Gênero")]
        public string? Genero { get; set; }

        [Column("ENDERECO")]
        [StringLength(200,
          MinimumLength = 1,
          ErrorMessage = "O endereço deve ter, no mínimo, 1 e, no máximo, 150 caracteres")]
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }

        [Column("CONTATO")]
        [StringLength(200,
          MinimumLength = 1,
          ErrorMessage = "O contato deve ter, no mínimo, 1 e, no máximo, 200 caracteres")]
        [Display(Name = "Contato")]
        public string? Contato { get; set; }


       



        public PacienteModel()
        {

        }

        public PacienteModel(int pacienteId, string nomePaciente)
        {
            PacienteId = pacienteId;
            NomePaciente = nomePaciente;
        }

       
    }
}