using ClientManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ClientManager.ViewModels
{
    public class PersonViewModel : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor preencher o nome")]
        [StringLength(255, ErrorMessage = "o Campo nome pode conter até 255 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Favor preencher o CPF")]
        [StringLength(25, ErrorMessage = "o Campo cpf pode conter até 25 caracteres")]
        public string Cpf { get; set; }

        [StringLength(255, ErrorMessage = "o Campo RG pode conter até 255 caracteres")]
        public string Rg { get; set; }


        [Display(Name = "Data De Nascimento")]
        [Required(ErrorMessage = "Favor inserir a data de nascimento")]
        [Column(TypeName = "datetime2")]
        [Range(typeof(DateTime), "01/01/1753", "01/01/2999", ErrorMessage = "A data para {0} deve ser entre de mínimo {1} até {2}")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Favor preencher o telefone")]
        public string Phonenumber { get; set; }

        [Required(ErrorMessage = "Favor selecionar a UF")]
        public string Uf { get; set; }

        public IEnumerable<SelectListItem> UfList
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text="Paraná", Value="PR"},
                    new SelectListItem { Text="Santa Catarina", Value="SC"},
                };
            }
        }
    }
}