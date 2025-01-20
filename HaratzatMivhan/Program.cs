using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
//lya moshel - 25/12

namespace TshovotMivhan
{
    public class Program
    {
        static void Main(string[] args)
        {
            //בדיקות גם לפונקציה שהוספתי
            Console.WriteLine("Hello, World!");
            ComPac pac1 = new ComPac(34, 78, 5);//נפח נתונים,מחיר חבילה,תשלום לכל הוספת ג'יגה
            pac1.CalcTotal(0);//כאן הלקוח אינו חורג לכן מצופה שהוא לא יכנס למערך החורגים
            ComPac pac2 = new ComPac(14, 61, 6);
            pac2.CalcTotal(21);//חורג במעל שבע לכן יוכנס ערך אמת
            ComPac pac3 = new ComPac(51, 80, 12);
            pac3.CalcTotal(52);// חורג אך לא במעל 7 יוכנס ערך שקר
            ComPac pac4 = new ComPac(50, 100, 10);
            pac4.CalcTotal(3);//לא חורג לא יוכנס למערך
            ComPac pac5 = new ComPac(31, 67, 3);
            pac5.CalcTotal(38);//חורג בדיוק ב 7 יוכנס ערך אמת




            // יצירת מערך החבילות
            //סעיף ג
            ComPac[] Packages = { pac1, pac2, pac3, pac4, pac5 };
            int result2 = CheckExtra(Packages);
            Console.WriteLine(result2);

            //סעיף ד
            int[] result = CalcHefresh(Packages);
            PrintArray(result);


            // יצירה של נקודה וישר לפונקציה שלי ולשאלה 2 מהמבחן
            Point1 p1 = new Point1(28, 8);
            Line l1 = new Line(4, 15);
            Point1 p2 = new Point1(5, 20);
            Line l2 = new Line(2, 5);
            Point1 p3 = new Point1(-16, 4);
            Line l3 = new Line(0,4);

            //שאלה 2 מהמבחן
            Line mak = Makbil(l1, p1);
            Console.WriteLine(mak);
            Line mak1 = Makbil(l2, p2);
            Console.WriteLine(mak1);
            Line mak3 = Makbil(l3, p3);
            Console.WriteLine(mak3);

            //הדפסות ובדיקות לפונקציה שלי
            IsPointBelowOrAboveLine(l1, p1);//מכיוון שהוואי של הנקודה קטן מהוואי של הישר הנקודה תהיה מתחתיו
            IsPointBelowOrAboveLine(l2, p2);//מכיוון שהוואי של הנקודה גדול מהוואי של הישר הנקודה תהיה מעליו
            IsPointBelowOrAboveLine(l3, p3);//מכיוון שהוואי של הנקודה שווה לוואי של הישר הנקודה תהיה בדיוק עליו



            // יצירת מערך של החורגים בכדי להשתמש בו בפונקציה מה שבע
            ComPac[] hargoPackages = CalcArrHorgim(Packages);
            bool[] maSheva = GetMaShevaArr(hargoPackages);
            PrintArray(maSheva);
         
            

        }

        public static int CheckExtra(ComPac[] Packages)
        {
            //פונקציה זו מקבלת את המערך חבילות ומחזירה את כמות הלקוחות שחרגו מהמחיר הבסיסי
            int countHargo = 0;
            // לולאת פור שתעבור את כל המערך ותבדוק מי חרג את חבילת הבסיס
            for (int i = 0; i < Packages.Length; i++)
            {
                if (Packages[i].GetExtraUsage())
                {
                    countHargo++;
                }
            }
            return countHargo;

        }

        public static int[] CalcHefresh(ComPac[] packages)
        {
            //פונקציה שמקבלת מערך פאקאייג ומחזירה מערך שבכל תא הפרש המחיר בין חבילת הבסיס לבין הסכום בפועל
            int len = CheckExtra(packages);
            int[] HefreshArray = new int[len];
            int index = 0;
            for (int i = 0; i < packages.Length; i++)
            {
                //תנאי שבו נבדוק האם הלקוח במקום האיי  צריך להכנס למערך החדש
                //נכניס אותם לפי מיקומם במערך כדי לא לחרוג ממנו, לכן השימוש במשתנה אינדקס
                if (packages[i].GetExtraUsage())
                {
                    HefreshArray[index] = packages[i].GetTotal() - packages[i].GetBasePrice();
                    index++;
                }
            }
            return HefreshArray;
        }


        public static Line Makbil(Line l, Point1 p)
        {
            //פונקציה לחישוב ישר מקביל לקו המתקבל ועובר בנקודה המתקבלת
            double m = l.GetM();
            double b = p.GetY() - p.GetX() * m;
            Line newLine = new Line(m, b);
            return newLine;
        }

        // :תרגיל לקראת מועד ב
        //זה הפונקציות שהמצאתי - נמצאות בקובץ דוקס מצורף
        public static ComPac[] CalcArrHorgim(ComPac[] packages)
        {
            //הפונקציה מקבלת את מערך החבילות ומחזירה מערך חדש של כל האנשים שחרגו מחבילת הבסיס
            // אנחנו צריכים את זה בשביל להשתמש במערך בפונקציה של מה שבע
            int len = CheckExtra(packages);
            ComPac[] hargoPackages = new ComPac[len]; ;
            int index = 0;
            for (int i = 0; i < packages.Length; i++)
            {
                //תנאי שבו נבדוק האם הלקוח במקום האיי  צריך להכנס למערך החדש
                //נכניס אותם לפי מיקומם במערך כדי לא לחרוג ממנו, לכן השימוש במשתנה אינדקס
                if (packages[i].GetExtraUsage())
                {
                    hargoPackages[index] = packages[i];
                    index++;
                }
            }
            return hargoPackages;
        }


        public static bool[] GetMaShevaArr(ComPac[] hargoPackages)
        {
            //הפונקציה מקבלת מערך אנשים שחרגו מחבילת הבסיס ובודקת בכמה כל אחד חרג, במידה והחריגה גדולה מ7 ג'יגה יוחזר ערך אמת
            //במידה ובפחות יוחזר ערך שקר
            bool[] maSheve = new bool[hargoPackages.Length];
            for (int i = 0; i < hargoPackages.Length; i++)
            {
                int extraGiga = 0;
                //בדיקה שבה נבדוק את כמות הג'יגה החורגים
                extraGiga = (hargoPackages[i].GetTotal() - hargoPackages[i].GetBasePrice()) / hargoPackages[i].GetExtraGigaPrice();

                if (extraGiga >= 7)
                {
                    maSheve[i] = true;
                }
                else
                {
                    maSheve[i] = false;
                }
            }
            return maSheve;
        }

        public static void IsPointBelowOrAboveLine(Line l, Point1 p)
        {
            //הפונקציה מקבלת ישר ונקודה ומחזירה איפה נמצאת הנקודה ביחס לישר
            double lineY = l.GetM() * p.GetX() + l.GetB();
            
            if (lineY > p.GetY())
            {
                 Console.WriteLine("the point " + p + " is below the line :" + " " + l) ;
            }
            if (lineY < p.GetY())
            {
                Console.WriteLine("the point " + p + " is  above the line: " + " " + l);
            }
            if (lineY == p.GetY())

            {
                Console.WriteLine("the point " + p + " is on the line: " + " " + l);
            }
        }


        public static void PrintArray<T>(T[] array)
        {
            //  פונקציה המקבלת מערך ומדפיסה אותו עם הוספת סוגריים מרובעים בהתחלה ובסוף
            //  ועם פסיקים בין כל איבר במערך  
            int arrayLen = array.Length;
            Console.Write("[");
            for (int i = 0; i < arrayLen; i++)
            {
                Console.Write(array[i]);
                if (i < arrayLen - 1)
                {
                    Console.Write(",");
                }
                else
                {
                    Console.WriteLine("]");
                }
            }
        }
    }
}
