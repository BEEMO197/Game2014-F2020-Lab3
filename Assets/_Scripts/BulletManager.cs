using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bullet;
    public int maxBullets;

    private Queue<GameObject> m_bullets;
    // Start is called before the first frame update
    void Start()
    {
        BuildBulletPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildBulletPool()
    {
        m_bullets = new Queue<GameObject>();

        for(int i = 0; i < maxBullets; i++)
        {
            var tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            m_bullets.Enqueue(tempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bullets.Dequeue();

        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_bullets.Enqueue(returnedBullet);


    }
}
