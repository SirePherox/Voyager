using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    private float timer = 5.0f;
    private bool timerCanRun = false;
    private void Awake()
    {
        timerCanRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerCanRun)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
