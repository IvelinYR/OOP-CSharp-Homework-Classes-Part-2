namespace Structure
{
    using System;
    using System.Linq;

    public struct Point3D
    {
        private static readonly Point3D pointO = new Point3D() { X = 0, Y = 0, Z = 0 };

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public static Point3D PointO
        {
            get
            {
                return pointO;
            }
        }

        public override string ToString()
        {
            return string.Format("Point ({0}, {1}, {2})", this.X, this.Y, this.Z);
        }

        public static Point3D Parse(string text)
        {
            int openPar = text.IndexOf("(");
            double[] coord = text
                .Substring(openPar + 1, text.Length - openPar - 2)
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .ToArray();

            return new Point3D() { X = coord[0], Y = coord[1], Z = coord[2] };
        }
    }
}
