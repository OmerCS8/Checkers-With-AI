using System;
using System.Collections.Generic;

namespace SystemEngine
{
    public class ArtificialIntelligence
    {
        public enum eComputerLevel
        {
            Easy,
            Medium,
            Hard
        }

        public static GameMove GenerateValidMovesToComputer(Checkers i_CheckersGame, eComputerLevel i_Difficulty)
        {
            int numOfStepsAheadThinking;
            GameMove chosenMove;
            bool isComputerTurn = true;

            switch(i_Difficulty)
            {
                case eComputerLevel.Easy:
                    numOfStepsAheadThinking = 3;
                    break;
                case eComputerLevel.Medium:
                    numOfStepsAheadThinking = 5;
                    break;
                case eComputerLevel.Hard:
                    numOfStepsAheadThinking = 7;
                    break;
                default:
                    numOfStepsAheadThinking = 4;
                    break;
            }

            GenerateMoveValueAtGivenDepth(i_CheckersGame, isComputerTurn ,numOfStepsAheadThinking, out chosenMove);

            return chosenMove;
        }

        public static int GenerateMoveValueAtGivenDepth(Checkers i_Checkers, bool i_IsComputerTurn, int i_Depth, out GameMove o_ChosenMove)
        {
            bool isDoubleMoveNeeded;
            bool isBecomingKing;
            GameMove bestmove = null;
            List<GameMove> possibleMoves;
            List<GameMove> possibleEatingMoves;
            int bestMoveValue = i_IsComputerTurn ? Int32.MinValue : Int32.MaxValue;
            int currentMoveValue;

            if(i_Depth == 0 || i_Checkers.GameStatus != Checkers.eGameStatus.OnGoing)
            {
                bestMoveValue = calcComputerStateValue(i_Checkers);
            }
            else
            {
                possibleMoves = i_Checkers.GetPlayerInTurn().GetPossibleMovesOfPlayer();
                possibleEatingMoves = i_Checkers.GetPlayerInTurn().GetPossibleEatingMoves();
                possibleMoves = possibleEatingMoves.Count > 0 ? possibleEatingMoves : possibleMoves;

                foreach (GameMove gameMove in possibleMoves)
                {
                    isBecomingKing = checkIfMovePawnBecomingKing(gameMove, i_Checkers);
                    isDoubleMoveNeeded = i_Checkers.DoMoveAndCheckIfDoubleMoveIsNeeded(gameMove, false);

                    if(i_IsComputerTurn)
                    {
                        currentMoveValue = GenerateMoveValueAtGivenDepth(i_Checkers, isDoubleMoveNeeded, i_Depth - 1, out o_ChosenMove);
                        if(currentMoveValue > bestMoveValue)
                        {
                            bestMoveValue = currentMoveValue;
                            bestmove = gameMove;
                        }
                    }
                    else
                    {
                        currentMoveValue = GenerateMoveValueAtGivenDepth(i_Checkers, !isDoubleMoveNeeded, i_Depth - 1, out o_ChosenMove);
                        if(currentMoveValue < bestMoveValue)
                        {
                            bestMoveValue = currentMoveValue;
                            bestmove = gameMove;
                        }
                    }

                    i_Checkers.UnDoMove(gameMove, !isDoubleMoveNeeded, isBecomingKing);
                }
            }

            o_ChosenMove = bestmove;

            return bestMoveValue;
        }

        private static bool checkIfMovePawnBecomingKing(GameMove i_Move, Checkers i_Checkers)
        {
            Pawn movingPawn = i_Move.SourceCell.PawnOnCell;

            return !movingPawn.IsKing && 
                   i_Checkers.GameBoard.CheckIfCellAtKingRow(i_Move.DestinationCell, movingPawn.PawnColor);
        }

        private static int calcComputerStateValue(Checkers i_Checkers)
        {
            int computerStateValue = 0;
            Player computerPlayer = i_Checkers.PlayersArray[1];

            foreach(Player player in i_Checkers.PlayersArray)
            {
                foreach(Pawn pawn in player.PawnsArray)
                {
                    computerStateValue += player == computerPlayer ? 5 : -5;
                    if(pawn.IsKing)
                    {
                        computerStateValue += player == computerPlayer ? 5 : -5;
                    }

                    if(i_Checkers.GameBoard.CheckIfPawnAtStartRow(pawn))
                    {
                        computerStateValue += player == computerPlayer ? 2 : -2;
                    }

                    if(i_Checkers.GameBoard.CheckIfPawnAtMiddleBoard(pawn))
                    {
                        computerStateValue += player == computerPlayer ? 1 : -1;
                    }
                }
            }

            return computerStateValue;
        }
    }
}
