using System;
using System.Collections.Generic;
using System.Linq;

namespace leetCode
{
    internal class Program
    {
        public static double Mn = 35.0;
        public static double Jn = 40.0;
        public static double Qmax = 2.2;
        public static double Emax = 1.3;
        public static double qst = 1.5;
        public static double qsk = DigMinToRad(6);
        public static double P = 550;
        public static double Uyp = 220;
        public static double n = 2790;
        public static double Mdvn = 2;
        public static double Mpn = 2.2;
        public static double Jdv = 0.0005;
        public static double ipir = 16;
        public static double qto = DigMinToRad(0.5);
        public static double qgo = DigMinToRad(20);
        public static double kto = 3;
        public static double kgo = MVperDegMinToVperRad(1);
        public static double UmaxTO = 2.5;
        public static double UmaxGO = 3.4;

        private static void Main(string[] args)
        {
            var Ptr = GetPtr();
            Console.WriteLine("Ptr: " + Ptr);

            var Iopt = GetIopt();
            Console.WriteLine("Iopt: " + Iopt);

            var Qdv = ObPerMinutToRadPerSecond(n);
            Console.WriteLine("Qdv: " + Qdv);

            var Ireal = GetIreal(Qdv);
            Console.WriteLine("Ireal: " + Ireal);

            var Kred = GetKred(Ireal);
            Console.WriteLine("Kred: " + Kred);

            var Mtr = GetMtr(Iopt);
            Console.WriteLine("Mtr: " + Mtr);

            Console.WriteLine(Mtr / Mdvn);

            var Cw = GetCw(Qdv);
            Console.WriteLine("Cw: " + Cw);

            var Kdv = GetKdv(Cw);
            Console.WriteLine("Kdv: " + Kdv);

            var Tdv = GetTdv(Cw);
            Console.WriteLine("Tdv: " + Tdv);

            var qstir = Getqstir();
            Console.WriteLine("qstir: " + qstir);

            var Wir = MVperDegMinToVperRad(kto);
            Console.WriteLine("Wir: " + Wir);

            var MSc = GetMSc(Ireal);
            Console.WriteLine("MSc: " + MSc);

            var km = Getkm();
            Console.WriteLine("km: " + km);

            var qstmom = Getqstmom();
            Console.WriteLine("qstmom: " + qstmom);

            var kys = Getkys(MSc, qstmom, Wir, km);
            Console.WriteLine("kys: " + kys);

            Console.ReadKey();
        }

        private static double ObPerMinutToRadPerSecond(double num)
        {
            return num * 0.10471975511966;
        }

        private static double MVperDegMinToVperRad(double num)
        {
            return num / (1000 * 0.00029088820867);
        }

        private static double DigMinToRad(double num)
        {
            return num * 0.00029088820867;
        }

        private static double GetPtr()
        {
            return 2 * (Jn * Emax + Mn) * Qmax;
        }

        private static double GetIopt()
        {
            return Math.Sqrt((Jn * Emax + Mn) / (Jdv * Emax));
        }

        private static double GetIreal(double Qdv)
        {
            return Qdv / Qmax;
        }

        private static double GetKred(double Ireal)
        {
            return 1 / Ireal;
        }

        private static double GetMtr(double Iopt)
        {
            return (2 * (Mn + Jn * Emax)) / Iopt;
        }

        private static double GetCw(double Qdv)
        {
            return (Mpn - Mdvn) / Qdv;
        }

        private static double GetKdv(double Cw)
        {
            return Mpn / (Cw * Uyp);
        }

        private static double GetTdv(double Cw)
        {
            return Jdv / Cw;
        }

        private static double Getqstir()
        {
            return qst / 3;
        }

        private static double GetMSc(double Ireal)
        {
            return Mn / Ireal;
        }

        private static double Getkm()
        {
            return Mpn / Uyp;
        }

        private static double Getqstmom()
        {
            Console.WriteLine("qst: " + DigMinToRad(qst));
            return DigMinToRad(qst) * 0.95;
        }

        private static double Getkys(double MSc, double qstmom, double kir, double km)
        {
            return MSc / (qstmom * kir * km);
        }
    }
}