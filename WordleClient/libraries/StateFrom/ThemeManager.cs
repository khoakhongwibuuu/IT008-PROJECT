using WordleClient.libraries.CustomControls;

namespace WordleClient.libraries.StateFrom
{
    public static class ThemeManager
    {
        public static void ApplyTheme(Control parent)
        {
            Color backcolor = CustomDarkLight.IsDark ? Color.FromArgb(25, 26, 36) : Color.White;
            Color forecolor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            if (parent is CharBox || parent.Parent is CharBox)
            {
                if (parent is CharBox)
                {
                    if (CustomDarkLight.IsDark)
                    {
                        parent.BackColor = Color.FromArgb(110, 123, 152);
                    }
                    else
                    {
                        parent.BackColor = Color.LightGray;
                    }
                    foreach (Control c in parent.Controls)
                    {
                        ApplyTheme(c);
                    }
                    return;
                }
                if (parent.Parent is CharBox)
                {
                    if (CustomDarkLight.IsDark)
                    {
                        parent.ForeColor = Color.LightGray;
                    }
                    else
                    {
                        parent.ForeColor = Color.Black;
                    }
                    return;
                }
            }
            else if (parent.Parent is AlertBox)
            {
                if (parent is CustomGroupBox customGroup)
                {
                    customGroup.BackgroundColor = backcolor;
                    customGroup.BorderColor = forecolor;
                    Color labelColorForGroup = CustomDarkLight.IsDark ? Color.LightGray : Color.Black;
                    customGroup.TextColor = labelColorForGroup;
                    foreach (Control c in customGroup.Controls)
                    {
                        if (c is Label)
                        {
                            c.ForeColor = labelColorForGroup;
                        }
                        else
                        {
                            ApplyTheme(c);
                        }
                    }
                    return;
                }
            }
            parent.BackColor = backcolor;
            parent.ForeColor = forecolor;
            foreach (Control c in parent.Controls)
            {
                ApplyTheme(c);
            }
        }
    }
}