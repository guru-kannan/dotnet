namespace Drawing;

public class Line : Shape, IDisposable
{
  public Point Start { get; set; }
  public Point End { get; set; }

  public Line()
  {
    Start = new Point();
    End = new Point();
  }
  public Line(Point start, Point end, string Color, int BorderWidth)
  {
    Start = start;
    End = end;
    this.Color = Color;
    this.BorderWidth = BorderWidth;
  }
  public override void Draw()
  {
    Console.WriteLine($"Drawing Line from ({Start.X}, {Start.Y}) to ({End.X}, {End.Y}) with color {Color} and border width {BorderWidth}");
  }
  ~Line()
  {

  }
  public void Dispose()
  {
    GC.SuppressFinalize(this);
  }
}

