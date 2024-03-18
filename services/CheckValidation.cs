using System;
using System.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using services.employee;
using System.Text.RegularExpressions;
using Zaria.Core;


namespace employees
{

    internal class CheckValidations
    {
        public static bool Validation(string? text, string parameter)
        {
            if (String.IsNullOrEmpty(text))
            {
                Console.WriteLine("This is requried field! ");
                return false;
            }
            bool flag = true;
            switch (parameter)
            {
                case "name":
                    string pattern = @"^[A-Za-z]+$";
                    Regex rg = new Regex(pattern);
                    flag = rg.IsMatch(text!);
                    break;
                case "email":
                    pattern = @"^[a-zA-Z0-9._]+@[a-zA-Z0-9.]+\.[a-zA-Z]{2,}$";
                    rg = new Regex(pattern);
                    flag = rg.IsMatch(text!);
                    break;
                case "mobile":
                    pattern = @"^[1-9][0-9]{9}$";
                    rg = new Regex(pattern);
                    flag = rg.IsMatch(text!);
                    break;
            }
            if (!flag)
                Console.WriteLine("Validation Failed");
            return flag;
        }
    }

}
