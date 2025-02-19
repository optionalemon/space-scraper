using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public InputActionReference shoot;
    public GameObject bulletPrefab;
    
    public Transform firePoint;
    public float secondsBetweenShoot = 0.2f;
    float trackShoot;

    private int bullets = 0;

    void Start()
    {
   	shoot.action.Enable(); 
    }

    void Update() 
    {
        Debug.Log(shoot.action.ReadValue<float>());
        if (shoot.action.ReadValue<float>() == 1 & trackShoot <= 0 && bullets > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.transform.rotation = firePoint.rotation * Quaternion.Euler(90, 0, 0);
            trackShoot = secondsBetweenShoot;
            bullets--;
        }
        trackShoot -= Time.deltaTime;
    }

    public void loadBullets() {
        bullets += 10;
        Debug.Log("Loaded bullets, total bullets now: " + bullets);
    }
}

