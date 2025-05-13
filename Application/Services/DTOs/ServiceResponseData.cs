using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DTOs
{
    public  record class ServiceResponseData(
        bool Success = false,
        string Message = null!,
        object? Data = null
        );

}
