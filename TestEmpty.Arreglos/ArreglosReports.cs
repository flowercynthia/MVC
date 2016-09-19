using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEmpty.Arreglos.ViewModels;
using TestEmpty.Models;

namespace TestEmpty.Arreglos
{
    public static class ArreglosReports
    {
        public static IEnumerable<ArreglosMesViewModel> GetArreglosMes(this IApplicationDbContext dbContext, DateTime fecha)
        {
            return new List<ArreglosMesViewModel>();
        }
    }
}
