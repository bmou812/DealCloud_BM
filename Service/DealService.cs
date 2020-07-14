using DealCloud_BM.Data;
using DealCloud_BM.Interfaces;
using DealCloud_BM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealCloud_BM.Service
{
    public class DealService : Service, IDealService
    {
          
        public DealService(): base()
        {
            
        }

               

        public decimal GetAverage(List<decimal> list)
        {
            var arr = list.ToArray<decimal>(); 
            decimal avg = Queryable.Average(arr.AsQueryable());

            return avg;

        }

        
        public decimal GetMaximum(List<decimal> list)
        {
            var arr = list.ToArray<decimal>(); 
            decimal max = Queryable.Max(arr.AsQueryable());

            return max;

        }

        public decimal CalculateROI(decimal tsdFirst, decimal tsdLast)
        {
            decimal netIncome = 0M;
            decimal differenc = decimal.Subtract(tsdLast, tsdFirst);
            decimal factor = decimal.Multiply(tsdFirst, 100);

            decimal retn = decimal.Divide(decimal.Add(netIncome, differenc),factor);

            return retn;
        }

        public void Dispose()
        {
            if (base.DataLayerInstance != null)
                this.DataLayerInstance = null;
        }

       
        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
