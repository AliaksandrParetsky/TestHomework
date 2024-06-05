using UnityEngine;

public class WanderingObj : MonoBehaviour
{
    private float speed = 2.0f;

    private bool isAlive;
    public bool Alive
    {
        get
        {
            return isAlive;
        }
        set
        {
            isAlive = value;
        }
    }

    private Material material;
    public Material Material { get { if (material == null) material = GetComponent<Material>(); return material; } }

    private void Start()
    {
        Alive = true;
    }

    private void Update()
    {
        if (Alive)
        {
            SetRotation();

            Alive = false;
        }

        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void SetRotation()
    {
        float angle = Random.Range(0, 360);
        transform.Rotate(0, angle, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, speed))
        {
            

            Vector3 newDirection = Vector3.Reflect(transform.forward, hit.normal);
            newDirection = new Vector3(newDirection.x, 0, newDirection.z);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
