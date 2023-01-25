using OrderAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Domain.Extensions
{
    public static class DbTableExtension
    {
        public static string GetName(this DbTable val)
        {
            return Enum.GetName(val);
        }
    }
}
