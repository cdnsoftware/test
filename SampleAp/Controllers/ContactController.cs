using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleAp.Data.Entities;
using SampleApCore.Interfaces;
using SampleApCore.ViewModels;

namespace SampleAp.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactUs contact;
        private readonly ICommon common;

        public ContactController(IContactUs _contact, ICommon _common)
        {
            contact = _contact;
            common = _common;
        }

        public ActionResult ExceptionTest()
        {
            // on exception will be redirected to base controller OnException Action
            
            throw new InvalidOperationException("Something went wrong");
        }

       
        
        /// <summary>
      /// Method : GET hold the partial view to display all the contacts
      /// </summary>
      /// <returns></returns>
      /// 
        public ActionResult Index(bool check = false)
        {
            if (!check)
                TempData["Msg"] = "";
            return View();
        }

        /// <summary>
        /// Method : GET - Partial view to show list will get all the available contacts into the database
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ContactList()
        {
            try
            {
                var lst = contact.GetAllNewTestContacts();
                return PartialView(lst);
            }
            catch
            {
                return PartialView(new List<SampleAp.Data.Entities.Contact>());
            }
        }
        /// <summary>
        /// GET method which intialize the model for the new contact. Too will load the details of the conatct if PK Id > 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CreateContact(int id = 0)
        {
            Contact model = new Contact();
            model.MasterDisplayAsId = 2; //as default 
            ViewBag.DisplayAs = new SelectList(common.GetAllDisplayFormats(), "Id", "DisplayAs");
            
            if (id > 0)
            {
                try
                {
                    model = contact.GetAllContacts(id).FirstOrDefault();
                }
                catch (Exception ex)
                {

                }
            }
            return PartialView(model);
        }
        /// <summary>
        /// Same method will insert the new record if PK Id = 0 and will update if PK Id > 0
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContact(Contact model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = contact.CreateContact(model);
                    TempData["Msg"] = result.Message;
                }
                catch (Exception)
                {

                    TempData["Msg"] = "Contact not created.try again!";
                }
                return RedirectToAction("Index", new { @check = true });
            }
            return RedirectToAction("Index");
           
        }

        /// <summary>
        /// This method will hard delete the record from table for the matching id after confirm box. NOTE: we can have soft delete too by maitaining IdDelete bool flag
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteContact(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = contact.DeleteContact(id);
                    TempData["Msg"] = result.Message;
                }
                else
                {
                    TempData["Msg"] = "Some error occurred. Try again";
                }
            }
            catch (Exception)
            {
                TempData["Msg"] = "Some error occurred. Try again";
            }
            return RedirectToAction("Index", new { @check = true });
        }


    }
}
