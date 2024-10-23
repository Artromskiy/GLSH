using GlmSharpGenerator.Members;
using System.Collections.Generic;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {
        private IEnumerable<Member> RandomFunctions()
        {
            var doubleVType = new VectorType(BuiltinType.TypeDouble, Components);

            if (BaseType.IsBool)
            {
                yield return new Function(this, "Random")
                {
                    Static = true,
                    ParameterString = "Random random, float trueProbability = 0.5f",
                    CodeString = Construct(this, "random.NextDouble() < trueProbability".RepeatTimes(Components)),
                    Comment = $"Returns a {Name} with independent and identically distributed random true/false values (the probability for 'true' can be configured)."
                };
            }
            else if (BaseType.IsInteger)
            {
                yield return new Function(this, "Random")
                {
                    Static = true,
                    ParameterString = "Random random",
                    CodeString = Construct(this, (BaseTypeCast + "random.Next()").RepeatTimes(Components)),
                    Comment = $"Returns a {Name} with independent and identically distributed uniform integer values between 0 (inclusive) and int.MaxValue (exclusive)."
                };

                yield return new ComponentWiseStaticFunction(Fields, this, "Random", this, "maxValue", BaseTypeCast + "random.Next((int){0})")
                {
                    FirstParameter = "Random random",
                    CommentOverride = $"Returns a {Name} with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)"
                };
                yield return new ComponentWiseStaticFunction(Fields, this, "Random", this, "minValue", this, "maxValue", BaseTypeCast + "random.Next((int){0}, (int){1})")
                {
                    FirstParameter = "Random random",
                    CommentOverride = $"Returns a {Name} with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)"
                };
                yield return new ComponentWiseStaticFunction(Fields, this, "RandomUniform", this, "minValue", this, "maxValue", BaseTypeCast + "random.Next((int){0}, (int){1})")
                {
                    FirstParameter = "Random random",
                    CommentOverride = $"Returns a {Name} with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)"
                };

                yield return new ComponentWiseStaticFunction(Fields, this, "RandomPoisson", doubleVType, "lambda", BaseTypeCast + "{0}.GetPoisson(random)")
                {
                    DisableGlmGen = BaseType != BuiltinType.TypeInt,
                    FirstParameter = "Random random",
                    CommentOverride = $"Returns a {Name} with independent and identically distributed integer values according to a poisson distribution with given lambda parameter."
                };

                // TODO: http://en.wikipedia.org/wiki/Bernoulli_distribution
                // TODO: http://en.wikipedia.org/wiki/Binomial_distribution
                // TODO: http://en.wikipedia.org/wiki/Geometric_distribution
                // TODO: http://en.wikipedia.org/wiki/Negative_binomial_distribution
            }
            else if (BaseType.IsFloatingPoint)
            {
                yield return new Function(this, "Random")
                {
                    Static = true,
                    ParameterString = "Random random",
                    CodeString = Construct(this, (BaseTypeCast + "random.NextDouble()").RepeatTimes(Components)),
                    Comment = $"Returns a {Name} with independent and identically distributed uniform values between 0.0 and 1.0."
                };
                yield return new Function(this, "RandomSigned")
                {
                    Static = true,
                    ParameterString = "Random random",
                    CodeString = Construct(this, (BaseTypeCast + "(random.NextDouble() * 2.0 - 1.0)").RepeatTimes(Components)),
                    Comment = $"Returns a {Name} with independent and identically distributed uniform values between -1.0 and 1.0."
                };

                // uniform
                yield return new ComponentWiseStaticFunction(Fields, this, "Random", this, "minValue", this, "maxValue", BaseTypeCast + "random.NextDouble() * ({1} - {0}) + {0}")
                {
                    FirstParameter = "Random random",
                    CommentOverride = $"Returns a {Name} with independent and identically distributed uniform values between 'minValue' and 'maxValue'."
                };
                yield return new ComponentWiseStaticFunction(Fields, this, "RandomUniform", this, "minValue", this, "maxValue", BaseTypeCast + "random.NextDouble() * ({1} - {0}) + {0}")
                {
                    FirstParameter = "Random random",
                    CommentOverride = $"Returns a {Name} with independent and identically distributed uniform values between 'minValue' and 'maxValue'."
                };

                // normal, gaussian
                yield return new Function(this, "RandomNormal")
                {
                    Static = true,
                    ParameterString = "Random random",
                    CodeString = Construct(this, (BaseTypeCast + "(Math.Cos(2 * Math.PI * random.NextDouble()) * Math.Sqrt(-2.0 * Math.Log(random.NextDouble())))").RepeatTimes(Components)),
                    Comment = $"Returns a {Name} with independent and identically distributed values according to a normal distribution (zero mean, unit variance)."
                };
                yield return new ComponentWiseStaticFunction(Fields, this, "RandomNormal", this, "mean", this, "variance",
                    BaseTypeCast + "(Math.Sqrt((double){1}) * Math.Cos(2 * Math.PI * random.NextDouble()) * Math.Sqrt(-2.0 * Math.Log(random.NextDouble()))) + {0}")
                {
                    FirstParameter = "Random random",
                    CommentOverride = $"Returns a {Name} with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance."
                };
                yield return new ComponentWiseStaticFunction(Fields, this, "RandomGaussian", this, "mean", this, "variance",
                    BaseTypeCast + "(Math.Sqrt((double){1}) * Math.Cos(2 * Math.PI * random.NextDouble()) * Math.Sqrt(-2.0 * Math.Log(random.NextDouble()))) + {0}")
                {
                    FirstParameter = "Random random",
                    CommentOverride = $"Returns a {Name} with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance."
                };
            }
        }
    }
}
