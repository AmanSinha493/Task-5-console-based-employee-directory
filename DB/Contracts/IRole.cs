namespace employees;

interface IRole
{
    string? Name { get; set; }
    string? Location { get; set; }
    string? Department { get; set; }
    string? Description { get; set; }
}