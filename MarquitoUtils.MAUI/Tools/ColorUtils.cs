namespace MarquitoUtils.MAUI.Tools
{
    /// <summary>
    /// Utils methods about colors, such as converting between System.Drawing.Color and Microsoft.Maui.Graphics.Color, or getting the opposite color based on luminosity.
    /// </summary>
    public static class ColorUtils
    {
        /// <summary>
        /// Get the opposite color
        /// </summary>
        /// <param name="color">The color to find his opposite</param>
        /// <param name="resources">Resources dictionnary to found colors</param>
        /// <param name="lightThemeColorName">Light theme name</param>
        /// <param name="darkThemeColorName">Dark theme name</param>
        /// <returns>The opposite color</returns>
        public static Color GetOppositeColor(this Color color, ResourceDictionary resources,
            string lightThemeColorName, string darkThemeColorName)
        {
            Color oppositeColor;

            if (color.GetLuminosity() > 0.5f)
            {
                oppositeColor = resources.TryGetValue(lightThemeColorName, out object fontColor)
                    ? (Color)fontColor : Colors.Black;
            }
            else
            {
                oppositeColor = resources.TryGetValue(darkThemeColorName, out object fontColor)
                    ? (Color)fontColor : Colors.White;
            }

            return oppositeColor;
        }

        #region Color conversion

        /// <summary>
        /// Convert a System.Drawing.Color to a Microsoft.Maui.Graphics.Color
        /// </summary>
        /// <param name="color">The color to convert</param>
        /// <returns>The color converted to Microsoft.Maui.Graphics.Color</returns>
        public static Color ConvertColorToMAUIColor(this System.Drawing.Color color)
        {
            return Color.FromRgba($"#{color.R:X2}{color.G:X2}{color.B:X2}{color.A:X2}");
        }

        /// <summary>
        /// Convert a Microsoft.Maui.Graphics.Color to a System.Drawing.Color
        /// </summary>
        /// <param name="color">The color to convert</param>
        /// <returns>The color converted to System.Drawing.Color</returns>
        public static System.Drawing.Color ConvertMAUIColorToColor(this Color color)
        {
            int alpha = Math.Clamp((int)Math.Round(color.Alpha * 255f), 0, 255);
            int red = Math.Clamp((int)Math.Round(color.Red * 255f), 0, 255);
            int green = Math.Clamp((int)Math.Round(color.Green * 255f), 0, 255);
            int blue = Math.Clamp((int)Math.Round(color.Blue * 255f), 0, 255);

            return System.Drawing.Color.FromArgb(alpha, red, green, blue);
        }

        #endregion Color conversion
    }
}
