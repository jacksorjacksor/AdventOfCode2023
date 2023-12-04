public class Coordinates
{
    public int Row {get; set; }
    public int Col { get; set; }
    public Coordinates(int row, int col)
    { 
        Row = row;
        Col = col;
    }

    public string GetId()
    {
        return $"R{Row}C{Col}";
    }
}