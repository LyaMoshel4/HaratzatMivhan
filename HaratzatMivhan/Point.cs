using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//lya moshel - 25/12

namespace TshovotMivhan;

public class Point1
{
    private char name;
    private double x;
    private double y;

    public Point1(double x, double y)
    // פונקציית בנאי
    {
        this.x = x;
        this.y = y;
    }
    public double GetX()
    {
        return this.x;

    }


    public double GetY()
    {
        return this.y;
    }
    public override string ToString()
    {
        return "(" + this.x + "," + this.y + ")";

    }
}
