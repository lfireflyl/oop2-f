using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newLab2
{
    class Team:InameAndCopy
    {
        protected string organisation;
        public string Organisation { get { return organisation; } set { organisation = value; } }
        protected int registrationNumber;
        public int RegistrationNumber {
            get { return registrationNumber; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Registration number must be more than 0 ");
                }
                else {
                    registrationNumber = value;
                }
            }
        }

        string InameAndCopy.Name
        {
            get
            {
                return string.Format("Team of organisation {0} with registration number {1}",organisation,registrationNumber);
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Team(string Organisation, int RegistrationNumber) {
            organisation = Organisation;
            registrationNumber = RegistrationNumber;
        }
        public Team():this("Unknown organisation",1) {
        }
        public virtual object DeepCopy(){
            return new Team(this.organisation,this.registrationNumber);
            }
        public virtual bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
           Team objAsTeam = obj as Team;
            if (objAsTeam as Team == null) {
                return false;
            }
            return objAsTeam.Organisation == this.Organisation && objAsTeam.RegistrationNumber == this.RegistrationNumber;

        }
        static public bool operator ==(Team l_Team,Team r_Team) {
            if (ReferenceEquals(l_Team, r_Team)) {
                return true;
            }
            if ((((object)l_Team)==null)||(((object)r_Team)==null)) {
                return false;
            }
            return false; //(l_Team.Organisation == r_Team.Organisation);// && (l_Team.RegistrationNumber==r_Team.RegistrationNumber);

        }
        static public bool operator !=(Team l_Team, Team r_Team)
        {
            return !(l_Team==r_Team);
        }

        public virtual new int GetHashCode() {
            int HashCode = 0;
            foreach (char ch in organisation.ToCharArray()) {
                HashCode += (int) Convert.ToUInt32(ch);
            }           
                HashCode += registrationNumber;
            return HashCode;
        }
        public virtual new string ToString() {
            return string.Format("Team of organisation {0} with registration number {1}",organisation,registrationNumber);
            }
        }
}
