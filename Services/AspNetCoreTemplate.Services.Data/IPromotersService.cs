using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Services.Data
{
    public interface IPromotersService
    {
        T GetById<T>(int id);

    }
}
