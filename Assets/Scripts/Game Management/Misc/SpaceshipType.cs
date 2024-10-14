using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceshipType {
    public abstract float CalcStartingFuel(int level);
    public abstract float CalcThrust(int level);


}

public class BasicSpaceship : SpaceshipType {
    public override float CalcThrust(int level) {
        return 0.15f * (1 + 0.075f * level);
    }

    public override float CalcStartingFuel(int level) {
        return 300 * (1+0.175f*level);
    }

}

public class FuelFiller : SpaceshipType {
    public override float CalcThrust(int level) {
        return 0.1f * (1 + 0.025f * level);
    }
    
    public override float CalcStartingFuel(int level) {
        return 600 * (1 + 0.2f * level);
    }

}