using TMPro;
using UnityEngine;

public class Rankings : MonoBehaviour
{
    public TextMeshProUGUI[] Names; 
    public TextMeshProUGUI[] Scores; 
    public float[] HighScores; 
    public int savepos; 

    void Start()
    {
        CheckRank(LifeTraker.Instance.RunScore);
    }

    public void CheckRank(float newscore)
    {
        var index = 0;
        foreach (var score in HighScores)
        {
            index++;
            if (score < newscore)
            {
                savepos = index - 1;
                Scores[savepos].text = newscore.ToString();
            }
        }    
    }
}
