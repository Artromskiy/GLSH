using GlmSharpGenerator.Members;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {
        public IEnumerable<Member> Constructors()
        {
            // ctors
            yield return new Constructor(this, Fields)
            {
                Parameters = Fields.TypedArgs(BaseType),
                Initializers = Fields,
                Comment = "Component-wise constructor"
            };

            yield return new Constructor(this, Fields)
            {
                ParameterString = BaseTypeName + " v",
                Initializers = "v".RepeatTimes(Components),
                Comment = "all-same-value constructor"
            };

            for (var comps = 2; comps <= 4; ++comps)
            {
                var commentAddition = "";
                if (comps < Components)
                    commentAddition = " (empty fields are zero/false)";
                else if (comps > Components)
                    commentAddition = " (additional fields are truncated)";

                yield return new Constructor(this, Fields)
                {
                    ParameterString = new VectorType(BaseType, comps).NameThat + " v",
                    Initializers = "v".DotComp(comps),
                    Comment = "from-vector constructor" + commentAddition
                };

                for (var ucomps = comps; ucomps < Components; ++ucomps)
                {
                    commentAddition = "";
                    if (ucomps < Components - 1)
                        commentAddition = " (empty fields are zero/false)";

                    yield return new Constructor(this, Fields)
                    {
                        ParameterString = new VectorType(BaseType, comps).NameThat + " v, " + SubCompParameterString(comps, ucomps),
                        Initializers = "v".DotComp(comps).Concat(SubCompArgs(comps, ucomps)),
                        Comment = "from-vector-and-value constructor" + commentAddition
                    };
                }
            }
        }
    }
}
