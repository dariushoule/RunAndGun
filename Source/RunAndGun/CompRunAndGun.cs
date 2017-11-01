﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;
using HugsLib.Settings;
using HugsLib;

namespace RunAndGun
{
    public class CompRunAndGun : ThingComp
    {

        private Pawn pawn
        {
            get
            {

                Pawn pawn = (Pawn) (parent as Pawn);
                if (pawn == null)
                    Log.Error("pawn is null");
                return pawn;
            }
        }
        public bool isEnabled = false; 





        public override void Initialize(CompProperties props)
        {
            base.Initialize(props);
            Pawn pawn = (Pawn)(parent as Pawn);
            ModSettingsPack settings = HugsLibController.SettingsManager.GetModSettings("RunAndGun");
            bool enableRGForAI = settings.GetHandle<bool>("enableRGForAI").Value;
            if (!pawn.IsColonist && enableRGForAI)
            {
                isEnabled = true;
            }
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref isEnabled, "isEnabled", false);
        }

    }
}

