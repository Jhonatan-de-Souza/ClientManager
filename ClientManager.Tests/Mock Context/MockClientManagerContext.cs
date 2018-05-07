using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using ClientManager.Core.Domain;

namespace ClientManager.Tests.Mock_Context
{
    public class MockClientManagerContext
    {
        public List<Person> People
        {
            get
            {
                return new List<Person>
                {
                    new Person
                    {
                        Id = 1,
                        Birthdate = Convert.ToDateTime("05/05/1990"),
                        Name = "Person1",
                        Uf = "MG",
                        CreationDate = Convert.ToDateTime("05/05/2018"),
                        Rg = "MG18008215",
                        Cpf = "071569485",
                        CreatedBy = "Administrator",
                        Deleted = false,
                        LastUpdateDate = Convert.ToDateTime("01/01/2018"),
                        LastUpdatedBy = "Administrator",
                        Phonenumber = "9855124589"

                    },
                    new Person
                    {
                        Id = 2,
                        Birthdate = Convert.ToDateTime("05/05/1990"),
                        Name = "Person2",
                        Uf = "MG",
                        CreationDate = Convert.ToDateTime("05/05/2018"),
                        Rg = "MG18008215",
                        Cpf = "071569485",
                        CreatedBy = "Administrator",
                        Deleted = false,
                        LastUpdateDate = Convert.ToDateTime("01/01/2018"),
                        LastUpdatedBy = "Administrator",
                        Phonenumber = "9855124589"

                    },
                    new Person
                    {
                        Id = 3,
                        Birthdate = Convert.ToDateTime("05/05/1990"),
                        Name = "Person3",
                        Uf = "MG",
                        CreationDate = Convert.ToDateTime("05/05/2018"),
                        Rg = "MG18008215",
                        Cpf = "071569485",
                        CreatedBy = "Administrator",
                        Deleted = false,
                        LastUpdateDate = Convert.ToDateTime("01/01/2018"),
                        LastUpdatedBy = "Administrator",
                        Phonenumber = "9855124589"

                    }
                };
            }
        }

    }

}
