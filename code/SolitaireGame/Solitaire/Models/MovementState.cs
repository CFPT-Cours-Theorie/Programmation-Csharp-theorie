using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.Models
{
    internal class MovementState
    {
        public bool Movable { get; set; }
        public bool Selectable { get; set; }

        public MovementState(bool movable, bool selectable)
        {
            Movable = movable;
            Selectable = selectable;
        }

        public MovementState()
        {
            Movable = false;
            Selectable = false;
        }
    }
}
