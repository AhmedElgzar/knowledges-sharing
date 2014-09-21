using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yInvoice.Domain.Entities;
using yInvoice.Domain.Repositories;
using yInvoice.Web.Filters;
using yInvoice.Web.Models;

namespace yInvoice.Web.Controllers
{
    public class UserController : Controller
    {
        IUserRepository _users;
        IUnitOfWork _unitOfWork;
        public UserController(IUserRepository users, IUnitOfWork unitOfWork)
        {
            _users = users;
            _unitOfWork = unitOfWork;
        }

        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        public ActionResult Index()
        {
            //we have single company for now
            return View(_users.GetAll().Where(c => c.CompanyID == 1).ToList());
        }
        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        public ActionResult Create()
        {
            return View(new UserEditModel());
        }
        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        [HttpPost]
        public ActionResult Create(UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                model.CompanyID = 1;
                Mapper.CreateMap<UserEditModel, User>();
                var dbModel = Mapper.Map<User>(model);
                _users.Add(dbModel);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        public ActionResult Edit(int id)
        {
            var dbModel = _users.GetById(id);
            Mapper.CreateMap<User, UserEditModel>();
            var model = Mapper.Map<UserEditModel>(dbModel);
            return View(model);
        }

        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        [HttpPost]
        public ActionResult Edit(int id, UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                model.CompanyID = 1;
                Mapper.CreateMap<UserEditModel, User>();
                var dbModel = Mapper.Map<User>(model);
                _users.Update(dbModel);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        public ActionResult Delete(int id)
        {
            _users.RemoveById(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
	}
}