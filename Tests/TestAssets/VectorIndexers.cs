﻿using GLSH;
using GLSH.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public class VectorIndexers
    {
        [VertexEntryPoint]
        private SystemPosition4 VS(Position4 input)
        {
            Vector2 v2 = new Vector2();
            float f = v2.GetComponent(0);
            v2.SetComponent(1, f);

            Vector3 v3 = new Vector3();
            f = v3.GetComponent(0);
            v3.SetComponent(1, f);

            Vector4 v4 = new Vector4();
            f = v4.GetComponent(0);
            v4.SetComponent(1, f);

            SystemPosition4 output;
            output.Position = input.Position;
            return output;
        }
    }
}
