using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instace {get; set;}
    string highScoreKey = "BestWaveSavedValue";
    private void Awake()
    {
        if(Instace != null && Instace !=this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instace=this;
        }
        DontDestroyOnLoad(this);
    }

    public void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt(highScoreKey,score);
    }

    public int LoadHighScore()
    {
        if(PlayerPrefs.HasKey(highScoreKey))
        {
            return PlayerPrefs.GetInt(highScoreKey);
        }
        return 0;
    }
    
}
