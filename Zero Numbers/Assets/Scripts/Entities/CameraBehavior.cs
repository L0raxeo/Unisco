using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void stopShaking()
    {
        animator.SetBool("isShaking", false);
    }

}
