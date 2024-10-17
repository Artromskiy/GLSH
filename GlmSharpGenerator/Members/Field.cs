using GlmSharpGenerator.Types;
using System.Collections.Generic;

namespace GlmSharpGenerator.Members
{
    internal class Field : Member
    {
        /// <summary>
        /// Member type
        /// </summary>
        public AbstractType Type { get; set; }

        /// <summary>
        /// True iff field is readonly
        /// </summary>
        public bool Readonly { get; set; }

        public override string MemberPrefix => base.MemberPrefix + (Readonly ? " readonly" : "");

        public override IEnumerable<string> Lines
        {
            get
            {
                foreach (var line in base.Lines)
                    yield return line;

                yield return $"{MemberPrefix} {Type.NameThat} {Name};";
            }
        }

        public Field(string name, AbstractType type)
        {
            Name = name;
            Type = type;
            Attributes = AbstractType.Version >= 40 ? new[] { "DataMember" } : new string[] { };
        }
    }
}
