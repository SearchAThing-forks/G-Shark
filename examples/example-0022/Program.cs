using GShark.Core;
using GShark.Geometry;
using Plane = GShark.Geometry.Plane;

using SearchAThing.OpenGL.Nurbs;

namespace example;

// example-0022
// TODO: doc

class Program
{

    static void Main(string[] args)
    {
        InitAvalonia();

        var w = GLWindow.Create(
            onFocusedControlChanged: (split, AvaloniaGLControl, isInitial) =>
            {
                if (isInitial)
                    split.LoadViewLayout();
            }
        );

        GLTriangleFigure? joinFig = null;

        w.GLModel.BuildModel = (glCtl, isInitial) =>
        {
            if (!isInitial) return;

            var glModel = glCtl.GLModel;

            const int JOINT_DIV = 8;
            const int TUBE_DIV = JOINT_DIV;
            const int RAIL_DIVS = 40;

            GShark.Debug.GLModel = glModel;

            glModel.Clear();

            glModel.AddFigure(MakeWCSFigure());

            var tube1 = new Cone(
                baseCS: (WCS * Matrix4x4.CreateRotationX((float)(PI / 2)) * Matrix4x4.CreateRotationZ(-(float)(PI / 4)))
                    .Move(-1f, -1f, 0),
                baseRadius: 1, topRadius: 1, height: 6,
                bottomCap: false, topCap: false).Figure(JOINT_DIV);

            var tube2 = tube1.Mirror(YZCS)!;

            glModel.AddFigure(tube1);
            glModel.AddFigure(tube2);

            glModel.PointLights.Add(new GLPointLight(0, -1, 2));

            // grab tube vertexes near join as profile to sweep

            var profilePts = tube1
                .BuildVertexPosDict(tol: 1e-7f)
                .Select(w => w.Value.First())
                .Where(r => r.Position.Length() < 2).Select(w => w.Position).ToList();
            // var profileCenter = profilePts[0];
            var profileCenter = profilePts.Mean();

            glModel.AddFigure(new GLPointFigure(profilePts).SetColor(Color.Green));

            var railPts = new List<Vector3>();
            {
                var N = RAIL_DIVS;
                var alpha = 0f;
                var alphaStep = (float)(PI / 2 / N);
                var rotCenter = new Vector3(0, -2f, 0);
                for (int i = 0; i < N + 1; ++i)
                {
                    railPts.Add(Vector3.Transform(profileCenter, Matrix4x4.CreateRotationZ(-alpha, rotCenter)));
                    // if (i == 0)
                    //     railPts.Add(Vector3.Transform(profileCenter, Matrix4x4.CreateRotationZ(-alpha - alphaStep/2f, rotCenter)));

                    alpha += alphaStep;
                }
            }

            for (int i = 0; i < railPts.Count; ++i)
            {
                var railPt = railPts[i];
                System.Console.WriteLine($"rail [{i}]: {railPt}");
            }

            for (int i = 0; i < profilePts.Count; ++i)
            {
                var profilePt = profilePts[i];
                System.Console.WriteLine($"profile [{i}]: {profilePt}");
            }

            var sweepNurb = NurbsSurface.FromSweep(
                new NurbsCurve(railPts.ToPoint3().ToList(), 1),
                new NurbsCurve(profilePts.ToPoint3().ToList(), 1));

            var railFig = new GLPointFigure(railPts).SetColor(Color.Yellow);
            glModel.AddFigure(railFig);

            joinFig = sweepNurb.NurbToGL(Color.Red, N: TUBE_DIV).ToFigure();
            glModel.AddFigure(joinFig);

            // glCtl.CameraView(CameraViewType.Top);
            // glCtl.LoadView();
        };

        w.KeyDown += (sender, e) =>
        {
            if (e.Key == Key.Space)
            {
                if (joinFig is not null) joinFig.Visible = !joinFig.Visible;

                w.Invalidate();
            }
        };

        w.ShowSync();
    }

}