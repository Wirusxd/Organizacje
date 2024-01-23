
Testowi użytkownicy:

Admin

    login    “Admin” 
    hasło    “password”
User

     login   “User”
     hasło   “password”


Boss

    int BossId 
    string FirstName 
    string LastName 
    int Age 
    Nationality Nationality 
    string OrganizationName 
    IList<Organization> Organizations 

Gang member
 
    int MemberId 
    string FirstName 
    string LastName 
    Nationality Nationality 
    Organization Organization
    int Strength 
    int Endurance 
    int Intelligence 
    int Luck 

Base

     int BaseID 
     string Name 
     string Adress 
     string OrganizationName 
     Organization Organization 

Organization 

     int OgranizationId 
     string Name 
     string CountryOfOrigin 
     string NameOfBoss 
     Boss Boss 
     IList<GangMember> Members 
     IList<Base> Bases 


