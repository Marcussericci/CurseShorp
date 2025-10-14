using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leson1.Class.BaseClass
{
    public abstract class Сar
    {
        private int Id;
        internal string Name;
        protected string Model;
        public DateTime CreateDate;
        internal protected DateTime UseDate;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public double sum(int num1, int num2)
        {
            return num1 + num2;
        }
        public double sum(int num1, int num2, int num3)
        {
            return num1 + num2+num3;
        }
        public double sum(double num1, double num2)
        {
            return num1 + num2;
        }
    }   
}

