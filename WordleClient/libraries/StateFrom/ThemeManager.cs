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
            // Handle CharBox controls and their children
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