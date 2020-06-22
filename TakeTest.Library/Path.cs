using System;
using System.Collections.Generic;

namespace TakeTest.Library
{
    public class Path
    {
        private List<string> vertices;

        public List<string> Vertices
        {
            get {
                if (this.vertices == null)
                    this.vertices = new List<string>();
                return this.vertices;
            }
            set { this.vertices = value; }
        }
        public int TotalDistance { get; set; }
    }
}