using ClientManager.Core.Domain;
using ClientManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClientManager.Persistence.Repositories
{
    public class ReportRepository : Repository<Person>, IReportRepository
    {

        private DateTime _convertedBirthdate;
        private DateTime _convertedCreationDate;
        public ReportRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }


        public IEnumerable<Person> GetFilteredResults(string creationDate = "", string name = "", string birthDate = "")
        {
            try
            {
                //Aplicando filtragem múltipla
                if (!string.IsNullOrEmpty(birthDate) && !string.IsNullOrEmpty(name) &&
                    !string.IsNullOrEmpty(creationDate))
                {
                    _convertedBirthdate = DateTime.Parse(birthDate);
                    _convertedCreationDate = DateTime.Parse(creationDate);
                    var filteredResult = Context.Person
                        .Where(x => x.Name.Contains(name))
                        .Where(x => x.Birthdate == _convertedBirthdate)
                        .Where(x => DbFunctions.TruncateTime(x.CreationDate) == _convertedCreationDate).ToList();
                    return filteredResult;
                }

                //Filtragens de duplas
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(birthDate))
                {
                    _convertedBirthdate = DateTime.Parse(birthDate);
                    var filteredResult = Context.Person
                        .Where(x => x.Name.Contains(name))
                        .Where(x => x.Birthdate == _convertedBirthdate).ToList();
                    return filteredResult;
                }

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(creationDate))
                {
                    _convertedCreationDate = DateTime.Parse(creationDate);
                    var filteredResult = Context.Person
                        .Where(x => x.Name.Contains(name))
                        .Where(x => DbFunctions.TruncateTime(x.CreationDate) == _convertedCreationDate).ToList();
                    return filteredResult;
                }

                if (!string.IsNullOrEmpty(birthDate) && !string.IsNullOrEmpty(name))
                {
                    _convertedBirthdate = DateTime.Parse(birthDate);
                    var filteredResult = Context.Person
                        .Where(x => x.Name.Contains(name))
                        .Where(x => x.Birthdate == _convertedBirthdate).ToList();
                    return filteredResult;
                }

                if (!string.IsNullOrEmpty(birthDate) && !string.IsNullOrEmpty(creationDate))
                {
                    _convertedBirthdate = DateTime.Parse(birthDate);
                    _convertedCreationDate = DateTime.Parse(creationDate);
                    var filteredResult = Context.Person
                        .Where(x => x.Birthdate == _convertedBirthdate)
                        .Where(x => DbFunctions.TruncateTime(x.CreationDate) == _convertedCreationDate).ToList();
                    return filteredResult;
                }

                //Filtragens Básicas
                if (!string.IsNullOrEmpty(creationDate))
                {
                    _convertedCreationDate = DateTime.Parse(creationDate);
                    var filteredResult = Context.Person
                        .Where(x => DbFunctions.TruncateTime(x.CreationDate) == _convertedCreationDate).ToList();
                    return filteredResult;
                }

                if (!string.IsNullOrEmpty(birthDate))
                {
                    _convertedBirthdate = DateTime.Parse(birthDate);
                    var filteredResult = Context.Person
                        .Where(x => x.Birthdate == _convertedBirthdate).ToList();
                    return filteredResult;
                }

                if (!string.IsNullOrEmpty(name))
                {
                    var filteredResult = Context.Person
                        .Where(x => x.Name.Contains(name)).ToList();
                    return filteredResult;
                }

                var unfilteredfilteredResultult = Context.Person.ToList();
                return unfilteredfilteredResultult;



            }
            catch (Exception e)
            {
                if (e.Message == "String was not recognized as a valid DateTime.")
                {
                    throw new Exception("String was not recognized as a valid DateTime.", e);
                }
                return Enumerable.Empty<Person>();
            }

        }


    }
}