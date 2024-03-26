using System;
namespace employees;
class EmployeeManagement : ICrudOperation<Employee>
{
    readonly IValidation? validator = null;
    readonly IHandleData<Employee>? employeeData = null;
    public EmployeeManagement()
    {
        this.validator = new CheckValidations();
        this.employeeData = new HandleEmployeeData();
    }
    public void Delete(string id)
    {
        List<Employee> employeeList = employeeData!.GetData();
        bool dltFlag = false;
        foreach (Employee employee in employeeList)
        {
            if (employee.Id == id)
            {
                employeeList.Remove(employee);
                employeeData.Upsert(employeeList);
                Console.WriteLine("Employee Deleted Successfully");
                dltFlag = true;
                break;
            }
        }
        if (!dltFlag)
            Console.WriteLine("Employee Not Found");
    }

    public void DisplayById(string id)
    {
        Console.WriteLine($"ID         | NAME                 | EMAIL                | LOCATION      | DEPARTMENT    | ROLE          | DATE          | MANAGER NAME        | PROJECT NAME         |");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine($"           |                      |                      |               |               |               |               |                     |                      |");
        List<Employee> employeeList = employeeData!.GetData();
        bool Flag = false;
        foreach (Employee employee in employeeList)
        {
            if (employee.Id == id)
            {
                DisplayEmployee(employee);
                Flag = true;
                break;
            }
        }
        if (!Flag)
            Console.WriteLine("Employee Not Found");
    }
    public void DisplayEmployee(Employee employee)
    {
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine($"{employee.Id,-10} | {employee.FName + " " + employee.LName,-20} | {employee.Email,-20} | {employee.Location,-13} | {employee.Department,-13} | {employee.Role,-13} | {employee.JoiningDate,-13} | {employee.Manager,-20} | {employee.Project,-20}|");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");

    }

    public void DisplayList()
    {
        List<Employee> employeeList = employeeData!.GetData();
        if (employeeList.Count == 0)
        {
            Console.WriteLine("No Record Found");
            return;
        }
        Console.WriteLine($"ID         | NAME                 | EMAIL                | LOCATION      | DEPARTMENT    | ROLE          | DATE          | MANAGER NAME        | PROJECT NAME         |");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine($"           |                      |                      |               |               |               |               |                     |                      |");
        foreach (Employee employee in employeeList)
            DisplayEmployee(employee);
    }

    public void Edit(string id)
    {
        bool editFlag = false;
        List<Employee> employeeList = employeeData!.GetData();
        foreach (Employee employee in employeeList)
        {
            if (employee.Id == id)
            {
                GetDetails(employee, true);
                editFlag = true;
                employeeData.Upsert(employeeList);
                break;
            }
        }
        if (!editFlag)
            Console.WriteLine("Employee Not Found");
    }

    public void GetDetails(Employee employee, bool edit = false)
    {
        bool checkVal;
        if (!edit)
        {
        ID:
            Console.Write("Enter the Employee No. : ");
            employee.Id = Console.ReadLine();
            checkVal = validator!.Validation(employee.Id!, "id");
            if (!checkVal)
                goto ID;
        }

    Fname:
        Console.Write("Enter the first name : ");
        employee.FName = Console.ReadLine();
        checkVal = validator!.Validation(employee.FName!, "name");
        if (!checkVal)
            goto Fname;

        Lname:
        Console.Write("Enter the last name  : ");
        employee.LName = Console.ReadLine();
        checkVal = validator.Validation(employee.LName!, "name");
        if (!checkVal)
            goto Lname;

        Email:
        Console.Write("Enter the Email      : ");
        employee.Email = Console.ReadLine();
        checkVal = validator.Validation(employee.Email!, "email");
        if (!checkVal)
            goto Email;

        Location:
        Console.Write("Enter the Location : ");
        employee.Location = Console.ReadLine();
        checkVal = validator.Validation(employee.Location!, "Location");
        if (!checkVal)
            goto Location;

        Department:
        Console.Write("Enter the Department : ");
        employee.Department = Console.ReadLine();
        checkVal = validator.Validation(employee.Department!, "department");
        if (!checkVal)
            goto Department;
        Role:
        Console.Write("Enter the Role : ");
        employee.Role = Console.ReadLine();
        checkVal = validator.Validation(employee.Role!, "role");
        if (!checkVal)
            goto Role;
        DOB:
        Console.Write("Enter the Date of Birth (format: dd-mm-yyyy): ");
        employee.Dob = Console.ReadLine();
        checkVal = validator.Validation(employee.Dob!, "date");
        if (!checkVal)
            goto DOB;
        Mobile:
        Console.Write("Enter the Mobile No. : ");
        employee.MobileNo = Console.ReadLine();
        checkVal = validator.Validation(employee.MobileNo!, "mobile");
        if (!checkVal)
            goto Mobile;
        DOJ:
        Console.Write("Enter the Joining Date (format: dd-mm-yyyy): ");
        employee.JoiningDate = Console.ReadLine();
        checkVal = validator.Validation(employee.JoiningDate!, "date");
        if (!checkVal)
            goto DOJ;

        Console.Write("Enter the Manager Name. : ");
        employee.Manager = Console.ReadLine();
        Console.Write("Enter the Project Name : ");
        employee.Project = Console.ReadLine();
        if (!edit)
        {
            List<Employee> employeeList = employeeData!.GetData();

            employeeList.Add(employee);
            employeeData.Upsert(employeeList);
            Console.WriteLine("Employee Added Successfully");
        }
        else
            Console.WriteLine("Employee Updated Successfully");
    }
}
