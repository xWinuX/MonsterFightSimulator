using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MonsterFightSimulator.Core;

namespace MonsterFightSimulator.Rendering
{
    interface IRenderable
    {
        void Render(RenderSurface renderSurface, Vector2<float> position);
    }
}
