using System.ComponentModel;

namespace BattleshipControl
{
    /// <summary>
    /// The enumerator for different type of occupation for board's cells
    /// Author: Roman Belovolov
    /// Date: 08/04/2018
    /// </summary>
    public enum OccupationType
    {
        Empty,
        Battleship,
        Cruiser,
        Destroyer,
        Submarine,
        Carrier,
        Hit,
        Sink,
        Miss
    }
    /// <summary>
    /// The enumerator for shot results
    /// Author: Roman Belovolov
    /// Date: 08/04/2018
    /// </summary>
    public enum ShotResult
    {
        Miss,
        Hit,
        Sink
    }

    public enum GamePhase
    {
        Setup,
        ManualSetup,
        Play
    }
    /// <summary>
    /// The enumerator for the orientation of a ship
    /// Author: Roman Belovolov
    /// Date: 08/04/2018
    /// </summary>
    public enum ShipDirection
    {
        Horizontal,
        Vertical
    }
}