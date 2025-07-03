using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform shootPoint;
    public float shootForce = 5f;
    public int maxAmmo = 5;
    private int currentAmmo;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentAmmo > 0)
        {
            GameObject bullet = BulletPool.instance.GetBullet();
            bullet.transform.position = shootPoint.position;
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * shootForce;

            currentAmmo--;
            if (currentAmmo <= 0)
            {
                // Desactivar arma, eliminar, etc.
                Destroy(gameObject); // o esconderla
            }
        }
    }

    public void SetAmmo(int amount)
    {
        maxAmmo = amount;
        currentAmmo = amount;
    }
}
