﻿using ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface ICustomer
    {
        List<CustomerDto> GetAllCustomers();
    }
}
