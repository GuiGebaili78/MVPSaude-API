using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Api.MVPSaude.Model
{
    [Table("PRONTUARIO")]
    public class ProntuarioModel
    {
        [HiddenInput]
        [Key]
        [Column("PRONTUARIOID")]
        public int ProntuarioId { get; set; }


        [Display(Name = "Paciente")]
        [Column("PACIENTEID")]
        public int PacienteId { get; set; }
        public PacienteModel? Paciente { get; set; }



        [Column("HISTORICOPACIENTE")]
        [StringLength(4000, MinimumLength = 2, ErrorMessage = "O histórico médico deve ter, no mínimo, 2 e, no máximo, 4000 caracteres")]
        [Display(Name = "Histórico Paciente")]
        public string? HistPaciente { get; set; }


        [Column("MEDICAMENTO")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "O campo medicamento deve ter, no mínimo, 2 e, no máximo, 1000 caracteres")]
        [Display(Name = "Medicamentos")]
        public string? Medicamento { get; set; }


        [Column("TRIAGEM")]
        [Required(ErrorMessage = "Triagem é obrigatória!")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "O campo triagem deve ter, no mínimo, 1 e, no máximo, 1000 caracteres")]
        [Display(Name = "Triagem")]
        public string? Triagem { get; set; }


        [Column("HISTORICOFAMILIAR")]
        [StringLength(2000, MinimumLength = 1, ErrorMessage = "O histórico familiar deve ter, no mínimo, 1 e, no máximo, 2000 caracteres")]
        [Display(Name = "Histórico Familiar")]
        public string? HistFamiliar { get; set; }

        [Column("EXAMES")]
        [StringLength(4000, MinimumLength = 1, ErrorMessage = "O campo exames deve ter, no mínimo, 1 e, no máximo, 4000 caracteres")]
        [Display(Name = "Exames e Laudos")]
        public string? Exames { get; set; }

        [Display(Name = "Data do Prontuário")]
        [Required(ErrorMessage = "Data do Prontuário é obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "Data do Prontuário incorreta")]
        [Column("DATAPRONTUARIO")]
        public DateTime DataProntuario { get; set; }

        [Display(Name = "Médico")]
        [Column("MEDICOID")]        
        public int MedicoId { get; set; }
        public MedicoModel? Medico { get; set; }

        public ProntuarioModel()
        {
        }

        public ProntuarioModel(int prontuarioId, int pacienteId, PacienteModel? paciente, string? histPaciente, string? medicamento, string? triagem, string? histFamiliar, string? exames, DateTime dataProntuario, int medicoId, MedicoModel? medico)
        {
            ProntuarioId = prontuarioId;
            PacienteId = pacienteId;
            Paciente = paciente;
            HistPaciente = histPaciente;
            Medicamento = medicamento;
            Triagem = triagem;
            HistFamiliar = histFamiliar;
            Exames = exames;
            DataProntuario = dataProntuario;
            MedicoId = medicoId;
            Medico = medico;
        }
    }
}
