﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFramework.Configuration
{
    public abstract class BaseConfiguration<T>
        :EntityTypeConfiguration<T> where T:class
    {
    }

}
