﻿using GLSH.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public class VectorConstructors
    {
        [VertexEntryPoint]
        private SystemPosition4 VS(Position4 input)
        {
            Vector2 v2 = new Vector2();
            v2 = new Vector2(1);
            v2 = new Vector2(1, 2);

            Vector3 v3 = new Vector3();
            v3 = new Vector3(1);
            v3 = new Vector3(v2, 3);
            v3 = new Vector3(1, 2, 3);

            Vector4 v4 = new Vector4();
            v4 = new Vector4(1);
            v4 = new Vector4(v3, 4);
            v4 = new Vector4(v2, 3, 4);
            v4 = new Vector4(1, 2, 3, 4);

            SystemPosition4 output;
            output.Position = input.Position;
            return output;
        }
    }
}
