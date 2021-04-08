using UnityEngine;

public class Number : MonoBehaviour
{

    [HideInInspector]
    public int ObjectID;
    public bool selected = false;

    private Vector3 DEFAULT_SCALE;

    private void Start()
    {
        DEFAULT_SCALE = new Vector3(1f, 1f, 1f);
    }

    private void Update()
    {
        if (transform.localScale == DEFAULT_SCALE)
            gameObject.GetComponent<Animator>().enabled = false;
    }

}
