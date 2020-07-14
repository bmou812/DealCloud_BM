using DealCloud_BM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DealCloud_BM.Interfaces
{
    public interface IDealService: IDisposable
    {
        public decimal GetAverage(List<decimal> list);

        public decimal GetMaximum(List<decimal> list);

        public decimal CalculateROI(decimal tsdFirst, decimal tsdLast);

    }
}
 