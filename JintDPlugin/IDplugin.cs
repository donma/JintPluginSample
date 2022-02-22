using System;
using System.Collections.Generic;
using System.Text;

namespace JintDPlugin
{
    public interface IDplugin
    {
     
        int Version { get; }

        string Name { get; }

        string CallResult(string input);
    }
}
