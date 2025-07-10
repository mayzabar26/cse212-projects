﻿using System;
using System.Collections.Generic;
public static class ComplexStack
{
    public static void Main()
    {
        //Adding actions to the stack
        Console.WriteLine(CheckBraces("(a == 3 or (b == 5 and c == 6))"));
        Console.WriteLine(CheckBraces("(students]i].Grade > 80 and students[i].Grade < 90)"));
        Console.WriteLine(CheckBraces("(robot[id + 1].Execute(.Pass() || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))"));
    }

    public static bool CheckBraces(string line)
    {
        var stack = new Stack<char>();
        foreach (var item in line)
        {
            if (item is '(' or '[' or '{')
            {
                stack.Push(item);
            }
            else if (item is ')')
            {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']')
            {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}')
            {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}