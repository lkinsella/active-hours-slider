using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

namespace Codeology.ActiveHours.Slider
{
    public sealed class ActiveHoursSlider : IActiveHoursSlider
    {
        private const string UxRegistryKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\WindowsUpdate\UX\Settings";
        private const string AuRegistryKey = @"HKLM\Software\Policies\Microsoft\Windows\WindowsUpdate";
        private const string ActiveHoursStartValueName = "ActiveHoursStart";
        private const string ActiveHoursEndValueName = "ActiveHoursEnd";
        private const string SetActiveHoursName = "SetActiveHours";

        #region Static Methods

        private static ActiveHours GetHours()
        {
            int? hoursStart = (int?)Registry.GetValue(UxRegistryKey, ActiveHoursStartValueName, null);
            int? hoursEnd = (int?)Registry.GetValue(UxRegistryKey, ActiveHoursEndValueName, null);

            var result = new ActiveHours(hoursStart ?? -1, hoursEnd ?? -1);

            return result;
        }

        private static void SetHours(int start, int end)
        {
            Registry.SetValue(UxRegistryKey, ActiveHoursStartValueName, start, RegistryValueKind.DWord);
            Registry.SetValue(UxRegistryKey, ActiveHoursEndValueName, end, RegistryValueKind.DWord);

            //Registry.SetValue(AuRegistryKey, ActiveHoursStartValueName, start, RegistryValueKind.DWord);
            //Registry.SetValue(AuRegistryKey, ActiveHoursEndValueName, end, RegistryValueKind.DWord);
            //Registry.SetValue(AuRegistryKey, SetActiveHoursName, 0, RegistryValueKind.DWord);
        }

        #endregion

        #region Methods

        public ActiveHours Slide()
        {
            var now = DateTime.Now;
            var beyondNow = DateTime.Now.AddHours(12);
            //var hours = GetHours();
            //
            // Don't apply if already set to the correct active hours window
            //if ((hours.Start > -1 && hours.Start == now.Hour) && (hours.End > -1 && hours.End == beyondNow.Hour))
            //{
            //    return null;
            //}

            var start = now.Hour;
            var end = beyondNow.Hour;

            SetHours(start, end);

            var result = new ActiveHours(start, end);

            return result;
        }

        public Task<ActiveHours> SlideAsync()
        {
            var result = Slide();

            return Task.FromResult(result);
        }

        #endregion
    }
}
