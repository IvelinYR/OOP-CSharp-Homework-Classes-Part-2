namespace Structure
{
    using System.IO;

    public class PathSorage
    {
        public static void SavePath(Path path, string filePath)
        {
            using (var streamWriter = new StreamWriter(filePath))
            {
                foreach (var point in path)
                {
                    streamWriter.WriteLine(point);
                }
            }
        }

        public static Path LodePath(string filePath)
        {
            var path = new Path();
            using (var streamReader = new StreamReader(filePath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Point3D point = Point3D.Parse(line);
                    path.AddPoint(point);
                }
                return path;
            }
        }
    }
}
