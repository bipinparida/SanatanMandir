﻿using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatanMandir.Controllers
{
    [Area(AreaNames.SanatanMandir)]
    public class SanatanMandirDashboardController : BasePluginController
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public SanatanMandirDashboardController(IWebHostEnvironment hostEnvironment)

        {
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View("~/Plugins/SanatanMandir/Views/SanatanMandirDashboard/Dashboard.cshtml");
        }
    }
}
