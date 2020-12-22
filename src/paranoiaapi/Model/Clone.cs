using System;
using Paranoia.App;

namespace Paranoia 
{
    public class Clone
    {
        private string _name;
        // Core Information
        public string Name 
        { 
            get { return $"{_name}-{SecurityClearance}-{HomeSector}"; }
            set { _name = value; } 
        }
        public char SecurityClearance { get; set; }
        public string HomeSector { get; set; }
        public int CloneNumber { get; set; }
        public Constants.Gender Gender { get; set; }
        // Development
        public string TreasonStars { get; set; }
        public int XPPoints { get; set; }
        // Stats
        public int Violence { get; set; }
        public int Brains { get; set; }
        public int Chutzpah { get; set; }
        public int Mechanics { get; set; }
        // Skills
        // Violence skills
        public int Athletics { get; set; }
        public int Guns { get; set; }
        public int Melee { get; set; }
        public int Throw { get; set; }
        // Brains skills
        public int Science { get; set; }
        public int Psychology { get; set; }
        public int Bureaucracy { get; set; }
        public int AlphaComplex { get; set; }
        // Chutzpah skills
        public int Bluff { get; set; }
        public int Charm { get; set; }
        public int Intimidate { get; set; }
        public int Stealth { get; set; }
        // Mechanics skills
        public int Operate { get; set; }
        public int Engineer { get; set; }
        public int Program { get; set; }
        public int Demolitions { get; set; }
        // Wellbeing
        public int? Moxie { get; set; }
        public int? Hurt { get; set; }
        public int? Injured { get; set; }
        public int? Maimed { get; set; }
        public int? Dead { get; set; }
        public string Memory { get; set; }
        // Equipment
        public string Equipment { get; set; }
        public Player Player { get; set; }
    }

    public class Player
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime RegisteredDate { get; set; }
    }
}