using MVCFrontendOfTh6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;



namespace MVCFrontendOfTh6.Controllers
{
    
    public class SanPhamController : Controller
    {
        private string uri = "https://localhost:44384/";
        // GET: SanPham
        public SanPhamController()
        {

        }
        public IEnumerable<DanhMuc> tatca() {
            List<DanhMuc> dm = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var respondtask = client.GetAsync("api/DanhMucs");
                respondtask.Wait();
                var rs = respondtask.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readtask = rs.Content.ReadAsAsync<List<DanhMuc>>();
                    readtask.Wait();
                    dm = readtask.Result;
                }
                else dm = null;
            }
            return dm;
        }
        public ActionResult Index()
        {
            List<SanPham> product=null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var respondtask = client.GetAsync("SanPhams/all");
                respondtask.Wait();
                var rs = respondtask.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readtask = rs.Content.ReadAsAsync<List<SanPham>>();
                    readtask.Wait();
                    product = readtask.Result;
                }
                else product = null;
            }
            return View(product);
        }
        
        // GET: SanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Getbymaloai( int id)
        {SanPham product=null;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(uri);
                var respondtask = client.GetAsync("SanPhams/by-ma-danh-muc/" + id);
                respondtask.Wait();
                var rs = respondtask.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readtask = rs.Content.ReadAsAsync<SanPham>();
                    readtask.Wait();
                    product = readtask.Result;
                }
                else product = null;
            }
            return View(product);
        }
        public ActionResult laygia(int gia)
        {
            var client = new HttpClient();
            List<SanPham> product;
            client.BaseAddress = new Uri(uri);
            var respondtask = client.GetAsync("SanPhams/by-price/" + gia);
            respondtask.Wait();
            var rs = respondtask.Result;
            if (rs.IsSuccessStatusCode)
            {
                var readtask = rs.Content.ReadAsAsync<List<SanPham>>();
                readtask.Wait();
                product = readtask.Result;
            }
            else product = null;
            return View(product);
        }
        public ActionResult laygiaminmax(int min,int max)
        {
            var client = new HttpClient();
            List<SanPham> product;
            client.BaseAddress = new Uri(uri);
            var respondtask = client.GetAsync("SanPhams/by-prices/" + min+"/"+max);
            respondtask.Wait();
            var rs = respondtask.Result;
            if (rs.IsSuccessStatusCode)
            {
                var readtask = rs.Content.ReadAsAsync<List<SanPham>>();
                readtask.Wait();
                product = readtask.Result;
            }
            else product = null;
            return View(product);
        }
        public ActionResult laytheoten(string ten)
        {
            var client = new HttpClient();
            SanPham product;
            client.BaseAddress = new Uri(uri);
            var respondtask = client.GetAsync("SanPhams/by-name/" + ten);
            respondtask.Wait();
            var rs = respondtask.Result;
            if (rs.IsSuccessStatusCode)
            {
                var readtask = rs.Content.ReadAsAsync< SanPham>();
                readtask.Wait();
                product = readtask.Result;
            }
            else product = null;
            return View(product);
        }
        // GET: SanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPham/Create
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                // TODO: Add insert logic here
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPham/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPham/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
