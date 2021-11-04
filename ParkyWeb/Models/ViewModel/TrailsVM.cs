﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ParkyWeb.Models
{
    public class TrailsVM
    {
        public IEnumerable<SelectListItem> NationalParkList { get; set; }

        public Trail Trail { get; set; }

    }
}
