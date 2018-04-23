using ClientManager.Core.Domain;
using ClientManager.ViewModels;
using System.Collections.Generic;

namespace ClientManager.Core.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetClientsByParams(PersonViewModel viewModel);
    }
}
