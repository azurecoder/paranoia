using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Paranoia.App
{
    public class CharacterGenerator
    {
        private int GetDieRoll(int maxNumber)
        {
            var d6 = new Random(Guid.NewGuid().GetHashCode());
            return d6.Next(1, maxNumber);
        }

        private Clone GenerateSkills(CharacterGenerator generator, Clone clone)
        {
            List<string> skills = new List<string>();
            PropertyInfo[] infos = clone.GetType().GetProperties();
            // Get skills assignment and range
            foreach (int i in Enumerable.Range(0, 11))  
            {
                int dieRoll = generator.GetDieRoll(Constants.Skills.Length);
                while(skills.Contains(Constants.Skills[dieRoll]))
                {
                    dieRoll = generator.GetDieRoll(Constants.Skills.Length);
                }
                // Match the clone properties with the properties on the clone object
                PropertyInfo info = infos.First(property => property.Name == Constants.Skills[dieRoll]);
                info.SetValue(clone, i - 5);
                skills.Add(Constants.Skills[dieRoll]);
            }
                    
            return clone;
        }

        ///<Summary>
        ///This creates a new character and assigned default values from various constants and other initializations
        ///</Summary>
        public static Clone NewCharacter()
        {
            var character = new Clone();
            var generator = new CharacterGenerator();
            
            return generator.GenerateSkills(generator, character);
        }
    }

    public static class Constants 
    {
        public static string[] Skills = new string[]
        {
            "Operate",
            "Engineer",
            "Program",
            "Demolitions",
            "Athletics",
            "Guns",
            "Melee",
            "Throw",
            "Science",
            "Psychology",
            "Bureaucracy",
            "AlphaComplex",
            "Bluff",
            "Charm",
            "Intimidate",
            "Stealth",
            "Operate",
            "Engineer",
            "Program",
            "Demolitions"
        };

    }
}