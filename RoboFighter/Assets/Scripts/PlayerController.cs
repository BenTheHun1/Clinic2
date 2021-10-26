using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Transform model;
    public Transform lookat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetAxis("Vertical") != 0f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime, ForceMode.Impulse);
        }

        lookat.localPosition = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        model.LookAt(lookat);
    }
}
