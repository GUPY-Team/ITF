using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml;
using Bogus;
using UserModule;

namespace FakeData
{
    public class FakeDataInitializer
    {
       public static string Path = "../../../../FakeData/Generated.json";
       public static List<Category> Categories = new List<Category>();
    
       public static List<EmployerContacts> EmployerContactsList = new List<EmployerContacts>();
       public static List<ApplicantContacts> ApplicantContactsList = new List<ApplicantContacts>();
       
       public static List<ApplicantSkill> UserSkills = new List<ApplicantSkill>();
       public static List<CompanyInfo> CompanyInfos = new List<CompanyInfo>();
       
       public static List<EmployerProfile> EmployerProfiles = new List<EmployerProfile>();
       public static List<ApplicantProfile> ApplicantProfiles = new List<ApplicantProfile>();
       
       public static List<User> Users = new List<User>();

       private static string[] _positions = {"Junior","Middle","Senior"};

       private static string[] _languages =
       {
          "C#", "Python", "Unity",
          "Web", "C++", "Java",
          "Go", "Ruby", "Swift",
          "Embedded", ".NET", "React.JS",
          "Angular.JS", "Vue.Js", "Kotlin",
          "PHP", "React Native"
       };

       public static ICollection<User> Init(int count, bool writeToFile = false, bool dumpToConsole = false)
       {
          var categoryFaker = new Faker<Category>()
             .RuleFor(c => c.Id, _ => Guid.NewGuid())
             .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);
      
          var empContactFaker = new Faker<EmployerContacts>()
             .RuleFor(ec => ec.Telegram, f => f.Internet.UserName())
             .RuleFor(ec => ec.PhoneNumber, f => f.Phone.PhoneNumber())
             .RuleFor(ec => ec.LinkedInLink, f => f.Internet.UrlWithPath(null, "https://www.linkedin.com"))
             .RuleFor(ec => ec.EmployerProfileId, _ => Guid.NewGuid());
            
          var aplContactFaker = new Faker<ApplicantContacts>()
             .RuleFor(ac => ac.Email, f => f.Internet.Email())
             .RuleFor(ac => ac.PortfolioLink, f => f.Internet.Url())
             .RuleFor(ac => ac.FullName, f => f.Name.FullName())
             .RuleFor(ac => ac.Telegram, f => f.Internet.UserName())
             .RuleFor(ac => ac.PhoneNumber, f => f.Phone.PhoneNumber())
             .RuleFor(ac => ac.LinkedInLink, f => f.Internet.UrlWithPath(null, "https://www.linkedin.com"))
             .RuleFor(ac => ac.ApplicantProfileId, _ => Guid.NewGuid());
       
          var skillsFaker = new Faker<ApplicantSkill>()
             .RuleFor(us => us.ApplicantProfileId, _ => Guid.NewGuid())
             .RuleFor(us => us.Name, f => f.Hacker.Noun());
          
          var skills = skillsFaker.Generate(50);
          UserSkills.AddRange(skills);

          var cmpInfFaker = new Faker<CompanyInfo>()
             .RuleFor(ci => ci.EmployerProfileId, _ => Guid.NewGuid())
             .RuleFor(ci => ci.CompanyDescription, f => f.Lorem.Sentences(2))
             .RuleFor(ci => ci.CompanyWebsite, f => f.Internet.Url());

          var empProfileFaker = new Faker<EmployerProfile>()
             .RuleFor(ep => ep.CompanyInfoId, _ => Guid.NewGuid())
             .RuleFor(ep => ep.FullName, f => f.Name.FullName())
             .RuleFor(ep => ep.CompanyInfo, (f, ep) =>
             {
                cmpInfFaker.RuleFor(ci => ci.EmployerProfileId, _ => ep.CompanyInfoId);
                var cmpInf = cmpInfFaker.Generate();
                FakeDataInitializer.CompanyInfos.Add(cmpInf);

                return cmpInf;
             })
             .RuleFor(ep => ep.Position, f => 
                $"{f.PickRandom(_positions)} " +
                $"{f.PickRandom(_languages)} developer")
             .RuleFor(ep => ep.EmployerContacts, (f, ep) =>
             {
                empContactFaker.RuleFor(ec => ec.EmployerProfileId, _ => ep.EmployerContactsId);
                var empCon = empContactFaker.Generate();
                FakeDataInitializer.EmployerContactsList.Add(empCon);
                
                return empCon;
             });

          var aplProfileFaker = new Faker<ApplicantProfile>()
             .RuleFor(ap => ap.Category, (f, ap) =>
             {
                categoryFaker.RuleFor(c => c.Id, _ => ap.CategoryId);
                var ct = categoryFaker.Generate();
                FakeDataInitializer.Categories.Add(ct);
                return ct;
             })
             .RuleFor(ap => ap.City, f => f.Address.City())
             .RuleFor(ap => ap.Achievements, f => f.Lorem.Lines())
             .RuleFor(ap => ap.Expectations, f => f.Lorem.Sentence())
             .RuleFor(ap => ap.Position, f =>
                $"{f.PickRandom(_positions)} " +
                $"{f.PickRandom(_languages)} developer")
             .RuleFor(ap => ap.ExperienceInYears, f => f.Random.Int(0, 20))
             .RuleFor(ap => ap.EnglishProficiency, 
                f => f.PickRandom<EnglishProficiency>())
             .RuleFor(ap => ap.ExperienceDescription, f => f.Lorem.Sentences(2))
             .RuleFor(ap => ap.HourlyRate, f => f.Random.Int(1, 100))
             .RuleFor(ap => ap.SalaryExpectation, f => f.Random.Int(300, 10000))
             .RuleFor(ap => ap.EmploymentOptions, f => f.Random.ArrayElements(Enum.GetValues<EmploymentOption>()))
             .RuleFor(ap => ap.Skills, f => f.Random.ArrayElements(UserSkills.ToArray(), f.Random.Int(2, 8)))
             .RuleFor(ap => ap.ApplicantContacts, (f, ap) =>
             {
                aplContactFaker.RuleFor(ac => ac.ApplicantProfileId, _ => ap.ApplicantContactsId);

                var aplCon = aplContactFaker.Generate();
                
                ApplicantContactsList.Add(aplCon);
                return aplCon;
             });


          var usersFaker = new Faker<User>()
             .RuleFor(u => u.Id, _ => Guid.NewGuid())
             .RuleFor(u => u.ApplicantProfile, (f, u) =>
             {
                var aplProf = aplProfileFaker.Generate();
                
                ApplicantProfiles.Add(aplProf);
                return aplProf;
             })
             .RuleFor(u => u.EmployerProfile, (f, u) =>
             {
                var empProf = empProfileFaker.Generate();
                
                EmployerProfiles.Add(empProf);
                return empProf;
             });

          var users = usersFaker.Generate(count);
          Users.AddRange(users);

          if (dumpToConsole)
          {
             users.Dump();
          }

          if (writeToFile)
          {
             WriteToFile(Path,users);
          }

          return users;
       }

       public static void WriteToFile(string path, ICollection<User> users)
       {
          using var sw = new StreamWriter(File.Open(path, FileMode.Create));

          sw.WriteLine( users.DumpString());
       }

       public static ICollection<User> ReadFromFile(string path)
       {
          using StreamReader sw = new StreamReader(path);

          return JsonSerializer.Deserialize<User[]>(sw.ReadToEnd());
       }
    }
    
    public static class ExtensionsForTesting
    {
       public static void Dump(this object obj)
       {
          Console.WriteLine(obj.DumpString());
       }

       public static string DumpString(this object obj)
       {
          return JsonSerializer.Serialize(obj,new JsonSerializerOptions() {WriteIndented = true});
       }
    }
   
}