﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier2Presta.Service.Entities.XmlPrice
{
    public interface IPriceXmlItem
    {
        List<XmlItem> Items { get; set; }
    }
}