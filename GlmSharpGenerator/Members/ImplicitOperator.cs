using GlmSharpGenerator.Types;

namespace GlmSharpGenerator.Members
{
    internal class ImplicitOperator : Function
    {
        public override string MemberPrefix => base.MemberPrefix + " implicit";
        public override string FunctionName => ReturnType.NameThat;
        public override string ReturnName => "operator";

        public ImplicitOperator(AbstractType type) : base(type, type.Name)
        {
            Static = true;
        }
    }
}
