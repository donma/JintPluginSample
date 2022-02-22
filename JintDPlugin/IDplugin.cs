using System;
using System.Collections.Generic;
using System.Text;

namespace JintDPlugin
{
    public interface IDPlugin
    {
     
        int Version { get; }

        string Name { get; }

        string CallResult(string input);
    }
}
