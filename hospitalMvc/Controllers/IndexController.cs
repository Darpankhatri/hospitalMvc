using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using hospitalMvc.Models;
using Newtonsoft.Json;

namespace hospitalMvc.Controllers
{
    public class IndexController : Controller
    {
        string Baseurl = "http://127.0.0.1:8000/";
        static Token t1 = new Token();
        
        // GET: Index
        public ActionResult Index()
        {
            ViewBag.token = t1.access_token;
            return View();
        }
        public ActionResult About()
        {
            ViewBag.token = t1.access_token;
            return View();
        }
        public ActionResult Cart()
        {

            ViewBag.token = t1.access_token;
            try
            {
                if(t1.access_token == "0")
                {
                    return RedirectToAction("User_Login");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Contact()
        {
            ViewBag.token = t1.access_token;
            return View();
        }
        public ActionResult Product()
        {
            ViewBag.token = t1.access_token;
            return View();
        }

        public ActionResult Product_detail()
        {
            ViewBag.token = t1.access_token;
            return View();
        }
        public ActionResult User_Login()
        {
            ViewBag.token = t1.access_token;
            try
            {
                if (t1.access_token != "0")
                {
                    return RedirectToAction("Index");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login_pro(string id, string val1)
        {
            t1.access_token = val1;
            ViewBag.token = val1;
            ViewBag.id = id;
            //return View();
            return RedirectToAction("Index");

        }

        public ActionResult User_register()
        {
            ViewBag.token = t1.access_token;
            try
            {
                if (t1.access_token != "0")
                {
                    return RedirectToAction("Index");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Checkout()
        {
            ViewBag.token = t1.access_token;
            try
            {
                if (t1.access_token == "0")
                {
                    return RedirectToAction("User_Login");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Checkd()
        {
            List<User> userd = new List<User>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/check-api");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    userd = JsonConvert.DeserializeObject<List<User>>(EmpResponse);
                }
                return View(userd);
            }


        }

    }
}