using BowlingTournamentBrackets.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BowlingTournamentBrackets
{
    public partial class TournamentBracketsForm : Form
    {
        private readonly List<string> _file;
        public string[,] _tournament;

        private const int _name = 0;
        private const int _game1Score = 1;
        private const int _game2Score = 2;
        private const int _game3Score = 3;

        private int Player1Row { get; set; }
        private int Player2Row { get; set; }
        private int Player3Row { get; set; }
        private int Player4Row { get; set; }
        private int Player5Row { get; set; }
        private int Player6Row { get; set; }
        private int Player7Row { get; set; }
        private int Player8Row { get; set; }

        public TournamentBracketsForm()
        {
            InitializeComponent();

            // Initialize the file list
            _file = new List<string>();

            // Gets the embedded file path for tournament.txt
            string filePath = Resources.tournament;

            // Splits each line into an array
            string[] file = filePath.Split
                            (
                                new[]
                                {
                                    Environment.NewLine
                                },
                                StringSplitOptions.RemoveEmptyEntries
                            ).ToArray();

            // Loop through each line and splits each item in that line (by whitespace) into an array
            foreach (string line in file) 
            {
                string[] lineAsArray = line.Split(' ');

                // Loop through each item in the line once it's been divided into an array
                foreach (string item in lineAsArray) 
                {
                    _file.Add(item);
                }
            }

            // TODO: Generate random players
            Player1Row = 0;
            Player2Row = 1;
            Player3Row = 2;
            Player4Row = 3;
            Player5Row = 4;
            Player6Row = 5;
            Player7Row = 6;
            Player8Row = 7;
        }

        private void TournamentBracketsForm_Load(object sender, EventArgs e)
        {
            int line = 8; // There's 8 lines in the text file
            int lineItems = 4; // There are 4 items in each line

            // Create a multi-dimensional array to store the file contents
            string[,] tournamentDataArray = new string[line, lineItems];

            int fileListIndex = 0;

            // Loop through each row and column to add each bolwer and their 3 game scores
            for (int row = 0; row < line; row++) 
            {
                for (int col = 0; col < lineItems; col++) 
                {
                    tournamentDataArray[row, col] = _file[fileListIndex];
                    fileListIndex++;
                }
            }

            /*
                Once finished, the multi-dimensional array should look like this:

                           G1    G2    G3
                Ava     | 253 | 251 | 268
                ---------------------------
                Bob     | 252 | 251 | 268
                ---------------------------
                Dave    | 244 | 249 | 299
                ---------------------------
                Eve     | 239 | 300 | 300
                ---------------------------
                Frank   | 288 | 275 | 286
                ---------------------------
                Gina    | 298 | 277 | 279
                ---------------------------
                Hank    | 299 | 281 | 269
                ---------------------------
                Ivy     | 228 | 295 | 294

             */

            _tournament = tournamentDataArray;
        }

        private void GenerateTournamentBtn_Click(object sender, EventArgs e)
        {
            // Disable the generate button
            GenerateTournamentBtn.Enabled = false;

            #region Game 1
            // Add random players in the text boxes for game 1
            Game1Txt1.Text = $"{_tournament[Player1Row, _name]} {_tournament[Player1Row, _game1Score]}";
            Game1Txt2.Text = $"{_tournament[Player2Row, _name]} {_tournament[Player2Row, _game1Score]}";
            Game1Txt3.Text = $"{_tournament[Player3Row, _name]} {_tournament[Player3Row, _game1Score]}";
            Game1Txt4.Text = $"{_tournament[Player4Row, _name]} {_tournament[Player4Row, _game1Score]}";
            Game1Txt5.Text = $"{_tournament[Player5Row, _name]} {_tournament[Player5Row, _game1Score]}";
            Game1Txt6.Text = $"{_tournament[Player6Row, _name]} {_tournament[Player6Row, _game1Score]}";
            Game1Txt7.Text = $"{_tournament[Player7Row, _name]} {_tournament[Player7Row, _game1Score]}";
            Game1Txt8.Text = $"{_tournament[Player8Row, _name]} {_tournament[Player8Row, _game1Score]}";
            #endregion

            #region Game 2
            int bracket1WinnerRowG2;
            int bracket2WinnerRowG2;
            int bracket3WinnerRowG2;
            int bracket4WinnerRowG2;

            // Player 1 vs Player 2
            if (Convert.ToInt32(_tournament[Player1Row, _game1Score]) > Convert.ToInt32(_tournament[Player2Row, _game1Score]))
            {
                Game2Txt1.Text = $"{_tournament[Player1Row, _name]} {_tournament[Player1Row, _game2Score]}";
                bracket1WinnerRowG2 = Player1Row;
            }
            else 
            {
                Game2Txt1.Text = $"{_tournament[Player2Row, _name]} {_tournament[Player2Row, _game2Score]}";
                bracket1WinnerRowG2 = Player2Row;
            }

            // Plater 3 vs Player 4
            if (Convert.ToInt32(_tournament[Player3Row, _game1Score]) > Convert.ToInt32(_tournament[Player4Row, _game1Score]))
            {
                Game2Txt2.Text = $"{_tournament[Player3Row, _name]} {_tournament[Player3Row, _game2Score]}";
                bracket2WinnerRowG2 = Player3Row;
            }
            else 
            {
                Game2Txt2.Text = $"{_tournament[Player4Row, _name]} {_tournament[Player4Row, _game2Score]}";
                bracket2WinnerRowG2 = Player4Row;
            }

            // Player 5 vs Player 6
            if (Convert.ToInt32(_tournament[Player5Row, _game1Score]) > Convert.ToInt32(_tournament[Player6Row, _game1Score]))
            {
                Game2Txt3.Text = $"{_tournament[Player5Row, _name]} {_tournament[Player5Row, _game2Score]}";
                bracket3WinnerRowG2 = Player5Row;
            }
            else 
            {
                Game2Txt3.Text = $"{_tournament[Player6Row, _name]} {_tournament[Player6Row, _game2Score]}";
                bracket3WinnerRowG2 = Player6Row;
            }

            // Player 7 vs Player 8
            if (Convert.ToInt32(_tournament[Player7Row, _game1Score]) > Convert.ToInt32(_tournament[Player8Row, _game1Score]))
            {
                Game2Txt4.Text = $"{_tournament[Player7Row, _name]} {_tournament[Player7Row, _game2Score]}";
                bracket4WinnerRowG2 = Player7Row;
            }
            else 
            {
                Game2Txt4.Text = $"{_tournament[Player8Row, _name]} {_tournament[Player8Row, _game2Score]}";
                bracket4WinnerRowG2 = Player8Row;
            }
            #endregion

            #region Game 3
            int bracket1WinnerRowG3;
            int bracket2WinnerRowG3;

            if (Convert.ToInt32(_tournament[bracket1WinnerRowG2, _game2Score]) > Convert.ToInt32(_tournament[bracket2WinnerRowG2, _game2Score]))
            {
                Game3Txt1.Text = $"{_tournament[bracket1WinnerRowG2, _name]} {_tournament[bracket1WinnerRowG2, _game3Score]}";
                bracket1WinnerRowG3 = bracket1WinnerRowG2;
            }
            else 
            {
                Game3Txt1.Text = $"{_tournament[bracket2WinnerRowG2, _name]} {_tournament[bracket2WinnerRowG2, _game3Score]}";
                bracket1WinnerRowG3 = bracket2WinnerRowG2;
            }

            if (Convert.ToInt32(_tournament[bracket3WinnerRowG2, _game2Score]) > Convert.ToInt32(_tournament[bracket4WinnerRowG2, _game2Score]))
            {
                Game3Txt2.Text = $"{_tournament[bracket3WinnerRowG2, _name]} {_tournament[bracket3WinnerRowG2, _game3Score]}";
                bracket2WinnerRowG3 = bracket3WinnerRowG2;
            }
            else
            {
                Game3Txt2.Text = $"{_tournament[bracket4WinnerRowG2, _name]} {_tournament[bracket4WinnerRowG2, _game3Score]}";
                bracket2WinnerRowG3 = bracket4WinnerRowG2;
            }
            #endregion

            #region 1st and 2nd Place Winners
            if (Convert.ToInt32(_tournament[bracket1WinnerRowG3, _game3Score]) > Convert.ToInt32(_tournament[bracket2WinnerRowG3, _game3Score]))
            {
                FirstPlaceTxt.Text = $"{_tournament[bracket1WinnerRowG3, _name]} $25";
                SecondPlaceTxt.Text = $"{_tournament[bracket2WinnerRowG3, _name]} $10";
            }
            else
            {
                FirstPlaceTxt.Text = $"{_tournament[bracket2WinnerRowG3, _name]} $25";
                SecondPlaceTxt.Text = $"{_tournament[bracket1WinnerRowG3, _name]} $10";
            }
            #endregion
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Enable the generate button 
            GenerateTournamentBtn.Enabled = true;

            // Clear game 1 text boxes
            Game1Txt1.Text = "";
            Game1Txt2.Text = "";
            Game1Txt3.Text = "";
            Game1Txt4.Text = "";
            Game1Txt5.Text = "";
            Game1Txt6.Text = "";
            Game1Txt7.Text = "";
            Game1Txt8.Text = "";

            // Clear game 2 text boxes
            Game2Txt1.Text = "";
            Game2Txt2.Text = "";
            Game2Txt3.Text = "";
            Game2Txt4.Text = "";

            // Clear game 3 text boxes
            Game3Txt1.Text = "";
            Game3Txt2.Text = "";

            // Clear first and second place text boxes
            FirstPlaceTxt.Text = "";
            SecondPlaceTxt.Text = "";
        }
    }
}
