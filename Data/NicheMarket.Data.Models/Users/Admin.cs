﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicheMarket.Data.Models.Users
{
    [Authorize(Roles = "Administrator")]
    public class Admin : NicheMarketUser, User
    {

    }
}
