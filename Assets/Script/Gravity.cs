using UnityEngine;

public class ObjectManipulation : MonoBehaviour
{
    [SerializeField] private float attractionForce = 10f; //Attraction Force
    [SerializeField] private float repulsionForce = 10f; //Repulsion Force
    [SerializeField] private float interactionRadius = 10f; //Radius

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttractObjects();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RepelObjects();
        }
    }
    //Find objects
    private void AttractObjects()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Gravity"))
            {
                Vector3 direction = (transform.position - collider.transform.position).normalized;
                collider.GetComponent<Rigidbody>().AddForce(direction * attractionForce);
            }
        }
    }

    private void RepelObjects()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRadius); 
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Gravity"))
            {
                Vector3 direction = (collider.transform.position - transform.position).normalized;
                collider.GetComponent<Rigidbody>().AddForce(direction * repulsionForce);
            }
        }
    }

    //Display radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRadius); 
    }
}
