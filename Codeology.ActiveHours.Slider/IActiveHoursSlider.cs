using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeology.ActiveHours.Slider
{
    public interface IActiveHoursSlider
    {
        #region Methods

        ActiveHours Slide();

        Task<ActiveHours> SlideAsync();

        #endregion
    }
}
