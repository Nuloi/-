using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float v; // 상하 화살표 키값 저장할 변수
    private float h; // 좌우 화살표 키값 저장할 변수
    private float r; // 회전 값을 저장할 변수

    // 이동 속도 변수
    [SerializeField] // 직렬화
    private float moveSpeed = 6.0f;  // 이동속도
    [SerializeField]
    private float turnSpeed = 200.0f; // 회전속도

    [SerializeField]
    private Animator animator;

    void Start()
    {
        Debug.Log("Hello World");
    }

    void Update()
    {
        v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        h = Input.GetAxis("Horizontal");
        r = Input.GetAxis("Mouse X");

        // 이동처리
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);
        // 회전처리
        transform.Rotate(Vector3.up * Time.deltaTime * r * turnSpeed);

        }

}