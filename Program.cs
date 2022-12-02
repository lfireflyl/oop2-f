using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newLab2
{
    enum TimeFrame { Year, TwoYears, Long }
    class Program
    {
        static void Main(string[] args)
        {
            Team MyTeam1 = new Team("Maxon",7);
            Team MyTeam2 = new Team("Ottoy", 7);
            Console.WriteLine(MyTeam1.Equals(MyTeam2));
            Console.WriteLine(MyTeam1==MyTeam2);
            Console.WriteLine(string.Format(" MyTeam1: {0}, MyTeam2: {1} ", MyTeam1.GetHashCode(),MyTeam2.GetHashCode()));
            try {
                MyTeam2.RegistrationNumber = -2;
            }
            catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex.Message);
            }
            ResearchTeam MyTeam3 = new ResearchTeam();
            MyTeam3.AddMembers(new Person[3] { new Person("Ivan","Sharov",new DateTime(2003,09,20)),new Person("Bobby", "Tarantino", new DateTime(1998, 11, 03)),new Person()});
            MyTeam3.AddPapers(new Paper[2] { new Paper("Parse vk", new Person("Ivan", "Sharov", new DateTime(2014, 01, 23)),new DateTime(2018,03,29)), new Paper() });
            Console.WriteLine(MyTeam3.getTeamType.ToString());
            ResearchTeam MyTeam4 = (ResearchTeam)MyTeam3.DeepCopy();
            MyTeam3.Organisation = "mirea";
            MyTeam3.RegistrationNumber = 8;
            Console.WriteLine(MyTeam3.ToString());
            Console.WriteLine(MyTeam4.ToString());
            
            foreach (Person pers in MyTeam3.MembersWithoutPublications()) {
                Console.WriteLine(pers);
            }
            foreach (Paper pap in MyTeam3.LastPapers(2))
            {
                Console.WriteLine(pap);
            }

            Console.ReadKey();
        }
    }
}
