using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public int NumberOfLegs;
    public bool Feathers;
    public int Teeth;
    public bool Tail;

    // Start is called before the first frame update
    void Start()
    {
        // validate our data
        NumberOfLegs = Mathf.Max(NumberOfLegs, 1);
        Teeth = Mathf.Max(Teeth, 1);
        Feathers = Tail;

        AnimalRequirements requirements = new AnimalRequirements();
        requirements.NumberOfLegs = NumberOfLegs;
        requirements.Feathers = Feathers;
        requirements.Teeth = Teeth;

        //IVehicle v = new Unicycle();
        IAnimal v = GetAnimal(requirements);
        Debug.Log(v);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private static IAnimal GetAnimal(AnimalRequirements requirements)
    {
        AnimalFactory factory = new AnimalFactory(requirements);
        return factory.Create();
    }
}