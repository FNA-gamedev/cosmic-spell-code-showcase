using System.Collections.Generic;
using static Studio.Sudoku.Systems.Enums;

namespace Studio.Sudoku.Systems
{
    public class SudokuData
    {
        public struct SudokuBoardData 
        {
            public int[] unsolved_data;
            public int[] solved_data;

            public SudokuBoardData(int[] unsolved, int[] solved) : this() 
            {
                this.unsolved_data = unsolved;
                this.solved_data = solved;
            }
        }

        #region Variables
        public Dictionary<string, List<SudokuBoardData>> sudoku_game;
        #endregion

        #region Methods
        public void Initialize() 
        {
            sudoku_game = new Dictionary<string, List<SudokuBoardData>>();
            sudoku_game.Add(eGameDifficulty.EASY.ToString(), SudokuEasyData.getData());
            sudoku_game.Add(eGameDifficulty.MEDIUM.ToString(), SudokuMediumData.getData());
            sudoku_game.Add(eGameDifficulty.HARD.ToString(), SudokuHardData.getData());
            sudoku_game.Add(eGameDifficulty.CHALLENGE.ToString(), SudokuChallengeData.getData());
        }

        public void Dispose() 
        {
            sudoku_game.Clear();
        }
		#endregion
	}
}

