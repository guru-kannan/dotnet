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
  public Line(Point start, Point end, Color color, int BorderWidth)
  {
    Start = start;
    End = end;
    this.ShapeColor = color;
    this.BorderWidth = BorderWidth;
  }
  public override void Draw()
  {
    Console.WriteLine($"Drawing Line from {Start} to {End}) with color {ShapeColor} and border width {BorderWidth}");
  }
  ~Line()
  {

  }
  public void Dispose()
  {
    GC.SuppressFinalize(this);
  }
}

