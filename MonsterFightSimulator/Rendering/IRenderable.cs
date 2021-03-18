using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MonsterFightSimulator.Core;

namespace MonsterFightSimulator.Rendering
{
    public interface IRenderable
    {
        string[] Texture { get; set; }
    }
}
