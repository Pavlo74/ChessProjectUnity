using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPlayer : MonoBehaviour
{
    private object white;
    private Board board;
    internal TeamColor team;
    internal object activePieces;

    public ChessPlayer(object white, Board board)
    {
        this.white = white;
        this.board = board;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void AddPiece(Piece newPiece)
    {
        throw new NotImplementedException();
    }

    internal void GenerateAllPossibleMoves()
    {
        throw new NotImplementedException();
    }

    internal Piece[] GetPieceAtackingOppositePiceOfType<T>()
    {
        throw new NotImplementedException();
    }

    internal object GetPiecesOfType<T>()
    {
        throw new NotImplementedException();
    }

    internal void RemoveMovesEnablingAttakOnPieceOfType<T>(ChessPlayer activePlayer, Piece attackedKing)
    {
        throw new NotImplementedException();
    }

    internal bool CanHidePieceFromAttack<T>(ChessPlayer activePlayer)
    {
        throw new NotImplementedException();
    }

    internal void OnGameRestarted()
    {
        throw new NotImplementedException();
    }

    internal void RemovePiece(Piece piece)
    {
        throw new NotImplementedException();
    }
}
