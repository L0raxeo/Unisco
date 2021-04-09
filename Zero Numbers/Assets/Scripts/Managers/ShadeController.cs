using UnityEngine;

public class ShadeController : MonoBehaviour
{

    private Animator shade;

    private void Start()
    {
        shade = GetComponent<Animator>();
    }

    public void ToSolid()
    {
        shade.SetBool("isSolid", true);
    }

    public void ToClear()
    {
        shade.SetBool("isSolid", false);
    }

}
