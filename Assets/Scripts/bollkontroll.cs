using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 movement = Vector2.up; // Movement

        transform.Translate(movement* speed * Time.deltaTime);

        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(this.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
