using Bogus;
using ITF.Domain.Entities;
using ITF.Domain.Enums;

namespace FakeData;

public static class FakeDataInitializer
{
    public static User CreateUser(Guid userId)
    {
        var positions = new List<string> { "Junior", "Middle", "Senior" };

        var languages = new List<string>
        {
            "C#", "Python", "Unity",
            "Web", "C++", "Java",
            "Go", "Ruby", "Swift",
            "Embedded", ".NET", "React.JS",
            "Angular", "Vue.Js", "Kotlin",
            "PHP", "React Native"
        };

        var developerCategories = new Faker<DeveloperCategory>()
            .RuleFor(dc => dc.Id, Guid.NewGuid)
            .RuleFor(dc => dc.Name, f => f.Hacker.Noun())
            .Generate(30);

        var developerContactsFaker = new Faker<DeveloperContacts>()
            .RuleFor(dc => dc.Email, f => f.Internet.Email())
            .RuleFor(dc => dc.PortfolioLink, f => f.Internet.Url())
            .RuleFor(dc => dc.FullName, f => f.Name.FullName())
            .RuleFor(dc => dc.Telegram, f => f.Internet.UserName())
            .RuleFor(dc => dc.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(dc => dc.LinkedInLink, f => f.Internet.UrlWithPath("https", "www.linkedin.com"));

        var developerProfileFaker = new Faker<DeveloperProfile>()
            .RuleFor(dp => dp.Id, Guid.NewGuid)
            .RuleFor(dp => dp.Position, f => $"{f.PickRandom(positions)} {f.PickRandom(languages)} Developer")
            .RuleFor(dp => dp.SalaryExpectation, f => f.Random.Number(300, 6000))
            .RuleFor(dp => dp.HourlyRate, f => f.Random.Number(1, 50).OrNull(f, 0.8f))
            .RuleFor(dp => dp.ExperienceInYears, f => f.Random.Number(1, 20).OrNull(f, 0.3f))
            .RuleFor(dp => dp.City, f => f.Address.City())
            .RuleFor(dp => dp.EnglishProficiency, f => f.PickRandom<EnglishProficiency>())
            .RuleFor(dp => dp.ExperienceDescription, f => f.Lorem.Lines())
            .RuleFor(dp => dp.Expectations, f => f.Lorem.Lines().OrNull(f, 0.3f))
            .RuleFor(dp => dp.Achievements, f => f.Lorem.Lines().OrNull(f, 0.2f))
            .RuleFor(dp => dp.IsActive, f => f.Random.Bool(0.75f))
            .RuleFor(dp => dp.DeveloperContacts, developerContactsFaker.Generate())
            .RuleFor(dp => dp.DeveloperCategory, f => f.PickRandom(developerCategories))
            .RuleFor(dp => dp.Skills, f => f.Make(f.Random.Number(5, 30), () => f.Hacker.Noun()))
            .RuleFor(dp => dp.WorkOptions, f => f.Make(f.Random.Number(4), f.PickRandom<WorkOption>).Distinct().ToList());

        return new User
        {
            Id = userId,
            DeveloperProfile = developerProfileFaker.Generate()
        };
    }
}