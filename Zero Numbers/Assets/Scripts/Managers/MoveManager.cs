using UnityEngine;
using TMPro;

public class MoveManager : MonoBehaviour
{

    public TMP_Text turns;

    public void addTurns(int turns)
    {
        this.turns.text = (int.Parse(this.turns.text) + turns).ToString();
    }

    public void subtractTurns(int turns)
    {
        this.turns.text = (int.Parse(this.turns.text) - turns).ToString();
    }

    public void setTurns(int turns)
    {
        this.turns.text = turns.ToString();
    }

    public int getTurnsLeft()
    {
        return int.Parse(turns.text);
    }

}
