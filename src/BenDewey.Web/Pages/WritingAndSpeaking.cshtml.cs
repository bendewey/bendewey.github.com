using BenDewey.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BenDewey.Web.Pages;

public sealed class WritingAndSpeakingModel : PageModel
{
    public IReadOnlyList<SpeakingEngagement> Engagements { get; } =
    [
        new(new DateOnly(2015, 11, 19), "XAML Antipatterns", "VS Live Orlando"),
        new(new DateOnly(2015, 11, 19), "Building Adaptive UIs for All Types of Windows", "VS Live Orlando"),
        new(new DateOnly(2015, 10, 24), "Creating Responsive Web Apps with JavaScript and Bootstrap", "Atlanta Code Camp"),
        new(new DateOnly(2015, 10, 24), "Unit Testing JavaScript Applications", "Atlanta Code Camp"),
        new(new DateOnly(2015, 10, 17), "Building Adaptive UIs for All Types of Windows", "Raleigh Code Camp"),
        new(new DateOnly(2015, 10, 1), "Async Patterns for .NET Development", "VS Live New York"),
        new(new DateOnly(2015, 9, 30), "XAML Antipatterns", "VS Live New York"),
        new(new DateOnly(2015, 8, 26), "Design Patterns for .NET Developers, Part 1", "Charleston .NET User Group"),
        new(new DateOnly(2015, 7, 8), "Unit Testing JavaScript Apps", "TriNug"),
        new(new DateOnly(2015, 6, 25), "Async Development in .NET", "Charleston .NET User Group"),
        new(new DateOnly(2015, 6, 6), "Unit Testing JavaScript Apps", "SparkConf"),
        new(new DateOnly(2015, 5, 28), "SOLID Application Development with .NET", "Charleston .NET User Group"),
        new(new DateOnly(2015, 3, 19), "Unit Testing JavaScript Applications", "VS Live Las Vegas"),
        new(new DateOnly(2015, 3, 18), "Cross-Platform Mobile Apps Using AngularJS and the Ionic Framework", "VS Live Las Vegas"),
        new(new DateOnly(2015, 3, 17), "Creating Responsive Cross-Platform Native/Web Apps with JavaScript and Bootstrap", "VS Live Las Vegas"),

        new(new DateOnly(2013, 12, 11), "Reimagining the Mobile Workplace", "Microsoft Executive Summit, Foxwoods, Connecticut"),
        new(new DateOnly(2013, 8, 22), "Windows 8 Apps with MVVM, HTML/JS, and Web API", "VS Live Redmond"),
        new(new DateOnly(2013, 8, 21), "Sharing Code Between Windows 8 and Windows Phone 8 Apps", "VS Live Redmond"),
        new(new DateOnly(2013, 8, 21), "Migrating from WPF or Silverlight to WinRT", "VS Live Redmond"),
        new(new DateOnly(2013, 5, 22), "Windows Store Shopping App Framework", "Microsoft Offices New York"),
        new(new DateOnly(2013, 5, 15), "Sharing Code Between Windows 8 and Windows Phone 8 Apps", "VS Live Chicago"),
        new(new DateOnly(2013, 5, 14), "Make Your App Alive with Tiles and Notifications", "VS Live Chicago"),
        new(new DateOnly(2013, 5, 14), "Windows 8 Apps with MVVM, HTML/JS, and Web API", "VS Live Chicago"),
        new(new DateOnly(2013, 3, 27), "Sharing Code Between Windows 8 and Windows Phone 8 Apps", "VS Live Las Vegas"),
        new(new DateOnly(2013, 3, 26), "Make Your App Alive with Tiles and Notifications", "VS Live Las Vegas"),
        new(new DateOnly(2013, 3, 20), "See Windows 8 Apps in Action and Learn How to Transition Your Enterprise to Mobile", "Webinar"),
        new(new DateOnly(2013, 1, 14), "Shopping Reference App Demo", "National Retail Federation Annual Convention & Expo"),

        new(new DateOnly(2012, 12, 12), "Filling Up Your Charm Bracelet", "VS Live Orlando"),
        new(new DateOnly(2012, 12, 11), "Smackdown: Metro Style Apps vs. Websites", "VS Live Orlando"),
        new(new DateOnly(2012, 12, 3), "Smackdown: Metro Style Apps vs. Websites", "Fairfield/Westchester CT .NET User Group"),
        new(new DateOnly(2012, 10, 25), "SQL Server 2012 & Windows 8 Apps Book Launch", "Boston, Massachusetts"),
        new(new DateOnly(2012, 10, 18), "SQL Server 2012 & Windows 8 Apps Book Launch", "Midtown Manhattan"),
        new(new DateOnly(2012, 9, 19), "SQL Server 2012 & Windows 8 Apps Book Launch", "Farmington, Connecticut"),
        new(new DateOnly(2012, 9, 15), "WinRT for Web Devs", "NYC Code Camp"),
        new(new DateOnly(2012, 9, 13), "SQL Server 2012 & Windows 8 Apps Book Launch", "Costa Mesa, California"),
        new(new DateOnly(2012, 8, 9), "Filling Up Your Charm Bracelet", "VS Live Redmond"),
        new(new DateOnly(2012, 8, 8), "WinRT for Web Devs", "VS Live Redmond"),
        new(new DateOnly(2012, 7, 17), "Windows 8 Charms", "Lehigh Valley .NET User Group"),
        new(new DateOnly(2012, 6, 1), "Getting Started with Metro Apps", "O’Reilly Media", "Summer 2012"),

        new(new DateOnly(2011, 10, 26), "Introduction to the Windows Runtime (WinRT)", "NY Alt.NET Meetup"),
        new(new DateOnly(2011, 10, 17), "Handling MultiTouch on the Windows Phone 7", "NYC Windows Phone User Group"),
        new(new DateOnly(2011, 10, 1), "Introduction to the Windows Runtime (WinRT)", "New York Code Camp"),
        new(new DateOnly(2011, 7, 16), "Agile CampFire", "New York"),
        new(new DateOnly(2011, 7, 1), "Handling MultiTouch on the Windows Phone 7", "MADExpo, Hampton, Virginia"),
        new(new DateOnly(2011, 6, 24), "Community MegaPhone Podcast #29", "Community MegaPhone Podcast"),
        new(new DateOnly(2011, 5, 26), "INETA Mentor", "New York/New Jersey"),
        new(new DateOnly(2011, 4, 9), "Building Modular Silverlight Applications with MEF", "Philly Code Camp"),
        new(new DateOnly(2011, 3, 3), "Handling MultiTouch on the Windows Phone 7", "Fairfield/Westchester User Groups"),
        new(new DateOnly(2011, 2, 19), "Handling MultiTouch on the Windows Phone 7", "New York Code Camp"),
        new(new DateOnly(2011, 1, 22), "Agile Firestarter: Agile Estimation", "Philadelphia"),

        new(new DateOnly(2010, 12, 11), "Unit Testing Silverlight Applications with the Silverlight Unit Testing Framework", "Northern Virginia Code Camp"),
        new(new DateOnly(2010, 8, 12), "Unit Testing Silverlight Applications with the Silverlight Unit Testing Framework", "NYC WPF & Silverlight Meetup"),
        new(new DateOnly(2010, 8, 10), "Apache Stonehenge M2", "Connected Show Podcast"),
        new(new DateOnly(2010, 7, 29), "Building Modular Silverlight Applications with MEF", "Northern Delaware .NET User Group"),
        new(new DateOnly(2010, 5, 8), "Agile Campfire", "New York"),
        new(new DateOnly(2010, 3, 27), "Agile Firestarter: Dependency Injection", "New York"),
        new(new DateOnly(2010, 3, 15), "Building Modular Silverlight Applications with MEF", "NYC WPF & Silverlight Meetup"),
        new(new DateOnly(2010, 3, 6), "Building a Rich Internet Application with jQuery", "New York Code Camp"),
        new(new DateOnly(2010, 3, 6), "Building Modular Silverlight Applications with MEF", "New York Code Camp"),
        new(new DateOnly(2010, 1, 12), "Apache Stonehenge", "New York Connected Systems Group"),

        new(new DateOnly(2009, 11, 19), "ALT.NET REST Presentation", "NYC ALT.NET Meetup"),
        new(new DateOnly(2009, 8, 13), "Litware Training CourseFeed Service", "Channel 9"),
        new(new DateOnly(2009, 8, 13), "Litware Training Overview", "Channel 9"),
        new(new DateOnly(2009, 7, 16), "Stonehenge", "NYC .NET Developer’s User Group"),
        new(new DateOnly(2009, 2, 9), "Intro to jQuery", "NYC Web Design Meetup")
    ];
}
