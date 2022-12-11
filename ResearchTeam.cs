using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newLab2
{
    class ResearchTeam:Team,InameAndCopy
    {
        private string Theme;

        private TimeFrame ResearchDuration;

        System.Collections.ArrayList ProjectParticipants = new ArrayList();
        System.Collections.ArrayList Publications = new ArrayList();

        public System.Collections.ArrayList ListOfPublication { get { return Publications; } set { Publications = value; } }
        public ResearchTeam(string InvestigationTheme, string Organisation, int RegistrationNumber, TimeFrame InvestigationDuration,ArrayList ProjectPartipants, ArrayList Publications)
            :base(Organisation,RegistrationNumber)
        {
            Theme = InvestigationTheme;
            ResearchDuration = InvestigationDuration;
        }
        public ResearchTeam()
            :base()
        { 
                this.Theme = "";
                this.ResearchDuration = TimeFrame.Long;

        }

        public Paper LastPaper {
            get {
                if (Publications.Count == 0) {
                    return null;
                }
                int MaxIndex = 0;
                DateTime MaxDateTime = ((Paper)Publications[0])._TimeOfPublication;
                for (int i=0;i<Publications.Count;i++)
                {
                    if (((Paper)Publications[i])._TimeOfPublication > MaxDateTime) {
                        MaxIndex = i;
                        MaxDateTime = ((Paper)Publications[i])._TimeOfPublication;
                    }
                }
                return (Paper)Publications[MaxIndex];
            }
        }
        public void AddPapers(params Paper[] AdditionalPapers) 
        {
        Publications.AddRange(AdditionalPapers);
        }
        public override string ToString()
        {
            string stringListOfPublications = "";
            foreach (Paper pap in Publications) {
                stringListOfPublications += pap.ToString() + "\r\n";
            }
            string stringListOfParticipants = "";
            foreach (Person pers in ProjectParticipants)
            {
                stringListOfParticipants += pers.ToString() + "\r\n";
            }
            return base.ToString()+string.Format("\r\n Theme: {0}, Duration: {1} \r\n Participants: {2} \r\n Publications: {3}",Theme,ResearchDuration,stringListOfParticipants,stringListOfPublications);
        }
        public string ToShortString() {
            return base.ToString() + string.Format("\r\n Theme: {0}, Duration: {1} \r\n ", Theme, ResearchDuration);
        }
        public System.Collections.ArrayList ListOfParticipants { get { return ProjectParticipants; } set { ProjectParticipants = value; } }
        public void AddMembers(params Person[] AdditionalMembers) {
            ProjectParticipants.AddRange(AdditionalMembers);
        }
        public Team getTeamType {
            get {
                return new Team(Organisation, RegistrationNumber);
            }
            set {
                this.Organisation = value.Organisation;
                this.RegistrationNumber = value.RegistrationNumber;
            }
        }
        public override object DeepCopy()
        {
            Paper [] temp_paper;
            Person[] temp_person;
            List<Paper> temp_paper2 = new List<Paper>();
            List<Person> temp_person2 = new List<Person>();
            temp_person = (Person[])this.ProjectParticipants.ToArray(typeof(Person));
            temp_paper = (Paper[])this.Publications.ToArray(typeof(Paper));
            foreach(Person a in temp_person){
                temp_person2.Add((Person)a.DeepCopy());
            }
            foreach(Paper a in temp_paper){
                temp_paper2.Add((Paper)a.DeepCopy());
            }
            ArrayList temp1 = new ArrayList(temp_person2);
            ArrayList temp2 = new ArrayList(temp_paper2);
            ResearchTeam CopyTeam = new ResearchTeam(this.Theme, this.Organisation, this.RegistrationNumber, this.ResearchDuration, temp1, temp2);
            return CopyTeam;

        }
        public IEnumerable<Person> MembersWithoutPublications() {

            ArrayList AutorsWithoutP = new ArrayList();
            bool someBool;
            foreach(Person pers in ProjectParticipants) {
                someBool = true;
                foreach (Paper pap in Publications)
                {
                    if (pap._Author == pers)
                    {
                        someBool = false;
                        break;
                    }
                }
                    if (someBool) {
                        AutorsWithoutP.Add(pers);
                        Console.WriteLine(pers.ToShortString());
                    }                    
                
            }
            for (int i = 0; i < AutorsWithoutP.Count; i++) {
                yield return (Person)AutorsWithoutP[i];
                Console.Write(((Person)AutorsWithoutP[i]).ToShortString());
            }

        }
        public IEnumerable<Paper> LastPapers(int N_years) {
            for (int i = 0; i < Publications.Count; i++) {
                if (((Paper)Publications[i])._TimeOfPublication.Year >= DateTime.Now.Year - N_years) {
                    yield return (Paper)Publications[i];
                    Console.Write(((Paper)Publications[i]).ToString());
                }
            }
        }
    }
}
