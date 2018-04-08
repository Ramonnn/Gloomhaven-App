﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class TestRegex : MonoBehaviour
{
    public TestDeck currentCard;
    public Dictionary<string, int> normalMonsterStats;
    public Dictionary<string, int> eliteMonsterStats;
    public Dictionary<string, string> MACROS = new Dictionary<string, string>() {

      { "%air%", "<img class='element' src='images/air.svg'>" }
    , { "%any%","<img class='element' src='images/any_element.svg'>" }
    , { "%aoe-4-with-black%", "<img class='aoe h2' src='images/aoe-4-with-black.svg'>" }
    , { "%aoe-circle%", "<div class='collapse small'><img class='aoe h3' src='images/aoe-circle.svg'></div>" }
    , { "%aoe-circle-with-middle-black%", "<div class='collapse small'><img class='aoe h3' src='images/aoe-circle-with-middle-black.svg'></div>" }
    , { "%aoe-circle-with-side-black%", "<img class='aoe h3' src='images/aoe-circle-with-side-black.svg'>" }
    , { "%aoe-line-3-with-black%", "<div class='collapse'><img class='aoe h1 rotated' src='images/aoe-line-3-with-black.svg'></div>" }
    , { "%aoe-line-4-with-black%", "<div class='collapse'><img class='aoe h1 rotated' src='images/aoe-line-4-with-black.svg'></div>" }
    , { "%aoe-line-6-with-black%", "<img class='aoe h6 right-aligned' src='images/aoe-line-6-with-black.svg'></div>" }
    , { "%aoe-triangle-2-side%", "<div class='collapse'><img class='aoe h2' src='images/aoe-triangle-2-side.svg'></div>" }
    , { "%aoe-triangle-2-side-with-black%", "<div class='collapse'><img class='aoe h2' src='images/aoe-triangle-2-side-with-black.svg'></div>" }
    , { "%aoe-triangle-3-side-with-corner-black%", "<div class='collapse'><img class='aoe h3' src='images/aoe-triangle-3-side-with-corner-black.svg'></div>" }
    , { "%attack%", "<span class='nobr'>Attack, <img class='icon' src='images/attack.svg'></span>" }
    , { "%bless%", "<span class='nobr'>BLESS, <img class='icon' src='images/bless.svg'></span>" }
    , { "%boss-aoe-elder-drake-sp1%", "<div class='collapse'><img class='aoe h3' src='images/elderDrake.special1Area.svg'></div>" }
    , { "%boss-aoe-inox-bodyguard-sp1%", "<div class='collapse'><img class='aoe h3' src='images/inoxBodyguard.special1Area.svg'></div>" }
    , { "%boss-aoe-sightless-eye-sp1%", "<div class='collapse'><img class='aoe h3' src='images/sightlessEye.special1Area.svg'></div>" }
    , { "%boss-aoe-sightless-eye-sp2%", "<div class='collapse'><img class='aoe h3' src='images/sightlessEye.special2Area.svg'></div>" }
    , { "%curse%", "<span class='nobr'>CURSE <img class='icon' src='images/curse.svg'></span>" }
    , { "%dark%", "<img class='element' src='images/dark.svg'>" }
    , { "%disarm%", "<span class='nobr'>DISARM <img class='icon' src='images/disarm.svg'></span>" }
    , { "%earth%", "<img class='element' src='images/earth.svg'>" }
    , { "%fire%", "<img class='element' src='images/fire.svg'>" }
    , { "%heal%", "<span class='nobr'>Heal <img class='icon' src='images/heal.svg'></span>" }
    , { "%ice%", "<img class='element' src='images/ice.svg'>" }
    , { "%immobilize%", "<span class='nobr'>IMMOBILIZE <img class='icon' src='images/immobilize.svg'></span>" }
    , { "%invisible%", "<span class='nobr'>INVISIBLE <img class='icon' src='images/invisibility.svg'></span>" }
    , { "%jump%", "<span class='nobr'>Jump <img class='icon' src='images/jump.svg'></span>" }
    , { "%light%", "<img class='element' src='images/light.svg'>" }
    , { "%loot%", "<span class='nobr'>Loot <img class='icon' src='images/loot.svg'></span>" }
    , { "%move%", "<span class='nobr'>Move <img class='icon' src='images/move.svg'></span>" }
    , { "%muddle%", "<span class='nobr'>MUDDLE <img class='icon' src='images/muddle.svg'></span>" }
    , { "%pierce%", "<span class='nobr'>PIERCE <img class='icon' src='images/pierce.svg'></span>" }
    , { "%poison%", "<span class='nobr'>POISON <img class='icon' src='images/poison.svg'></span>" }
    , { "%pull%", "<span class='nobr'>PULL <img class='mirrored icon' src='images/push.svg'></span>" }
    , { "%push%", "<span class='nobr'>PUSH <img class='icon' src='images/push.svg'></span>" }
    , { "%range%", "<span class='nobr'>Range <img class='icon' src='images/range.svg'></span>" }
    , { "%retaliate%", "<span class='nobr'>Retaliate <img class='icon' src='images/retaliate.svg'></span>" }
    , { "%shield%", "<span class='nobr'>Shield <img class='icon' src='images/shield.svg'></span>" }
    , { "%flying%", "<span class='nobr'><img class='icon' src='images/fly.svg'></span>" }
    , { "%strengthen%", "<span class='nobr'>STRENGTHEN <img class='icon' src='images/strengthen.svg'></span>" }
    , { "%stun%", "<span class='nobr'>STUN <img class='icon' src='images/stun.svg'></span>" }
    , { "%target%", "<span class='nobr'>Target <img class='icon' src='images/target.svg'></span>" }
    , { "%use_element%", "<img class='element overlay' src='images/use_element.svg'>" }
    , { "%wound%", "<span class='nobr'>WOUND <img class='icon' src='images/wound.svg'></span>" }

    };



    public void IdentifyStat(TestDeck currentCard)
    {
        var regExp = new Regex("(\\*\\s\\% (attack | range | move)\\%)\\s\\+\\d");
        for (int i = 0; i < currentCard.modifierLines.Count; i++)
        {
            Match match = regExp.Match("attack");
            Debug.Log(match.Value);
            //foreach (Match match in matches)
            //{
            //    if (matches[0].ToString() == "attack")
            //    {
            //        regExp.Replace(matches[0].ToString(), "<sprite=20>");
            //    }
            //    if (matches[0].ToString() == "move")
            //    {
            //        regExp.Replace(matches[0].ToString(), "<sprite=20>");
            //    }
            //    if (matches[0].ToString() == "range")
            //    {
            //        regExp.Replace(matches[0].ToString(), "<sprite=20>");
            //    }
            //}
        }
    }


    //private void FindString(string stat)
    //{
    //    foreach (string line in currentCard.modifierLines)
    //    {
    //        var regExp = new Regex("%" + stat + "% (\\+|-)(\\d*)", RegexOptions.IgnoreCase);
    //        regExp.Match(line);
    //    }
    //}
    //// Use this for initialization
    //void Start()
    //{
    //    currentCard = GetComponent<TestAbilityDeckHandler>().currentCard;
    //    currentMonsters =
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}