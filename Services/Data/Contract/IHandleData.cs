namespace employees;

interface IHandleData<T>{
    public List<T> GetData();
    public  void Upsert(List<T> List);
}
