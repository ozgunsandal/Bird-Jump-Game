using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings 
{
    public static List<BirdProps> kuslar = new List<BirdProps> {new BirdProps {name="ates", platformName="pl1", buttonName="kirmizi", featherName="f1",deathSound="BirdDeath1Sound",gravity=2.75f,color=Color.yellow},
                                                                new BirdProps {name="gri", platformName="pl2", buttonName="sari", featherName="f2",deathSound="BirdDeath2Sound",gravity=4f,color=Color.gray},
                                                                new BirdProps {name="hiphop", platformName="pl3", buttonName="kahve", featherName="f3",deathSound="BirdDeath3Sound",gravity=1.90f,color=Color.yellow},
                                                                new BirdProps {name="kahve", platformName="pl4", buttonName="kahve", featherName="f4",deathSound="BirdDeath4Sound",gravity=5f,color=Color.gray},
                                                                new BirdProps {name="kartal", platformName="pl5", buttonName="kirmizi", featherName="f5",deathSound="BirdDeath2Sound",gravity=1f,color=Color.black},
                                                                new BirdProps {name="kirmizi", platformName="pl2", buttonName="kirmizi", featherName="f6",deathSound="BirdDeath4Sound",gravity=3f,color=Color.red},
                                                                new BirdProps {name="mavi", platformName="pl5", buttonName="kahve", featherName="f7",deathSound="BirdDeath3Sound",gravity=3.75f,color=Color.blue},
                                                                new BirdProps {name="mor", platformName="pl1", buttonName="sari", featherName="f8",deathSound="BirdDeath1Sound",gravity=4.50f,color=Color.magenta},
                                                                new BirdProps {name="ordek", platformName="pl4", buttonName="sari", featherName="f9",deathSound="DuckDeathSound",gravity=2.0f,color=Color.yellow},
                                                                new BirdProps {name="pembe", platformName="pl3", buttonName="kirmizi", featherName="f10",deathSound="BirdDeath3Sound",gravity=3.90f,color=Color.magenta},
                                                                new BirdProps {name="sari", platformName="pl2", buttonName="sari", featherName="f11",deathSound="BirdDeath1Sound",gravity=4.90f,color=Color.yellow},
                                                                new BirdProps {name="siyah", platformName="pl1", buttonName="kahve", featherName="f12",deathSound="BirdDeath2Sound",gravity=6f,color=Color.black}};
    public static int selectedBirdIndex = 11;
    public static int totalTopCloud = 5;
    public static float[] cloudSpeeds = {.1f,.2f,.3f,.4f,.5f};
}
