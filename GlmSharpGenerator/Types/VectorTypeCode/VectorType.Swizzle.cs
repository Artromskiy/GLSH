using GlmSharpGenerator.Members;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {
        /// <summary>
        /// Refers to GLSL 450 specs.
        /// 5 Operators and Expressions.
        /// 5.5 Vector and Scalar Components and Length.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Member> SwizzleProperties()
        {
            // inline-swizzle XYZW
            foreach (var swizzleBits in InlineSwizzle())
            {
                if (swizzleBits.Count(c => c == '1') < 2)
                    continue; // at least two set

                var swizzle = swizzleBits.Select((c, i) => c == '1' ? ArgOfs(i) : "").Aggregate((s1, s2) => s1 + s2);
                var vecType = new VectorType(BaseType, swizzle.Length);

                yield return new Property(swizzle, vecType)
                {
                    GetterLine = $"return {Construct(vecType, swizzle.Select(c => c.ToString()))};",
                    Setter = swizzle.Select((c, i) => $"{c} = value.{ArgOf(i)};"),
                    Comment = "Gets or sets the specified subset of components."
                };
            }
            // inline-swizzle RGBA
            foreach (var swizzleBits in InlineSwizzle())
            {
                if (swizzleBits.Count(c => c == '1') < 2)
                    continue; // at least two set

                var swizzle = swizzleBits.Select((c, i) => c == '1' ? ArgOfs(i) : "").Aggregate((s1, s2) => s1 + s2);
                var vecType = new VectorType(BaseType, swizzle.Length);

                yield return new Property(ToRgba(swizzle), vecType)
                {
                    GetterLine = $"return {Construct(vecType, swizzle.Select(c => c.ToString()))};",
                    Setter = swizzle.Select((c, i) => $"{c} = value.{ArgOf(i)};"),
                    Comment = "Gets or sets the specified subset of components."
                };
            }
            for (var c = 0; c < Components; ++c)
            {
                yield return new Property("rgba"[c].ToString(), BaseType)
                {
                    GetterLine = $"return {"xyzw"[c]};",
                    SetterLine = $"{"xyzw"[c]} = value;",
                    Comment = "Gets or sets the specified RGBA component."
                };
            }
        }

        private IEnumerable<string> InlineSwizzle(int nr = 0)
        {
            if (nr >= Components)
            {
                yield return "";
                yield break;
            }

            foreach (var sw in InlineSwizzle(nr + 1))
            {
                yield return "0" + sw;
                yield return "1" + sw;
            }
        }
    }
}
