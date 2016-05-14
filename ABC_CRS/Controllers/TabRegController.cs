using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABC_CRS.Controllers
{
    public class TabRegController : Controller
    {

        private ABC_CRSEntities2 db = new ABC_CRSEntities2();


        // GET: TabReg
        public ActionResult Index()
        {
            return View();
        }

        public  class TestModel
        {
            public CompanyHR companyHR { get; set; }
            public Company company { get; set; }

            public Participant participant { get; set; }

        }


    }
}