namespace employees;
class RoleManagement : ICrudOperation<Role>
{
    IHandleData<Role>? roleData = null;
    private IValidation? validator = null;
    public RoleManagement()
    {
        this.validator = new CheckValidations();

        this.roleData = new HandleRoleData();
    }
    public void Delete(string id)
    {
        throw new NotImplementedException();
    }

    public void DisplayById(string id)
    {
        throw new NotImplementedException();
    }

    public void DisplayList()
    {
        List<Role> RoleList = roleData!.GetData();
        Console.WriteLine($"| NAME                 | LOCATION      | DEPARTMENT    |");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine($"                       |               |               |");
        foreach (Role role in RoleList)
            DisplayRole(role);
        if (RoleList.Count == 0)
            Console.WriteLine("No Record Found");
    }
    public void DisplayRole(Role role)
    {
        Console.WriteLine("---------------------------------------------------------");
        // Console.WriteLine($"{role.Id,-10} | {role.Name ,-20} | {role.Location,-13} | {role.Department,-13} |");
        Console.WriteLine($"{role.Name,-20} | {role.Location,-13} | {role.Department,-13} |");
        Console.WriteLine("---------------------------------------------------------");
    }

    public void Edit(string id)
    {
        throw new NotImplementedException();
    }

    public void GetDetails(Role role, bool edit = false)
    {
        bool checkVal;
    // ID:
    //     Console.Write("Enter the Role Id. : ");
    //     role.Id = Console.ReadLine();
    //     checkVal = CheckValidations.Validation(role.Id, "id");
    //     if (!checkVal)
    //         goto ID;

    Name:
        Console.Write("Enter  Role name : ");
        role.Name = Console.ReadLine();
        checkVal = validator!.Validation(role.Name!, "name");
        if (!checkVal)
            goto Name;

        Location:
        Console.Write("Enter the Location : ");
        role.Location = Console.ReadLine();
        checkVal = validator.Validation(role.Location!, "Location");
        if (!checkVal)
            goto Location;

        Department:
        Console.Write("Enter the Department : ");
        role.Department = Console.ReadLine();
        checkVal = validator.Validation(role.Department!, "department");
        if (!checkVal)
            goto Department;


        List<Role> RoleList = roleData!.GetData();
        RoleList.Add(role);
        roleData.Upsert(RoleList);
        Console.WriteLine("Role Added Successfully");
    }
}