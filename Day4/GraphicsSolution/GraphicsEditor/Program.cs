using Drawing;
using System.Collections.Generic;

using (Line line = new Line())
{
  List<Line> lines = new List<Line>();

  Line l1 = new Line(new Point(12, 56), new Point(350, 100), Color.Red, 2);
  Line l2 = new Line(new Point(100, 200), new Point(300, 400), Color.Blue, 3);
  Line l3 = new Line(new Point(50, 60), new Point(500, 600), Color.Green, 4);

  lines.Add(l1);
  lines.Add(l2);
  lines.Add(l3);
}

