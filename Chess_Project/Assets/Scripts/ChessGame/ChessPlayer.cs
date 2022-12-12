using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPlayer 
{

    public TeamColor team { get; set; }
    public Board board { get; set; }
    public List<Piece> activePieces { get; private set; }

    public ChessPlayer(TeamColor team, Board board)
    {
        activePieces = new List<Piece>();
        this.board = board;
        this.team = team;
    }
    public void AddPiece(Piece piece)
    {
        if (!activePieces.Contains(piece))
            activePieces.Add(piece);
    }
    public void RemovePiece(Piece piece)
    {
        if (activePieces.Contains(piece))
            activePieces.Remove(piece);
    }
    public void GenerateAllPossibleMoves()
    {
        foreach (var piece in activePieces)
        {
            if (board.HasPiece(piece))
                piece.SelectAvaliableSquares();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
