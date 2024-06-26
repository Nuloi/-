using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCntroller : MonoBehaviour
{
    float v=0;
    float h=0;
    
    public float speed =10;

    Animator anime;

    void Update()
    {
        v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        h = Input.GetAxis("Horizontal");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(moveDir.normalized * Time.deltaTime * speed);

        
    }
}
