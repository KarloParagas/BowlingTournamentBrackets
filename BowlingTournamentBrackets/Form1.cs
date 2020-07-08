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
            string txt1Game

            #region Game 1
            // Add random players in the text boxes for game 1
            Game1Txt1 = GetRandomPlayer();
            Game1Txt2 = GetRandomPlayer();
            #endregion

            #region Game 2
            #endregion

            #region Game 3
            #endregion
        }

        private TextBox GetRandomPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
