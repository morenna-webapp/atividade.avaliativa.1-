using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damageToGive = 1;

    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
      
        Destroy(gameObject, 3f);
    }

    
    private void OnTriggerEnter(Collider other)
    {
      
        Target target = other.GetComponent<Target>();

        if (target != null)
        {
            
            target.TakeDamage(damageToGive);
            
           
            Destroy(gameObject);
        }
    }
}
