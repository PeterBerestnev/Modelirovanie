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
        Stack<char> myStack = new Stack<char>();//стек реализовать самому
        Dictionary<string, string> FunctionMean = new Dictionary<string, string>();
        Dictionary<string, string> SymbolMean = new Dictionary<string, string>();
        string[] functionString = { "arcsin", "ctg", "sin", "tg" };//эти массивы связаны, должны быть равны по длине и не иметь повторяющихся элементов
        string[] functionChar = { "A", "C", "S", "T" };
        char[] alphabit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 'u', 'v', 'w', 'x', 'y', 'z' };
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
                    if (myStack.Count != 0) 
                    { 
                        char g = myStack.Peek();
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
                            if (myStack.Count != 0)
                            switch (myStack.Peek())
                            {
                                case '+':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '-':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '*':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '/':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '^':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '(':
                                    myStack.Push(stroka[i]);
                                    break;
                               default:
                                        char z = myStack.Pop();
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
                                                myStack.Push(stroka[i]);
                                                char q = myStack.Peek();
                                            }
                                            p++;
                                        }
                                        break;
                            }
                        else
                        {
                            myStack.Push(stroka[i]);
                        }

                        
                        break;
                    case '-':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (myStack.Count != 0)
                            switch (myStack.Peek())
                            {
                                case '+':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '-':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '*':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '/':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '^':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '(':
                                        myStack.Push(stroka[i]);
                                    break;
                                default:
                                        char z = myStack.Pop();
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
                            myStack.Push(stroka[i]);
                        }
                        break;
                    case '*':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (myStack.Count != 0)
                            switch (myStack.Peek())
                            {
                                case '+':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '-':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '*':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '/':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '^':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '(':
                                    myStack.Push(stroka[i]);
                                    break;
                                default:
                                        char z = myStack.Pop();
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
                            myStack.Push(stroka[i]);
                        }
                        break;
                    case '/':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (myStack.Count != 0)
                            switch (myStack.Peek())
                            {
                                case '+':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '-':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '*':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '/':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '^':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '(':
                                    myStack.Push(stroka[i]);
                                    break;
                                default:
                                        char z = myStack.Pop();
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
                            myStack.Push(stroka[i]);
                        }
                        break;
                    case '^':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (myStack.Count != 0)
                            switch (myStack.Peek())
                            {
                                case '+':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '-':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '*':
                                    myStack.Push(stroka[i]);
                                    break;

                                case '/':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '^':
                                    finstroka = finstroka + myStack.Pop();
                                    if (myStack.Count == 0 || myStack.Peek() == '(')//вопрос по взаимодействию со скобками. Надо разобраться!
                                        myStack.Push(stroka[i]);
                                    break;
                                case '(':
                                    myStack.Push(stroka[i]);
                                    break;
                                default:
                                        char z = myStack.Pop();
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
                            myStack.Push(stroka[i]);
                        }
                        break;
                    case '(':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (myStack.Count != 0)
                            switch (myStack.Peek())
                            {
                                case '+':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '-':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '*':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '/':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '^':
                                    myStack.Push(stroka[i]);
                                    break;
                                case '(':
                                    myStack.Push(stroka[i]);
                                    break;
                                default:
                                        char z = myStack.Peek();
                                        int p = 0;
                                        while (p < functionChar.Length)
                                        {//есть идея о проверке символа на букву, после чего
                                            if (z == functionChar[p][0])
                                            {
                                                myStack.Push(stroka[i]);
                                                p = functionChar.Length;
                                            }
                                            p++;
                                        }
                                        break;
                            }
                        else
                        {
                            myStack.Push(stroka[i]);
                        }
                        break;
                    case ')':
                            if (oprt == false)
                            {
                                finstroka += alphabit[num2];
                                num2++;
                            }
                            oprt = true;
                            if (myStack.Count != 0)
                            switch (myStack.Peek())
                            {
                                case '+':
                                        //пока стек не будет равен 0 (но в таком случае нужна ошибка) или пока символ стека не будет равен "(" (но его мы в строку не отпрвляем)
                                        while (myStack.Peek()!='(')
                                        {
                                           if (myStack.Peek() != '(')
                                            finstroka = finstroka + myStack.Pop();
                                        }
                                        myStack.Pop();
                                        break;
                                case '-':
                                        while (myStack.Peek() != '(')
                                        {
                                            if (myStack.Peek() != '(')
                                                finstroka = finstroka + myStack.Pop();
                                        }
                                        myStack.Pop();
                                        break;
                                case '*':
                                        while (myStack.Peek() != '(')
                                        {
                                            if (myStack.Peek() != '(')
                                                finstroka = finstroka + myStack.Pop();
                                        }
                                        myStack.Pop();
                                        break;
                                case '/':
                                        while (myStack.Peek() != '(')
                                        {
                                            if (myStack.Peek() != '(')
                                                finstroka = finstroka + myStack.Pop();
                                        }
                                        myStack.Pop();
                                        break;
                                case '^':
                                        while (myStack.Peek() != '(')
                                        {
                                            if (myStack.Peek() != '(')
                                                finstroka = finstroka + myStack.Pop();
                                        }
                                        myStack.Pop();
                                        break;
                                case '(':
                                        myStack.Pop();
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
                        if (myStack.Count != 0)
                            switch (myStack.Peek())
                            {
                                case '+':
                                    finstroka = finstroka + myStack.Pop();
                                    finstroka += alphabit[num2];
                                        
                                            while (myStack.Count != 0)
                                            {
                                                if(myStack.Peek()!='(')
                                                    finstroka = finstroka + myStack.Pop();
                                                else
                                                    myStack.Pop();
                                            }
                                        
                                        break;
                                case '-':
                                    finstroka = finstroka + myStack.Pop();
                                    finstroka += alphabit[num2];
                                        while (myStack.Count != 0)
                                        {
                                            if (myStack.Peek() != '(')
                                                finstroka = finstroka + myStack.Pop();
                                            else
                                                myStack.Pop();
                                        }
                                        break;
                                case '*':
                                    finstroka = finstroka + myStack.Pop();
                                    finstroka += alphabit[num2];
                                        while (myStack.Count != 0)
                                        {
                                            if (myStack.Peek() != '(')
                                                finstroka = finstroka + myStack.Pop();
                                            else
                                                myStack.Pop();
                                        }
                                        break;
                                case '/':
                                    finstroka = finstroka + myStack.Pop();
                                    finstroka += alphabit[num2];
                                        while (myStack.Count != 0)
                                        {
                                            if (myStack.Peek() != '(')
                                                finstroka = finstroka + myStack.Pop();
                                            else
                                                myStack.Pop();
                                        }
                                        break;
                                case '^':
                                    finstroka = finstroka + myStack.Pop();
                                    finstroka += alphabit[num2];
                                        while (myStack.Count != 0)
                                        {
                                            if (myStack.Peek() != '(')
                                                finstroka = finstroka + myStack.Pop();
                                            else
                                                myStack.Pop();
                                        }
                                        break;
                                case '('://ТУТ ПРОБЛЕМА 
                                        //надо найти строчку с закрывающей скобкой и удалятьпри ней из стека открывающую
                                        myStack.Pop();
                                        finstroka = finstroka + myStack.Pop();
                                        while (myStack.Count != 0)
                                        {
                                            if (myStack.Peek() != '(')
                                                finstroka = finstroka + myStack.Pop();
                                            else
                                                myStack.Pop();
                                        }
                                        //Пробное решение
                                        break;
                                    default:
                                        //ТУТ ОШИБКА
                                        char z = myStack.Pop();
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

                                        while (myStack.Count != 0)
                                        {
                                            if (myStack.Peek() != '(')
                                                finstroka = finstroka + myStack.Pop();
                                            else
                                                myStack.Pop();
                                        }

                                        break;
                                }
                        else
                        {
                               //
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
                                myStack.Push(stroka[i]);
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
