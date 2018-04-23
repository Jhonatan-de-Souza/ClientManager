using ClientManager.Core;
using ClientManager.Core.Domain;
using ClientManager.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Web.Mvc;

namespace ClientManager.Controllers
{
    public class PersonController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        private string GetUserName()
        {
            return User.Identity.GetUserName();
        }
        private static int GetAge(DateTime bday)
        {
            DateTime reference = DateTime.Now;
            DateTime birthday = bday;
            int age = reference.Year - birthday.Year;
            if (reference < birthday.AddYears(age)) age--;

            return age;
        }
        // GET: Person
        public ActionResult Index()
        {
            return View("PeopleList", _unitOfWork.People.GetAll());
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            var viewModel = new PersonViewModel();
            ViewBag.Title = "Cadastro de Pessoa";
            return View("PersonEditForm", viewModel);
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!IsValidPerson(viewModel))
                    {
                        return View("PersonEditForm", viewModel);
                    }

                    var mappedPerson = AutoMapper.Mapper.Map<PersonViewModel, Person>(viewModel);

                    mappedPerson.CreationDate = DateTime.Now;
                    mappedPerson.Deleted = false;
                    mappedPerson.CreatedBy = GetUserName();

                    TempData["success"] = "Cliente cadastrado com sucesso!";

                    _unitOfWork.People.Add(mappedPerson);
                    _unitOfWork.Complete();

                    return RedirectToAction("Index");
                }
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
                return View("PersonEditForm", viewModel);
            }


            return RedirectToAction("Index");
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person person = _unitOfWork.People.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            var mappedPerson = AutoMapper.Mapper.Map<Person, PersonViewModel>(person);

            ViewBag.Title = "Alteração de Cadastro";
            return View("PersonEditForm", mappedPerson);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!IsValidPerson(viewModel))
                    {
                        return View("PersonEditForm", viewModel);
                    }
                    var mappedPerson = AutoMapper.Mapper.Map<PersonViewModel, Person>(viewModel);

                    mappedPerson.CreationDate = DateTime.Now;
                    mappedPerson.Deleted = false;
                    mappedPerson.LastUpdatedBy = GetUserName();
                    mappedPerson.LastUpdateDate = DateTime.Now;

                    TempData["success"] = "Client cadastrado com sucesso!";

                    _unitOfWork.People.Add(mappedPerson);
                    _unitOfWork.Complete();

                    return RedirectToAction("Index");
                }
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
                return View("PersonEditForm", viewModel);
            }


            return RedirectToAction("Index");
        }
        // POST: Person/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Person person = _unitOfWork.People.GetById(id);

            _unitOfWork.People.Remove(person);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }


        private bool IsValidPerson(PersonViewModel viewModel)
        {
            int age = GetAge(viewModel.Birthdate);
            //Caso algum usuário mal intencionado consiga passar a validação Client-Side
            if (viewModel.Uf == "SC" && (viewModel.Rg == null || string.IsNullOrEmpty(viewModel.Rg)))
            {
                string errMgs = "Cadastro de RG obrigatório para clientes de Santa Catarina.";
                ModelState.AddModelError("Erro", errMgs);
                ViewBag.Title = "Cadastro de Pessoa";
                TempData["warning"] = "Favor corrigir os erros descritos";
                return false;
            }
            if (viewModel.Uf == "PR" && age <= 18)
            {
                string errMgs = "Somente clientes maiores de 18 anos do Paraná podem ser cadastrados no sistema.";
                ModelState.AddModelError("Erro", errMgs);
                ViewBag.Title = "Cadastro de Pessoa";
                TempData["warning"] = "Favor corrigir os erros descritos";
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
