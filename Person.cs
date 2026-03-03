using LABB_4_I_J;

public class person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender PersonGender { get; set; }
    public Hair PersonHair { get; set; }
    public DateTime Birthday { get; set; }
    public string EyeColor { get; set; }

    public override string ToString()
    {
        return $"Namn: {FirstName} {LastName}, Kön: {PersonGender}, Hår: {PersonHair.Color} ({PersonHair.Length}cm), Född: {Birthday.ToShortDateString()}";
    }
}