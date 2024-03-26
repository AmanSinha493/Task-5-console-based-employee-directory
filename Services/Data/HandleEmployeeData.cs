using Newtonsoft.Json;
namespace employees;


class HandleEmployeeData:IHandleData<Employee>
{
    public  List<Employee> GetData()
    {
        using StreamReader reader = new("./db/EmployeesDetail.json");
        var json = reader.ReadToEnd();
        List<Employee>? Employees = JsonConvert.DeserializeObject<List<Employee>>(json);
        // List<Employee>? Employees = JsonSerializer.Deserialize<List<Employee>>(json);
        return Employees!;
    }
    public  void Upsert(List<Employee> empList)
    {
        string json = JsonConvert.SerializeObject(empList);
        File.WriteAllText(@"./db/EmployeesDetail.json", json);
    }
}