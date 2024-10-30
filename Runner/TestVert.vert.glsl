#version 450
#extension GL_ARB_separate_shader_objects : enable
#extension GL_ARB_shading_language_420pack : enable
struct Runner_Some_StupidNamespace_MinExample_VertexInput
{
    vec3 Position;
    vec2 TextureCoord;
};
struct Runner_Some_StupidNamespace_MinExample_FragmentInput
{
    vec4 Position;
    vec2 TextureCoord;
};
struct Runner_Some_StupidNamespace_MinExample_TestStruct
{
    vec2 field;
    vec2 AutoProp;
};
void Runner_Some_StupidNamespace_MinExample_TestStruct_set_Prop(inout Runner_Some_StupidNamespace_MinExample_TestStruct this,   vec2 value)
{
     this.field = value;
}
vec2 Runner_Some_StupidNamespace_MinExample_TestStruct_get_Prop(inout Runner_Some_StupidNamespace_MinExample_TestStruct this)
{
    return this.field;
}
void Runner_Some_StupidNamespace_MinExample_TestStruct_SetMethod(inout Runner_Some_StupidNamespace_MinExample_TestStruct this,   vec2 val)
{
    this.field = val;
}
void Runner_Some_StupidNamespace_MinExample_TestStruct_SetMethodAutoProp(inout Runner_Some_StupidNamespace_MinExample_TestStruct this,   vec2 val)
{
    this.AutoProp = val;
}
void Runner_Some_StupidNamespace_MinExample_TestStruct_SetMethodProp(inout Runner_Some_StupidNamespace_MinExample_TestStruct this,   vec2 val)
{
    Runner_Some_StupidNamespace_MinExample_TestStruct_set_Prop(inout this, val);
}
vec2 Runner_Some_StupidNamespace_MinExample_TestStruct_GetMethod(inout Runner_Some_StupidNamespace_MinExample_TestStruct this)
{
    return this.field;
}
vec2 Runner_Some_StupidNamespace_MinExample_TestStruct_GetMethodAutoProp(inout Runner_Some_StupidNamespace_MinExample_TestStruct this)
{
    return this.AutoProp;
}
vec2 Runner_Some_StupidNamespace_MinExample_TestStruct_GetMethodProp(inout Runner_Some_StupidNamespace_MinExample_TestStruct this)
{
    return Runner_Some_StupidNamespace_MinExample_TestStruct_get_Prop(inout this);
}
