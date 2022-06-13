using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shot : MonoBehaviour
{
    public Transform transOrigin;
    public GameObject prefBullet;
    public float shotCooldown = 1.0f;

    protected RaycastHit raycastHit;
    protected Ray ray;
    protected bool cooldownShoot;
    protected GameObject goBullet;

    protected bool shot;

    private void Start()
    {
        ray = new Ray();
    }

    public void HandleShot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            shot = true;
        }
        if (context.canceled)
        {
            shot = false;
        }
    }

    private void Update()
    {
        if (!cooldownShoot && shot)
        {
            cooldownShoot = true;

            Invoke("CooldownShoot", shotCooldown);

            SimulatedShot();
        }
    }

    protected void SimulatedShot()
    {
        goBullet = Instantiate(prefBullet);

        goBullet.transform.position = transOrigin.position + transform.forward;
        goBullet.transform.forward = transOrigin.forward;

        goBullet.GetComponent<Bullet>().shot = this;
    }

    protected void CooldownShoot()
    {
        cooldownShoot = false;
    }
}
