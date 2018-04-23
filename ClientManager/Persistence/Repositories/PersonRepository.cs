using ClientManager.Core.Domain;
using ClientManager.Core.Repositories;
using ClientManager.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ClientManager.Persistence.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<Person> GetClientsByParams(PersonViewModel viewModel)
        {
            return Context.Person.Where(x => x.Deleted == false);
        }
    }
}