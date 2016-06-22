namespace Structure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class StartProgram
    {
        static void Main()
        {
            Console.WriteLine(Point3D.PointO);

            Point3D onePoint = new Point3D() { X = 2, Y = 3, Z = 4 };
            Point3D twoPoint = new Point3D() { X = 3, Y = 1, Z = 5 };
            var distance = Point3DExtention.CalculatedDistance(onePoint, twoPoint);
            Console.WriteLine(distance);

            var path = new Path();
            for (int i = 0; i < 15; i++)
            {
                path.AddPoint(new Point3D() { X = i, Y = i * 3, Z = i + 3 });
            }

            PathSorage.SavePath(path, ".../../path.txt");
            var pathFromFile = PathSorage.LodePath(".../../path.txt");

            foreach (var point in pathFromFile)
            {
                Console.WriteLine(point);
            }
        }
    }
}
