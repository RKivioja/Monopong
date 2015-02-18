using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace monoplatformer
{
    class MenuItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Action<Keys> Action { get; set; }
    }
}
