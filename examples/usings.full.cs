// core ( deps )
global using System;
global using System.Linq;
global using System.Globalization;
global using System.Collections;
global using System.Collections.Generic;
global using System.Collections.ObjectModel;
global using System.Text;
global using System.Text.RegularExpressions;
global using System.IO;
global using System.Diagnostics;
global using System.Threading.Tasks;
global using System.Numerics;
global using System.ComponentModel;
global using System.Runtime.CompilerServices;
global using static System.Math;
global using static System.FormattableString;
global using Vector3 = System.Numerics.Vector3;
global using Color = System.Drawing.Color;
global using Size = System.Drawing.Size;
global using ColorTranslator = System.Drawing.ColorTranslator;
global using System.Reflection;
global using SearchAThing.Ext;
global using static SearchAThing.Ext.Toolkit;

// render ( deps )
global using SkiaSharp;
global using Silk.NET.OpenGL;
global using System.Threading;

// gui ( deps )
global using SearchAThing.Desktop;
global using Avalonia;
global using Avalonia.Input;
global using Point = Avalonia.Point;
global using Avalonia.Media;
global using AColor = Avalonia.Media.Color;
global using ABrush = Avalonia.Media.Brush;
global using Avalonia.Data.Converters;

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

// nurbs
global using SearchAThing.OpenGL.Nurbs;
global using static SearchAThing.OpenGL.Nurbs.Toolkit;