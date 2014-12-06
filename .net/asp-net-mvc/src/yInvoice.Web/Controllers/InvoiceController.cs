using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using yInvoice.Domain.Entities;
using yInvoice.Domain.Repositories;
using yInvoice.Web.Filters;
using yInvoice.Web.Models;

namespace yInvoice.Web.Controllers
{
    public class InvoiceController : Controller
    {
        IInvoiceRepository _invoices;
        IUnitOfWork _unitOfWork;
        public InvoiceController(IInvoiceRepository invoices, IUnitOfWork unitOfWork)
        {
            _invoices = invoices;
            _unitOfWork = unitOfWork;
        }
        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        public ActionResult Index()
        {
            //we have single company for now
            return View(_invoices.GetAll().Include(c=>c.Client).Where(c => c.CompanyID == 1).ToList());
        }
        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        public ActionResult Create()
        {
            return View(new InvoiceEditModel());
        }
        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        [HttpPost]
        public ActionResult Create(InvoiceEditModel model)
        {
            if (ModelState.IsValid)
            {
                model.CompanyID = 1;
                Mapper.CreateMap<InvoiceEditModel, Invoice>();
                var dbModel = Mapper.Map<Invoice>(model);
                _invoices.Add(dbModel);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        public ActionResult Edit(int id)
        {
            var dbModel = _invoices.GetById(id);
            Mapper.CreateMap<Invoice, InvoiceEditModel>();
            var model = Mapper.Map<InvoiceEditModel>(dbModel);
            return View(model);
        }

        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        [HttpPost]
        public ActionResult Edit(int id, InvoiceEditModel model)
        {
            if (ModelState.IsValid)
            {
                model.CompanyID = 1;
                Mapper.CreateMap<UserEditModel, Invoice>();
                var dbModel = Mapper.Map<Invoice>(model);
                _invoices.Update(dbModel);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [yInvoiceAuth(Roles = new UserRole[] { UserRole.Admin, UserRole.StaffMember })]
        public ActionResult Delete(int id)
        {
            _invoices.RemoveById(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
	}
}