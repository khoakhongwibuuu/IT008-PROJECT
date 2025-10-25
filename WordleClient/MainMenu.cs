using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordleClient
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterButtons(MainPanel, new Button[] { singleplayerButton, multiplayerButton });
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            // Center the button inside the form

            CenterButtons(MainPanel, new Button[] { singleplayerButton, multiplayerButton });
        }
        private void CenterButtons(Control container, Button[] buttons)
        {
            int spacing = 10; // space between buttons

            // Calculate total height of all buttons + spacing
            int totalHeight = 0;
            foreach (Button btn in buttons)
                totalHeight += btn.Height;
            totalHeight += spacing * (buttons.Length - 1);

            // Center the group vertically within the container
            int startY = (container.ClientSize.Height - totalHeight) / 2;

            // Position each button
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Left = (container.ClientSize.Width - buttons[i].Width) / 2;
                buttons[i].Top = startY + i * (buttons[i].Height + spacing);
            }
        }


        private void singleplayerButton_Click(object sender, EventArgs e)
        {
            ShowPanel(OptionsPanel);
        }
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ShowPanel(MainPanel);
        }

        private void buttonStartGameSinglePlayer_Click(object sender, EventArgs e)
        {
            ShowPanel(SingleplayerPanel);
            ShowPanel(ToolbarPanel);
            ShowPanel(KeyboardPanel);
        }
        private void buttonReturnFromOptions_Click(object sender, EventArgs e)
        {
            ShowPanel(MainPanel);
        }
        private void ShowPanel(Panel panelToShow)
        {
            // Hide all panels in the main area
            foreach (Control ctrl in MainPanel.Controls)
            {
                if (ctrl is Panel pnl)
                    pnl.Visible = false;
            }
            // Show the one you want
            panelToShow.Visible = true;
            panelToShow.BringToFront(); // ensures it's on top visually
        }


    }
}
