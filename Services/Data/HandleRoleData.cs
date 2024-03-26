using Newtonsoft.Json;
namespace employees;


class HandleRoleData: IHandleData<Role>
{
    public  List<Role> GetData()
    {
        using StreamReader reader = new("./db/RolesDetail.json");
        var json = reader.ReadToEnd();
        List<Role>? Roles = JsonConvert.DeserializeObject<List<Role>>(json);
        return Roles!;
    }
    public  void Upsert(List<Role> roleList)
    {
        string json = JsonConvert.SerializeObject(roleList);
        File.WriteAllText(@"./db/RolesDetail.json", json);
    }

}