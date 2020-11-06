﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchBarApp
{

    public class MenuMasterMenuItem
    {
        public MenuMasterMenuItem()
        {
            TargetType = typeof(MenuMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}