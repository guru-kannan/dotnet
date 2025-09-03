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
  public Circle(Point center, double radius, string Color, int BorderWidth)
  {
    Center = center;
    Radius = radius;
    this.Color = Color;
    this.BorderWidth = BorderWidth;
  }

  public override void Draw()
  {
    Console.WriteLine($"Drawing Circle at ({Center.X}, {Center.Y}) with radius {Radius}, color {Color}, and border width {BorderWidth}");
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