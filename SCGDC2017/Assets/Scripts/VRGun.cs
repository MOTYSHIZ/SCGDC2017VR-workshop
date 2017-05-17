using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK.Examples
{
    public class VRGun : VRTK_InteractableObject
    {
        private GameObject bullet;
        private float bulletSpeed = 1000f;
        private float bulletLife = 5f;

        public override void StartUsing(GameObject currentUsingObject)
        {
            base.StartUsing(currentUsingObject);
            FireBullet();
        }

        // Use this for initialization
        void Awake()
        {
            bullet = transform.Find("bullet").gameObject;
            bullet.SetActive(false);
        }

        // Update is called once per frame
        void FireBullet()
        {
            GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(bulletClone.transform.forward * bulletSpeed);
            Destroy(bulletClone, bulletLife);
        }
    }
}