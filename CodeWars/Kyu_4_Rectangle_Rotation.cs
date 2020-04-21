using System;
using System.Collections.Generic;
using System.Text;

/*
Task
A rectangle with sides equal to even integers a and b is drawn on the Cartesian plane.
Its center (the intersection point of its diagonals) coincides with the point (0, 0),
but the sides of the rectangle are not parallel to the axes; instead,
they are forming 45 degree angles with the axes.

How many points with integer coordinates are located inside the given
rectangle (including on its sides)?

Example
For a = 6 and b = 4, the output should be 23

The following picture illustrates the example,
and the 23 points are marked green.

Input/Output
[input] integer a

A positive even integer.
Constraints: 2 ≤ a ≤ 10000.
[input] integer b
A positive even integer.
Constraints: 2 ≤ b ≤ 10000.
[output] an integer
The number of inner points with integer coordinates. 
*/
namespace CodeWars
{
    class Kyu_4_Rectangle_Rotation
    {
        public int RectangleRotation(int a, int b)
        {
            double diagonalLength = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            double OA = b / (2 * Math.Cos(Math.PI / 4.0));
            double AB = (a - b) / 2;
            double OB = diagonalLength / 2;
            double[] angleArray = new double[4];
            angleArray[0] = Math.Acos((Math.Pow(OA, 2) + Math.Pow(OB, 2) - Math.Pow(AB, 2)) / (2 * OA * OB));
            angleArray[1] = Math.PI / 2 - angleArray[0];
            angleArray[2] = Math.PI + angleArray[0];
            angleArray[3] = 3 * Math.PI / 2 - angleArray[0];
            List<Point> rectVertices = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                AddPoint(OB, angleArray[i], rectVertices);
            }
            List<LineEquationCoef> rectSides = new List<LineEquationCoef>();
            AddCoef(rectVertices[0], rectVertices[1], rectSides);
            AddCoef(rectVertices[1], rectVertices[2], rectSides);
            AddCoef(rectVertices[2], rectVertices[3], rectSides);
            AddCoef(rectVertices[3], rectVertices[0], rectSides);
            int totalVertices = 0;
            for (int i = (int)rectVertices[2].x - 1; i < (int)rectVertices[0].x + 2; i++)
            {
                if (i <= rectVertices[3].x)
                {
                    int start = GetY(rectSides[2], i);
                    int end = GetY(rectSides[1], i);
                    int result = end - start;
                    if (result > 0)
                        totalVertices += result;
                }
                if (i > rectVertices[3].x && i <= rectVertices[1].x)
                {
                    int start = GetY(rectSides[3], i);
                    int end = GetY(rectSides[1], i);
                    int result = end - start;
                    if (result > 0)
                        totalVertices += result;
                }
                if (i > rectVertices[1].x)
                {
                    int start = GetY(rectSides[3], i);
                    int end = GetY(rectSides[0], i);
                    int result = end - start;
                    if (result > 0)
                        totalVertices += result;
                }
            }
            return totalVertices;
        }
        int GetY(LineEquationCoef coef, int x)
        {
            double toReturn = (coef.kx * x + coef.c);
            return (int)Math.Ceiling(toReturn);
        }
        class Point
        {
            public double x;
            public double y;
        }
        class LineEquationCoef
        {
            public double kx;
            public double c;
        }
        void AddCoef(Point vertex1, Point vertex2, List<LineEquationCoef> equationCoef)
        {
            LineEquationCoef coef = new LineEquationCoef();
            coef.kx = (vertex2.y - vertex1.y) / (vertex2.x - vertex1.x);
            coef.c = (-1 * (vertex1.x * (vertex2.y - vertex1.y) / (vertex2.x - vertex1.x))) + vertex1.y;
            equationCoef.Add(coef);
        }
        void AddPoint(double radius, double angle, List<Point> vertexPoint)
        {
            Point vertex = new Point();
            vertex.x = radius * Math.Cos(angle);
            vertex.y = radius * Math.Sin(angle);
            vertexPoint.Add(vertex);
        }
    }
}
