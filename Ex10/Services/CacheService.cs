using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex10.Models;

namespace Ex10.Services
{
    internal class CacheService
    {
        private readonly Dictionary<string, CacheEntry> _cache = new();

        public bool TryGetMeteo(string ville, out Meteo meteo)
        {
            meteo = null;

            if (_cache.TryGetValue(ville.ToLower(), out var entry))
            {
                if (DateTime.Now <= entry.DateExpiration)
                {
                    meteo = entry.Meteo;
                    return true;
                }

                _cache.Remove(ville.ToLower());
            }

            return false;
        }

        public void AjouterCache(string ville, Meteo meteo)
        {
            _cache[ville.ToLower()] = new CacheEntry
            {
                Ville = ville,
                Meteo = meteo,
                DateExpiration = DateTime.Now.AddMinutes(10)
            };
        }
    }
}
