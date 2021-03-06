namespace NewtonLibraryManager.Models;

public class DisplayProductModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Language { get; set; }
    public string Category { get; set; }
    public int NrOfCopies { get; set; }
    public decimal Dewey { get; set; }
    public string Description { get; set; }
    public string Isbn { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProductType { get; set; }
    public string Authors { get { 
            if(!String.IsNullOrWhiteSpace(LastName) && !String.IsNullOrWhiteSpace(FirstName))
            {
                return LastName + ", " + FirstName;
            }
            else if(!String.IsNullOrWhiteSpace(FirstName))
            {
                return FirstName;
            }
            else if (!String.IsNullOrWhiteSpace(LastName))
            {
                return LastName;
            }
            else
            {
                return "";
            }
        } }
    public List<string> AuthorsList { get; set; }
    public string DeweyString { get {
            return Dewey.ToString("000.###", new System.Globalization.CultureInfo("en-US"));
        } }
}