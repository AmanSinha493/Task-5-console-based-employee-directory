namespace employees;
public interface IEmployee
{
    string? Id { get; set; }
    string? FName { get; set; }
    string? LName { get; set; }
    string? Email { get; set; }
    string? Location { get; set; }
    string? Department { get; set; }
    string? Role { get; set; }
    string? MobileNo { get; set; }
    string? JoiningDate { get; set; }
    string? Dob { get; set; }
    string? Manager { get; set; }
    string? Project { get; set; }
}
