using ClientManager.Core;
using System;
using System.Web.Mvc;

namespace ClientManager.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportsController(IUnitOfWork unitOfWork)
        {
            ViewBag.Title = "Relatório de Clientes";
            _unitOfWork = unitOfWork;
        }

        // GET: Reports
        public ActionResult Index(string creationDate = "", string name = "", string birthDate = "")
        {
            try
            {
                var res = _unitOfWork.Reports.GetFilteredResults(creationDate, name, birthDate);
                return View("PeopleReportList", res);
            }
            catch (Exception e)
            {
                if (e.Message == "String was not recognized as a valid DateTime.")
                {
                    TempData["error"] = "Datas devem estar no formato dd-mm-aaaa!";
                }
                else
                {
                    TempData["warning"] = "Houve algum erro inesperado!";
                }

                return View("PeopleReportList", _unitOfWork.People.GetAll());
            }




        }
    }
}
