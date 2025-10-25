namespace WordleClient
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainPanel = new Panel();
            singleplayerButton = new Button();
            multiplayerButton = new Button();
            KeyboardPanel = new Panel();
            KeyboardRow3 = new TableLayoutPanel();
            buttonEnter = new Button();
            buttonZ = new Button();
            buttonX = new Button();
            buttonC = new Button();
            buttonV = new Button();
            buttonB = new Button();
            buttonN = new Button();
            buttonM = new Button();
            buttonBackspace = new Button();
            KeyboardRow2 = new TableLayoutPanel();
            buttonA = new Button();
            buttonS = new Button();
            buttonD = new Button();
            buttonF = new Button();
            buttonG = new Button();
            buttonH = new Button();
            buttonJ = new Button();
            buttonK = new Button();
            buttonL = new Button();
            KeyboardRow1 = new TableLayoutPanel();
            buttonQ = new Button();
            buttonW = new Button();
            buttonE = new Button();
            buttonR = new Button();
            buttonT = new Button();
            buttonY = new Button();
            buttonU = new Button();
            buttonI = new Button();
            buttonO = new Button();
            buttonP = new Button();
            ToolbarPanel = new Panel();
            buttonReturn = new Button();
            buttonIdea = new Button();
            buttonStats = new Button();
            buttonHelp = new Button();
            buttonSetting = new Button();
            SingleplayerPanel = new Panel();
            MultiplayerPanel = new Panel();
            OptionsPanel = new Panel();
            buttonStartGameSinglePlayer = new Button();
            buttonReturnFromOptions = new Button();
            DifficultyPanel = new Panel();
            labelDifficulty = new Label();
            radioButtonRandom = new RadioButton();
            radioButtonEasy = new RadioButton();
            radioButtonHard = new RadioButton();
            NumAttemptsPanel = new Panel();
            labelNum8 = new Label();
            labelNum6 = new Label();
            labelNum7 = new Label();
            trackBarAttempts = new TrackBar();
            labelNumAttempts = new Label();
            comboBoxTopic = new ComboBox();
            labelTopic = new Label();
            MainPanel.SuspendLayout();
            KeyboardPanel.SuspendLayout();
            KeyboardRow3.SuspendLayout();
            KeyboardRow2.SuspendLayout();
            KeyboardRow1.SuspendLayout();
            ToolbarPanel.SuspendLayout();
            OptionsPanel.SuspendLayout();
            DifficultyPanel.SuspendLayout();
            NumAttemptsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarAttempts).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(singleplayerButton);
            MainPanel.Controls.Add(multiplayerButton);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Margin = new Padding(3, 4, 3, 4);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(800, 562);
            MainPanel.TabIndex = 70;
            // 
            // singleplayerButton
            // 
            singleplayerButton.AutoSize = true;
            singleplayerButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            singleplayerButton.Location = new Point(346, 189);
            singleplayerButton.Margin = new Padding(3, 4, 3, 4);
            singleplayerButton.Name = "singleplayerButton";
            singleplayerButton.Size = new Size(101, 30);
            singleplayerButton.TabIndex = 43;
            singleplayerButton.Text = "Singleplayer";
            singleplayerButton.UseVisualStyleBackColor = true;
            singleplayerButton.Click += singleplayerButton_Click;
            // 
            // multiplayerButton
            // 
            multiplayerButton.AutoSize = true;
            multiplayerButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            multiplayerButton.Location = new Point(353, 229);
            multiplayerButton.Margin = new Padding(3, 4, 3, 4);
            multiplayerButton.Name = "multiplayerButton";
            multiplayerButton.Size = new Size(94, 30);
            multiplayerButton.TabIndex = 42;
            multiplayerButton.Text = "Multiplayer";
            multiplayerButton.UseVisualStyleBackColor = true;
            // 
            // KeyboardPanel
            // 
            KeyboardPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            KeyboardPanel.Controls.Add(KeyboardRow3);
            KeyboardPanel.Controls.Add(KeyboardRow2);
            KeyboardPanel.Controls.Add(KeyboardRow1);
            KeyboardPanel.Location = new Point(-2, 354);
            KeyboardPanel.Margin = new Padding(3, 4, 3, 4);
            KeyboardPanel.Name = "KeyboardPanel";
            KeyboardPanel.Size = new Size(800, 208);
            KeyboardPanel.TabIndex = 73;
            // 
            // KeyboardRow3
            // 
            KeyboardRow3.ColumnCount = 9;
            KeyboardRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            KeyboardRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            KeyboardRow3.Controls.Add(buttonEnter, 0, 0);
            KeyboardRow3.Controls.Add(buttonZ, 1, 0);
            KeyboardRow3.Controls.Add(buttonX, 2, 0);
            KeyboardRow3.Controls.Add(buttonC, 3, 0);
            KeyboardRow3.Controls.Add(buttonV, 4, 0);
            KeyboardRow3.Controls.Add(buttonB, 5, 0);
            KeyboardRow3.Controls.Add(buttonN, 6, 0);
            KeyboardRow3.Controls.Add(buttonM, 7, 0);
            KeyboardRow3.Controls.Add(buttonBackspace, 8, 0);
            KeyboardRow3.Location = new Point(9, 142);
            KeyboardRow3.Margin = new Padding(3, 4, 3, 4);
            KeyboardRow3.Name = "KeyboardRow3";
            KeyboardRow3.RowCount = 1;
            KeyboardRow3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            KeyboardRow3.Size = new Size(761, 65);
            KeyboardRow3.TabIndex = 2;
            // 
            // buttonEnter
            // 
            buttonEnter.Location = new Point(3, 4);
            buttonEnter.Margin = new Padding(3, 4, 3, 4);
            buttonEnter.Name = "buttonEnter";
            buttonEnter.Size = new Size(75, 29);
            buttonEnter.TabIndex = 31;
            buttonEnter.Text = "Enter";
            buttonEnter.UseVisualStyleBackColor = true;
            // 
            // buttonZ
            // 
            buttonZ.BackColor = Color.White;
            buttonZ.Location = new Point(117, 4);
            buttonZ.Margin = new Padding(3, 4, 3, 4);
            buttonZ.Name = "buttonZ";
            buttonZ.Size = new Size(43, 57);
            buttonZ.TabIndex = 24;
            buttonZ.Text = "Z";
            buttonZ.UseVisualStyleBackColor = false;
            // 
            // buttonX
            // 
            buttonX.BackColor = Color.White;
            buttonX.Location = new Point(193, 4);
            buttonX.Margin = new Padding(3, 4, 3, 4);
            buttonX.Name = "buttonX";
            buttonX.Size = new Size(43, 57);
            buttonX.TabIndex = 25;
            buttonX.Text = "X";
            buttonX.UseVisualStyleBackColor = false;
            // 
            // buttonC
            // 
            buttonC.BackColor = Color.White;
            buttonC.Location = new Point(269, 4);
            buttonC.Margin = new Padding(3, 4, 3, 4);
            buttonC.Name = "buttonC";
            buttonC.Size = new Size(43, 57);
            buttonC.TabIndex = 26;
            buttonC.Text = "C";
            buttonC.UseVisualStyleBackColor = false;
            // 
            // buttonV
            // 
            buttonV.BackColor = Color.White;
            buttonV.Location = new Point(345, 4);
            buttonV.Margin = new Padding(3, 4, 3, 4);
            buttonV.Name = "buttonV";
            buttonV.Size = new Size(43, 57);
            buttonV.TabIndex = 27;
            buttonV.Text = "V";
            buttonV.UseVisualStyleBackColor = false;
            // 
            // buttonB
            // 
            buttonB.BackColor = Color.White;
            buttonB.Location = new Point(421, 4);
            buttonB.Margin = new Padding(3, 4, 3, 4);
            buttonB.Name = "buttonB";
            buttonB.Size = new Size(43, 57);
            buttonB.TabIndex = 28;
            buttonB.Text = "B";
            buttonB.UseVisualStyleBackColor = false;
            // 
            // buttonN
            // 
            buttonN.BackColor = Color.White;
            buttonN.Location = new Point(497, 4);
            buttonN.Margin = new Padding(3, 4, 3, 4);
            buttonN.Name = "buttonN";
            buttonN.Size = new Size(43, 57);
            buttonN.TabIndex = 29;
            buttonN.Text = "N";
            buttonN.UseVisualStyleBackColor = false;
            // 
            // buttonM
            // 
            buttonM.BackColor = Color.White;
            buttonM.Location = new Point(573, 4);
            buttonM.Margin = new Padding(3, 4, 3, 4);
            buttonM.Name = "buttonM";
            buttonM.Size = new Size(43, 57);
            buttonM.TabIndex = 30;
            buttonM.Text = "M";
            buttonM.UseVisualStyleBackColor = false;
            // 
            // buttonBackspace
            // 
            buttonBackspace.Location = new Point(649, 4);
            buttonBackspace.Margin = new Padding(3, 4, 3, 4);
            buttonBackspace.Name = "buttonBackspace";
            buttonBackspace.Size = new Size(75, 29);
            buttonBackspace.TabIndex = 60;
            buttonBackspace.Text = "⌫";
            buttonBackspace.UseVisualStyleBackColor = true;
            // 
            // KeyboardRow2
            // 
            KeyboardRow2.ColumnCount = 9;
            KeyboardRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.11111F));
            KeyboardRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.11111F));
            KeyboardRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.11111F));
            KeyboardRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.11111F));
            KeyboardRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.11111F));
            KeyboardRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.11111F));
            KeyboardRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.11111F));
            KeyboardRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.11111F));
            KeyboardRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.11111F));
            KeyboardRow2.Controls.Add(buttonA, 0, 0);
            KeyboardRow2.Controls.Add(buttonS, 1, 0);
            KeyboardRow2.Controls.Add(buttonD, 2, 0);
            KeyboardRow2.Controls.Add(buttonF, 3, 0);
            KeyboardRow2.Controls.Add(buttonG, 4, 0);
            KeyboardRow2.Controls.Add(buttonH, 5, 0);
            KeyboardRow2.Controls.Add(buttonJ, 6, 0);
            KeyboardRow2.Controls.Add(buttonK, 7, 0);
            KeyboardRow2.Controls.Add(buttonL, 8, 0);
            KeyboardRow2.Location = new Point(9, 78);
            KeyboardRow2.Margin = new Padding(3, 4, 3, 4);
            KeyboardRow2.Name = "KeyboardRow2";
            KeyboardRow2.RowCount = 1;
            KeyboardRow2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            KeyboardRow2.Size = new Size(761, 65);
            KeyboardRow2.TabIndex = 1;
            // 
            // buttonA
            // 
            buttonA.BackColor = Color.White;
            buttonA.Location = new Point(3, 4);
            buttonA.Margin = new Padding(3, 4, 3, 4);
            buttonA.Name = "buttonA";
            buttonA.Size = new Size(43, 57);
            buttonA.TabIndex = 15;
            buttonA.Text = "A";
            buttonA.UseVisualStyleBackColor = false;
            // 
            // buttonS
            // 
            buttonS.BackColor = Color.White;
            buttonS.Location = new Point(87, 4);
            buttonS.Margin = new Padding(3, 4, 3, 4);
            buttonS.Name = "buttonS";
            buttonS.Size = new Size(43, 57);
            buttonS.TabIndex = 16;
            buttonS.Text = "S";
            buttonS.UseVisualStyleBackColor = false;
            // 
            // buttonD
            // 
            buttonD.BackColor = Color.White;
            buttonD.Location = new Point(171, 4);
            buttonD.Margin = new Padding(3, 4, 3, 4);
            buttonD.Name = "buttonD";
            buttonD.Size = new Size(43, 57);
            buttonD.TabIndex = 17;
            buttonD.Text = "D";
            buttonD.UseVisualStyleBackColor = false;
            // 
            // buttonF
            // 
            buttonF.BackColor = Color.White;
            buttonF.Location = new Point(255, 4);
            buttonF.Margin = new Padding(3, 4, 3, 4);
            buttonF.Name = "buttonF";
            buttonF.Size = new Size(43, 57);
            buttonF.TabIndex = 18;
            buttonF.Text = "F";
            buttonF.UseVisualStyleBackColor = false;
            // 
            // buttonG
            // 
            buttonG.BackColor = Color.White;
            buttonG.Location = new Point(339, 4);
            buttonG.Margin = new Padding(3, 4, 3, 4);
            buttonG.Name = "buttonG";
            buttonG.Size = new Size(43, 57);
            buttonG.TabIndex = 19;
            buttonG.Text = "G";
            buttonG.UseVisualStyleBackColor = false;
            // 
            // buttonH
            // 
            buttonH.BackColor = Color.White;
            buttonH.Location = new Point(423, 4);
            buttonH.Margin = new Padding(3, 4, 3, 4);
            buttonH.Name = "buttonH";
            buttonH.Size = new Size(43, 57);
            buttonH.TabIndex = 20;
            buttonH.Text = "H";
            buttonH.UseVisualStyleBackColor = false;
            // 
            // buttonJ
            // 
            buttonJ.BackColor = Color.White;
            buttonJ.Location = new Point(507, 4);
            buttonJ.Margin = new Padding(3, 4, 3, 4);
            buttonJ.Name = "buttonJ";
            buttonJ.Size = new Size(43, 57);
            buttonJ.TabIndex = 21;
            buttonJ.Text = "J";
            buttonJ.UseVisualStyleBackColor = false;
            // 
            // buttonK
            // 
            buttonK.BackColor = Color.White;
            buttonK.Location = new Point(591, 4);
            buttonK.Margin = new Padding(3, 4, 3, 4);
            buttonK.Name = "buttonK";
            buttonK.Size = new Size(43, 57);
            buttonK.TabIndex = 22;
            buttonK.Text = "K";
            buttonK.UseVisualStyleBackColor = false;
            // 
            // buttonL
            // 
            buttonL.BackColor = Color.White;
            buttonL.Location = new Point(675, 4);
            buttonL.Margin = new Padding(3, 4, 3, 4);
            buttonL.Name = "buttonL";
            buttonL.Size = new Size(43, 57);
            buttonL.TabIndex = 23;
            buttonL.Text = "L";
            buttonL.UseVisualStyleBackColor = false;
            // 
            // KeyboardRow1
            // 
            KeyboardRow1.ColumnCount = 10;
            KeyboardRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            KeyboardRow1.Controls.Add(buttonQ, 0, 0);
            KeyboardRow1.Controls.Add(buttonW, 1, 0);
            KeyboardRow1.Controls.Add(buttonE, 2, 0);
            KeyboardRow1.Controls.Add(buttonR, 3, 0);
            KeyboardRow1.Controls.Add(buttonT, 4, 0);
            KeyboardRow1.Controls.Add(buttonY, 5, 0);
            KeyboardRow1.Controls.Add(buttonU, 6, 0);
            KeyboardRow1.Controls.Add(buttonI, 7, 0);
            KeyboardRow1.Controls.Add(buttonO, 8, 0);
            KeyboardRow1.Controls.Add(buttonP, 9, 0);
            KeyboardRow1.Location = new Point(9, 5);
            KeyboardRow1.Margin = new Padding(3, 4, 3, 4);
            KeyboardRow1.Name = "KeyboardRow1";
            KeyboardRow1.RowCount = 1;
            KeyboardRow1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            KeyboardRow1.Size = new Size(764, 69);
            KeyboardRow1.TabIndex = 0;
            // 
            // buttonQ
            // 
            buttonQ.BackColor = Color.White;
            buttonQ.Location = new Point(3, 4);
            buttonQ.Margin = new Padding(3, 4, 3, 4);
            buttonQ.Name = "buttonQ";
            buttonQ.Size = new Size(50, 61);
            buttonQ.TabIndex = 5;
            buttonQ.Text = "Q";
            buttonQ.UseVisualStyleBackColor = false;
            // 
            // buttonW
            // 
            buttonW.BackColor = Color.White;
            buttonW.Location = new Point(79, 4);
            buttonW.Margin = new Padding(3, 4, 3, 4);
            buttonW.Name = "buttonW";
            buttonW.Size = new Size(43, 61);
            buttonW.TabIndex = 6;
            buttonW.Text = "W";
            buttonW.UseVisualStyleBackColor = false;
            // 
            // buttonE
            // 
            buttonE.BackColor = Color.White;
            buttonE.Location = new Point(155, 4);
            buttonE.Margin = new Padding(3, 4, 3, 4);
            buttonE.Name = "buttonE";
            buttonE.Size = new Size(43, 61);
            buttonE.TabIndex = 7;
            buttonE.Text = "E";
            buttonE.UseVisualStyleBackColor = false;
            // 
            // buttonR
            // 
            buttonR.BackColor = Color.White;
            buttonR.Location = new Point(231, 4);
            buttonR.Margin = new Padding(3, 4, 3, 4);
            buttonR.Name = "buttonR";
            buttonR.Size = new Size(43, 61);
            buttonR.TabIndex = 8;
            buttonR.Text = "R";
            buttonR.UseVisualStyleBackColor = false;
            // 
            // buttonT
            // 
            buttonT.BackColor = Color.White;
            buttonT.Location = new Point(307, 4);
            buttonT.Margin = new Padding(3, 4, 3, 4);
            buttonT.Name = "buttonT";
            buttonT.Size = new Size(43, 61);
            buttonT.TabIndex = 9;
            buttonT.Text = "T";
            buttonT.UseVisualStyleBackColor = false;
            // 
            // buttonY
            // 
            buttonY.BackColor = Color.White;
            buttonY.Location = new Point(383, 4);
            buttonY.Margin = new Padding(3, 4, 3, 4);
            buttonY.Name = "buttonY";
            buttonY.Size = new Size(43, 61);
            buttonY.TabIndex = 10;
            buttonY.Text = "Y";
            buttonY.UseVisualStyleBackColor = false;
            // 
            // buttonU
            // 
            buttonU.BackColor = Color.White;
            buttonU.Location = new Point(459, 4);
            buttonU.Margin = new Padding(3, 4, 3, 4);
            buttonU.Name = "buttonU";
            buttonU.Size = new Size(43, 61);
            buttonU.TabIndex = 11;
            buttonU.Text = "U";
            buttonU.UseVisualStyleBackColor = false;
            // 
            // buttonI
            // 
            buttonI.BackColor = Color.White;
            buttonI.Location = new Point(535, 4);
            buttonI.Margin = new Padding(3, 4, 3, 4);
            buttonI.Name = "buttonI";
            buttonI.Size = new Size(43, 61);
            buttonI.TabIndex = 12;
            buttonI.Text = "I";
            buttonI.UseVisualStyleBackColor = false;
            // 
            // buttonO
            // 
            buttonO.BackColor = Color.White;
            buttonO.Location = new Point(611, 4);
            buttonO.Margin = new Padding(3, 4, 3, 4);
            buttonO.Name = "buttonO";
            buttonO.Size = new Size(43, 61);
            buttonO.TabIndex = 13;
            buttonO.Text = "O";
            buttonO.UseVisualStyleBackColor = false;
            // 
            // buttonP
            // 
            buttonP.BackColor = Color.White;
            buttonP.Location = new Point(687, 4);
            buttonP.Margin = new Padding(3, 4, 3, 4);
            buttonP.Name = "buttonP";
            buttonP.Size = new Size(43, 61);
            buttonP.TabIndex = 14;
            buttonP.Text = "P";
            buttonP.UseVisualStyleBackColor = false;
            // 
            // ToolbarPanel
            // 
            ToolbarPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ToolbarPanel.Controls.Add(buttonReturn);
            ToolbarPanel.Controls.Add(buttonIdea);
            ToolbarPanel.Controls.Add(buttonStats);
            ToolbarPanel.Controls.Add(buttonHelp);
            ToolbarPanel.Controls.Add(buttonSetting);
            ToolbarPanel.Location = new Point(-2, -1);
            ToolbarPanel.Margin = new Padding(3, 4, 3, 4);
            ToolbarPanel.Name = "ToolbarPanel";
            ToolbarPanel.Size = new Size(800, 59);
            ToolbarPanel.TabIndex = 74;
            // 
            // buttonReturn
            // 
            buttonReturn.AutoSize = true;
            buttonReturn.Dock = DockStyle.Left;
            buttonReturn.Location = new Point(0, 0);
            buttonReturn.Margin = new Padding(3, 4, 3, 4);
            buttonReturn.Name = "buttonReturn";
            buttonReturn.Size = new Size(71, 59);
            buttonReturn.TabIndex = 37;
            buttonReturn.Text = "button2";
            buttonReturn.UseVisualStyleBackColor = true;
            buttonReturn.Click += buttonReturn_Click;
            // 
            // buttonIdea
            // 
            buttonIdea.AutoSize = true;
            buttonIdea.Dock = DockStyle.Right;
            buttonIdea.Location = new Point(484, 0);
            buttonIdea.Margin = new Padding(3, 4, 3, 4);
            buttonIdea.Name = "buttonIdea";
            buttonIdea.Size = new Size(79, 59);
            buttonIdea.TabIndex = 33;
            buttonIdea.Text = "button29";
            buttonIdea.UseVisualStyleBackColor = true;
            // 
            // buttonStats
            // 
            buttonStats.AutoSize = true;
            buttonStats.Dock = DockStyle.Right;
            buttonStats.Location = new Point(563, 0);
            buttonStats.Margin = new Padding(3, 4, 3, 4);
            buttonStats.Name = "buttonStats";
            buttonStats.Size = new Size(79, 59);
            buttonStats.TabIndex = 34;
            buttonStats.Text = "button30";
            buttonStats.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            buttonHelp.AutoSize = true;
            buttonHelp.Dock = DockStyle.Right;
            buttonHelp.Location = new Point(642, 0);
            buttonHelp.Margin = new Padding(3, 4, 3, 4);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(79, 59);
            buttonHelp.TabIndex = 35;
            buttonHelp.Text = "button31";
            buttonHelp.UseVisualStyleBackColor = true;
            // 
            // buttonSetting
            // 
            buttonSetting.AutoSize = true;
            buttonSetting.Dock = DockStyle.Right;
            buttonSetting.Location = new Point(721, 0);
            buttonSetting.Margin = new Padding(3, 4, 3, 4);
            buttonSetting.Name = "buttonSetting";
            buttonSetting.Size = new Size(79, 59);
            buttonSetting.TabIndex = 36;
            buttonSetting.Text = "button32";
            buttonSetting.UseVisualStyleBackColor = true;
            // 
            // SingleplayerPanel
            // 
            SingleplayerPanel.Dock = DockStyle.Fill;
            SingleplayerPanel.Location = new Point(0, 0);
            SingleplayerPanel.Margin = new Padding(3, 4, 3, 4);
            SingleplayerPanel.Name = "SingleplayerPanel";
            SingleplayerPanel.Size = new Size(800, 562);
            SingleplayerPanel.TabIndex = 72;
            // 
            // MultiplayerPanel
            // 
            MultiplayerPanel.Dock = DockStyle.Fill;
            MultiplayerPanel.Location = new Point(0, 0);
            MultiplayerPanel.Margin = new Padding(3, 4, 3, 4);
            MultiplayerPanel.Name = "MultiplayerPanel";
            MultiplayerPanel.Size = new Size(800, 562);
            MultiplayerPanel.TabIndex = 71;
            // 
            // OptionsPanel
            // 
            OptionsPanel.Controls.Add(labelTopic);
            OptionsPanel.Controls.Add(buttonStartGameSinglePlayer);
            OptionsPanel.Controls.Add(buttonReturnFromOptions);
            OptionsPanel.Controls.Add(DifficultyPanel);
            OptionsPanel.Controls.Add(NumAttemptsPanel);
            OptionsPanel.Controls.Add(comboBoxTopic);
            OptionsPanel.Dock = DockStyle.Fill;
            OptionsPanel.Location = new Point(0, 0);
            OptionsPanel.Margin = new Padding(3, 4, 3, 4);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new Size(800, 562);
            OptionsPanel.TabIndex = 75;
            // 
            // buttonStartGameSinglePlayer
            // 
            buttonStartGameSinglePlayer.AutoSize = true;
            buttonStartGameSinglePlayer.Location = new Point(291, 431);
            buttonStartGameSinglePlayer.Margin = new Padding(3, 4, 3, 4);
            buttonStartGameSinglePlayer.Name = "buttonStartGameSinglePlayer";
            buttonStartGameSinglePlayer.Size = new Size(89, 38);
            buttonStartGameSinglePlayer.TabIndex = 15;
            buttonStartGameSinglePlayer.Text = "StartGame";
            buttonStartGameSinglePlayer.UseVisualStyleBackColor = true;
            buttonStartGameSinglePlayer.Click += buttonStartGameSinglePlayer_Click;
            // 
            // buttonReturnFromOptions
            // 
            buttonReturnFromOptions.Location = new Point(2, 4);
            buttonReturnFromOptions.Margin = new Padding(3, 4, 3, 4);
            buttonReturnFromOptions.Name = "buttonReturnFromOptions";
            buttonReturnFromOptions.Size = new Size(75, 29);
            buttonReturnFromOptions.TabIndex = 14;
            buttonReturnFromOptions.Text = "button1";
            buttonReturnFromOptions.UseVisualStyleBackColor = true;
            buttonReturnFromOptions.Click += buttonReturnFromOptions_Click;
            // 
            // DifficultyPanel
            // 
            DifficultyPanel.Controls.Add(labelDifficulty);
            DifficultyPanel.Controls.Add(radioButtonRandom);
            DifficultyPanel.Controls.Add(radioButtonEasy);
            DifficultyPanel.Controls.Add(radioButtonHard);
            DifficultyPanel.Location = new Point(277, 24);
            DifficultyPanel.Margin = new Padding(3, 4, 3, 4);
            DifficultyPanel.Name = "DifficultyPanel";
            DifficultyPanel.Size = new Size(181, 178);
            DifficultyPanel.TabIndex = 13;
            // 
            // labelDifficulty
            // 
            labelDifficulty.AutoSize = true;
            labelDifficulty.Location = new Point(54, 16);
            labelDifficulty.Name = "labelDifficulty";
            labelDifficulty.Size = new Size(72, 20);
            labelDifficulty.TabIndex = 7;
            labelDifficulty.Text = "Difficulty:";
            // 
            // radioButtonRandom
            // 
            radioButtonRandom.AutoSize = true;
            radioButtonRandom.Location = new Point(57, 44);
            radioButtonRandom.Margin = new Padding(3, 4, 3, 4);
            radioButtonRandom.Name = "radioButtonRandom";
            radioButtonRandom.Size = new Size(86, 24);
            radioButtonRandom.TabIndex = 6;
            radioButtonRandom.TabStop = true;
            radioButtonRandom.Text = "Random";
            radioButtonRandom.UseVisualStyleBackColor = true;
            // 
            // radioButtonEasy
            // 
            radioButtonEasy.AutoSize = true;
            radioButtonEasy.Location = new Point(57, 90);
            radioButtonEasy.Margin = new Padding(3, 4, 3, 4);
            radioButtonEasy.Name = "radioButtonEasy";
            radioButtonEasy.Size = new Size(59, 24);
            radioButtonEasy.TabIndex = 3;
            radioButtonEasy.TabStop = true;
            radioButtonEasy.Text = "Easy";
            radioButtonEasy.UseVisualStyleBackColor = true;
            // 
            // radioButtonHard
            // 
            radioButtonHard.AutoSize = true;
            radioButtonHard.Location = new Point(57, 134);
            radioButtonHard.Margin = new Padding(3, 4, 3, 4);
            radioButtonHard.Name = "radioButtonHard";
            radioButtonHard.Size = new Size(63, 24);
            radioButtonHard.TabIndex = 4;
            radioButtonHard.TabStop = true;
            radioButtonHard.Text = "Hard";
            radioButtonHard.UseVisualStyleBackColor = true;
            // 
            // NumAttemptsPanel
            // 
            NumAttemptsPanel.Controls.Add(labelNum8);
            NumAttemptsPanel.Controls.Add(labelNum6);
            NumAttemptsPanel.Controls.Add(labelNum7);
            NumAttemptsPanel.Controls.Add(trackBarAttempts);
            NumAttemptsPanel.Controls.Add(labelNumAttempts);
            NumAttemptsPanel.Location = new Point(291, 269);
            NumAttemptsPanel.Margin = new Padding(3, 4, 3, 4);
            NumAttemptsPanel.Name = "NumAttemptsPanel";
            NumAttemptsPanel.Size = new Size(200, 112);
            NumAttemptsPanel.TabIndex = 12;
            // 
            // labelNum8
            // 
            labelNum8.AutoSize = true;
            labelNum8.Location = new Point(161, 71);
            labelNum8.Name = "labelNum8";
            labelNum8.Size = new Size(17, 20);
            labelNum8.TabIndex = 11;
            labelNum8.Text = "8";
            // 
            // labelNum6
            // 
            labelNum6.AutoSize = true;
            labelNum6.Location = new Point(15, 71);
            labelNum6.Name = "labelNum6";
            labelNum6.Size = new Size(17, 20);
            labelNum6.TabIndex = 9;
            labelNum6.Text = "6";
            // 
            // labelNum7
            // 
            labelNum7.AutoSize = true;
            labelNum7.Location = new Point(87, 71);
            labelNum7.Name = "labelNum7";
            labelNum7.Size = new Size(17, 20);
            labelNum7.TabIndex = 10;
            labelNum7.Text = "7";
            // 
            // trackBarAttempts
            // 
            trackBarAttempts.Location = new Point(3, 31);
            trackBarAttempts.Margin = new Padding(3, 4, 3, 4);
            trackBarAttempts.Maximum = 8;
            trackBarAttempts.Minimum = 6;
            trackBarAttempts.Name = "trackBarAttempts";
            trackBarAttempts.Size = new Size(181, 56);
            trackBarAttempts.TabIndex = 8;
            trackBarAttempts.Value = 6;
            // 
            // labelNumAttempts
            // 
            labelNumAttempts.AutoSize = true;
            labelNumAttempts.Location = new Point(32, 8);
            labelNumAttempts.Name = "labelNumAttempts";
            labelNumAttempts.Size = new Size(150, 20);
            labelNumAttempts.TabIndex = 12;
            labelNumAttempts.Text = "Numbers of attempts";
            // 
            // comboBoxTopic
            // 
            comboBoxTopic.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTopic.FormattingEnabled = true;
            comboBoxTopic.Location = new Point(309, 210);
            comboBoxTopic.Margin = new Padding(3, 4, 3, 4);
            comboBoxTopic.Name = "comboBoxTopic";
            comboBoxTopic.Size = new Size(200, 28);
            comboBoxTopic.TabIndex = 1;
            // 
            // labelTopic
            // 
            labelTopic.AutoSize = true;
            labelTopic.Location = new Point(255, 213);
            labelTopic.Name = "labelTopic";
            labelTopic.Size = new Size(48, 20);
            labelTopic.TabIndex = 16;
            labelTopic.Text = "Topic:";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(MainPanel);
            Controls.Add(KeyboardPanel);
            Controls.Add(ToolbarPanel);
            Controls.Add(SingleplayerPanel);
            Controls.Add(MultiplayerPanel);
            Controls.Add(OptionsPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainMenu";
            Text = "Form1";
            Load += Form1_Load;
            Resize += Form1_Resize;
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            KeyboardPanel.ResumeLayout(false);
            KeyboardRow3.ResumeLayout(false);
            KeyboardRow2.ResumeLayout(false);
            KeyboardRow1.ResumeLayout(false);
            ToolbarPanel.ResumeLayout(false);
            ToolbarPanel.PerformLayout();
            OptionsPanel.ResumeLayout(false);
            OptionsPanel.PerformLayout();
            DifficultyPanel.ResumeLayout(false);
            DifficultyPanel.PerformLayout();
            NumAttemptsPanel.ResumeLayout(false);
            NumAttemptsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarAttempts).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button singleplayerButton;
        private System.Windows.Forms.Button multiplayerButton;
        private System.Windows.Forms.Panel KeyboardPanel;
        private System.Windows.Forms.TableLayoutPanel KeyboardRow3;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Button buttonZ;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Button buttonV;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonN;
        private System.Windows.Forms.Button buttonM;
        private System.Windows.Forms.Button buttonBackspace;
        private System.Windows.Forms.TableLayoutPanel KeyboardRow2;
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Button buttonS;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Button buttonF;
        private System.Windows.Forms.Button buttonG;
        private System.Windows.Forms.Button buttonH;
        private System.Windows.Forms.Button buttonJ;
        private System.Windows.Forms.Button buttonK;
        private System.Windows.Forms.Button buttonL;
        private System.Windows.Forms.TableLayoutPanel KeyboardRow1;
        private System.Windows.Forms.Button buttonQ;
        private System.Windows.Forms.Button buttonW;
        private System.Windows.Forms.Button buttonE;
        private System.Windows.Forms.Button buttonR;
        private System.Windows.Forms.Button buttonT;
        private System.Windows.Forms.Button buttonY;
        private System.Windows.Forms.Button buttonU;
        private System.Windows.Forms.Button buttonI;
        private System.Windows.Forms.Button buttonO;
        private System.Windows.Forms.Button buttonP;
        private System.Windows.Forms.Panel ToolbarPanel;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonIdea;
        private System.Windows.Forms.Button buttonStats;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Panel SingleplayerPanel;
        private System.Windows.Forms.Panel MultiplayerPanel;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Panel DifficultyPanel;
        private System.Windows.Forms.Label labelDifficulty;
        private System.Windows.Forms.RadioButton radioButtonRandom;
        private System.Windows.Forms.RadioButton radioButtonEasy;
        private System.Windows.Forms.RadioButton radioButtonHard;
        private System.Windows.Forms.Panel NumAttemptsPanel;
        private System.Windows.Forms.Label labelNum8;
        private System.Windows.Forms.Label labelNum6;
        private System.Windows.Forms.Label labelNum7;
        private System.Windows.Forms.TrackBar trackBarAttempts;
        private System.Windows.Forms.Label labelNumAttempts;
        private System.Windows.Forms.ComboBox comboBoxTopic;
        private System.Windows.Forms.Button buttonReturnFromOptions;
        private System.Windows.Forms.Button buttonStartGameSinglePlayer;
        private Label labelTopic;
    }
}

