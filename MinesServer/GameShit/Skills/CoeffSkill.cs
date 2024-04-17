using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesServer.GameShit.Skills
{
    internal class CoeffSkill
    {
        public static float Digcoast(float x)
        {
            float coast = 750;
            if (x > 1 && x <= 5) { coast = 750 + (x - 1) * 250; }
            if (x > 5 && x <= 25) { coast = 1750 + (x - 5) * 500; }
            if (x > 25 && x <= 50) { coast = 11750 + (x - 25) * 750; }
            if (x > 50 && x <= 100) { coast = 30500 + (x - 50) * 1000; }
            if (x > 100 && x <= 250) { coast = 80500 + (x - 100) * 10000; }
            if (x > 250 && x <= 500) { coast = 1580500 + (x - 250) * 10000; }
            if (x > 500 && x <= 1000) { coast = 4080500 + (x - 500) * 11000; }
            if (x > 1000) { coast = 9580500 + (x - 1000) * 1000; }
            return coast;
        }
        public static float Digeffect(float x)
        {
            float eff = 100f;
            if (x > 1) eff += x * 10;
            return eff;
        }
        public static float Digexp(float x)
        {
            float exp = 5;
            if (x > 1 && x <= 5) { exp = 5 + (x - 1) * 10; }
            if (x > 5 && x <= 10) { exp = 45 + (x - 5) * 20; }
            if (x > 10 && x <= 25) { exp = 145 + (x - 10) * 40; }
            if (x > 25 && x <= 50) { exp = 745 + (x - 25) * 75; }
            if (x > 50 && x <= 100) { exp = 2620 + (x - 50) * 150; }
            if (x > 100 && x <= 250) { exp = 10120 + (x - 100) * 200; }
            if (x > 250 && x <= 500) { exp = 40120 + (x - 250) * 50; }
            if (x > 500 && x <= 1000) { exp = 52620 + (x - 500) * 25; }
            if (x > 1000 && x <= 2500) { exp = 65120 + (x - 1000) * 10; }
            if (x > 2500) { exp = 80250; }
            return exp;
        }
        public static float Hpcoast(float x)
        {
            float coast = 400;
            if (x > 1 && x <= 5) { coast = 400 + (x - 1) * 200; }
            if (x > 5 && x <= 10) { coast = 1200 + (x - 5) * 500; }
            if (x > 10 && x <= 25) { coast = 3700 + (x - 10) * 1000; }
            if (x > 25 && x <= 50) { coast = 18700 + (x - 25) * 2500; }
            if (x > 50 && x <= 100) { coast = 81200 + (x - 50) * 5000; }
            if (x > 100 && x <= 250) { coast = 331200 + (x - 100) * 12000; }
            if (x > 250 && x <= 500) { coast = 2131200 + (x - 250) * 4000; }
            if (x > 500 && x <= 1000) { coast = 3131200 + (x - 500) * 10000; }
            if (x > 1000) { coast = 8150000; }
            return coast;
        }
        public static float Hpeffect(float x)
        {
            float eff = 10;
            if (x > 1 && x <= 5) { eff = 10 + (x - 1) * 7; }
            if (x > 5 && x <= 10) { eff = 38 + (x - 5) * 5; }
            if (x > 10 && x <= 25) { eff = 63 + (x - 10) * 4; }
            if (x > 25 && x <= 50) { eff = 123 + (x - 25) * 3; }
            if (x > 50 && x <= 100) { eff = 198 + (x - 50) * 2; }
            if (x > 100 && x <= 250) { eff = 198 + (x - 100) * 2; }
            if (x > 250 && x <= 500) { eff = 500 + (x - 250) * 2; }
            if (x > 500) { eff = 1000 + (x - 500) * 1; }
            return eff;
        }
        public static float Hpexp(float x)
        {
            float exp = 25;
            if (x > 1 && x <= 5) { exp = exp + (x - 1) * 5; }
            if (x > 5 && x <= 10) { exp = 45 + (x - 5) * 15; }
            if (x > 10 && x <= 25) { exp = 120 + (x - 10) * 15; }
            if (x > 25 && x <= 50) { exp = 345 + (x - 25) * 25; }
            if (x > 50 && x <= 100) { exp = 970 + (x - 50) * 75; }
            if (x > 100 && x <= 250) { exp = 4720 + (x - 100) * 100; }
            if (x > 250 && x <= 500) { exp = 19720 + (x - 250) * 150; }
            if (x > 500 && x <= 1000) { exp = 57220 + (x - 500) * 25; }
            if (x > 1000) { exp = 69750; }
            return exp;
        }
        public static float Minecoast(float x)
        {
            float coast = 500;
            if (x > 1 && x <= 5) { coast = 500 + (x - 1) * 250; }
            if (x > 5 && x <= 10) { coast = 1500 + (x - 5) * 500; }
            if (x > 10 && x <= 25) { coast = 4000 + (x - 10) * 750; }
            if (x > 25 && x <= 50) { coast = 15250 + (x - 25) * 1000; }
            if (x > 50 && x <= 100) { coast = 40250 + (x - 50) * 1500; }
            if (x > 100 && x <= 250) { coast = 115250 + (x - 100) * 10000; }
            if (x > 250 && x <= 500) { coast = 1615250 + (x - 250) * 7500; }
            if (x > 500 && x <= 1000) { coast = 3490250 + (x - 500) * 6000; }
            if (x > 1000 && x <= 2500) { coast = 6490250 + (x - 1000) * 2000; }
            if (x > 2500) { coast = 9500000; }
            return coast;
        }
        public static float Mineeffect(float x)
        {
            float eff = 0.2f;
            if (x > 1 && x <= 5) { eff = eff + x * 0.3f; }
            if (x > 5 && x <= 25) { eff = eff + 0.9f + x * 0.12f; }
            if (x > 25 && x <= 50) { eff = eff + 1.65f + x * 0.09f; }
            if (x > 50 && x <= 100) { eff = eff + 3.65f + x * 0.05f; }
            if (x > 100 && x <= 150) { eff = eff + 4.65f + x * 0.04f; }
            if (x > 150 && x <= 500) { eff = eff + 7.66f + x * 0.02f; }
            if (x > 500 && x <= 1000) { eff = eff + 10.16f + x * 0.015f; }
            if (x > 1000) { eff = eff + 17.66f + x * 0.0075f; }
            return eff;
        }
        public static float Mineexp(float x)
        {
            float exp = 50;
            if (x > 1 && x <= 5) { exp = exp + (x * 20); }
            if (x > 5 && x <= 25) { exp = exp + (x * 30) - 50; }
            if (x > 25 && x <= 50) { exp = exp + (x * 50) - 550; }
            if (x > 50 && x <= 100) { exp = exp + (x * 70) - 1050; }
            if (x > 100 && x <= 250) { exp = exp + (x * 125) - 6625; }
            if (x > 250 && x <= 500) { exp = exp + (x * 150) - 12875; }
            if (x > 500 && x <= 1000) { exp = exp + (x * 35.65f) + 44300; }
            if (x > 1000) { exp = 80000; }
            return exp;
        }
        public static float Movecoast(float x)
        {
            float coast = 1500;
            if (x > 1 && x <= 5) { coast = 1500 + (x - 1) * 500; }
            if (x > 5 && x <= 25) { coast = 3500 + (x - 5) * 2000; }
            if (x > 25 && x <= 50) { coast = 43500 + (x - 25) * 2500; }
            if (x > 50 && x <= 100) { coast = 106000 + (x - 50) * 10000; }
            if (x > 100 && x <= 200) { coast = 606000 + (x - 100) * 20000; }
            if (x > 200 && x <= 500) { coast = 2606000 + (x - 200) * 30000; }
            if (x > 500) { x = 11750000; }
            return coast;
        }
        public static float Moveexp(float x)
        {
            float exp = 50;
            if (x > 1 && x <= 5) { exp = x * 50; }
            if (x > 5 && x <= 25) { exp = 250 + (x - 5) * 150; }
            if (x > 25 && x <= 50) { exp = 3250 + (x - 25) * 250; }
            if (x > 50 && x <= 100) { exp = 9500 + (x - 50) * 200; }
            if (x > 100 && x <= 250) { exp = 19500 + (x - 100) * 250; }
            if (x > 250 && x <= 500) { exp = 57000 + (x - 250) * 500; }
            if (x > 500) { x = 182000; }
            return exp;
        }
        public static float Moveeff(float x)
        {
            float eff = 2;
            if (x > 1) { eff = 2f + (x - 1f) * 0.4f; }
            if (x > 50) { eff = 2f + 19.6f + ((x - 50f) * 0.5f); }
            if (x > 70) { eff = 2f + 19.6f + 10f + (x - 70f) * 0.4f; }
            if (x > 90) { eff = 2f + 19.6f + 10f + 8f + (x - 90f) * 0.25f; }
            if (x > 120) { eff = 2f + 19.6f + 10f + 8f + 7.5f + ((x - 120f) * 0.15f); }
            if (x > 150) { eff = 2f + 19.6f + 10f + 8f + 7.5f + 4.5f + ((x - 150f) * 0.011f); }
            if (eff > 75f) eff = 75f; 
            return eff;
        }
        public static float Greencoast(float x)
        {
            float coast = 400;
            if (x > 1 && x <= 5) { coast = 400 + (x - 1) * 200; }
            if (x > 5 && x <= 10) { coast = 1200 + (x - 5) * 500; }
            if (x > 10 && x <= 25) { coast = 3700 + (x - 10) * 1000; }
            if (x > 25 && x <= 50) { coast = 18700 + (x - 25) * 2500; }
            if (x > 50 && x <= 100) { coast = 81200 + (x - 50) * 5000; }
            if (x > 100 && x <= 250) { coast = 331200 + (x - 100) * 12000; }
            if (x > 250 && x <= 500) { coast = 2131200 + (x - 250) * 4000; }
            if (x > 500 && x <= 1000) { coast = 3131200 + (x - 500) * 10000; }
            if (x > 1000) { coast = 8150000; }
            return coast;
        }
        public static float Greenexp(float x)
        {
            float exp = 10;
            if (x > 1 && x <= 5) { exp = 10 + (x - 1) * 10; }
            if (x > 5 && x <= 10) { exp = 50 + (x - 5) * 15; }
            if (x > 10 && x <= 25) { exp = 125 + (x - 10) * 25; }
            if (x > 25 && x <= 50) { exp = 500 + (x - 25) * 45; }
            if (x > 50 && x <= 100) { exp = 1625 + (x - 50) * 80; }
            if (x > 100 && x <= 250) { exp = 16125 + (x - 100) * 70; }
            if (x > 250 && x <= 1000) { exp = 26625 + (x - 250) * 20; }
            if (x > 1000) { exp = 41625 + (x - 1000) * 10; }
            return exp;
        }
        public static float Greeneff(float x)
        {
            float eff = 1;
            if (x > 1 && x <= 5) { eff = 1 + (x - 1) * 0.75f; }
            if (x > 5 && x <= 25) { eff = 4 + (x - 5) * 0.4f; }
            if (x > 25 && x <= 50) { eff = 12 + (x - 25) * 0.3f; }
            if (x > 50 && x <= 250) { eff = 19.5f + (x - 50) * 0.1f; }
            if (x > 250 && x <= 1000) { eff = 39.5f + (x - 50) * 0.05f; }
            if (x > 1000) { eff = 87; }
            return eff;
        }
        public static float Yellowcoast(float x)
        {
            float coast = 400;
            if (x > 1 && x <= 5) { coast = 400 + (x - 1) * 250; }
            if (x > 5 && x <= 10) { coast = 1400 + (x - 5) * 600; }
            if (x > 10 && x <= 25) { coast = 4400 + (x - 10) * 1200; }
            if (x > 25 && x <= 50) { coast = 22400 + (x - 25) * 2750; }
            if (x > 50 && x <= 100) { coast = 91150 + (x - 50) * 5500; }
            if (x > 100 && x <= 250) { coast = 366150 + (x - 100) * 14000; }
            if (x > 250 && x <= 500) { coast = 2466150 + (x - 250) * 4000; }
            if (x > 500 && x <= 1000) { coast = 3466150 + (x - 500) * 15000; }
            if (x > 1000) { coast = 11000000; }
            return coast;
        }
        public static float Yelloweffect(float x)
        {
            float eff = 1;
            if (x > 1 && x <= 5) { eff = 1 + (x - 1) * 0.85f; }
            if (x > 5 && x <= 25) { eff = 4.4f + (x - 5) * 0.6f; }
            if (x > 25 && x <= 50) { eff = 16.4f + (x - 25) * 0.4f; }
            if (x > 50 && x <= 250) { eff = 26.4f + (x - 50) * 0.2f; }
            if (x > 250 && x <= 1000) { eff = 66.4f + (x - 50) * 0.05f; }
            if (x > 1000) { eff = 114; }
            return eff;
        }
        public static float Yellowexp(float x)
        {
            float exp = 10;
            if (x > 1 && x <= 5) { exp = 10 + (x - 1) * 10; }
            if (x > 5 && x <= 10) { exp = 50 + (x - 5) * 15; }
            if (x > 10 && x <= 25) { exp = 125 + (x - 10) * 25; }
            if (x > 25 && x <= 50) { exp = 500 + (x - 25) * 45; }
            if (x > 50 && x <= 100) { exp = 1625 + (x - 50) * 80; }
            if (x > 100 && x <= 250) { exp = 16125 + (x - 100) * 70; }
            if (x > 250 && x <= 1000) { exp = 26625 + (x - 250) * 20; }
            if (x > 1000) { exp = 41625 + (x - 1000) * 10; }
            return exp;
        }
        public static float Redcoast(float x)
        {
            float coast = 400;
            if (x > 1 && x <= 5) { coast = 400 + (x - 1) * 400; }
            if (x > 5 && x <= 10) { coast = 2000 + (x - 5) * 750; }
            if (x > 10 && x <= 25) { coast = 5750 + (x - 10) * 1500; }
            if (x > 25 && x <= 50) { coast = 28250 + (x - 25) * 3000; }
            if (x > 50 && x <= 100) { coast = 103250 + (x - 50) * 7000; }
            if (x > 100 && x <= 250) { coast = 453250 + (x - 100) * 16000; }
            if (x > 250 && x <= 500) { coast = 2853250 + (x - 250) * 5000; }
            if (x > 500 && x <= 1000) { coast = 4103250 + (x - 500) * 21700; }
            if (x > 1000) { coast = 15000000; }
            return coast;
        }
        public static float Redeffect(float x)
        {
            float eff = 1;
            if (x > 1 && x <= 5) { eff = 1 + (x - 1) * 1; }
            if (x > 5 && x <= 25) { eff = 5 + (x - 5) * 0.75f; }
            if (x > 25 && x <= 50) { eff = 20 + (x - 25) * 0.6f; }
            if (x > 50 && x <= 250) { eff = 35 + (x - 50) * 0.3f; }
            if (x > 250 && x <= 1000) { eff = 95 + (x - 50) * 0.1f; }
            if (x > 1000) { eff = 190; }
            return eff;
        }
        public static float Redexp(float x)
        {
            float exp = 10;
            if (x > 1 && x <= 5) { exp = 10 + (x - 1) * 10; }
            if (x > 5 && x <= 10) { exp = 50 + (x - 5) * 15; }
            if (x > 10 && x <= 25) { exp = 125 + (x - 10) * 25; }
            if (x > 25 && x <= 50) { exp = 500 + (x - 25) * 45; }
            if (x > 50 && x <= 100) { exp = 1625 + (x - 50) * 80; }
            if (x > 100 && x <= 250) { exp = 16125 + (x - 100) * 70; }
            if (x > 250 && x <= 1000) { exp = 26625 + (x - 250) * 20; }
            if (x > 1000) { exp = 41625 + (x - 1000) * 10; }
            return exp;
        }
        public static float Oporacoast(float x)
        {
            float coast = 250;
            if (x > 1 && x <= 25) { coast = coast + 250 * (x - 1); }
            if (x > 25 && x <= 50) { coast = 6250 + 750 * (x - 25); }
            if (x > 50 && x <= 100) { coast = 25000 + 1250 * (x - 50); }
            if (x > 100 && x <= 250) { coast = 87500 + 2500 * (x - 100); }
            if (x > 250) { coast = 462500; }
            return coast;
        }
        public static float Oporaeffect(float x)
        {
            float eff = 5;
            if (x > 1 && x <= 5) { eff = 5 - (x - 1) * 0.15f; }
            if (x > 5 && x <= 25) { eff = 4.4f - (x - 5) * 0.075f; }
            if (x > 25 && x <= 50) { eff = 2.9f - (x - 25) * 0.05f; }
            if (x > 50 && x <= 100) { eff = 1.65f - (x - 25) * 0.02f; }
            if (x > 100) { eff = 0.15f; }
            return eff;
        }
        public static float Oporaexp(float x)
        {
            float exp = 10;
            if (x > 1 && x <= 5) { exp = 10 + (x - 1) * 10; }
            if (x > 5 && x <= 10) { exp = 50 + (x - 5) * 15; }
            if (x > 10 && x <= 25) { exp = 125 + (x - 10) * 25; }
            if (x > 25 && x <= 50) { exp = 500 + (x - 25) * 45; }
            if (x > 50 && x <= 100) { exp = 1625 + (x - 50) * 80; }
            if (x > 100 && x <= 250) { exp = 16125 + (x - 100) * 70; }
            if (x > 250 && x <= 1000) { exp = 26625 + (x - 250) * 20; }
            if (x > 1000) { exp = 41625 + (x - 1000) * 10; }
            return exp;
        }
        public static float Zopcoast(float x)
        {
            float coast = 250;
            if (x > 2 && x <= 10) { coast = coast + (x - 2) * 2500; }
            if (x > 10 && x <= 50) { coast = (20250 + (x - 10) * 5000) - 250; }
            if (x > 50 && x <= 150) { coast = (220000 + (x - 50) * 7000) - 250; }
            if (x > 150 && x <= 400) { coast = (919750 + (x - 150) * 8000) - 250; }
            if (x > 400 && x <= 521) { coast = (2919500 + (x - 400) * 9000) - 250; }
            if (x > 521 && x <= 1000) { coast = (4008250 + (x - 521) * 12000) - 250; }
            if (x > 1000) { coast = 9756000; }
            return coast;
        }
        public static float Zopexp(float x)
        {
            float exp = 50;
            if (x > 1 && x <= 10) { exp = exp + (x - 1) * 25; }
            if (x > 10 && x <= 50) { exp = (275 + (x - 10) * 35); }
            if (x > 50 && x <= 150) { exp = (1675 + (x - 50) * 45); }
            if (x > 150 && x <= 250) { exp = (6175 + (x - 150) * 75); }
            if (x > 250 && x <= 521) { exp = (13675 + (x - 250) * 225); }
            if (x > 521) { exp = 74650; }
            return exp;
        }
        public static float Zopeffect(float x)
        {
            float eff = 1;
            if (x > 1 && x <= 10) { eff = 1 + (x - 1) * 0.5f; }
            if (x > 10 && x <= 25) { eff = 5.5f + (x - 10) * 0.3f; }
            if (x > 25 && x <= 100) { eff = 10 + (x - 25) * 0.2f; }
            if (x > 100 && x <= 250) { eff = 25 + (x - 100) * 0.1f; }
            if (x > 250 && x <= 520) { eff = 40 + (x - 250) * 0.1925925925925926f; }
            if (x > 520) { eff = 92; }
            return eff;
        }
        public static float Roadcoast(float x)
        {
            float coast = 50;
            if (x > 1 && x <= 5) { coast = coast + (x - 1) * 25; }
            if (x > 5 && x <= 10) { coast = 150 + (x - 5) * 50; }
            if (x > 10 && x <= 25) { coast = 400 + (x - 10) * 75; }
            if (x > 25 && x <= 50) { coast = 1525 + (x - 25) * 150; }
            if (x > 50 && x <= 100) { coast = 5275 + (x - 50) * 250; }
            if (x > 100 && x <= 500) { coast = 17775 + (x - 100) * 1000; }
            if (x > 500 && x <= 1000) { coast = 417775 + (x - 500) * 5000; }
            if (x > 1000) { coast = 2917775; }
            return coast;
        }
        public static float Roadexp(float x)
        {
            float exp = 10;
            if (x > 1 && x <= 5) { exp = 10 + (x - 1) * 10; }
            if (x > 5 && x <= 10) { exp = 50 + (x - 5) * 15; }
            if (x > 10 && x <= 25) { exp = 125 + (x - 10) * 25; }
            if (x > 25 && x <= 50) { exp = 500 + (x - 25) * 45; }
            if (x > 50 && x <= 100) { exp = 1625 + (x - 50) * 80; }
            if (x > 100 && x <= 250) { exp = 16125 + (x - 100) * 70; }
            if (x > 250 && x <= 1000) { exp = 26625 + (x - 250) * 20; }
            if (x > 1000) { exp = 41625 + (x - 1000) * 10; }
            return exp;
        }
        public static float Roadeffect(float x)
        {
            float eff = 5;
            if (x > 1 & x <= 5) { eff = eff - x * 0.1f; }
            if (x > 5 & x <= 51) { eff = eff - 0.15f - x * 0.07f; }
            if (x > 51 & x <= 75) { eff = eff - 1.13f - x * 0.05f; }
            if (x > 75) { eff = 0.1f; }
            return eff;
        }
        public static float Depthcoast(float x)
        {
            float coast = 200 * x / 2;
            if (x > 2 && x <= 5) { coast = coast * x * 3; }
            if (x > 5 && x <= 25) { coast = coast * x * 4; }
            if (x > 25 && x <= 50) { coast = coast * x * 5; }
            if (x > 50 && x <= 75) { coast = coast * x * 7; }
            if (x > 75) { coast = 3937500; }
            return coast;
        }
        public static float Depthexp(float x)
        {
            float exp = 4;
            if (x > 1 && x <= 5) { exp = exp * x * 1.25f; }
            if (x > 5 && x <= 10) { exp = exp * x * 2f; }
            if (x > 10 && x <= 25) { exp = exp * x * 4f; }
            if (x > 25 && x <= 75) { exp = exp * x * 13.33f; }
            if (x > 75 && x <= 125) { exp = exp * x * 15f; }
            if (x > 125 && x <= 500) { exp = exp * x * 15f; }
            return exp;
        }
        public static float Deptheffect(float x)
        {
            float eff = 100;
            if (x > 0) { eff = eff * x; }
            return eff;
        }
        public static float Capacitycoast(float x)
        {
            float coast = 100;
            if (x > 1 && x <= 5) { coast = coast + x * 50; }
            if (x > 5 && x <= 10) { coast = coast + x * 75; }
            if (x > 10 && x <= 25) { coast = coast + x * 150; }
            if (x > 25 && x <= 50) { coast = coast + x * 250; }
            if (x > 50 && x <= 100) { coast = coast + x * 350; }
            if (x > 100 && x <= 500) { coast = coast + x * 500; }
            if (x > 500) { coast = 255000; }
            return coast;
        }
        public static float Capacityexp(float x)
        {
            float exp = 10;
            if (x > 1 && x <= 5) { exp = exp + x * 4; }
            if (x > 5 && x <= 10) { exp = exp + x * 6; }
            if (x > 10 && x <= 25) { exp = exp + x * 7; }
            if (x > 25 && x <= 50) { exp = exp + x * 10; }
            if (x > 50 && x <= 250) { exp = exp + x * 20; }
            if (x > 250 && x <= 500) { exp = exp + x * 25; }
            if (x > 500 && x <= 1000) { exp = exp + x * 35; }
            if (x > 1000) { exp = 40000; }
            return exp;
        }
        public static float Capacityeffect(float x)
        {
            float eff = 50;
            if (x > 0) { eff = eff * x; }
            return eff;
        }
        public static float Compressioncoast(float x)
        {
            float coast = 250;
            if (x > 1 && x <= 5) { coast = coast + x * 75; }
            if (x > 5 && x <= 10) { coast = coast + x * 100; }
            if (x > 10 && x <= 25) { coast = coast + x * 250; }
            if (x > 25 && x <= 50) { coast = coast + x * 500; }
            if (x > 50 && x <= 100) { coast = coast + x * 750; }
            if (x > 100 && x <= 500) { coast = coast + x * 1000; }
            if (x > 500) { coast = 505505; }
            return coast;
        }
        public static float Compressionyexp(float x)
        {
            float exp = 20;
            if (x > 1 && x <= 5) { exp = exp + x * 6; }
            if (x > 5 && x <= 10) { exp = exp + x * 8; }
            if (x > 10 && x <= 25) { exp = exp + x * 10; }
            if (x > 25 && x <= 50) { exp = exp + x * 12; }
            if (x > 50 && x <= 250) { exp = exp + x * 30; }
            if (x > 250 && x <= 500) { exp = exp + x * 35; }
            if (x > 500 && x <= 1000) { exp = exp + x * 50; }
            if (x > 1000) { exp = 50000; }
            return exp;
        }
        public static float Compressioneffect(float x)
        {
            float eff = 100;
            if (x > 0) { eff = 100 * x; }
            return eff;
        }
        public static float Hсompressioncoast(float x)
        {
            float coast = 500;
            if (x > 1 && x <= 5) { coast = coast + x * 250; }
            if (x > 5 && x <= 10) { coast = coast + x * 500; }
            if (x > 10 && x <= 25) { coast = coast + x * 1000; }
            if (x > 25 && x <= 50) { coast = coast + x * 1500; }
            if (x > 50 && x <= 100) { coast = coast + x * 2000; }
            if (x > 100 && x <= 500) { coast = coast + x * 4000; }
            if (x > 500) { coast = 2000000; }
            return coast;
        }
        public static float Hcompressionyexp(float x)
        {
            float exp = 50;
            if (x > 1 && x <= 5) { exp = exp + x * 15; }
            if (x > 5 && x <= 10) { exp = exp + x * 25; }
            if (x > 10 && x <= 25) { exp = exp + x * 40; }
            if (x > 25 && x <= 50) { exp = exp + x * 60; }
            if (x > 50 && x <= 250) { exp = exp + x * 75; }
            if (x > 250 && x <= 500) { exp = exp + x * 100; }
            if (x > 500 && x <= 1000) { exp = exp + x * 150; }
            if (x > 1000) { exp = 150150; }
            return exp;
        }
        public static float Hcompressioneffect(float x)
        {
            float eff = 250;
            if (x > 0) { eff = 250 * x; }
            return eff;
        }
        public static float Nanocoast(float x)
        {
            float coast = 2500;
            if (x > 1 && x <= 5) { coast = coast + x * 1500; }
            if (x > 5 && x <= 10) { coast = coast + x * 2500; }
            if (x > 10 && x <= 25) { coast = coast + x * 5000; }
            if (x > 25 && x <= 50) { coast = coast + x * 10000; }
            if (x > 50 && x <= 100) { coast = coast + x * 20000; }
            if (x > 100 && x <= 500) { coast = coast + x * 30000; }
            if (x > 500) { coast = 15000000; }
            return coast;
        }
        public static float Nanoexp(float x)
        {
            float exp = 250;
            if (x > 1 && x <= 5) { exp = exp + x * 100; }
            if (x > 5 && x <= 10) { exp = exp + x * 125; }
            if (x > 10 && x <= 25) { exp = exp + x * 150; }
            if (x > 25 && x <= 50) { exp = exp + x * 175; }
            if (x > 50 && x <= 250) { exp = exp + x * 200; }
            if (x > 250) { exp = 55555; }

            return exp;
        }
        public static float Nanoeffect(float x)
        {
            float eff = 500;
            if (x > 0) { eff = 500 * x; }
            return eff;
        }
        public static float GMineCricoast(float x)
        {
            float coast = 1000;
            if (x > 1 && x <= 5) { coast = 1000 + (x - 1) * 500; }
            if (x > 5 && x <= 25) { coast = 1000 + (x - 1) * 500 + (x - 5) * 1000; }
            if (x > 25 && x <= 50) { coast = 1000 + (x - 1) * 500 + (x - 5) * 1000 + (x - 25) * 500; }
            if (x > 50 && x <= 100) { coast = 1000 + (x - 1) * 500 + (x - 5) * 1000 + (x - 25) * 500 + (x - 50) * 1000; }
            if (x > 100 && x <= 250) { coast = 233000 + (x - 100) * 1000; }
            if (x > 250 && x <= 500) { coast = 233000 + (x - 100) * 1000 + (x - 250) * 500; }
            if (x > 500 && x <= 997) { coast = 233000 + (x - 100) * 1000 + (x - 250) * 500 + (x - 500) * 2000; }
            if (x > 997) { coast = 2500000; }
            return coast;
        }
        public static float GMineCrieffect(float x)
        {
            float eff = 0.2f;
            if (x > 1 && x <= 5) { eff = 0.2f + (x - 1) * 0.1f; }
            if (x > 5 && x <= 25) { eff = 0.6f + (x - 5) * 0.07f; }
            if (x > 25 && x <= 250) { eff = 2 + (x - 25) * 0.035f; }
            if (x > 250 && x <= 1000) { eff = 9.875f + (x - 250) * 0.015f; }
            if (x > 1000) { eff = 21.125f + (x - 1000) * 0.02f; }
            return eff;
        }
        public static float GMineCriexp(float x)
        {
            float exp = 50;
            if (x > 1 && x <= 5) { exp = 50 + (x - 1) * 50; }
            if (x > 5 && x <= 25) { exp = 50 + (x - 1) * 50 + (x - 5) * 25; }
            if (x > 25 && x <= 100) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75; }
            if (x > 100 && x <= 300) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75 + (x - 100) * 20; }
            if (x > 300 && x <= 1000) { exp = 47000 + (x - 300) * 32; }
            if (x > 1000) { exp = 69500; }
            return exp;
        }
        public static float BMineCricoast(float x)
        {
            float coast = 1000;
            if (x > 1 && x <= 5) { coast = 1000 + (x - 1) * 750; }
            if (x > 5 && x <= 25) { coast = 1000 + (x - 1) * 750 + (x - 5) * 1250; }
            if (x > 25 && x <= 50) { coast = 1000 + (x - 1) * 750 + (x - 5) * 1250 + (x - 25) * 750; }
            if (x > 50 && x <= 100) { coast = 1000 + (x - 1) * 750 + (x - 5) * 1250 + (x - 25) * 750 + (x - 50) * 1100; }
            if (x > 100 && x <= 250) { coast = 305250 + (x - 100) * 1100; }
            if (x > 250 && x <= 500) { coast = 305250 + (x - 100) * 1100 + (x - 250) * 750; }
            if (x > 500 && x <= 1000) { coast = 305250 + (x - 100) * 1100 + (x - 250) * 750 + (x - 500) * 2000; }
            if (x > 1000) { coast = 2860000; }
            return coast;
        }
        public static float BMineCrieff(float x)
        {
            float eff = 0.2f;
            if (x > 1 && x <= 5) { eff = 0.2f + (x - 1) * 0.1f; }
            if (x > 5 && x <= 25) { eff = 0.6f + (x - 5) * 0.05f; }
            if (x > 25 && x <= 250) { eff = 1.6f + (x - 25) * 0.03f; }
            if (x > 250 && x <= 1000) { eff = 8.35f + (x - 250) * 0.013f; }
            if (x > 1000) { eff = 18.1f + (x - 1000) * 0.016f; }
            return eff;
        }
        public static float BMineCriexp(float x)
        {
            float exp = 50;
            if (x > 1 && x <= 5) { exp = 50 + (x - 1) * 50; }
            if (x > 5 && x <= 25) { exp = 50 + (x - 1) * 50 + (x - 5) * 25; }
            if (x > 25 && x <= 100) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75; }
            if (x > 100 && x <= 300) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75 + (x - 100) * 20; }
            if (x > 300 && x <= 1000) { exp = 47000 + (x - 300) * 32; }
            if (x > 1000) { exp = 69500; }
            return exp;
        }
        public static float RMineCricoast(float x)
        {
            float coast = 1000;
            if (x > 1 && x <= 5) { coast = 1000 + (x - 1) * 1000; }
            if (x > 5 && x <= 25) { coast = 1000 + (x - 1) * 1000 + (x - 5) * 1500; }
            if (x > 25 && x <= 50) { coast = 1000 + (x - 1) * 1000 + (x - 5) * 1500 + (x - 25) * 1000; }
            if (x > 50 && x <= 100) { coast = 1000 + (x - 1) * 1000 + (x - 5) * 1500 + (x - 25) * 1000 + (x - 50) * 1250; }
            if (x > 100 && x <= 250) { coast = 380000 + (x - 100) * 1250; }
            if (x > 250 && x <= 500) { coast = 380000 + (x - 100) * 1250 + (x - 250) * 750; }
            if (x > 500 && x <= 1000) { coast = 380000 + (x - 100) * 1250 + (x - 250) * 750 + (x - 500) * 2000; }
            if (x > 1000) { coast = 3067500; }
            return coast;
        }
        public static float RMineCrieff(float x)
        {
            float eff = 0.2f;
            if (x > 1 && x <= 5) { eff = 0.2f + (x - 1) * 0.1f; }
            if (x > 5 && x <= 25) { eff = 0.6f + (x - 5) * 0.03f; }
            if (x > 25 && x <= 250) { eff = 1.2f + (x - 25) * 0.025f; }
            if (x > 250 && x <= 1000) { eff = 6.825f + (x - 250) * 0.012f; }
            if (x > 1000) { eff = 18.1f + (x - 1000) * 0.013f; }
            return eff;
        }
        public static float RMineCriexp(float x)
        {
            float exp = 50;
            if (x > 1 && x <= 5) { exp = 50 + (x - 1) * 50; }
            if (x > 5 && x <= 25) { exp = 50 + (x - 1) * 50 + (x - 5) * 25; }
            if (x > 25 && x <= 100) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75; }
            if (x > 100 && x <= 300) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75 + (x - 100) * 20; }
            if (x > 300 && x <= 1000) { exp = 47000 + (x - 300) * 32; }
            if (x > 1000) { exp = 69500; }
            return exp;
        }
        public static float VMineCricoast(float x)
        {
            float coast = 1000;
            if (x > 1 && x <= 5) { coast = 1000 + (x - 1) * 1250; }
            if (x > 5 && x <= 25) { coast = 1000 + (x - 1) * 1250 + (x - 5) * 1750; }
            if (x > 25 && x <= 50) { coast = 1000 + (x - 1) * 1250 + (x - 5) * 1750 + (x - 25) * 1000; }
            if (x > 50 && x <= 100) { coast = 1000 + (x - 1) * 1250 + (x - 5) * 1750 + (x - 25) * 1000 + (x - 50) * 1250; }
            if (x > 100 && x <= 250) { coast = 428500 + (x - 100) * 1500; }
            if (x > 250 && x <= 500) { coast = 428500 + (x - 100) * 1500 + (x - 250) * 1000; }
            if (x > 500 && x <= 1000) { coast = 428500 + (x - 100) * 1500 + (x - 250) * 1000 + (x - 500) * 2000; }
            if (x > 1000) { coast = 3528500; }
            return coast;
        }
        public static float VMineCrieff(float x)
        {
            float eff = 0.2f;
            if (x > 1 && x <= 5) { eff = 0.2f + (x - 1) * 0.1f; }
            if (x > 5 && x <= 25) { eff = 0.6f + (x - 5) * 0.03f; }
            if (x > 25 && x <= 250) { eff = 1.2f + (x - 25) * 0.025f; }
            if (x > 250 && x <= 1000) { eff = 6.825f + (x - 250) * 0.012f; }
            if (x > 1000) { eff = 18.1f + (x - 1000) * 0.013f; }
            return eff;
        }
        public static float VMineCriexp(float x)
        {
            float exp = 50;
            if (x > 1 && x <= 5) { exp = 50 + (x - 1) * 50; }
            if (x > 5 && x <= 25) { exp = 50 + (x - 1) * 50 + (x - 5) * 25; }
            if (x > 25 && x <= 100) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75; }
            if (x > 100 && x <= 300) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75 + (x - 100) * 20; }
            if (x > 300 && x <= 1000) { exp = 47000 + (x - 300) * 32; }
            if (x > 1000) { exp = 69500; }
            return exp;
        }
        public static float WMineCricoast(float x)
        {
            float coast = 1000;
            if (x > 1 && x <= 5) { coast = 1000 + (x - 1) * 1500; }
            if (x > 5 && x <= 25) { coast = 1000 + (x - 1) * 1500 + (x - 5) * 2000; }
            if (x > 25 && x <= 50) { coast = 1000 + (x - 1) * 1500 + (x - 5) * 2000 + (x - 25) * 1250; }
            if (x > 50 && x <= 100) { coast = 1000 + (x - 1) * 1500 + (x - 5) * 2000 + (x - 25) * 1250 + (x - 50) * 1250; }
            if (x > 100 && x <= 250) { coast = 495750 + (x - 100) * 1500; }
            if (x > 250 && x <= 500) { coast = 495750 + (x - 100) * 1500 + (x - 250) * 1250; }
            if (x > 500 && x <= 1000) { coast = 495750 + (x - 100) * 1500 + (x - 250) * 1250 + (x - 500) * 2250; }
            if (x > 1000) { coast = 3908250; }
            return coast;
        }
        public static float WMineCrieff(float x)
        {
            float eff = 0.2f;
            if (x > 1 && x <= 5) { eff = 0.2f + (x - 1) * 0.1f; }
            if (x > 5 && x <= 25) { eff = 0.6f + (x - 5) * 0.025f; }
            if (x > 25 && x <= 250) { eff = 1.1f + (x - 25) * 0.02f; }
            if (x > 250 && x <= 1000) { eff = 5.6f + (x - 250) * 0.01f; }
            if (x > 1000) { eff = 18.1f + (x - 1000) * 0.008f; }
            return eff;
        }
        public static float WMineCriexp(float x)
        {
            float exp = 50;
            if (x > 1 && x <= 5) { exp = 50 + (x - 1) * 50; }
            if (x > 5 && x <= 25) { exp = 50 + (x - 1) * 50 + (x - 5) * 25; }
            if (x > 25 && x <= 100) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75; }
            if (x > 100 && x <= 300) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75 + (x - 100) * 20; }
            if (x > 300 && x <= 1000) { exp = 47000 + (x - 300) * 32; }
            if (x > 1000) { exp = 69500; }
            return exp;
        }
        public static float CMineCricoast(float x)
        {
            float coast = 1000;
            if (x > 1 && x <= 5) { coast = 1000 + (x - 1) * 2000; }
            if (x > 5 && x <= 25) { coast = 1000 + (x - 1) * 2000 + (x - 5) * 2000; }
            if (x > 25 && x <= 50) { coast = 1000 + (x - 1) * 2000 + (x - 5) * 2000 + (x - 25) * 1250; }
            if (x > 50 && x <= 100) { coast = 1000 + (x - 1) * 2000 + (x - 5) * 2000 + (x - 25) * 1250 + (x - 50) * 1250; }
            if (x > 100 && x <= 250) { coast = 545250 + (x - 100) * 1750; }
            if (x > 250 && x <= 500) { coast = 545250 + (x - 100) * 1750 + (x - 250) * 1750; }
            if (x > 500 && x <= 1000) { coast = 545250 + (x - 100) * 1750 + (x - 250) * 1750 + (x - 500) * 2500; }
            if (x > 1000) { coast = 4682750; }
            return coast;
        }
        public static float CMineCrieff(float x)
        {
            float eff = 0.2f;
            if (x > 1 && x <= 5) { eff = 0.2f + (x - 1) * 0.1f; }
            if (x > 5 && x <= 25) { eff = 0.6f + (x - 5) * 0.025f; }
            if (x > 25 && x <= 250) { eff = 1.1f + (x - 25) * 0.02f; }
            if (x > 250 && x <= 1000) { eff = 5.6f + (x - 250) * 0.01f; }
            if (x > 1000) { eff = 18.1f + (x - 1000) * 0.008f; }
            return eff;
        }
        public static float CMineCrixp(float x)
        {
            float exp = 50;
            if (x > 1 && x <= 5) { exp = 50 + (x - 1) * 50; }
            if (x > 5 && x <= 25) { exp = 50 + (x - 1) * 50 + (x - 5) * 25; }
            if (x > 25 && x <= 100) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75; }
            if (x > 100 && x <= 300) { exp = 50 + (x - 1) * 50 + (x - 5) * 25 + (x - 25) * 75 + (x - 100) * 20; }
            if (x > 300 && x <= 1000) { exp = 47000 + (x - 300) * 32; }
            if (x > 1000) { exp = 69500; }
            return exp;
        }
        public static float Healcoast(float x)
        {
            float coast = 250;
            if (x > 1 && x <= 5) { coast = 250 + (x - 1) * 50; }
            if (x > 5 && x <= 25) { coast = 250 + (x - 1) * 50 + (x - 5) * 1000; }
            if (x > 25 && x <= 100) { coast = 250 + (x - 1) * 50 + (x - 5) * 1000 + (x - 25) * 10000; }
            if (x > 100 && x <= 250) { coast = 250 + (x - 1) * 50 + (x - 5) * 1000 + (x - 25) * 10000 + (x - 100) * 5000; }
            if (x > 250 && x <= 1000) { coast = 3257700 + (x - 250) * 6323.066666666667f; }
            if (x > 1000 && x <= 2000) { coast = 8000000 + (x - 1000) * 2000; }
            if (x > 2000) { coast = 10000000; }
            return coast;
        }
        public static float Healeff(float x)
        {
            float eff = 1;
            if (x > 1 && x <= 5) { eff = 1 + (x - 1) * 0.5f; }
            if (x > 5 && x <= 25) { eff = 3 + (x - 5) * 0.15f; }
            if (x > 25 && x <= 150) { eff = 6 + (x - 25) * 0.032f; }
            if (x > 150 && x <= 1000) { eff = 10 + (x - 150) * 0.0058823529411765f; }
            if (x > 1000) { eff = 15 + (x - 1000) * 0.0025f; }
            return eff;
        }
        public static float Healexp(float x)
        {
            float exp = 15;
            if (x > 1 && x <= 5) { exp = 10 + (x - 1) * 5; }
            if (x > 5 && x <= 25) { exp = 10 + (x - 1) * 5 + (x - 5) * 10; }
            if (x > 25 && x <= 100) { exp = 5 + (x - 1) * 5 + (x - 5) * 10 + (x - 25) * 100; }
            if (x > 100 && x <= 1000) { exp = 8950 + (x - 100) * 9; }
            if (x > 1000 && x <= 2000) { exp = 17050 + (x - 1000) * 2.95f; }
            if (x > 2000) { exp = 20000; }
            return exp;
        }


    }
}
