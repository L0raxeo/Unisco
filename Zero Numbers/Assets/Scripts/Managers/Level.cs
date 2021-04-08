using UnityEngine;

public class Level : MonoBehaviour
{

    public Board board;
    public ScoreManager score;

    public GameObject[] selected;
    public bool isMatchValid = false;

    public void addition()
    {

        int targetSum = int.Parse(selected[0].name[0].ToString());

        int currentSum = 0;

        for (int i = 1; i < selected.Length; i++)
        {

            if (selected[i] == null)
                break;

            currentSum += int.Parse(selected[i].name[0].ToString());
        }

        if (targetSum == currentSum)
        {
            score.addScore(targetSum + currentSum);
            isMatchValid = true;
        }
    }

    public void multiplication()
    {

        int targetProduct = int.Parse(selected[0].name[0].ToString());

        int currentProduct = 1;

        for (int i = 1; i < selected.Length; i++)
        {
            if (selected[i] == null)
                break;

            currentProduct *= int.Parse(selected[i].name[0].ToString());
        }

        if (targetProduct == currentProduct)
        {
            score.addScore(targetProduct * currentProduct);
            isMatchValid = true;
        }
    }

    public void power()
    {

        int targetProduct = int.Parse(selected[0].name[0].ToString());

        if (selected[3] != null)
            return;

        if (Mathf.Pow(int.Parse(selected[1].name[0].ToString()), int.Parse(selected[2].name[0].ToString())) == targetProduct)
        {

            score.addScore(2 * (targetProduct * int.Parse(selected[1].name[0].ToString()) * int.Parse(selected[2].name[0].ToString())));
            isMatchValid = true;
        }

    }

    public void pythagoreanTriple()
    {

        if (selected[3] != null) return;

        if (int.Parse(selected[0].name[0].ToString()) == 3 && int.Parse(selected[1].name[0].ToString()) == 4 && int.Parse(selected[2].name[0].ToString()) == 5)
        {
            score.addScore(125);
            isMatchValid = true;
        }
        else
        {
            //Debug.Log("Not a match");
        }
    }


    public void repeated()
    {

        bool repeated = true;
        int targetNumber = int.Parse(selected[0].name[0].ToString());

        foreach (GameObject o in selected)
        {
            try
            {
                if (int.Parse(o.name[0].ToString()) != targetNumber)
                {
                    repeated = false;
                    break;
                }
            }
            catch
            {
                continue;
            }
        }

        if (repeated)
        {
            score.addScore(targetNumber);
            isMatchValid = true;
        }
    }

    public void consecutive()
    {

        bool consecutive = true;

        for (int i = 0; i < selected.Length; i++)
        {

            if (i == 0)
                continue;

            if (selected[i] == null)
                continue;

            if (int.Parse(selected[i].name[0].ToString()) != int.Parse(selected[i - 1].name[0].ToString()) + 1)
            {
                consecutive = false;
                break;
            }
        }

        if (consecutive)
        {
            isMatchValid = true;
            for (int i = 0; i < selected.Length; i++)
            {
                if (selected[i] == null)
                {
                    score.addScore(selected[i - 1].name[0]);
                    break;
                }
            }
        }

    }

}
