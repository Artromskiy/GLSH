﻿using GLSH.Attributes;
using System.Numerics;

namespace Tests.TestAssets.CustomStructResource
{
    public class CustomStructResource
    {
        public CustomBlittableStruct CustomField;
        public Matrix4x4 RegularField;

        [VertexEntryPoint]
        public SystemPosition4 VS(Position4 input)
        {
            input.Position.X += CustomField.F2_4.X;
            input.Position.Y += CustomField.F1_3;
            input.Position.Z -= CustomField.F2_1.Y;
            input.Position.W -= CustomField.F3_0.Z;

            SystemPosition4 output;
            output.Position = input.Position;
            return output;
        }
    }
}
