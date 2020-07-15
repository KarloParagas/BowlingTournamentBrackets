using BowlingTournamentBrackets.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private int TotalRows { get; set; }
        private int TotalColumns { get; set; }

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

            // Assign the total rows
            TotalRows = file.Length;

            // Assign the total columns
            TotalColumns = file[0].Split(' ').Length;

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
        }

        private void TournamentBracketsForm_Load(object sender, EventArgs e)
        {
            int line = TotalRows; // There's 8 lines in the text file
            int lineItems = TotalColumns; // There are 4 items in each line

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

            #region Once finished, the multi-dimensional array should look like this:

            /*             
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

            #endregion

            _tournament = tournamentDataArray;
        }

        /// <summary>
        /// Runs the tournament simulation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateTournamentBtn_Click(object sender, EventArgs e)
        {
            #region Assumptions

            /*
                - Text file is valid and well formed with "Name Score1 Score2 Score3", per line.
             */

            #endregion

            // Disable the generate button
            GenerateTournamentBtn.Enabled = false;

            #region Assign Players

            // List to store all assigned players for randomization
            List<int> assignedPlayerNums = new List<int>();

            // Assign random player numbers to each property
            Player1Row = GetPlayer(assignedPlayerNums);
            Player2Row = GetPlayer(assignedPlayerNums);
            Player3Row = GetPlayer(assignedPlayerNums);
            Player4Row = GetPlayer(assignedPlayerNums);
            Player5Row = GetPlayer(assignedPlayerNums);
            Player6Row = GetPlayer(assignedPlayerNums);
            Player7Row = GetPlayer(assignedPlayerNums);
            Player8Row = GetPlayer(assignedPlayerNums);

            #endregion

            #region Pre-Game

            PreGame();

            #endregion

            #region Game 1

            int game1Winner1, game1Winner2, game1Winner3, game1Winner4;
            Game1(out game1Winner1, out game1Winner2, out game1Winner3, out game1Winner4);

            #endregion

            #region Game 2

            int game2Winner1, game2Winner2;
            Game2(game1Winner1, game1Winner2, game1Winner3, game1Winner4, out game2Winner1, out game2Winner2);

            #endregion

            #region Game 3

            int firstPlaceWinner, secondPlaceWinner;
            Game3(game2Winner1, game2Winner2, out firstPlaceWinner, out secondPlaceWinner);

            #endregion

            #region Display 1st and 2nd place winners

            DisplayWinners(firstPlaceWinner, secondPlaceWinner);

            #endregion
        }

        /// <summary>
        /// Displays the random players generated to each slot for Game 1.
        /// </summary>
        private void PreGame()
        {
            // Once the player numbers have been assigned to the fields, 
            // display them in the text boxes.
            Game1Txt1.Text = $"{_tournament[Player1Row, _name]} {_tournament[Player1Row, _game1Score]}";
            Game1Txt2.Text = $"{_tournament[Player2Row, _name]} {_tournament[Player2Row, _game1Score]}";
            Game1Txt3.Text = $"{_tournament[Player3Row, _name]} {_tournament[Player3Row, _game1Score]}";
            Game1Txt4.Text = $"{_tournament[Player4Row, _name]} {_tournament[Player4Row, _game1Score]}";
            Game1Txt5.Text = $"{_tournament[Player5Row, _name]} {_tournament[Player5Row, _game1Score]}";
            Game1Txt6.Text = $"{_tournament[Player6Row, _name]} {_tournament[Player6Row, _game1Score]}";
            Game1Txt7.Text = $"{_tournament[Player7Row, _name]} {_tournament[Player7Row, _game1Score]}";
            Game1Txt8.Text = $"{_tournament[Player8Row, _name]} {_tournament[Player8Row, _game1Score]}";
        }

        /// <summary>
        /// Runs the Game 1 tournament and advances the winners to Game 2.
        /// </summary>
        /// <param name="game1Winner1"></param>
        /// <param name="game1Winner2"></param>
        /// <param name="game1Winner3"></param>
        /// <param name="game1Winner4"></param>
        private void Game1(out int game1Winner1, out int game1Winner2, out int game1Winner3, out int game1Winner4)
        {

            // Player 1 vs Player 2
            if (Convert.ToInt32(_tournament[Player1Row, _game1Score]) > Convert.ToInt32(_tournament[Player2Row, _game1Score]))
            {
                Game2Txt1.Text = $"{_tournament[Player1Row, _name]} {_tournament[Player1Row, _game2Score]}";
                game1Winner1 = Player1Row;
            }
            else
            {
                Game2Txt1.Text = $"{_tournament[Player2Row, _name]} {_tournament[Player2Row, _game2Score]}";
                game1Winner1 = Player2Row;
            }

            // Plater 3 vs Player 4
            if (Convert.ToInt32(_tournament[Player3Row, _game1Score]) > Convert.ToInt32(_tournament[Player4Row, _game1Score]))
            {
                Game2Txt2.Text = $"{_tournament[Player3Row, _name]} {_tournament[Player3Row, _game2Score]}";
                game1Winner2 = Player3Row;
            }
            else
            {
                Game2Txt2.Text = $"{_tournament[Player4Row, _name]} {_tournament[Player4Row, _game2Score]}";
                game1Winner2 = Player4Row;
            }

            // Player 5 vs Player 6
            if (Convert.ToInt32(_tournament[Player5Row, _game1Score]) > Convert.ToInt32(_tournament[Player6Row, _game1Score]))
            {
                Game2Txt3.Text = $"{_tournament[Player5Row, _name]} {_tournament[Player5Row, _game2Score]}";
                game1Winner3 = Player5Row;
            }
            else
            {
                Game2Txt3.Text = $"{_tournament[Player6Row, _name]} {_tournament[Player6Row, _game2Score]}";
                game1Winner3 = Player6Row;
            }

            // Player 7 vs Player 8
            if (Convert.ToInt32(_tournament[Player7Row, _game1Score]) > Convert.ToInt32(_tournament[Player8Row, _game1Score]))
            {
                Game2Txt4.Text = $"{_tournament[Player7Row, _name]} {_tournament[Player7Row, _game2Score]}";
                game1Winner4 = Player7Row;
            }
            else
            {
                Game2Txt4.Text = $"{_tournament[Player8Row, _name]} {_tournament[Player8Row, _game2Score]}";
                game1Winner4 = Player8Row;
            }
        }

        /// <summary>
        /// Runs the Game 2 tournament and advances the winners to Game 3.
        /// </summary>
        /// <param name="game1Winner1"></param>
        /// <param name="game1Winner2"></param>
        /// <param name="game1Winner3"></param>
        /// <param name="game1Winner4"></param>
        /// <param name="game2Winner1"></param>
        /// <param name="game2Winner2"></param>
        private void Game2(int game1Winner1, int game1Winner2, int game1Winner3, int game1Winner4, out int game2Winner1, out int game2Winner2)
        {

            // Game 2 bracket 1 winner vs Game 2 bracket 2 winner
            if (Convert.ToInt32(_tournament[game1Winner1, _game2Score]) > Convert.ToInt32(_tournament[game1Winner2, _game2Score]))
            {
                Game3Txt1.Text = $"{_tournament[game1Winner1, _name]} {_tournament[game1Winner1, _game3Score]}";
                game2Winner1 = game1Winner1;
            }
            else
            {
                Game3Txt1.Text = $"{_tournament[game1Winner2, _name]} {_tournament[game1Winner2, _game3Score]}";
                game2Winner1 = game1Winner2;
            }

            // Game 2 bracket 3 winner vs Game 2 bracket 4 winner
            if (Convert.ToInt32(_tournament[game1Winner3, _game2Score]) > Convert.ToInt32(_tournament[game1Winner4, _game2Score]))
            {
                Game3Txt2.Text = $"{_tournament[game1Winner3, _name]} {_tournament[game1Winner3, _game3Score]}";
                game2Winner2 = game1Winner3;
            }
            else
            {
                Game3Txt2.Text = $"{_tournament[game1Winner4, _name]} {_tournament[game1Winner4, _game3Score]}";
                game2Winner2 = game1Winner4;
            }
        }

        /// <summary>
        /// Runs the Game 3 tournament and determines who is 1st and 2nd place.
        /// </summary>
        /// <param name="game2Winner1"></param>
        /// <param name="game2Winner2"></param>
        /// <param name="firstPlaceWinner"></param>
        /// <param name="secondPlaceWinner"></param>
        private void Game3(int game2Winner1, int game2Winner2, out int firstPlaceWinner, out int secondPlaceWinner)
        {
            if (Convert.ToInt32(_tournament[game2Winner1, _game3Score]) > Convert.ToInt32(_tournament[game2Winner2, _game3Score]))
            {
                firstPlaceWinner = game2Winner1;
                secondPlaceWinner = game2Winner2;
            }
            else
            {
                firstPlaceWinner = game2Winner2;
                secondPlaceWinner = game2Winner1;
            }
        }

        /// <summary>
        /// Displays the 1st and 2nd place winners.
        /// </summary>
        /// <param name="firstPlaceWinner"></param>
        /// <param name="secondPlaceWinner"></param>
        private void DisplayWinners(int firstPlaceWinner, int secondPlaceWinner)
        {
            FirstPlaceTxt.Text = $"{_tournament[firstPlaceWinner, _name]} $25";
            SecondPlaceTxt.Text = $"{_tournament[secondPlaceWinner, _name]} $10";
        }

        /// <summary>
        /// Generates a random player based on their row number in the multi-dimensional array.
        /// Returns an unassigned number.
        /// </summary>
        /// <param name="assignedPlayerNums">List that keeps track of the assigned numbers.</param>
        private int GetPlayer(List<int> assignedPlayerNums)
        {
            Random rand = new Random();

            bool keepGoing = true;
            int playerNumber = -1;

            while (keepGoing)
            {
                // Generate a random number from 0 - 7
                int num = rand.Next(0, 8);

                // If that number hasn't been assigned, assign it to playerNumber
                // and return it.
                if (!assignedPlayerNums.Contains(num))
                {
                    assignedPlayerNums.Add(num);
                    keepGoing = false;
                    playerNumber = num;
                }
                else
                {
                    keepGoing = true;
                }
            }

            return playerNumber;
        }

        /// <summary>
        /// Clears all the text boxes, and re-enables the generate button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
