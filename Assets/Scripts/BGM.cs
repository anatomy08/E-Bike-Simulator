using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    static BGM instance; // Static reference to the BGM class itself

    public static BGM GetInstance() // Static method to get the BGM instance
    {
        return instance;
    }

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            // If an instance already exists, deactivate and destroy this GameObject
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            // Set this instance as the singleton instance and don't destroy it on scene load
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
