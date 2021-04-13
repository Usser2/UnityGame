using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damageble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);

    }

    void OnTriggerEnter2D(Collider2D obj)
        {
            var component = obj.gameObject.GetComponent<hero>();
            if (component != null)
            {
            // ReloadLevel();
            GlobalVariable.Life = GlobalVariable.Life - 25;
                if (GlobalVariable.Life <= 0)
                {
                    ReloadLevel();
                }
            }
        }

    }
