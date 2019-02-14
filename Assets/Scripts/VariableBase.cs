using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class VariableBase {

    #region LevelManagment

    private static int _levelNumber = 0;

    public static int LevelNumber
    {
        get
        {
            // TODO: change back - fix so it's more intuitive
            _levelNumber = (SceneManager.GetActiveScene().buildIndex + 1)%SceneManager.sceneCountInBuildSettings;
            return _levelNumber;
        }
        set
        {
            _levelNumber = value;
        }
    }

    public static void resetLevelNumber()
    {
        _levelNumber = 0;
    }

    #endregion

    #region CameraManagment
    private static Vector3[] cameraPositions = { new Vector3(1810f, 0f, 8f),
                                                new Vector3(1870f, 0f, 7f),
                                                new Vector3(1916.4f, 0f, 4.3f),
                                                new Vector3(1970.38f, 0f, 7f) };

    public static bool initiatePositions(Vector3[] positions)
    {
        cameraPositions = positions;
        return true;
    }

    public static bool setCameraPosition(int index, Vector3 position)
    {
        cameraPositions[index] = position;
        return true;
    }

    public static Vector3 getCameraPosition(int index)
    {
       return cameraPositions[index];
    }
    #endregion

    #region PlayerInfo

    #region Values

    private static string _playerName = "Učenec";
    public static string PlayerName
    {
        get { return _playerName; }
        set
        {
            if (value != _playerName)
                _playerName = value;
        }
    }

    private static int _savePoint;
    public static int SavePoint
    {
        get { return _savePoint; }
        set
        {
            if (value != _savePoint)
                _savePoint = value;
        }
    }

    #endregion

    #region Methods

    //shranjevanje podatkov - magari na disk; save game points - TODO

    #endregion

    #endregion PlayerInfo

    #region TextUtility
    /*
     * Write down every possible variable, that you might want to switch with in text,
     * just so there's no confusion later:
     * {0} - Player Name
     * {1} - 
     * {2} - 
    */
    public static string InsertVariables(string str)
    {
        return string.Format(str, VariableBase.PlayerName);
    }
    #endregion

}
