﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain.Events
{
    public interface IEventRepository: IRepository<Event>
    {
    }
}
