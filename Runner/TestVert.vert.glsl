#version 450
#extension GL_ARB_separate_shader_objects : enable
#extension GL_ARB_shading_language_420pack : enable
struct Runner_Some_StupidNamespace_MinExample_VertexInput
{
    System_Numerics_Vector3 Position;
    System_Numerics_Vector2 TextureCoord;
    vec3 position;
    vec2 textureCoord;
};
struct Runner_Some_StupidNamespace_MinExample_FragmentInput
{
    System_Numerics_Vector4 Position;
    System_Numerics_Vector2 TextureCoord;
};
struct Runner_Some_StupidNamespace_MinExample_TestStruct
{
    vec2 field;
    vec2 AutoProp;
};
struct Runner_Some_StupidNamespace_MinExample_TestStruct2
{
    Runner_Some_StupidNamespace_MinExample_TestStruct field;
    Runner_Some_StupidNamespace_MinExample_TestStruct AutoProp;
};
void Runner_Some_StupidNamespace_MinExample_TestStruct_set_Prop(inout Runner_Some_StupidNamespace_MinExample_TestStruct this, vec2 value)
{
    this.field = value;
}
vec2 Runner_Some_StupidNamespace_MinExample_TestStruct_get_Prop(inout Runner_Some_StupidNamespace_MinExample_TestStruct this)
{
    return this.field;
}
void Runner_Some_StupidNamespace_MinExample_TestStruct_SetMethod(inout Runner_Some_StupidNamespace_MinExample_TestStruct this, vec2 val)
{
    this.field = val;
}
void Runner_Some_StupidNamespace_MinExample_TestStruct_SetMethodAutoProp(inout Runner_Some_StupidNamespace_MinExample_TestStruct this, vec2 val)
{
    this.AutoProp = val;
}
void Runner_Some_StupidNamespace_MinExample_TestStruct_SetMethodProp(inout Runner_Some_StupidNamespace_MinExample_TestStruct this, vec2 val)
{
    Runner_Some_StupidNamespace_MinExample_TestStruct_set_Prop(this, val);
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
    return Runner_Some_StupidNamespace_MinExample_TestStruct_get_Prop(this);
}
void Runner_Some_StupidNamespace_MinExample_TestStruct2_set_Prop(inout Runner_Some_StupidNamespace_MinExample_TestStruct2 this, vec2 value)
{
    Runner_Some_StupidNamespace_MinExample_TestStruct_set_Prop(this.field, value);
}
vec2 Runner_Some_StupidNamespace_MinExample_TestStruct2_get_Prop(inout Runner_Some_StupidNamespace_MinExample_TestStruct2 this)
{
    return Runner_Some_StupidNamespace_MinExample_TestStruct_get_Prop(this.field);
}
void Runner_Some_StupidNamespace_MinExample_TestStruct2_SetMethod(inout Runner_Some_StupidNamespace_MinExample_TestStruct2 this, vec2 val)
{
    this.field.field = val;
}
void Runner_Some_StupidNamespace_MinExample_TestStruct2_SetMethodMethod(inout Runner_Some_StupidNamespace_MinExample_TestStruct2 this, vec2 val)
{
    Runner_Some_StupidNamespace_MinExample_TestStruct_SetMethod(this.field, val);
}
void Runner_Some_StupidNamespace_MinExample_TestStruct2_SetMethodAutoProp(inout Runner_Some_StupidNamespace_MinExample_TestStruct2 this, vec2 val)
{
    this.field.AutoProp = val;
}
void Runner_Some_StupidNamespace_MinExample_TestStruct2_SetMethodProp(inout Runner_Some_StupidNamespace_MinExample_TestStruct2 this, vec2 val)
{
    Runner_Some_StupidNamespace_MinExample_TestStruct_set_Prop(this.field, val);
}
vec2 Runner_Some_StupidNamespace_MinExample_TestStruct2_GetMethod(inout Runner_Some_StupidNamespace_MinExample_TestStruct2 this)
{
    return this.field.field;
}
vec2 Runner_Some_StupidNamespace_MinExample_TestStruct2_GetMethodAutoProp(inout Runner_Some_StupidNamespace_MinExample_TestStruct2 this)
{
    return this.field.AutoProp;
}
vec2 Runner_Some_StupidNamespace_MinExample_TestStruct2_GetMethodProp(inout Runner_Some_StupidNamespace_MinExample_TestStruct2 this)
{
    return Runner_Some_StupidNamespace_MinExample_TestStruct_get_Prop(this.field);
}
vec2 Runner_Some_StupidNamespace_MinExample_TestStruct2_GetMethodMethod(inout Runner_Some_StupidNamespace_MinExample_TestStruct2 this)
{
    return Runner_Some_StupidNamespace_MinExample_TestStruct_GetMethod(this.field);
}
Runner_Some_StupidNamespace_MinExample_FragmentInput Runner_Some_StupidNamespace_MinExample_VertexShaderFunc(inout Runner_Some_StupidNamespace_MinExample this, Runner_Some_StupidNamespace_MinExample_VertexInput input)
{
    Runner_Some_StupidNamespace_MinExample_FragmentInput output ;
    Runner_Some_StupidNamespace_MinExample_TestStruct ts  = Runner_Some_StupidNamespace_MinExample_TestStruct__ctor();
    ts.AutoProp = vec2(1);
    vec2 b  = ts.AutoProp;
    Runner_Some_StupidNamespace_MinExample_TestStruct_set_Prop(ts, vec2(1));
    b = Runner_Some_StupidNamespace_MinExample_TestStruct_get_Prop(ts);
    Runner_Some_StupidNamespace_MinExample_TestStruct_SetMethod(ts, vec2(1));
    Runner_Some_StupidNamespace_MinExample_TestStruct_SetMethodAutoProp(ts, vec2(1));
    Runner_Some_StupidNamespace_MinExample_TestStruct_SetMethodProp(ts, vec2(1));
    b = Runner_Some_StupidNamespace_MinExample_TestStruct_GetMethod(ts);
    b = Runner_Some_StupidNamespace_MinExample_TestStruct_GetMethodAutoProp(ts);
    b = Runner_Some_StupidNamespace_MinExample_TestStruct_GetMethodProp(ts);
    Runner_Some_StupidNamespace_MinExample_TestStruct2 ts2  = Runner_Some_StupidNamespace_MinExample_TestStruct2__ctor();
    ts2.AutoProp = Runner_Some_StupidNamespace_MinExample_TestStruct__ctor();
    ts = ts2.AutoProp;
    Runner_Some_StupidNamespace_MinExample_TestStruct2_set_Prop(ts2, ts.field);
    ts.field = Runner_Some_StupidNamespace_MinExample_TestStruct2_get_Prop(ts2);
    Runner_Some_StupidNamespace_MinExample_TestStruct2_SetMethod(ts2, vec2(1));
    Runner_Some_StupidNamespace_MinExample_TestStruct2_SetMethodMethod(ts2, vec2(1));
    Runner_Some_StupidNamespace_MinExample_TestStruct2_SetMethodAutoProp(ts2, vec2(1));
    Runner_Some_StupidNamespace_MinExample_TestStruct2_SetMethodProp(ts2, vec2(1));
    b = Runner_Some_StupidNamespace_MinExample_TestStruct2_GetMethod(ts2);
    b = Runner_Some_StupidNamespace_MinExample_TestStruct2_GetMethodAutoProp(ts2);
    b = Runner_Some_StupidNamespace_MinExample_TestStruct2_GetMethodProp(ts2);
    b = Runner_Some_StupidNamespace_MinExample_TestStruct2_GetMethodMethod(ts2);
    Runner_Some_StupidNamespace_MinExample_TestStruct_set_Prop(ts, vec2(1));
    vec4 worldPos  = this.world * vec4(input.position, 1);
    vec4 viewPos  = this.view * worldPos;
    vec4 pos  = this.projection * viewPos;
    System_Numerics_Vector4 worldPosition  = GLSH_ShaderBuiltins_Mul(this.World, System_Numerics_Vector4__ctor(input.Position, 1));
    System_Numerics_Vector4 viewPosition  = GLSH_ShaderBuiltins_Mul(this.View, worldPosition);
    output.Position = GLSH_ShaderBuiltins_Mul(this.Projection, viewPosition);
    output.TextureCoord = input.TextureCoord;
    return output;
}
