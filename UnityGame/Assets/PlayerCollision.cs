using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject spellCall;
    private Collider spellTarget;
    bool collide;

    public void OnTriggerEnter(Collider other)
    {
        

        spellTarget = spellCall.GetComponent<SpellDisplay>().spellTarget.GetComponent<Collider>();

        if (other == spellTarget)
        {
            collide = true;
            spellCall.GetComponent<SpellDisplay>().telekinesisCollide(other, collide);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        spellTarget = spellCall.GetComponent<SpellDisplay>().spellTarget.GetComponent<Collider>();
        if (other == spellTarget)
        {
            collide = false;
            spellCall.GetComponent<SpellDisplay>().telekinesisCollide(other, collide);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
