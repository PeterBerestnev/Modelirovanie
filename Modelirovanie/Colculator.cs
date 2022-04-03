using System;
using System.Collections.Generic;
using System.Text;
//возможно сначала надо привести к буквенным значениям, а затем переписывать в постфиксную форму (хотя и так норм)
//строка анализируется на функцию и она отправляется в стек, но (возможно) оттуда не извлекается (проверить свитчи с анализом стека)
namespace Modelirovanie
{
    class Colculator
    {
        //Сделать стэк из ListBox  создать n кол-во элементов, заполнять с конца, данные не стираются, просто смещается указатель (аналог модели оперативной памяти)
        //или из массива
        Dictionary<char, int> VariableMean = new Dictionary<char, int>();
        int num = 10;//Multiplayer
        int num2 = 0;//alphabit position
        string stroka="";
        string finstroka = "";
        bool end = false;
        int m = 0;
        bool alreadyConverted = false;
        //Stack<char> ownStack = new Stack<char>();//стек реализовать самому
        Dictionary<string, string> FunctionMean = new Dictionary<string, string>();
        Dictionary<string, string> SymbolMean = new Dictionary<string, string>();
        Dictionary<char, int> StrokIndex = new Dictionary<char, int>();
        Dictionary<char, int> StackIndex = new Dictionary<char, int>();
        char[] OperationStrokaAlphabit = { '\0', '+', '-', '*', '/', '^', '(', ')', 'F', 'P' };
        char[] OperationStackAlphabit = { '\0', '+', '-', '*', '/', '^', '(','F'};
        string[] functionString = { "arcsin", "ctg", "sin", "tg" };//эти массивы связаны, должны быть равны по длине и не иметь повторяющихся элементов
        string[] functionChar = { "A", "C", "S", "T" };
        char[] alphabit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 'u', 'v', 'w', 'x', 'y', 'z' };
        static int lnth = 15;
        int pntr = -1;
        string tempString = "";
        MyOwnStak ownStack = new MyOwnStak(lnth);
        int[,] table = new int[8, 10] {  {4,1,1,1,1,1,1,5,1,6 },
                                         {2,2,2,1,1,1,1,2,1,6 },
                                         {2,2,2,1,1,1,1,2,1,6 }, 
                                         {2,2,2,2,2,1,1,2,1,6 }, 
                                         {2,2,2,2,2,1,1,2,1,6 }, 
                                         {2,2,2,2,2,2,1,2,1,6 },
                                         {5,1,1,1,1,1,1,3,1,6 }, 
                                         {2,2,2,2,2,2,1,2,7,6 }};
        public Colculator()
        {
            for (int k = 0; k < alphabit.Length; k++)
            {
                VariableMean.Add(alphabit[k], 0);
            }
            for (int k = 0; k < functionString.Length; k++)
            {
                FunctionMean.Add(functionString[k], functionChar[k]);
            }
            for (int k = 0; k < functionString.Length; k++)
            {
                SymbolMean.Add(functionChar[k], functionString[k]);
            }
            for (int k = 0; k < OperationStrokaAlphabit.Length; k++)
            {
                StrokIndex.Add(OperationStrokaAlphabit[k], k);
            }
            for (int k = 0; k < OperationStackAlphabit.Length; k++)
            {
                StackIndex.Add(OperationStackAlphabit[k], k);
            }
        }
        public bool isEnd()
        {
            return end;
        }
        private bool isFunction(char a)
        {
            bool answ = false;
            int p = 0;
            while (p < functionChar.Length)
            {
                if (a == functionChar[p][0])
                {
                    answ = true;
                    break;
                }
                p++;
            }
            return answ;
        }
        public void resetAll()
        {
           finstroka="";
           end = false;
           alreadyConverted = false;
        }
        public string getStroka()
        {
            return finstroka;
        }
        public int getPntr()
        {
            return pntr;
        }
        public char PeekStack()
        {
            return ownStack.Peek(pntr); ;
        }
        private char PoP()
        {
            char temp = ownStack.Peek(pntr);
            pntr -= 1;
            return temp;
        }
        private void PusH(char symb)
        {
            
                pntr += 1;
                ownStack.Push(pntr, symb);
            
        }
        public void Enumeration(string strok, bool step)
        {
            if(end)
            finstroka = "";
            int strokInd = 0;
            int stackInd = 0;
            if(!alreadyConverted)
            convertation(strok);
            while (!end)
            {
                strokInd = StrokIndex[tempString[m]];
                if (isFunction(ownStack.Peek(pntr))){
                    stackInd = StackIndex['F'];
                }
                else
                    stackInd = StackIndex[ownStack.Peek(pntr)];
                switch (table[stackInd, strokInd])
                {
                    case 1:
                        PusH(stroka[m]);
                        m++;
                        break;
                    case 2:
                        finstroka+= PoP();
                        break;
                    case 3:
                        while(ownStack.Peek(pntr)!='(')
                        {
                            finstroka += PoP();
                        }
                        PoP();
                        m++;
                        break;
                    case 4:
                        //Баг, надо подправить (при замене имен функций одна и та же может замениться несколько раз)
                        foreach (KeyValuePair<string, string> kvp in FunctionMean)
                        {
                            if (finstroka.Contains(kvp.Value))
                            {
                                finstroka = finstroka.Replace(kvp.Value, kvp.Key.ToUpper());
                            }
                        }
                        end = true;
                        pntr = -1;
                        stroka = "";
                        m = 0;
                        alreadyConverted = true;
                        //finstroka = "";
                        break;
                    case 5:
                        finstroka = "Ошибка скобочной структуры";
                        end = true;
                        pntr = -1;
                        stroka = "";
                        m = 0;
                        alreadyConverted = true;
                        break;
                    case 6:
                        finstroka += stroka[m];
                        m++;
                        break;
                    case 7:
                        finstroka = "Ошибка скобочной структуры";
                        end = true;
                        pntr = -1;
                        stroka = "";
                        m = 0;
                        alreadyConverted = true;
                        break;
                }
                if (step)
                {
                    break;
                }
            }
        }
        public void convertation(string strok)
        {
            bool isFunc = false;
            foreach (KeyValuePair<string, string> kvp in FunctionMean)
            {
                if (strok.Contains(kvp.Key))
                {
                    strok = strok.Replace(kvp.Key, kvp.Value);
                }
            }
            strok += '\0';
            for (int i = 0; i < strok.Length; i++)
            {
                isFunc = false;
                if (strok[i] == '+' || strok[i] == '-' || strok[i] == '*' || strok[i] == '/' || strok[i] == '^' || strok[i] == '(' || strok[i] == ')' || strok[i] == '\0')
                {
                    if (strok[i] != '(' && strok[i] != '\0' && strok[i - 1] != ')')
                    {
                        stroka += alphabit[num2];
                        num2++;
                    }
                    if (strok[i] == '\0' && strok[i - 1] != ')')
                    {
                        stroka += alphabit[num2];
                    }
                    stroka += strok[i];
                    
                }
                else
                {
                    int j = 0;
                    while (j < functionChar.Length)
                    {
                        if (strok[i] == functionChar[j][0])
                        {
                            stroka += strok[i];
                            isFunc = true;
                            break;
                        }
                        j++;
                    }
                    if (!isFunc)
                    {
                        if (VariableMean[alphabit[num2]] == 0)
                        {
                            VariableMean[alphabit[num2]] += (int)strok[i];
                        }
                        else
                        {
                            VariableMean[alphabit[num2]] = (VariableMean[alphabit[num2]] * num) + (int)strok[i];
                        }
                    }

                }
            }
            tempString = stroka;
            foreach (KeyValuePair<string, string> kvp in FunctionMean)
            {
                if (tempString.Contains(kvp.Value))
                {
                    tempString = tempString.Replace(kvp.Value, "F");
                }
            }
            for(int p = 0; p < tempString.Length; p++)
            {
                int b = 0;
                while (b < alphabit.Length)
                {
                    if (tempString[p] == alphabit[b])
                    {
                        tempString = tempString.Replace(tempString[p],'P');
                        break;
                    }
                    b++;
                }
            }
            alreadyConverted = true;
        }
    }
}
