# Tennis Match Kata

Kata project to display tennis score and maintain the state of a tennis match between 2 players. Is composed by two completly seperated parts.

### Tennis Score Calculation Package 
Standalone API in charge of a tennis match management. Implemented using TDD.

 * check out the [API documentation](TennisMatch/Help/TennisMatch.chm)
 
##### Example of API usage:

Start a tennis match:
```cs
var match = new Match("Player1 Name", "Player2 Name");
```
Add player points:
```cs
var playerPoints = match.AddPlayerPoint(PlayerOrder.player1);
```
Other available methods:
```cs
// Get player Name
var playerName = match.GetPlayerName(PlayerOrder.player1)

// Get player score in the current game
var player1Score = match.GetPlayerGameScore(PlayerOrder.player1);
var player2Score = match.GetPlayerGameScore(PlayerOrder.player2);

// Get player won games inside a set
var player1WonGames = match.GetPlayerSetScore(PlayerOrder.player1, setNumber);
var player2WonGames = match.GetPlayerSetScore(PlayerOrder.player2, setNumber);

// Get the player server in the current game
var playerServer = match.GetPlayerServer();

// Check if the game, set or match are finished
var gameFinished = match.IsGameFinished();
var setFinished = match.IsSetFinished();
var matchFInished = match.IsMatchFinished();
```
### Score Visual Board 

Graphical user interface for the tennis scoring system. WPF project implemented using MVVM pattern. The visual application is composed by 2 screens:
  
  * The score screen which display score on the court for the spectators  
  * The referee panel with commands for the referee to help him during the match to advance the score.