using System;
using System.Text.RegularExpressions;

namespace employees;

class CheckValidations : IValidation
{
    readonly IHandleData<Employee>? employeeData = null;

    public CheckValidations()
    {
        this.employeeData = new HandleEmployeeData();

    }
    public bool Validation(string text, string parameter)
    {

        if (String.IsNullOrEmpty(text))
        {
            Console.WriteLine("This is requried field! ");
            return false;
        }
        bool flag = true;
        switch (parameter)
        {
            case "id":
                List<Employee> employees =employeeData!.GetData();
                string pattern = @"^TZ+\d{4}$";
                Regex rg = new(pattern);
                flag = rg.IsMatch(text!);
                break;
            case "name":
                pattern = @"^[A-Za-z]+$";
                rg = new Regex(pattern);
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
            case "date":
                flag = DateTime.TryParse(text, out DateTime parsedDate);
                break;
        }
        if (!flag)
            Console.WriteLine("Validation Failed");
        return flag;
    }
}

