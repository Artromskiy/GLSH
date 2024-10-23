using GlmSharpGenerator.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlmSharpGenerator.Types
{
    partial class VectorType
    {
		private IEnumerable<Member> ExtendedMembers()
		{

			// predefs
			yield return new StaticProperty("Zero", this)
			{
				Value = Construct(this, ZeroValue.RepeatTimes(Components)),
				Comment = "Predefined all-zero vector"
			};

			if (!string.IsNullOrEmpty(BaseType.OneValue))
			{
				yield return new StaticProperty("Ones", this)
				{
					Value = Construct(this, OneValue.RepeatTimes(Components)),
					Comment = "Predefined all-ones vector"
				};

				for (var c = 0; c < Components; ++c)
				{
					yield return new StaticProperty("Unit" + ArgOfUpper(c), this)
					{
						Value = Construct(this, c.ImpulseString(BaseType.OneValue, ZeroValue, Components)),
						Comment = $"Predefined unit-{ArgOfUpper(c)} vector"
					};
				}
			}

		}

	}
}
