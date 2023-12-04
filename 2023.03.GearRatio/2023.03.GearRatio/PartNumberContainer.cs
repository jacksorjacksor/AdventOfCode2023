public class PartNumberContainer
{
    public int PartNumber { get; set; }
    public bool IsPartNumber { get; set; }
    public List<Coordinates> ListOfCoordinates { get; set; }

    public PartNumberContainer(int partNumber, bool isPartNumber, List<Coordinates> listOfCoordinates)
    {
        this.PartNumber = partNumber;
        this.IsPartNumber = isPartNumber;
        this.ListOfCoordinates = listOfCoordinates;
    }
}