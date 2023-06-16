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

namespace LinkedGateTask.Controllers
{
    public class DevicesPropertiesController : Controller
    {
        readonly IDevicePropertyGet devicePropertyGet;
        public DevicesPropertiesController() {
            devicePropertyGet = new DevicesProperties_Repos();
        }

        public async Task<ActionResult> Setup(int propId, int? deviceId)
        {

            return PartialView( await devicePropertyGet.Get(propId, deviceId));
        }


    }
}
