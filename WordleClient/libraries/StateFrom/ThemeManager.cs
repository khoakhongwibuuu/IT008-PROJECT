using System.Drawing;
using System.Windows.Forms;
using System.Text;
using WordleClient.libraries.CustomControls;
namespace WordleClient.libraries.StateFrom
{
    public static class ThemeManager
    {
        public static void ApplyTheme(Control parent)
        {
            // Define background and foreground based on dark/light mode
            Color backcolor = CustomDarkLight.IsDark ? Color.FromArgb(25, 26, 36) : Color.White;
            Color forecolor = CustomDarkLight.IsDark ? Color.White : Color.Black;

            // CharBox handling (control itself or a child inside a CharBox)
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
                    // Recurse into CharBox children
                    foreach (Control c in parent.Controls)
                    {
                        ApplyTheme(c);
                    }
                    return;
                }
                // Handle CharBox children 
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

            // CustomGroupBox: set its custom BackgroundColor and TextColor,
            // and make any child Label controls match the CharBox-children label color.
            else if (parent.Parent is AlertBox)
            {
                if (parent is CustomGroupBox customGroup)
                {
                    // Group background should match generic backcolor
                    customGroup.BackgroundColor = backcolor;
                    customGroup.BorderColor = forecolor;
                    // Labels inside should match the CharBox child label color (LightGray in dark, Black in light)
                    Color labelColorForGroup = CustomDarkLight.IsDark ? Color.LightGray : Color.Black;
                    customGroup.TextColor = labelColorForGroup;

                    // Apply to inner Label controls and recurse for other children so CharBox/others get themed correctly
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


            // Apply theme to other controls
            parent.BackColor = backcolor;
            parent.ForeColor = forecolor;
            // Recursively apply theme to children of generic controls
            foreach (Control c in parent.Controls)
            {
                ApplyTheme(c);
            }
        }
    }
}