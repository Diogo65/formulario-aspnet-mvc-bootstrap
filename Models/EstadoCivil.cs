using System.ComponentModel.DataAnnotations;

namespace FormularioAspNetMvc.Models
{
    public enum EstadoCivil
    {
        [Display(Name = "Solteiro(a)")]
        Solteiro,
        [Display(Name = "Casado(a)")]
        Casado,
        [Display(Name = "Divorciado(a)")]
        Divorciado,
        [Display(Name = "Viúvo(a)")]
        Viuvo,
        [Display(Name = "Separado(a)")]
        Separado
    }
}