using UnityEngine;

public class RotateAnim : MonoBehaviour
{
    public float speed = 0.5f;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = new Vector3(0, 0 + speed, 0);
        transform.Rotate(rot);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("finished");
        gm.FinishGame();
    }
}
