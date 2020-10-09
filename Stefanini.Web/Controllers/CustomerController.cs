using Stefanini.Application;
using Stefanini.Domain.Repository;
using Stefanini.Repository.SqlServer;
using Stefanini.Utils;
using Stefanini.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stefanini.Web.Controllers
{
    public class CustomerController : Controller
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["connectionStr"].ToString();

        [Authorize]
        public ActionResult Index()
        {
            LoadDropDownFiltersBag();

            return RedirectToAction("Search", new { name = string.Empty,
                                                    gender = string.Empty,
                                                    city = string.Empty,
                                                    region = string.Empty,
                                                    purchaseFrom = string.Empty,
                                                    purchaseUntil = string.Empty,
                                                    classification = string.Empty,
                                                    seller = string.Empty });
        }

        public ActionResult Search(string name, string gender, string city, string region, string purchaseFrom, string purchaseUntil, string classification, string seller)
        {
            LoadDropDownFiltersBag();

            ICustomerRepository customerRepository = new CustomerRepository(_connectionString);
            var customerApp = new CustomerApplication(customerRepository);

            if (Session["userIsAdmin"] != null && !Convert.ToBoolean(Session["userIsAdmin"].ToString())
               && Session["userId"] != null)
            {
                seller = Session["userId"].ToString();
            }

            return View("Index", customerApp
                .SearchCustomers(name, gender.ToInt32(), city.ToInt32(), region.ToInt32(), purchaseFrom.ToDateTime(), purchaseUntil.ToDateTime(), classification.ToInt32(), seller.ToInt32())
                .Select(c => CustomerEntityToModel(c)));
        }

        [NonAction]
        public Customer CustomerEntityToModel(Domain.Entity.Customer customerEntity)
        {
            return new Customer()
            {
                City = customerEntity.City.Name,
                Classification = customerEntity.Classification.Name,
                Gender = customerEntity.Gender.Name,
                LastPurchase = customerEntity.LastPurchase.ToString("dd/MM/yyyy"),
                Name = customerEntity.Name,
                Phone = customerEntity.Phone,
                Region = customerEntity.Region.Name,
                Seller = customerEntity.User.Login
            };
        }

        public void LoadDropDownFiltersBag()
        {
            IGenderRepository genderRepository = new GenderRepository(_connectionString);
            var genderApp = new GenderApplication(genderRepository);

            ViewBag.Genders = genderApp.GetAll().Select(g => new SelectListItem()
            {
                Text = g.Name,
                Value = g.Id.ToString()
            }).ToList();

            ICityRepository cityRepository = new CityRepository(_connectionString);
            var cityApp = new CityApplication(cityRepository);

            ViewBag.Cities = cityApp.GetAll().Select(g => new SelectListItem()
            {
                Text = g.Name,
                Value = g.Id.ToString()
            }).ToList();

            IRegionRepository regionRepository = new RegionRepository(_connectionString);
            var regionApp = new RegionApplication(regionRepository);

            ViewBag.Regions = regionApp.GetAll().Select(g => new SelectListItem()
            {
                Text = g.Name,
                Value = g.Id.ToString()
            }).ToList();

            IClassificationRepository classificationRepository = new ClassificationRepository(_connectionString);
            var classificationApp = new ClassificationApplication(classificationRepository);

            ViewBag.Classifications = classificationApp.GetAll().Select(g => new SelectListItem()
            {
                Text = g.Name,
                Value = g.Id.ToString()
            }).ToList();

            IUserSysRepository userRepository = new UserSysRepository(_connectionString);
            var userApp = new UserApplication(userRepository);

            ViewBag.Sellers = userApp.GetAll().Select(g => new SelectListItem()
            {
                Text = g.Login,
                Value = g.Id.ToString()
            }).ToList();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadRegionByCity(string cityId)
        {
            if (!string.IsNullOrWhiteSpace(cityId))
            {
                ICityRepository cityRepository = new CityRepository(_connectionString);
                var cityApp = new CityApplication(cityRepository);

                var regionList = cityApp.GetAll();

                regionList = regionList.Where(c => c.Id == cityId.ToInt32());

                var regionData = regionList.Select(r => new SelectListItem()
                {
                    Text = r.Region.Name,
                    Value = r.Region.Id.ToString(),
                });

                return Json(regionData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                IRegionRepository regionRepository = new RegionRepository(_connectionString);
                var regionApp = new RegionApplication(regionRepository);

                var regionData = regionApp.GetAll().Select(g => new SelectListItem()
                {
                    Text = g.Name,
                    Value = g.Id.ToString()
                }).ToList();

                return Json(regionData, JsonRequestBehavior.AllowGet);
            }
        }
    }
}