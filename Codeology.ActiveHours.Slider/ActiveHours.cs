using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeology.ActiveHours.Slider
{
    public sealed class ActiveHours
    {
        internal ActiveHours(int start, int end)
        {
            Start = start;
            End = end;
        }

        #region Properties

        public int Start { get; }
        public int End { get; }

        #endregion
    }
}
