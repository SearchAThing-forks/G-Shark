global using System.Collections.Generic;
global using Color = System.Drawing.Color;
global using SearchAThing.OpenGL.Core;
global using Line = GShark.Geometry.Line;
global using static System.Math;
global using System.Linq;
global using SearchAThing.OpenGL.Nurbs;
global using static GShark.Debug;
global using GShark.Geometry;


// core
global using SearchAThing.OpenGL.Core;
global using static SearchAThing.OpenGL.Core.Toolkit;
global using static SearchAThing.OpenGL.Core.Constants;

// gui
global using SearchAThing.OpenGL.GUI;
global using static SearchAThing.OpenGL.GUI.Toolkit;
global using static SearchAThing.OpenGL.GUI.Constants;

// shapes
global using SearchAThing.OpenGL.Shapes;
global using static SearchAThing.OpenGL.Shapes.Toolkit;
global using static SearchAThing.OpenGL.Shapes.Constants;

namespace GShark
{

    public static partial class Debug
    {

        public static SearchAThing.OpenGL.Core.GLModel GLModel;

        /// <summary>
        /// G-Shark Point3 to Vector3
        /// </summary>    
        public static System.Numerics.Vector3 ToVector3(this Point3 p) =>
            new System.Numerics.Vector3((float)p.X, (float)p.Y, (float)p.Z);

        /// <summary>
        /// G-Shark Vector3 to Vector3
        /// </summary>    
        public static System.Numerics.Vector3 ToVector3(this in GShark.Geometry.Vector3 p) =>
            new System.Numerics.Vector3((float)p.X, (float)p.Y, (float)p.Z);

        /// <summary>
        /// Vector3 to G-Shark Point3
        /// </summary>
        public static Point3 ToPoint3(this in System.Numerics.Vector3 v) => new Point3(v.X, v.Y, v.Z);

        /// <summary>
        /// Enumerable Vector3 to Enumerable G-Shark Point3
        /// </summary>
        /// <param name="vs">Vector3 enumerable.</param>
        /// <returns>G-Shark Point3 enumerable.</returns>
        public static IEnumerable<Point3> ToPoint3(this IEnumerable<System.Numerics.Vector3> vs) =>
            vs.Select(v => v.ToPoint3());


    }

}