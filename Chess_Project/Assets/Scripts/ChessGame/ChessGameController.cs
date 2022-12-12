using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(PieceCreator))]
public class ChessGameController : MonoBehaviour
{
    //protected const byte SET_GAME_STATE_EVENT_CODE = 1;

    [SerializeField] private BoardLayout startingBoardLayout;
    [SerializeField] private Board board;

    //private ChessUIManager UIManager;
    //private CameraSetup cameraSetup;
    //private Board board;
    private PieceCreator pieceCreator;
    protected ChessPlayer whitePlayer;
    protected ChessPlayer blackPlayer;
    protected ChessPlayer activePlayer;


    //protected GameState state;

    private void Awake()
    {
        pieceCreator = GetComponent<PieceCreator>();
        CreatePlayers();
    }

    private void CreatePlayers()
    {
        whitePlayer = new ChessPlayer(TeamColor.White, board);
        blackPlayer = new ChessPlayer(TeamColor.Black, board);
    }

    

    //internal void SetDependencies(CameraSetup cameraSetup, ChessUIManager UIManager, Board board)
    //{
    //this.cameraSetup = cameraSetup;
    //this.UIManager = UIManager;
    //this.board = board;
    // }

    //public void InitializeGame()
    //{
    //CreatePlayers();
    //}


    //private void CreatePlayers()
    //{
    // whitePlayer = new ChessPlayer(TeamColor.White, board);
    //blackPlayer = new ChessPlayer(TeamColor.Black, board);
    // }
    private void Start()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        //UIManager.OnGameStarted();
        //SetGameState(GameState.Init);
        board.SetDependencies(this);
        CreatePiecesFromLayout(startingBoardLayout);
        activePlayer = whitePlayer;
        GenerateAllPossiblePlayerMoves(activePlayer);
        //TryToStartThisGame();

    }

    

    private void GenerateAllPossiblePlayerMoves(ChessPlayer player)
    {
        player.GenerateAllPossibleMoves();
    }

    public void EndTurn()
    {
        GenerateAllPossiblePlayerMoves(activePlayer);
        GenerateAllPossiblePlayerMoves(GetOpponentToPlayer(activePlayer));
        ChangeActiveTeam();
        
    }

    private void ChangeActiveTeam()
    {
        activePlayer = activePlayer == whitePlayer ? blackPlayer : whitePlayer;
    }

    private ChessPlayer GetOpponentToPlayer(ChessPlayer player)
    {
       return player == whitePlayer ? blackPlayer : whitePlayer ;
    }

    private void SetGameState(object init)
    {
        throw new NotImplementedException();
    }

    //protected void SetGameState(GameState state);
   // public void TryToStartThisGame();
    //public bool CanPerformMove();

    //internal bool IsGameInProgress()
    //{
        //return state == GameState.Play;
   // }



    private void CreatePiecesFromLayout(BoardLayout layout)
    {
        for (int i = 0; i < layout.GetPiecesCount(); i++)
        {
            Vector2Int squareCoords = layout.GetSquareCoordsAtIndex(i);
            TeamColor team = layout.GetSquareTeamColorAtIndex(i);
            string typeName = layout.GetSquarePieceNameAtIndex(i);

            Type type = Type.GetType(typeName);
            CreatePieceAndInitialize(squareCoords, team, type);


        }
    }

    private void CreatePieceAndInitialize(Vector2Int squareCoords, TeamColor team, Type type)
    {
        Piece newPiece = pieceCreator.CreatePiece(type).GetComponent<Piece>();
        newPiece.SetData(squareCoords, team, board);

        Material teamMaterial = pieceCreator.GetTeamMaterial(team);
        newPiece.SetMaterial(teamMaterial);

        board.SetPieceOnBoard(squareCoords, newPiece);
        ChessPlayer currentPlayer = team == TeamColor.White ? whitePlayer : blackPlayer;
        currentPlayer.AddPiece(newPiece);
    }
    public bool IsTeamTurnActive(TeamColor team)
    {
        return activePlayer.team == team;
    }
}
