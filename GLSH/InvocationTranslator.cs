using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLSH;

public delegate string InvocationTranslator(string typeName, string methodName, InvocationParameterInfo[] parameters);
