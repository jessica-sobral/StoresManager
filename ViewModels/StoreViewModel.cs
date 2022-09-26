namespace StoresManager.ViewModels;

public class StoreViewModel
{
    public int Id { get; set; }
    public String Floor { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    public String Type { get; set; }
    public String Email { get; set; }

    public StoreViewModel(int id, string floor, string name, string description, string type, string email)
    {
        Id = id;
        Floor = floor;
        Name = name;
        Description = description;
        Type = type;
        Email = email;
    }
}