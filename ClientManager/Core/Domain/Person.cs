using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ClientManager.Core.Domain
{
    public class Person : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Favor preencher o nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Favor preencher o CPF")]
        public string Cpf { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Favor preencher o telefone")]
        public string Phonenumber { get; set; }
        [Required(ErrorMessage = "Favor selecionar a UF")]
        public string Uf{ get; set; }
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