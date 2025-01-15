using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//lya moshel - 25/12
namespace TshovotMivhan

{

    public class Line
    {
        private double m;
        private double b;

        public Line(double m, double b)
        // פונקציית בנאי
        {
            this.m = m;
            this.b = b;
        }
        public double GetM()
        {
            return this.m;
        }

        public double GetB()
        {
            return this.b;
        }
        public override string ToString()
        {
            return "y=" + this.m + "x" + "+" + this.b;

        }
    }
}
