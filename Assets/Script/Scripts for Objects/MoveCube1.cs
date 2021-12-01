using UnityEngine;

public class MoveCube1 : MonoBehaviour
{
    public enum Directions
    {
        Rotate,
        Move
    }

    public Directions thisObject = Directions.Move;

    [SerializeField]
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (thisObject)
        {
            case Directions.Rotate:
                {
                    gameObject.transform.Rotate(-Vector3.right * speed * 0 * Time.deltaTime);
                    break;
                }
            case Directions.Move:
                {
                    gameObject.transform.Translate(-Vector3.right * speed * Time.deltaTime * Mathf.Sin(Time.time));
                    break;
                }
        }
    }
}
