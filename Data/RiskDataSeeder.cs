using CyberRiskTracker.Data.Entities;
using static CyberRiskTracker.Models.Enums;

namespace CyberRiskTracker.Data
{
    public static class RiskDataInitializer
    {
        public static void InitializeAndSeedInMemDBIfNotFound(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CyberRiskDbContext>();

            // For InMemory, no migration is needed  just ensure database is created
            context.Database.EnsureCreated();
            SeedRisks(context);
            SeedAssets(context);
            context.SaveChanges();
        }

        private static void SeedAssets(CyberRiskDbContext context)
        {
            if (context.Assets.Any()) return;
            context.Assets.AddRange(new List<AssetEntity> {
             new AssetEntity { Id = 1, Name = "Payment API", Type = "API", Owner = "Fintech Team", Environment = EnvironmentType.Production, RiskLevel = RiskLevel.Critical, Location = "Azure" },
                new AssetEntity { Id = 2, Name = "Dev DB", Type = "Database", Owner = "DevOps", Environment = EnvironmentType.Development, RiskLevel = RiskLevel.Medium, Location = "On-Prem" },
                new AssetEntity { Id = 3, Name = "Web Frontend", Type = "Web App", Owner = "Frontend Team", Environment = EnvironmentType.Staging, RiskLevel = RiskLevel.Medium, Location = "Azure" },
                new AssetEntity { Id = 4, Name = "Kubernetes Cluster", Type = "Container", Owner = "Platform Team", Environment = EnvironmentType.Production, RiskLevel = RiskLevel.High, Location = "AWS" },
                new AssetEntity { Id = 5, Name = "Legacy CRM", Type = "Application", Owner = "Sales", Environment = EnvironmentType.Legacy, RiskLevel = RiskLevel.Critical, Location = "Data Center" },
                new AssetEntity { Id = 6, Name = "QA Database", Type = "Database", Owner = "QA Team", Environment = EnvironmentType.QA, RiskLevel = RiskLevel.Medium, Location = "Azure" },
                new AssetEntity { Id = 7, Name = "Internal Portal", Type = "Web App", Owner = "HR", Environment = EnvironmentType.Production, RiskLevel = RiskLevel.Low, Location = "Azure" },
                new AssetEntity { Id = 8, Name = "Jenkins Server", Type = "CI Tool", Owner = "DevOps", Environment = EnvironmentType.Staging, RiskLevel = RiskLevel.High, Location = "AWS" },
                new AssetEntity { Id = 9, Name = "GitHub Actions", Type = "CI/CD", Owner = "Developers", Environment = EnvironmentType.Production, RiskLevel = RiskLevel.High, Location = "Cloud" },
                new AssetEntity { Id = 10, Name = "Monitoring Stack", Type = "Observability", Owner = "SRE", Environment = EnvironmentType.Production, RiskLevel = RiskLevel.Medium, Location = "Azure" },
                new AssetEntity { Id = 11, Name = "Email Gateway", Type = "Service", Owner = "IT", Environment = EnvironmentType.Production, RiskLevel = RiskLevel.High, Location = "On-Prem" },
                new AssetEntity { Id = 12, Name = "Finance API", Type = "API", Owner = "Finance", Environment = EnvironmentType.Test, RiskLevel = RiskLevel.Medium, Location = "Azure" },
                new AssetEntity { Id = 13, Name = "SFTP Server", Type = "File Server", Owner = "Operations", Environment = EnvironmentType.Legacy, RiskLevel = RiskLevel.Critical, Location = "Data Center" },
                new AssetEntity { Id = 14, Name = "Data Warehouse", Type = "Database", Owner = "Analytics", Environment = EnvironmentType.Production, RiskLevel = RiskLevel.Critical, Location = "Azure" },
                new AssetEntity { Id = 15, Name = "Dev Test Portal", Type = "Web App", Owner = "Dev Team", Environment = EnvironmentType.Test, RiskLevel = RiskLevel.Low, Location = "Local" }

            });
        }

        private static void SeedRisks(CyberRiskDbContext context)
        {
            if (context.Risks.Any()) return;

            context.Risks.AddRange(new List<RiskItemEntity>
        {
         new RiskItemEntity {
        Title = "Phishing",
        Description = "Email/social engineering attack.",
        ImageUrl = "phishing.png",
        HowItWorks = "Tricks users into clicking malicious links or entering credentials.",
        AdditionalInformation = """
        - Common via fake emails or SMS
        - Often targets employee logins
        - Can lead to credential theft
        """
    },
    new RiskItemEntity {
        Title = "Ransomware",
        Description = "Encrypting data for ransom.",
        ImageUrl = "ransomware.png",
        HowItWorks = "Malware encrypts files and demands payment for decryption key.",
        AdditionalInformation = """
        - Delivered via email or unpatched systems
        - Common in healthcare and finance
        - Increasing in targeted attacks
        """
    },
    new RiskItemEntity {
        Title = "SQL Injection",
        Description = "Manipulate SQL queries.",
        ImageUrl = "sql.png",
        HowItWorks = "Injects SQL through input fields to access or alter data.",
        AdditionalInformation = """
        - Exploits poor input validation
        - Can dump entire databases
        - OWASP Top 10 entry
        """
    },
    new RiskItemEntity {
        Title = "XSS",
        Description = "Cross-site scripting to inject JS.",
        ImageUrl = "xss.png",
        HowItWorks = "Injects malicious JS into webpages viewed by others.",
        AdditionalInformation = """
        - Steals cookies or session tokens
        - Found in comments, forms
        - Stored, reflected, DOM-based types
        """
    },
    new RiskItemEntity {
        Title = "Broken Access Control",
        Description = "Unauthorized access to functions.",
        ImageUrl = "access.png",
        HowItWorks = "Lack of proper role checks or authorization logic.",
        AdditionalInformation = """
        - Can allow privilege escalation
        - Common in APIs
        - OWASP's #1 risk in 2021
        """
    },
    new RiskItemEntity {
        Title = "Insecure Deserialization",
        Description = "Execute code via object injection.",
        ImageUrl = "deserialize.png",
        HowItWorks = "Accepts untrusted serialized data that can execute code.",
        AdditionalInformation = """
        - Remote code execution (RCE) possible
        - Found in .NET and Java apps
        - Exploitable through custom object formats
        """
    },
            new RiskItemEntity { Title = "Misconfigured Security", Description = "Exposed ports, debug endpoints.", ImageUrl = "misconfig.png" },
            new RiskItemEntity { Title = "Man-in-the-Middle", Description = "Intercept network traffic.", ImageUrl = "mitm.png" },
            new RiskItemEntity { Title = "DoS/DDoS", Description = "Service disruption via flooding.", ImageUrl = "dos.png" },
            new RiskItemEntity { Title = "Insider Threat", Description = "Abuse by internal users.", ImageUrl = "insider.png" },
            new RiskItemEntity { Title = "Credential Stuffing", Description = "Using stolen credentials.", ImageUrl = "stuffing.png" },
            new RiskItemEntity { Title = "Weak Password Policies", Description = "Predictable or short passwords.", ImageUrl = "passwords.png" },
            new RiskItemEntity { Title = "Sensitive Data Exposure", Description = "Plaintext PII or secrets.", ImageUrl = "data.png" },
            new RiskItemEntity { Title = "Unvalidated Redirects", Description = "Redirects that trick users.", ImageUrl = "redirect.png" },
            new RiskItemEntity { Title = "Business Logic Flaws", Description = "Abuse of valid functions.", ImageUrl = "logic.png" },
            new RiskItemEntity { Title = "Cloud Misconfiguration", Description = "Public blobs, weak IAM.", ImageUrl = "cloud.png" },
            new RiskItemEntity { Title = "Privilege Escalation", Description = "Gain unauthorized access levels.", ImageUrl = "escalate.png" },
            new RiskItemEntity { Title = "CI/CD Risks", Description = "Poor secrets management in pipelines.", ImageUrl = "cicd.png" },
            new RiskItemEntity { Title = "Inadequate Logging", Description = "Lack of audit trails.", ImageUrl = "logging.png" },
            new RiskItemEntity { Title = "API Abuse", Description = "Overuse or tampering with endpoints.", ImageUrl = "api.png" },
            new RiskItemEntity { Title = "Server-Side Request Forgery (SSRF)", Description = "Force server to call resources.", ImageUrl = "ssrf.png" },
            new RiskItemEntity { Title = "CSP Bypass", Description = "Evading Content Security Policies.", ImageUrl = "csp.png" },
            new RiskItemEntity { Title = "Supply Chain Attack", Description = "Compromised dependencies.", ImageUrl = "supply.png" },
            new RiskItemEntity { Title = "Open Redirects", Description = "Unvalidated redirect targets.", ImageUrl = "open.png" },
            new RiskItemEntity { Title = "Exposed Dev Tools", Description = "Swagger, debug endpoints online.", ImageUrl = "devtools.png" },
            new RiskItemEntity { Title = "OAuth Misuse", Description = "Poor token validation or storage.", ImageUrl = "oauth.png" },
            new RiskItemEntity { Title = "Abandoned Endpoints", Description = "Legacy but accessible APIs.", ImageUrl = "legacy.png" },
            new RiskItemEntity { Title = "Excessive Permissions", Description = "Users/services with too many rights.", ImageUrl = "perm.png" },
            new RiskItemEntity { Title = "Azure AD Misconfiguration", Description = "Improper tenant setup, weak MFA.", ImageUrl = "aad.png" },
            new RiskItemEntity { Title = "Container Escapes", Description = "Breaking out of Docker/K8s.", ImageUrl = "container.png" }
        });
        }
    }
}
