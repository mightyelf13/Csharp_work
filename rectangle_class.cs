using System;

public class Rectangle
{
    private readonly (int x, int y) upperLeftCorner;
    private readonly (int x, int y) lowerRightCorner;

    public Rectangle((int x, int y) p, (int x, int y) q)
    {
        upperLeftCorner = p;
        lowerRightCorner = q;
    }

    public (int, int) upperLeft()
    {
        return upperLeftCorner;
    }

    public (int, int) lowerRight()
    {
        return lowerRightCorner;
    }

    public string str()
    {
        return $"({upperLeftCorner.Item1}, {upperLeftCorner.Item2}) - ({lowerRightCorner.Item1}, {lowerRightCorner.Item2})";
    }

    public int perimeter()
    {
        int width = Math.Abs(lowerRightCorner.Item1 - upperLeftCorner.Item1);
        int height = Math.Abs(lowerRightCorner.Item2 - upperLeftCorner.Item2);
        return 2 * (width + height);
    }

    public int area()
    {
        int width = Math.Abs(lowerRightCorner.Item1 - upperLeftCorner.Item1);
        int height = Math.Abs(lowerRightCorner.Item2 - upperLeftCorner.Item2);
        return width * height;
    }

    public bool contains(Rectangle r)
    {
        return upperLeftCorner.Item1 <= r.upperLeftCorner.Item1 &&
               upperLeftCorner.Item2 <= r.upperLeftCorner.Item2 &&
               lowerRightCorner.Item1 >= r.lowerRightCorner.Item1 &&
               lowerRightCorner.Item2 >= r.lowerRightCorner.Item2;
    }

    public bool overlap(Rectangle r)
    {
        return upperLeftCorner.Item1 < r.lowerRightCorner.Item1 &&
               lowerRightCorner.Item1 > r.upperLeftCorner.Item1 &&
               upperLeftCorner.Item2 < r.lowerRightCorner.Item2 &&
               lowerRightCorner.Item2 > r.upperLeftCorner.Item2;
    }

    public Rectangle intersect(Rectangle r)
    {
        int x1 = Math.Max(upperLeftCorner.Item1, r.upperLeftCorner.Item1);
        int y1 = Math.Max(upperLeftCorner.Item2, r.upperLeftCorner.Item2);
        int x2 = Math.Min(lowerRightCorner.Item1, r.lowerRightCorner.Item1);
        int y2 = Math.Min(lowerRightCorner.Item2, r.lowerRightCorner.Item2);

        if (x1 >= x2 || y1 >= y2)
            return new Rectangle((x1, y1), (x2, y2));
        else
            return new Rectangle((x1, y1), (x2, y2));
    }

}