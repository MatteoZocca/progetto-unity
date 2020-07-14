using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAssigner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int apoggino= this.getRandom();
        Material b = Resources.Load<Material>("Materials/Barba" + apoggino);
        Material c = Resources.Load<Material>("Materials/Capelli" + apoggino);
        Material m = Resources.Load<Material>("Materials/Maglietta" + this.getRandom());
        Material[] materials = GetComponent<SkinnedMeshRenderer>().materials;
        if (materials.Length > 0)
        {
            materials[0] = c;
            materials[2] = m;
            materials[3] = b;
            GetComponent<SkinnedMeshRenderer>().materials = materials;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int getRandom()
    {
        int i = Random.Range(1, 4);
        return i;
    }
}
