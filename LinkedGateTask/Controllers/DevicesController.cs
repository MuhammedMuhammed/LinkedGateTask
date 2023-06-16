using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataManager;
using DataManager.Models;
using BusinessManager.Interface;
using BusinessManager.Repository;
using Newtonsoft.Json;

namespace LinkedGateTask.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDevices idevices = new DevicesRepos();
        private readonly ICategory category = new CategoryRepos();
        readonly IDevicePropertyGet devicePropertyGet;
        public DevicesController()
        {
            devicePropertyGet = new DevicesProperties_Repos();
        }
        // GET: Devices
        public async Task<ActionResult> Index()
        {
            return View(await idevices.GetDevicesAsync());
        }

        // GET: Devices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devices devices = await idevices.GetDeviceAsync(id ?? 0);
            if (devices == null)
            {
                return HttpNotFound();
            }
            return View(devices);
        }

        // GET: Devices/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = await category.GetCategoriesAsync();
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Memo,AcquisitionDate,CatId")] Devices devices)
        {
            var keys = HttpContext.Request.Form.AllKeys;
            var val = HttpContext.Request.Form.GetValues(Array.IndexOf(keys,"propsList")).FirstOrDefault();
            devices.DevicesProperties = JsonConvert.DeserializeObject<ICollection<DevicesProperties>>(val);
            if (ModelState.IsValid)
            {
                var success = await idevices.AddDevice(devices);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Categories = await category.GetCategoriesAsync();

            return View(devices);
        }

        // GET: Devices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            Devices devices = await idevices.GetDeviceAsync(id ?? 0);
            ViewBag.Categories = await category.GetCategoriesAsync();
            if (devices == null)
            {
                return HttpNotFound();
            }
            return View(devices);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Memo,AcquisitionDate,CatId")] Devices devices)
        {
            var keys = HttpContext.Request.Form.AllKeys;
            var val = HttpContext.Request.Form.GetValues(Array.IndexOf(keys, "propsList")).FirstOrDefault();
            devices.DevicesProperties = JsonConvert.DeserializeObject<ICollection<DevicesProperties>>(val);

            if (ModelState.IsValid)
            {
                var success = await idevices.UpdateDevice(devices);
                if (success)
                    return RedirectToAction("Index");
            }
            ViewBag.Categories = await category.GetCategoriesAsync();
            return View(devices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                idevices.DisposeDB();
            }
            base.Dispose(disposing);
        }
    }
}
