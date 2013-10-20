using UnityEngine;

public class Fire : MonoBehaviour
{
    public float particleMultipler, colliderMultiplier;
    public float life = 0.01f;
    public float growthSpeed = 0.1f;
    public HelicopterWater playerInRange;
    public ParticleSystem pSys;

    private Vector3 initialColliderSize;

    void Start(){
        BoxCollider b = collider as BoxCollider;
        initialColliderSize = b.size;
    }

    private void Grow()
    {
        life += growthSpeed * Time.deltaTime;
    }

    public void Diminish()
    {
        if (playerInRange)
        {
            life = Mathf.Max(0, life - playerInRange.waterForce * Time.deltaTime);
            if (Dead)
                Destroy(gameObject);
        }
    }

    public bool Dead
    {
        get
        {
            return life <= 0;
        }
    }

    void Update()
    {
        Grow();
        UpdateCollider();
        UpdateParticleSystem();
    }

    private void UpdateCollider()
    {
        BoxCollider col = collider as BoxCollider;
        Vector3 size = initialColliderSize;
        size.x = size.z = (1 + life) * colliderMultiplier;
        col.size = size;
    }

    private void UpdateParticleSystem()
    {
        pSys.emissionRate = life * particleMultipler;
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.CompareTag("player"))
            playerInRange = c.GetComponent<HelicopterWater>();
    }

    void OnTriggerExit(Collider c)
    {
        if (c.CompareTag("player"))
            playerInRange = null;
    }
}