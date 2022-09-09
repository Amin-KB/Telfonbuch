using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telefonbuch.Services
{
    internal static class GenericService
    {
        public static List<List<T>> Partition<T>(this List<T> values, int chunkSize)
        {
            return values.Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
