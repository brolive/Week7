using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float amount = 0;

    public float prevX = 0;

    public GameObject bullet;
    public GameObject splosion;
    public Transform gun;

    AudioSource aS;

    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Rigidbody rb = GetComponent<Rigidbody>();
        /*rb.velocity = new Vector3(h * speed,
                                  rb.velocity.y,
                                  v * speed);*/

        transform.Translate(h * Time.deltaTime * speed, 0, v * Time.deltaTime * speed);

        float mouseXDelta = Input.mousePosition.x - prevX;
        amount += mouseXDelta;

        transform.rotation = Quaternion.Euler(new Vector3(0, amount, 0));


        /*amount += 1;
        transform.rotation = Quaternion.Euler(new Vector3(0, amount, 0));
        */

        prevX = Input.mousePosition.x;
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            aS.Play();
           

            if(Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log(hit.transform.tag);
                // damage enemy here
                Instantiate(splosion, hit.point, Quaternion.Euler(Vector3.zero));
            }

            GameObject b = Instantiate(bullet, gun.position, transform.rotation);
            //b.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 100);
        }

        Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.blue);
    }
}
