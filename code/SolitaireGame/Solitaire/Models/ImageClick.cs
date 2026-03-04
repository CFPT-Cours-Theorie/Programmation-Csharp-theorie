using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire.Models
{
    internal class ImageClick : MyImage
    {
        public Action onClick { get; private set; }

        public ImageClick(string name, Action callback) : base(name)
        {
            onClick = callback;
        }
    }
}
