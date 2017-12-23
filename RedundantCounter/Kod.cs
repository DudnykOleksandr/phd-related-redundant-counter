using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedundantCounter
{
    class Kod
    {
        int[] basis;
        int[] polinom;
        double radix;
        int length;

        public Kod(int[] mas)
        {
            if (mas.Length % 2 == 1)
            {
                length = mas.Length;
                polinom = mas;    
            }
            else
                throw new Exception("polinom length error");
        }
        public Kod(int num)
        {
            if (num % 2 == 1)
            {
                length = num;
                polinom = new int[num];
            }
            else
                throw new Exception("polinom length error");
        }
        public int getBitValue(int num)
        {
            if (num < polinom.Length)
                return polinom[num];
            else
                throw new Exception("polinom bounds error");
        }
        public void setBitValue(int num, int value)
        {
            if (num < polinom.Length)
                polinom[num]=value;
            else
                throw new Exception("polinom bounds error");
        }
        public override string ToString()
        {
            StringBuilder res=new StringBuilder();
            for (int i = 0; i<length; i++)
                res.AppendFormat(" {0}", polinom[i]);
            return res.ToString();
        }
        public bool AddOne()
        {
            int middleBitNum = length / 2;

            if (polinom[middleBitNum] == 0)
            {
                polinom[middleBitNum] = 1;
                return true;
            }
            else
            {
                wrapAllTheVariants();
                if (polinom[middleBitNum] == 0)
                {
                    polinom[middleBitNum] = 1;
                    return true;
                }
                else
                {
                    unWrapOnlyFromMiddleBit();
                    if (polinom[middleBitNum] == 0)
                    {
                        polinom[middleBitNum] = 1;
                        return true;
                    }
                }


            }
            return false;
        }
        public bool SubstractOne()
        {
            int middleBitNum = length / 2;

            if (polinom[middleBitNum] == 1)
            {
                polinom[middleBitNum] = 0;
                return true;
            }
            else
            {
                unWrapAllTheVariants();
                if (polinom[middleBitNum] == 1)
                {
                    polinom[middleBitNum] = 0;
                    return true;
                }
                else
                {
                    wrapOnlyFromMiddleBit();
                    if (polinom[middleBitNum] == 1)
                    {
                        polinom[middleBitNum] = 0;
                        return true;
                    }
                }
            }
            return false;
        }
        void wrapAllTheVariants()
        {
            bool flag=true;
            while(flag)
            {
                for (int i = 0; i<=length-3; i++)
                {
                    flag = false;
                    if (polinom[i] == 0 && polinom[i + 1] == 1 && polinom[i + 2] == 1)
                    {
                        polinom[i] = 1;
                        polinom[i + 1] = 0;
                        polinom[i + 2] = 0;
                        flag = true;
                        break;
                    }
                }
            }
        }
        void unWrapAllTheVariants()
        {
            bool flag = true;
            while (flag)
            {
                for (int i = 0; i <= length - 3; i++)
                {
                    flag = false;
                    if (polinom[i] == 1 && polinom[i + 1] == 0 && polinom[i + 2] == 0)
                    {
                        polinom[i] = 0;
                        polinom[i + 1] = 1;
                        polinom[i + 2] = 1;
                        flag = true;
                        break;
                    }
                }
            }
        }
        void unWrapOnlyFromMiddleBit()
        {
            int middleBitNum = length / 2;
            bool flag = true;

            while (polinom[middleBitNum]!=0&&flag)
            {
                for (int i = middleBitNum; i<=length - 3; i++)
                {
                    flag = false;
                    if (polinom[i] == 1 && polinom[i + 1] == 0 && polinom[i + 2] == 0)
                    {
                        polinom[i] = 0;
                        polinom[i + 1] = 1;
                        polinom[i + 2] = 1;
                        flag = true;
                        break;
                    }

                }
            }
 
        }
        void wrapOnlyFromMiddleBit()
        {
            int middleBitNum = length / 2;
            bool flag = true;

            while (polinom[middleBitNum] != 1 && flag)
            {
                for (int i = middleBitNum; i <= length - 3; i++)
                {
                    flag = false;
                    if (polinom[i] == 0 && polinom[i + 1] == 1 && polinom[i + 2] == 1)
                    {
                        polinom[i] = 1;
                        polinom[i + 1] = 0;
                        polinom[i + 2] = 0;
                        flag = true;
                        break;
                    }

                }
            }

        }
    }
}
