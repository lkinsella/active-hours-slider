using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Codeology.ActiveHours.Slider
{
    public sealed partial class Service : ServiceBase
    {
        private readonly CancellationTokenSource _cts;
        private readonly IActiveHoursSlider _slider;

        public Service()
        {
            InitializeComponent();

            _cts = new CancellationTokenSource();
            _slider = new ActiveHoursSlider();

            Disposed += OnDisposed;
        }

        #region Methods

        protected override void OnStart(string[] args)
        {
            Task.Run(async () =>
            {
                try
                {
                    while (!_cts.IsCancellationRequested)
                    {
                        await _slider.SlideAsync();
                        await Task.Delay(TimeSpan.FromHours(4), _cts.Token);
                    }
                }
                catch (TaskCanceledException)
                {
                    // Do nothing...
                }
            });
        }

        protected override void OnStop()
        {
            _cts.Cancel();
        }

        private void OnDisposed(object sender, EventArgs e)
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        #endregion
    }
}
