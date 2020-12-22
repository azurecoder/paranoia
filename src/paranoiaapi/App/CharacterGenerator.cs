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

        private int GetSkill(params int[] skills)
        {
            return (from skill in skills where skill > 0 select 1).Sum();
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
            // Now generate the aggregate skills - shift by 1 rather than randomly asign
            // violence 
            clone.Mechanics = GetSkill(clone.Athletics, clone.Guns, clone.Melee, clone.Throw);
            // brains
            clone.Violence = GetSkill(clone.Science, clone.Psychology, clone.Bureaucracy, clone.AlphaComplex);
            // chutzpah
            clone.Brains = GetSkill(clone.Bluff, clone.Charm, clone.Intimidate, clone.Stealth);
            // mechanics
            clone.Chutzpah = GetSkill(clone.Operate, clone.Engineer, clone.Program, clone.Demolitions);
            // set the personal details 
            clone.Gender = generator.GetDieRoll(2) == 1 ? Constants.Gender.Male : Constants.Gender.Female;
            clone.CloneNumber = 1;
            // TODO: Build a random name generator here
            clone.SecurityClearance = 'R';
            clone.HomeSector = "CONNECT";
            clone.Name = "Inter";
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

        public enum Gender 
        {
            Male, 
            Female
        }
    }
}