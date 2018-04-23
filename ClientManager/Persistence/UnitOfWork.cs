using ClientManager.Core;
using ClientManager.Core.Repositories;
using ClientManager.Persistence.Repositories;

namespace ClientManager.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        //here the unit of work will instaniate the repositories and use it across all of the application
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            People = new PersonRepository(_context);
            Reports = new ReportRepository(_context);

        }
        //The repositories used in the application must be set here
        public IPersonRepository People { get; private set; }
        public IReportRepository Reports { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {

            _context.Dispose();
        }

    }
}