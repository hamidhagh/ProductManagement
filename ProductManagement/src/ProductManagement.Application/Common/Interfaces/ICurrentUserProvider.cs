using ProductManagement.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Common.Interfaces
{
    public interface ICurrentUserProvider
    {
        CurrentUser GetCurrentUser();
    }
}
