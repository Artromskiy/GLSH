using GlmSharpGenerator.Types;

namespace GlmSharpGenerator.Members
{
    internal class ExplicitOperator : Function
    {
        public override string MemberPrefix => base.MemberPrefix + " explicit";
        public override string FunctionName => ReturnType.NameThat;
        public override string ReturnName => "operator";

        public ExplicitOperator(AbstractType type) : base(type, type.Name)
        {
            Static = true;
        }
    }
}
