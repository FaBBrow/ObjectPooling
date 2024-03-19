using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObjectPooling : MonoBehaviour
{
    public int poolSize = 10;
    public GameObject bulletPrefab;
    public Queue<GameObject> pool;
    public Transform bulletpoz;
    public Vector3 shotdirection;
    public float bulletspeed;
    private void Start()
    {
        pool = new Queue<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, Vector2.zero, Quaternion.identity);
            bullet.SetActive(false);    
            pool.Enqueue(bullet);
        }
    }
    public GameObject getFromPool()
    {
        if (pool.Count > 0) { 
        GameObject bullet=pool.Dequeue();
        bullet.SetActive(true);
        return bullet;
        }
        return null;
    }
 
  
    IEnumerator Poller(GameObject bullet)
    {
        yield return new WaitForSeconds(3f);
        bullet.SetActive(false);
        pool.Enqueue(bullet);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (pool.Count>0) { 
            GameObject bullet=getFromPool();
            bullet.transform.position = bulletpoz.position;
            shotdirection = (Player.instance.mousepoint - bulletpoz.position);
            Rigidbody2D bulletRigidbody=bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = shotdirection * bulletspeed;
            StartCoroutine(Poller(bullet));
            }
        }
    }

}
