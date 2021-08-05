using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace TMTD
{
    interface IColicionable
    {

        public FloatRect GetBounds();
        public void OnColitionStay(IColicionable other);
        public void OnColitionEnter(IColicionable other);
        public void OnColitionExit(IColicionable other);

    }
}
