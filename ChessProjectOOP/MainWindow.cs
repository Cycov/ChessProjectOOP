using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Networking;

namespace ChessProjectOOP
{
    public partial class MainWindow : Form
    {
        private Player player1, player2;
        private ChessTable mainChessTable;
        private bool isServer, isClient, gameRunning;

        // WARNING : Huge memory leak + ~500 (~23 mb) objects at first piece move start and + ~20 (~3.5 kb) objects more per consecutive move. Something is not disposing properly.

        //Initialisers

        public MainWindow()
        {
            InitializeComponent();
            InitialiseTable();

            isServer = gameRunning = false;
        }

        private void SetStatus(string status)
        {
            toolStripStatusLabel.Text = String.Format("[{0}]: {1}", DateTime.Now.ToString("hh:mm:ss"), status);
        }

        private void InitialisePlayers(OwnerTypes _player1, OwnerTypes _player2, string player2Name)
        {
            player1 = new Player(_player1) { Name = playerNameField.Text };
            player2 = new Player(_player2) { Name = player2Name };

            if (_player1 == OwnerTypes.White)
                player1.CanMove = true;
        }


        private void InitialiseTable()
        {
            SuspendLayout();

            mainChessTable = new ChessTable();
            mainChessTable.BackColor = Color.Black;
            mainChessTable.BlackBackgroundColor = Color.LightGray;
            mainChessTable.Dock = DockStyle.Fill;
            mainChessTable.ForeColor = Color.White;
            mainChessTable.Location = new Point(0, 0);
            mainChessTable.Name = "chessTable1";
            mainChessTable.SelectedColor = Color.Red;
            mainChessTable.Size = new Size(500, 500);
            mainChessTable.TabIndex = 0;
            mainChessTable.WhiteBackgroundColor = Color.White;
            mainChessTable.OnPieceMoved += MainChessTable_OnPieceMoved;
            mainChessTable.OnKingLost += MainChessTable_OnKingLost;
            ChessTableContainer.Controls.Add(this.mainChessTable);

            this.ResumeLayout();
        }

        //Various functionalities
        public void EndGame(OwnerTypes owner)
        {
            if (owner == player1.Owner)
            {
                SetStatus("You lost");
                MessageBox.Show("You lost");
            }
            else
            {
                SetStatus("You won");
                MessageBox.Show("You won !");
            }
            player1.Dispose();
            player2.Dispose();
            isServer = false;
            gameRunning = false;
            mainChessTable.ResetTable();

            //Reset network

            //Enable controls
            groupBox1.Enabled = true;
            joinGameBtn.Enabled = true;
            openGameBtn.Enabled = true;

            //Terminate connection
            networkConnection.StopListening("Game ended");
        }

        public void StartGame()
        {
            gameRunning = true;
            mainChessTable.InitialisePlayers(player1, player2);
            mainChessTable.Enabled = true;
        }

        //Event handlers

        private void testBtn_Click(object sender, EventArgs e)
        {
            InitialisePlayers(OwnerTypes.White, OwnerTypes.Black, "Computer");
            mainChessTable.ResetTable();
            historyDisplay.Items.Clear();
            mainChessTable.InitialisePlayers(player1, player2);
            StartGame();
        }

        private void joinGameBtn_Click(object sender, EventArgs e)
        {
            //Enable board
            //The protocol is as follows
            // 1-st byte - player pref color: 0 - none, 1- white, 2 - black
            // 2-257 - player name (ASCII) - 256 bytes

            if (isServer)
            {
                MessageBox.Show("Can't join a game while hosting");
                return;
            }

            groupBox1.Enabled = false;
            joinGameBtn.Enabled = false;
            openGameBtn.Enabled = false;

            networkConnection.IP = ipField2.IP;
            networkConnection.Port = (int)portTextBox.Value;
            char color = 'N';
            if (colorPreferenceOptionWhite.Checked)
                color = 'W';
            else if (colorPreferenceOptionBlack.Checked)
                color = 'B';

            try
            {
                networkConnection.Send(color + ";" + playerNameField.Text);
                isClient = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The game could not be joined", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupBox1.Enabled = true;
                joinGameBtn.Enabled = true;
                openGameBtn.Enabled = true;
                SetStatus("Error occured: " + ex.InnerException.Message);
            }

        }

        private void openGameBtn_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            joinGameBtn.Enabled = false;
            openGameBtn.Enabled = false;

            networkConnection.IP = ipField2.IP;
            networkConnection.Port = (int)portTextBox.Value;
            byte color = 0;
            if (colorPreferenceOptionWhite.Checked)
                color = 1;
            else if (colorPreferenceOptionBlack.Checked)
                color = 2;

            byte[] data = Encoding.ASCII.GetBytes((char)color + playerNameField.Text);

            try
            {
                networkConnection.StartListening();
                isServer = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupBox1.Enabled = true;
                joinGameBtn.Enabled = true;
                openGameBtn.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mainChessTable.Enabled = checkBox1.Checked;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            mainChessTable.Enabled = false;
        }

        private void showPos_Click(object sender, EventArgs e)
        {
            var positions = mainChessTable.GetAllPossibileMoves();
            foreach (var item in positions)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var pos in item.Value)
                {
                    builder.Append(" [" + pos.ToString() + "]");
                }
                Debug.WriteLine($"{item.Key} : {builder.ToString()}");
            }
        }

        private void networkConnection_OnDataRecieved(object sender, DataRecievedEventArgs e)
        {
            if (!gameRunning)
            {
                if (isServer)
                {
                    string[] data = e.Text.Split(';');
                    string opponentColor = data[0];
                    string opponentName = data[1];

                    OwnerTypes player1Owner = OwnerTypes.Undefined, player2Owner = OwnerTypes.Undefined;
                    string myColor = "N";
                    if (colorPreferenceOptionNone.Checked)
                    {
                        if (opponentColor == "W")
                        {
                            myColor = "B";
                            colorPreferenceOptionNone.Checked = false;
                            colorPreferenceOptionBlack.Checked = true;
                            player1Owner = OwnerTypes.Black;
                            player2Owner = OwnerTypes.White;
                        }
                        else //he chose black or none
                        {
                            myColor = "W";
                            colorPreferenceOptionNone.Checked = false;
                            colorPreferenceOptionWhite.Checked = true;
                            player1Owner = OwnerTypes.White;
                            player2Owner = OwnerTypes.Black;
                        }
                    }
                    else
                    {
                        if (colorPreferenceOptionWhite.Checked)
                        {
                            player1Owner = OwnerTypes.White;
                            player2Owner = OwnerTypes.Black;
                        }
                        else if (colorPreferenceOptionBlack.Checked)
                        {
                            player1Owner = OwnerTypes.Black;
                            player2Owner = OwnerTypes.White;
                        }
                    }
                    networkConnection.Reply(myColor + ";" + playerNameField.Text);

                    SetStatus(String.Format("You will be playing with {0}s vs {1} with {2}s",player1Owner, opponentName,player2Owner));
                    InitialisePlayers(player1Owner, player2Owner, opponentName);
                    StartGame();
                }
                else if (isClient)
                {
                    string[] data = e.Text.Split(';');
                    string opponentColor = data[0];
                    string opponentName = data[1];

                    OwnerTypes player1Owner = OwnerTypes.Undefined, player2Owner = OwnerTypes.Undefined;
                    if (opponentColor == "W")
                    {
                        player1Owner = OwnerTypes.Black;
                        player2Owner = OwnerTypes.White;
                    }
                    else
                    {
                        player1Owner = OwnerTypes.White;
                        player2Owner = OwnerTypes.Black;
                    }


                    SetStatus(String.Format("You will be playing with {0}s vs {1} with {2}s", player1Owner, opponentName, player2Owner));
                    InitialisePlayers(player1Owner, player2Owner, opponentName);
                    StartGame();
                }
                else
                    SetStatus("Unrequired data recieved: " + e.Text);
            }
            else //game is running
            {
                string[] data = e.Text.Split(';');
                if (data[0] != "M")
                {
                    MessageBox.Show("Unrequired data recieved: " + e.Text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {
                        player1.CanMove = true;
                        mainChessTable.MovePiece(new PiecePosition(data[1]), new PiecePosition(data[2]));
                        SetStatus("Piece moved " + e.Text);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Comunication error ( " + e.Text + " )\n" + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void MainChessTable_OnPieceMoved(object sender, PieceMovedEventArgs e)
        {
            //Add to history
            Bitmap arrow = Properties.Resources.ArrowRight;
            using (Bitmap image = new Bitmap(e.MovedPiece.Picture.Width * 2 + arrow.Width, e.MovedPiece.Picture.Height))
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawImage(e.MovedPiece.Picture, new Point(0, 0)); //Calculate 
                    g.DrawImage(arrow, new Point(e.MovedPiece.Picture.Width, arrow.Height / 2 + 30));
                    g.DrawImage(e.OverlappedPiece.Picture, new Point(e.MovedPiece.Picture.Width + arrow.Width, 0));
                    
                    // HACK: Because the matrix index grows right and downwards and the real table grows differently the display only will be shown as it should be. The position will remain "wrong"
                    historyDisplay.Items.Add(new PictureListboxItem(String.Format("{0} to {1}", e.BeforePosition.ToString(), e.AfterPosition.ToString()), image));
                }
            }

            historyDisplay.TopIndex = historyDisplay.Items.Count - 1;
            
            //Notify the other player of the move
            /*
            if (networkConnection.Connected && e.MovedPiece.Owner == player1.Owner)
            {
                player1.CanMove = false;
                //Protocol is as follows: <move marker>;<from.toString>;<to.toString>
                if (isClient)
                    networkConnection.Send("M;" + e.BeforePosition.ToString(false) + ";" + e.AfterPosition.ToString(false));
                else
                    networkConnection.Reply("M;" + e.BeforePosition.ToString(false) + ";" + e.AfterPosition.ToString(false));
            }*/
        }
        
        private void MainChessTable_OnKingLost(object sender, PieceLostEventArgs e)
        {
            if (e.LostPiece.Owner == player1.Owner)
            {
                SetStatus("You lost");
                MessageBox.Show("You lost");
            }
            else
            {
                SetStatus("You won");
                MessageBox.Show("You won !");
            }
            mainChessTable.Enabled = false;
            historyDisplay.Items.Clear();
            //EndGame(e.LostPiece.Owner);
        }

    }
}
