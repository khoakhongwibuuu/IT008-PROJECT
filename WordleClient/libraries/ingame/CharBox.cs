using System;
using System.Drawing;
using System.Windows.Forms;

namespace WordleClient.libraries.ingame
{
    // Simple user control that acts as a "box" which can show one character
    // and have its background color changed via the public methods.
    public class CharBox : UserControl
    {
        private readonly Label lbl;

        public CharBox()
        {
            // Initialize label
            lbl = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = false
            };

            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = SystemColors.Window;
            this.Controls.Add(lbl);

            // default size in case caller doesn't set it
            this.Size = new Size(45, 45);
        }

        // Sets the displayed character (single char). Use '\0' or empty char to clear.
        public void SetCharacter(char ch)
        {
            if (ch == '\0')
                lbl.Text = string.Empty;
            else
                lbl.Text = ch.ToString();
        }

        // Sets background color of the box
        public void SetBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        // Optional: expose the label text directly
        public string Character
        {
            get => lbl.Text;
            set => lbl.Text = (string.IsNullOrEmpty(value) ? string.Empty : value[0].ToString());
        }
    }
}
