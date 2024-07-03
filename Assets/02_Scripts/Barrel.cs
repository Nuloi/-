using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Barrel : MonoBehaviour
{
    // [SerializeField] private GameObject expEffect;
    // [SerializeField] private Texture[] textures;
    // [SerializeField] private AudioClip expSfx;

    // ScriptableObject 연결
    [SerializeField] private BarrelDataSO barrelDataSO;

    private int hitCount;
    private new MeshRenderer renderer;
    private new AudioSource audio;

    void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();
        audio = GetComponent<AudioSource>();

        int idx = UnityEngine.Random.Range(0, barrelDataSO.textures.Length); // 0, 1, 2
        renderer.material.mainTexture = barrelDataSO.textures[idx];
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    private void ExpBarrel()
    {
        // Random Impact Position 
        Vector3 impactPoint = UnityEngine.Random.insideUnitSphere * 1.5f;

        var rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddExplosionForce(1500.0f, transform.position + impactPoint, 5.0f, 1800.0f);

        Destroy(this.gameObject, 2.5f);
        var obj = Instantiate(barrelDataSO.effectPrefab, transform.position, Quaternion.identity);
        Destroy(obj, 5.0f);

        // Play Explosion SFX
        audio.PlayOneShot(barrelDataSO.expAudioClip, 0.9f);
    }
}
