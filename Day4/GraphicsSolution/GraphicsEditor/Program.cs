using Drawing;
using System.Collections.Generic;

using (List<Line> lines = new List<Line>())
{
  lines l1 = new lines(new Point { X = 0, Y = 0 }, new Point { X = 10, Y = 10 }, "Red", 2);
  lines l2 = new lines(new Point { X = 20, Y = 20 }, new Point { X = 30, Y = 30 }, "Blue", 3);
  lines.Add(l1);
  lines.Add(l2);
}