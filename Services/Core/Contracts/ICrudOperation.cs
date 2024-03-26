namespace employees;
interface ICrudOperation<T>
{
    public void GetDetails(T Type, bool edit = false);
    public void DisplayList();
    public void Delete(string id);
    public void Edit(string id);
    public void DisplayById(string id);
}

// interface ICreateAndRead<T>
// {
//     public void GetDetails(T Type, bool edit = false);
//     public void DisplayList();
// }
// interface IUpdateAndDelete<T>
// {
//     public void Delete(string id);
//     public void Edit(string id);
// }
// interface IReadById<T>
// {
// public void DisplayById(string id);
// }


