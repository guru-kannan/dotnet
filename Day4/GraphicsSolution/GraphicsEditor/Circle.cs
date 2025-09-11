using Drawing;

public class Circle : Shape, IDisposable
{
  public Point Center { get; set; }
  public double Radius { get; set; }

  public Circle()
  {
    Center = new Point();
    Radius = 0.0;
  }
  public Circle(Point center, double radius, Color color, int borderWidth)
  {
    Center = center;
    Radius = radius;
    this.ShapeColor = color;
    this.BorderWidth = borderWidth;
  }

  public override void Draw()
  {
    Console.WriteLine($"Drawing Circle at {Center} with radius {Radius}, color {this.ShapeColor}, and border width {BorderWidth}");
  }

  ~Circle()
  {

  }
  public void Dispose()
  {
    GC.SuppressFinalize(this);
  }
  public void Calculate(out double area, out double circumference)
  {
    area = Math.PI * Radius * Radius;
    circumference = 2 * Math.PI * Radius;
  }
}