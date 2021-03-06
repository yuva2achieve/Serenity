﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Serenity.CodeGenerator.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public partial class EntityScriptForm : RazorGenerator.Templating.RazorTemplateBase
    {
#line hidden
 public dynamic Model { get; set; } 
        public override void Execute()
        {


WriteLiteral("\r\n");



                                                   
    var dotModule = Model.Module == null ? "" : ("." + Model.Module);
    var moduleDot = Model.Module == null ? "" : (Model.Module + ".");

    Func<EntityCodeField, string> gt = (f) => {
        if (f.Type == "String") {
            return "StringEditor";
        }
        else if (f.Type == "Int32" || f.Type == "Int16" || f.Type == "Int64") {
            return "IntegerEditor";
        }
        else if (f.Type == "Single" || f.Type == "Double" || f.Type == "Decimal") {
            return "DecimalEditor";
        }
        else if (f.Type == "DateTime") {
            return "DateEditor";
        }
        else if (f.Type == "Boolean") {
            return "BooleanEditor";
        }
        else
            return "StringEditor";
    };


WriteLiteral("namespace ");


      Write(Model.RootNamespace);


                            Write(dotModule);

WriteLiteral(@"
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class ");


                     Write(Model.ClassName);

WriteLiteral("Form : PrefixedContext\r\n    {\r\n        [InlineConstant] public const string FormK" +
"ey = \"");


                                                    Write(moduleDot);


                                                                Write(Model.ClassName);

WriteLiteral("\";\r\n\r\n        public ");


           Write(Model.ClassName);

WriteLiteral("Form(string idPrefix) : base(idPrefix) {}\r\n\r\n");


 foreach (var x in Model.Fields)
    {
        if (x.Ident != Model.Identity)
        {
WriteLiteral("\r\n        public ");


           Write(gt(x));

WriteLiteral(" ");


                   Write(x.Ident);

WriteLiteral(" { get { return ById<");


                                                 Write(gt(x));

WriteLiteral(">(\"");


                                                            Write(x.Ident);

WriteLiteral("\"); } }");


                                                                                        }
    }

WriteLiteral("\r\n    }\r\n}");


        }
    }
}
#pragma warning restore 1591
