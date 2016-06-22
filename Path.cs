﻿namespace Structure
{
    using System.Collections.Generic;

    public class Path : IEnumerable<Point3D>
    {
        private ICollection<Point3D> points;

        public Path()
        {
            this.points = new HashSet<Point3D>();
        }

        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
        }

        public void RemuvePoint(Point3D point)
        {
            this.points.Remove(point);
        }

        public IEnumerator<Point3D> GetEnumerator()
        {
            return this.points.GetEnumerator();
        }

        System.Collections.IEnumerator
            System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
