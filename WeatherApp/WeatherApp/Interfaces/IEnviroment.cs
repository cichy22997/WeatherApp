using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WeatherApp.Interfaces
{
    public interface IEnviroment
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
