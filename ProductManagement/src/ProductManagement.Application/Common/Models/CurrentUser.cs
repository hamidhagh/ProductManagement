﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Common.Models
{
    public record CurrentUser(
    Guid Id,
    IReadOnlyList<string> Permissions,
    IReadOnlyList<string> Roles);
}
