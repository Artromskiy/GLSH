#version 450

#extension GL_ARB_separate_shader_objects : enable
#extension GL_ARB_shading_language_420pack : enable

// Structs
struct Runner_VertexInput
{
    vec3 position;
    vec2 textureCoord;
}
struct Runner_TestStruct
{
    vec2 field;
    vec2 AutoProp;
}
struct Runner_TestStruct2
{
    Runner_TestStruct field;
    Runner_TestStruct AutoProp;
}
struct Runner_TestStruct3
{
    Runner_TestStruct f;
    float f2;
    Runner_TestStruct2 ts;
}
struct Runner_FragmentInput
{
    vec4 Position;
    vec2 TextureCoord;
}
// Defaults
Runner_VertexInput Runner_VertexInput_default()
{
    Runner_VertexInput glsh_this;
    glsh_this.position = vec3(0);
    glsh_this.textureCoord = vec2(0);
    return glsh_this;
}

Runner_TestStruct Runner_TestStruct_default()
{
    Runner_TestStruct glsh_this;
    glsh_this.field = vec2(0);
    glsh_this.AutoProp = vec2(0);
    return glsh_this;
}

Runner_TestStruct2 Runner_TestStruct2_default()
{
    Runner_TestStruct2 glsh_this;
    glsh_this.field = Runner_TestStruct_default();
    glsh_this.AutoProp = Runner_TestStruct_default();
    return glsh_this;
}

Runner_TestStruct3 Runner_TestStruct3_default()
{
    Runner_TestStruct3 glsh_this;
    glsh_this.f = Runner_TestStruct_default();
    glsh_this.f2 = 0f;
    glsh_this.ts = Runner_TestStruct2_default();
    return glsh_this;
}

Runner_FragmentInput Runner_FragmentInput_default()
{
    Runner_FragmentInput glsh_this;
    glsh_this.Position = vec4(0);
    glsh_this.TextureCoord = vec2(0);
    return glsh_this;
}

// Methods

Runner_TestStruct2 Runner_TestStruct2__ctor()
{
    Runner_TestStruct2 glsh_this = Runner_TestStruct2_default();

    return glsh_this;
}


void Runner_TestStruct3__ctor()
{
    Runner_TestStruct3 glsh_this = Runner_TestStruct3_default();
    glsh_this.f = Runner_TestStruct_default();
    glsh_this.f2 = 0;
    glsh_this.ts = Runner_TestStruct2__ctor();

    glsh_this.ts = Runner_TestStruct2__ctor();

    return glsh_this;
}

// Main
Runner_FragmentInput Runner_MinExample_VertexShaderFunc(inout Runner_MinExample glsh_this, Runner_VertexInput input)
{
    Runner_TestStruct3 d = Runner_TestStruct3_default();
    Runner_FragmentInput output = Runner_FragmentInput_default();
    output = Runner_FragmentInput_default();
    d = Runner_TestStruct3__ctor();
    vec4 worldPosition = glsh_this.world * vec4(input.position, 0);
    vec4 viewPosition = glsh_this.view * worldPosition;
    output.Position = glsh_this.projection * viewPosition;
    output.TextureCoord = input.textureCoord;
    return output;

}

