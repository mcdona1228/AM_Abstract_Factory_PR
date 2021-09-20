using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimalFactory
{
    IAnimal Create(AnimalRequirements requirements);
}

public class ChickenFactory : IAnimalFactory
{
    public IAnimal Create(AnimalRequirements requirements)
    {
        switch (requirements.Teeth)
        {
            case 1:
                if (requirements.NumberOfLegs == 1) return new Chicken();
                return new Hawk();
            default:
                return new Hawk();
        }
    }
}

public class LizardAnimalFactory : IAnimalFactory
{
    public IAnimal Create(AnimalRequirements requirements)
    {
        switch (requirements.Teeth)
        {
            case 1:
                return new Lizard();
            default:
                return new Komodo_Dragon();
        }
    }
}

public abstract class AbstractAnimalFactory
{
    //public abstract IVehicleFactory CycleFactory();
    //public abstract IVehicleFactory MotorVehicleFactory();

    public abstract IAnimal Create();
}



public class AnimalFactory : AbstractAnimalFactory
{
    //public override IVehicleFactory CycleFactory()
    //{
    //    return new CycleFactory();
    //}

    //public override IVehicleFactory MotorVehicleFactory()
    //{
    //    return new MotorVehicleFactory();
    //}

    private readonly IAnimalFactory _factory;
    private readonly AnimalRequirements _requirements;

    public AnimalFactory(AnimalRequirements requirements)
    {
        _factory = requirements.Feathers ? (IAnimalFactory)new LizardAnimalFactory() : new ChickenFactory();
        _requirements = requirements;
    }

    public override IAnimal Create()
    {
        return _factory.Create(_requirements);
    }
}
