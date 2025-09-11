namespace Drawing;

public enum Color
{
  Red,
  Green,
  Blue,
  Yellow,
  Black,
  White
}

public abstract class Shape
{
  public Color ShapeColor { get; set; }
  public int BorderWidth { get; set; }
  public abstract void Draw();
}