﻿using GLSH.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public class WhileAndDoWhile
    {
        public Vector4 UniformInput;

        [VertexEntryPoint]
        public SystemPosition4 VS()
        {
            SystemPosition4 output;
            output.Position = Vector4.Zero;

            float counter = UniformInput.X;
            do
            {
                output.Position += new Vector4(counter);
            } while (counter-- > 0);

            counter = UniformInput.Y;
            while (counter > 0)
            {
                output.Position -= new Vector4(counter);
                counter -= 1;
            }

            return output;
        }
    }
}
