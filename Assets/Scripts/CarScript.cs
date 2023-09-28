using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarScript : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float increaseSpeedOverTime = 0.3f;
    [SerializeField] float turnSpeed = 200f;
    
    int steervalue; // if positive we turn right if negative we turn left

    // Update is called once per frame
    void Update()
    {
        speed += increaseSpeedOverTime * Time.deltaTime;

        transform.Rotate(0f, steervalue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Obstacle")
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Steer(int value)
    {
        steervalue = value;
    }


}
