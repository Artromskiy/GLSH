using GlmSharpGenerator.Types;

namespace GlmSharpGenerator.Members
{
    internal class StaticProperty : Property
    {
        public StaticProperty(string name, AbstractType type) : base(name, type)
        {
            Static = true;
        }
    }
}
