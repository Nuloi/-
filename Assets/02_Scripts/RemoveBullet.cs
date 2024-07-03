using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    [SerializeField] private GameObject sparkEffect;

    void OnCollisionEnter(Collision coll)
    {
        //if (coll.collider.tag == "BULLET")
        if (coll.collider.CompareTag("BULLET")) // GC 발생하지 않음.
        {
            // 충돌 정보 추출
            ContactPoint cp = coll.GetContact(0);

            // ContactPoint[] cp = coll.contacts;
            // cp[0].point;
            // cp[0].normal;

            // 충돌 지점
            Vector3 _point = cp.point;
            // 충돌 지점의 법선 벡터
            Vector3 _normal = -cp.normal;
            // 법선 벡터를 쿼터니언 타입으로 변환
            Quaternion rot = Quaternion.LookRotation(_normal);

            // 스파크 생성
            var obj = Instantiate(sparkEffect, _point, rot);
            Destroy(obj, 0.5f);

            Destroy(coll.gameObject);
        }
    }
}

/*
    Collider 컴포넌트의 IsTrigger 언체크

    OnCollisionEnter  => 1
    OnCollisionStay   => n
    OnCollisionExit   => 1

    Collider 컴포넌트의 IsTrigger 체크

    OnTriggerEnter
    OnTriggerStay
    OnTriggerExit

    # 충돌콜백함수가 호출되는 필수조건

     1. 양쪽 객체에 Collider 컴포넌트를 보유
     2. 이동하는 객체에는 반드시 Rigidbody 컴포넌트가 있어야 함

*/

