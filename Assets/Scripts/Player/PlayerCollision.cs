using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float ps = 6;
    public float force = 4;

    public bool grounded;

    private Vector3 initalScale;

    // Start is called before the first frame update
    void Start()
    {
        initalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += ps * Vector3.right * Time.deltaTime;
            transform.localScale = new Vector3(initalScale.x, initalScale.y, initalScale.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += ps * Vector3.left * Time.deltaTime;
            transform.localScale = new Vector3(-initalScale.x, initalScale.y, initalScale.z);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(force * Vector3.up, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
        if (collision.collider.gameObject.layer == 10 && !grounded)
        {
            Destroy(collision.rigidbody.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = false;
        }
    }
}
