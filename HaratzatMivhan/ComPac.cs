using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//lya moshel - 25/12

namespace TshovotMivhan
{
    public class ComPac
    {
        private int gigaSize;
        private int basePrice;
        private int extraGigaPrice;
        private int totalPrice;
        private bool extraUsage;

        public ComPac(int gigaSize, int basePrice, int extraGigaPrice)
        {
            //פונקציית בנאי
            this.gigaSize = gigaSize;
            this.basePrice = basePrice;
            this.extraGigaPrice = extraGigaPrice;
            this.totalPrice = basePrice;
            this.extraUsage = false;

        }

        public void CalcTotal(int usage)
        {
            //הפונקציה מקבלת את נפח השימוש שהשתמש בו הלקוח ומעדכנת בהתאם את את אקסטרהיוסאייג ואת המחיר הכולל
            //אין לי אפשרות לכתוב באנגלית בהערות אז כתבתי את השם משתנה בעברית
            if (usage > this.gigaSize)
            {
                this.extraUsage = true;
                this.totalPrice = this.basePrice + (usage - this.gigaSize) * this.extraGigaPrice;
            }
            else
            {
                this.totalPrice = this.basePrice;
            }
        }

        public bool GetExtraUsage()
        {
            return this.extraUsage;
        }

        public int GetTotal()
        {
            return this.totalPrice;
        }

        public int GetBasePrice()
        {
            return this.basePrice;
        }

        public int GetExtraGigaPrice()
        {
            return this.extraGigaPrice;
        }
    }


}

