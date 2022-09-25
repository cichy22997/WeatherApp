using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Core.Enums;

namespace WeatherApp.Extentions
{
    public static class EnumExtentions
    {
        public static string GetContent(this ContentType type)
        {
            switch (type)
            {
                case ContentType.JSON:
                    return "application/json";

                case ContentType.XML:
                    return "application/xml";

                case ContentType.URLENCODED:
                    return "application/x-www-form-urlencoded";

                default:
                    return "";
            }
        }
    }
}
