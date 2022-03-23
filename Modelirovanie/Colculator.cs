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
        string stroka;
        string finstroka = "";
        //Stack<char> ownStack = new Stack<char>();//стек реализовать самому
        Dictionary<string, string> FunctionMean = new Dictionary<string, string>();
        Dictionary<string, string> SymbolMean = new Dictionary<string, string>();
        string[] functionString = { "arcsin", "ctg", "sin", "tg" };//эти массивы связаны, должны быть равны по длине и не иметь повторяющихся элементов
        string[] functionChar = { "A", "C", "S", "T" };
        char[] alphabit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 'u', 'v', 'w', 'x', 'y', 'z' };
        static int lnth=15;
        int pntr = 0;
        MyOwnStak ownStack = new MyOwnStak(lnth);
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

        }
        public void deleteSpaceBars()
        {
            stroka = stroka.Trim();
        }
        public string getStroka()
        {
            return finstroka;
        }
        private char PoP()
        {
            char temp = ownStack.Peek(pntr);
            pntr -=1;
            return temp;
        }
        private void PusH(char symb)
        {
           if(pntr==0 && ownStack.Peek(pntr)=='\n')
            {
                ownStack.Push(pntr,symb);
            }
            else
            {
                pntr += 1;
                ownStack.Push(pntr, symb);
            }
        }
        public void Enumeration(string strok)
        {

            foreach (KeyValuePair<string, string> kvp in FunctionMean)
            {
                if (strok.Contains(kvp.Key))
                {
                    strok = strok.Replace(kvp.Key, kvp.Value);
                }
            }
            stroka = strok;
            Console.WriteLine(stroka);
            stroka += '\0';
            deleteSpaceBars();
            bool oprt = true;
            //лишний символ появляется из-за обработки f(x) в  default
            if(stroka.Length>1)
            for (int i = 0; i < stroka.Length; i++)
            {
                    if (pntr != 0) 
                    { 
                        char g = ownStack.Peek(pntr);
                        char t = stroka[i];
                    }
                    
                switch (stroka[i])
                {
                    case '+':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (ownStack.Peek(pntr) != '\n')
                            switch (ownStack.Peek(pntr))
                            {
                                case '+':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '-':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '*':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '/':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '^':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '(':
                                    PusH(stroka[i]);
                                    break;
                               default:
                                        char z = PoP();
                                        int p = 0;
                                        while (p < functionChar.Length)
                                        {//есть идея о проверке символа на букву, после чего
                                            if (z == functionChar[p][0])
                                            {
                                                string h = "" + z;
                                                for (int y = 0; y < functionChar.Length; y++)
                                                {
                                                    if (SymbolMean[h] == functionString[y])
                                                        finstroka = finstroka + functionString[y].ToUpper();

                                                }

                                                p = functionChar.Length;
                                                PusH(stroka[i]);
                                                char q = ownStack.Peek(pntr);
                                            }
                                            p++;
                                        }
                                        break;
                            }
                        else
                        {
                            PusH(stroka[i]);
                        }

                        
                        break;
                    case '-':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (ownStack.Peek(pntr) != '\n')
                            switch (ownStack.Peek(pntr))
                            {
                                case '+':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '-':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '*':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '/':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '^':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '(':
                                        PusH(stroka[i]);
                                    break;
                                default:
                                        char z = PoP();
                                        int p = 0;
                                        while (p < functionChar.Length)
                                        {//есть идея о проверке символа на букву, после чего
                                            if (z == functionChar[p][0])
                                            {
                                                string h = "" + z;
                                                for (int y = 0; y < functionChar.Length; y++)
                                                {
                                                    if (SymbolMean[h] == functionString[y])
                                                        finstroka = finstroka + functionString[y].ToUpper();

                                                }

                                                p = functionChar.Length;
                                            }
                                            p++;
                                        }
                                        break;
                            }
                        else
                        {
                            PusH(stroka[i]);
                        }
                        break;
                    case '*':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (ownStack.Peek(pntr) != '\n')
                            switch (ownStack.Peek(pntr))
                            {
                                case '+':
                                    PusH(stroka[i]);
                                    break;
                                case '-':
                                    PusH(stroka[i]);
                                    break;
                                case '*':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '/':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '^':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '(':
                                    PusH(stroka[i]);
                                    break;
                                default:
                                        char z = PoP();
                                        int p = 0;
                                        while (p < functionChar.Length)
                                        {//есть идея о проверке символа на букву, после чего
                                            if (z == functionChar[p][0])
                                            {
                                                string h = "" + z;
                                                for (int y = 0; y < functionChar.Length; y++)
                                                {
                                                    if (SymbolMean[h] == functionString[y])
                                                        finstroka = finstroka + functionString[y].ToUpper();

                                                }

                                                p = functionChar.Length;
                                            }
                                            p++;
                                        }
                                        break;
                            }
                        else
                        {
                            PusH(stroka[i]);
                            char ok = ownStack.Peek(pntr);
                        }
                        break;
                    case '/':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (ownStack.Peek(pntr) != '\n')
                            switch (ownStack.Peek(pntr))
                            {
                                case '+':
                                    PusH(stroka[i]);
                                    break;
                                case '-':
                                    PusH(stroka[i]);
                                    break;
                                case '*':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '/':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '^':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '(':
                                    PusH(stroka[i]);
                                    break;
                                default:
                                        char z = PoP();
                                        int p = 0;
                                        while (p < functionChar.Length)
                                        {//есть идея о проверке символа на букву, после чего
                                            if (z == functionChar[p][0])
                                            {
                                                string h = "" + z;
                                                for (int y = 0; y < functionChar.Length; y++)
                                                {
                                                    if (SymbolMean[h] == functionString[y])
                                                        finstroka = finstroka + functionString[y].ToUpper();

                                                }

                                                p = functionChar.Length;
                                            }
                                            p++;
                                        }
                                        break;
                            }
                        else
                        {
                            PusH(stroka[i]);
                        }
                        break;
                    case '^':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (ownStack.Peek(pntr) != '\n')
                            switch (ownStack.Peek(pntr))
                            {
                                case '+':
                                    PusH(stroka[i]);
                                    break;
                                case '-':
                                    PusH(stroka[i]);
                                    break;
                                case '*':
                                    PusH(stroka[i]);
                                    break;

                                case '/':
                                    PusH(stroka[i]);
                                    break;
                                case '^':
                                    finstroka = finstroka + PoP();
                                    if (ownStack.Peek(pntr) == '\n' || ownStack.Peek(pntr) == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        PusH(stroka[i]);
                                    break;
                                case '(':
                                    PusH(stroka[i]);
                                    break;
                                default:
                                        char z = PoP();
                                        int p = 0;
                                        while (p < functionChar.Length)
                                        {//есть идея о проверке символа на букву, после чего
                                            if (z == functionChar[p][0])
                                            {
                                                string h = "" + z;
                                                for (int y = 0; y < functionChar.Length; y++)
                                                {
                                                    if (SymbolMean[h] == functionString[y])
                                                        finstroka = finstroka + functionString[y].ToUpper();

                                                }

                                                p = functionChar.Length;
                                            }
                                            p++;
                                        }
                                        break;
                            }
                        else
                        {
                            PusH(stroka[i]);
                        }
                        break;
                    case '(':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (ownStack.Peek(pntr) != '\n')
                            switch (ownStack.Peek(pntr))
                            {
                                case '+':
                                    PusH(stroka[i]);
                                    break;
                                case '-':
                                    PusH(stroka[i]);
                                    break;
                                case '*':
                                    PusH(stroka[i]);
                                    break;
                                case '/':
                                    PusH(stroka[i]);
                                    break;
                                case '^':
                                    PusH(stroka[i]);
                                    break;
                                case '(':
                                    PusH(stroka[i]);
                                    break;
                                default:
                                        char z = ownStack.Peek(pntr);
                                        int p = 0;
                                        while (p < functionChar.Length)
                                        {//есть идея о проверке символа на букву, после чего
                                            if (z == functionChar[p][0])
                                            {
                                                PusH(stroka[i]);
                                                p = functionChar.Length;
                                            }
                                            p++;
                                        }
                                        break;
                            }
                        else
                        {
                            PusH(stroka[i]);
                        }
                        break;
                    case ')':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (ownStack.Peek(pntr) != '\n')
                            switch (ownStack.Peek(pntr))
                            {
                                case '+':
                                        //пока стек не будет равен 0 (но в таком случае нужна ошибка) или пока символ стека не будет равен "(" (но его мы в строку не отпрвляем)
                                        while (ownStack.Peek(pntr)!='(')
                                        {
                                           if (ownStack.Peek(pntr) != '(')
                                            finstroka = finstroka + PoP();
                                        }
                                        PoP();
                                        break;
                                case '-':
                                        while (ownStack.Peek(pntr) != '(')
                                        {
                                            if (ownStack.Peek(pntr) != '(')
                                                finstroka = finstroka + PoP();
                                        }
                                        PoP();
                                        break;
                                case '*':
                                        while (ownStack.Peek(pntr) != '(')
                                        {
                                            if (ownStack.Peek(pntr) != '(')
                                                finstroka = finstroka + PoP();
                                        }
                                        PoP();
                                        break;
                                case '/':
                                        while (ownStack.Peek(pntr) != '(')
                                        {
                                            if (ownStack.Peek(pntr) != '(')
                                                finstroka = finstroka + PoP();
                                        }
                                        PoP();
                                        break;
                                case '^':
                                        while (ownStack.Peek(pntr) != '(')
                                        {
                                            if (ownStack.Peek(pntr) != '(')
                                                finstroka = finstroka + PoP();
                                        }
                                        PoP();
                                        break;
                                case '(':
                                        PoP();
                                        break;
                                default:
                                       //Ошибка скобочной структуры
                                        break;
                            }
                        else
                        {
                            //ошибка скобочной структуры
                        }
                        break;
                    case '\0':
                        if (ownStack.Peek(pntr) != '\n')
                            switch (ownStack.Peek(pntr))
                            {
                                case '+':
                                        finstroka += alphabit[num2];
                                        finstroka = finstroka + PoP();
                                    
                                        
                                            while (ownStack.Peek(pntr) != '\n')
                                            {
                                                if(ownStack.Peek(pntr)!='(')
                                                    finstroka = finstroka + PoP();
                                                else
                                                    PoP();
                                            }
                                        
                                        break;
                                case '-':
                                        finstroka += alphabit[num2];
                                        finstroka = finstroka + PoP();
                                        while (ownStack.Peek(pntr) != '\n')
                                        {
                                            if (ownStack.Peek(pntr) != '(')
                                                finstroka = finstroka + PoP();
                                            else
                                                PoP();
                                        }
                                        break;
                                case '*':
                                        finstroka += alphabit[num2];
                                        finstroka = finstroka + PoP();
                                        while (ownStack.Peek(pntr) != '\n')
                                        {
                                            if (ownStack.Peek(pntr) != '(')
                                                finstroka = finstroka + PoP();
                                            else
                                                PoP();
                                        }
                                        break;
                                case '/':
                                        finstroka += alphabit[num2];
                                        finstroka = finstroka + PoP();
                                        while (ownStack.Peek(pntr) != '\n')
                                        {
                                            if (ownStack.Peek(pntr) != '(')
                                                finstroka = finstroka + PoP();
                                            else
                                                PoP();
                                        }
                                        break;
                                case '^':
                                        finstroka += alphabit[num2];
                                        finstroka = finstroka + PoP();
                                        while (ownStack.Peek(pntr) != '\n')
                                        {
                                            if (ownStack.Peek(pntr) != '(')
                                                finstroka = finstroka + PoP();
                                            else
                                                PoP();
                                        }
                                        break;
                                case '('://ТУТ ПРОБЛЕМА 
                                        //надо найти строчку с закрывающей скобкой и удалятьпри ней из стека открывающую
                                        PoP();
                                        finstroka = finstroka + PoP();
                                        while (ownStack.Peek(pntr) != '\n')
                                        {
                                            if (ownStack.Peek(pntr) != '(')
                                                finstroka = finstroka + PoP();
                                            else
                                                PoP();
                                        }
                                        //Пробное решение
                                        break;
                                    default:
                                        //ТУТ ОШИБКА
                                        char z = PoP();
                                        int p = 0;
                                        while (p < functionChar.Length)
                                        {//есть идея о проверке символа на букву, после чего
                                            if (z == functionChar[p][0])
                                            {
                                                string h = "" + z;
                                                for (int y = 0; y < functionChar.Length; y++)
                                                {
                                                    if (SymbolMean[h]==functionString[y])
                                                        finstroka = finstroka + functionString[y].ToUpper();
                                                    
                                                }

                                                p = functionChar.Length;
                                            }
                                            p++;
                                        }

                                        while (ownStack.Peek(pntr) != '\n')
                                        {
                                            if (ownStack.Peek(pntr) != '(')
                                                finstroka = finstroka + PoP();
                                            else
                                                PoP();
                                        }

                                        break;
                                }
                        else
                        {
                                stroka = "";
                                finstroka = "";
                                pntr = 0;
                                ownStack.clearStack();
                            }

                        break;
                    default:
                        oprt = false;
                        int j = 0;
                        while (j < functionChar.Length)
                        {
                                char b = functionChar[j][0];  
                                if (stroka[i] == b)
                            {
                                PusH(stroka[i]);
                                j = functionChar.Length;
                                oprt = true;
                                
                                //else ошибка скобочной структуры
                            }
                            j++;
                        }

                        //Здесь надо совершать проверку на функцию, в противном случае считать переменной
                        if (oprt == false)
                        {
                            //здесь надо перенести данные из словаря в выходную строку
                            // или поместить букву замены в конечную строку
                            if (VariableMean[alphabit[num2]] == 0)
                            {
                                VariableMean[alphabit[num2]] += (int)stroka[i];
                            }
                            else
                            {
                                VariableMean[alphabit[num2]] = (VariableMean[alphabit[num2]] * num) + (int)stroka[i];
                            }
                        }

                        break;
                }

            }
        }
    }
}
