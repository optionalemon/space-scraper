using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shootForce = 100f;
    Rigidbody rigidbody;
    public float timeToDestroy = 10;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

	// Using transform.up instead of transform.forward because the bullet was rotated 90 degrees in the x-axis in GunController.cs
        rigidbody.AddForce(transform.up * shootForce); 
    }

    void Update() 
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy < 0)
        {
            Destroy(gameObject);
        }
    }

}


