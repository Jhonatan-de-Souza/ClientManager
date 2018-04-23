using ClientManager.Core.Domain;
using System.Collections.Generic;

namespace ClientManager.Core.Repositories
{
    public interface IReportRepository : IRepository<Person>
    {
        IEnumerable<Person> GetFilteredResults(string creationDate = "", string name = "", string birthDate = "");
    }
}