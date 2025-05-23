﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Options
{
    public sealed class JwtOptions
    {
        public string Issuer { get; init; }

        public string Audience { get; init; }

        public string Key { get; init; }
    }

}
