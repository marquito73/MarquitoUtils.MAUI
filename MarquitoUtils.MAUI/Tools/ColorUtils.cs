namespace MarquitoUtils.MAUI.Tools
{
    public static class ColorUtils
    {
        public static Color ConvertColorToMAUIColor(this System.Drawing.Color color)
        {
            return Color.FromRgba($"#{color.R:X2}{color.G:X2}{color.B:X2}{color.A:X2}");
        }

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
    }
}
