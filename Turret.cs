using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;



public class Turret : MonoBehaviour
{
    public float Range;
    public Transform Target;
    private bool Detected;
    private Vector2 Direction;
    public GameObject AlarmLight;
    public GameObject GunPoint;
    public float FireRate;
    public float nextTimeToFire = 0;
    public Transform ShootPoint;
    public Rigidbody2D bullet;
    
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                Detected = true;
                
                if (Detected == true)
                {
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
             if (rayInfo.collider.gameObject.tag != "Player")
             {
                 Detected = false;
                 if (Detected == false)
                 {
                     AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                 }
             }
            
        }

        if (Detected)
        {
            GunPoint.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                Shoot();
            }
        }
        
        
    }

    void Shoot()
    {
         //GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
         //BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
         
         Vector2 projecttilevelocity = CalculateProjectTileVelocity(ShootPoint.position, Target.position, 1f);
         Rigidbody2D fire = Instantiate(bullet, ShootPoint.position, quaternion.identity);
         fire.velocity = projecttilevelocity;
    }

    private void OnDrawGizmos()
    {
       Gizmos.DrawWireSphere(transform.position,Range); 
    }
    
                //enemy.transform.position = new Vector2(hit2D.point.x, hit2D.point.y);
    


    Vector2 CalculateProjectTileVelocity(Vector2 origin, Vector2 target, float t)
    {
        //distance between two point
        Vector2 distance = target - origin;
        
        //distanceX
        Vector2 distanceX = distance;
        distanceX.y = 0f;
        float X = distanceX.magnitude;
        
        //distanceY
        float Y = distance.y;
        
        //find Vx, Vy
        float velocityX = X / t;
        float velocityY = Y / t + 0.5f * Mathf.Abs(Physics2D.gravity.y) * t;
        
        //merge velocity and direction
        Vector2 result = distanceX.normalized;
        result *= velocityX;
        result.y = velocityY;
        
        return result;
    }


}
