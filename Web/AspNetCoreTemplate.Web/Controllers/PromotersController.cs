﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTemplate.Web.Controllers
{
    public class PromotersController:Controller
    {
        public IActionResult Add()
        {
            return this.View();
        }


    }
}
