using CyberRiskTracker.Models;
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

            if (context.Risks.Any()) return; 

            context.Risks.AddRange(new List<RiskItem>
        {
            new RiskItem { Title = "Phishing", Description = "Email/social engineering attack.", ImageUrl = "phishing.png" },
            new RiskItem { Title = "Ransomware", Description = "Encrypting data for ransom.", ImageUrl = "ransomware.png" },
            new RiskItem { Title = "SQL Injection", Description = "Manipulate SQL queries.", ImageUrl = "sql.png" },
            new RiskItem { Title = "XSS", Description = "Cross-site scripting to inject JS.", ImageUrl = "xss.png" },
            new RiskItem { Title = "Broken Access Control", Description = "Unauthorized access to functions.", ImageUrl = "access.png" },
            new RiskItem { Title = "Insecure Deserialization", Description = "Execute code via object injection.", ImageUrl = "deserialize.png" },
            new RiskItem { Title = "Misconfigured Security", Description = "Exposed ports, debug endpoints.", ImageUrl = "misconfig.png" },
            new RiskItem { Title = "Man-in-the-Middle", Description = "Intercept network traffic.", ImageUrl = "mitm.png" },
            new RiskItem { Title = "DoS/DDoS", Description = "Service disruption via flooding.", ImageUrl = "dos.png" },
            new RiskItem { Title = "Insider Threat", Description = "Abuse by internal users.", ImageUrl = "insider.png" },
            new RiskItem { Title = "Credential Stuffing", Description = "Using stolen credentials.", ImageUrl = "stuffing.png" },
            new RiskItem { Title = "Weak Password Policies", Description = "Predictable or short passwords.", ImageUrl = "passwords.png" },
            new RiskItem { Title = "Sensitive Data Exposure", Description = "Plaintext PII or secrets.", ImageUrl = "data.png" },
            new RiskItem { Title = "Unvalidated Redirects", Description = "Redirects that trick users.", ImageUrl = "redirect.png" },
            new RiskItem { Title = "Business Logic Flaws", Description = "Abuse of valid functions.", ImageUrl = "logic.png" },
            new RiskItem { Title = "Cloud Misconfiguration", Description = "Public blobs, weak IAM.", ImageUrl = "cloud.png" },
            new RiskItem { Title = "Privilege Escalation", Description = "Gain unauthorized access levels.", ImageUrl = "escalate.png" },
            new RiskItem { Title = "CI/CD Risks", Description = "Poor secrets management in pipelines.", ImageUrl = "cicd.png" },
            new RiskItem { Title = "Inadequate Logging", Description = "Lack of audit trails.", ImageUrl = "logging.png" },
            new RiskItem { Title = "API Abuse", Description = "Overuse or tampering with endpoints.", ImageUrl = "api.png" },
            new RiskItem { Title = "Server-Side Request Forgery (SSRF)", Description = "Force server to call resources.", ImageUrl = "ssrf.png" },
            new RiskItem { Title = "CSP Bypass", Description = "Evading Content Security Policies.", ImageUrl = "csp.png" },
            new RiskItem { Title = "Supply Chain Attack", Description = "Compromised dependencies.", ImageUrl = "supply.png" },
            new RiskItem { Title = "Open Redirects", Description = "Unvalidated redirect targets.", ImageUrl = "open.png" },
            new RiskItem { Title = "Exposed Dev Tools", Description = "Swagger, debug endpoints online.", ImageUrl = "devtools.png" },
            new RiskItem { Title = "OAuth Misuse", Description = "Poor token validation or storage.", ImageUrl = "oauth.png" },
            new RiskItem { Title = "Abandoned Endpoints", Description = "Legacy but accessible APIs.", ImageUrl = "legacy.png" },
            new RiskItem { Title = "Excessive Permissions", Description = "Users/services with too many rights.", ImageUrl = "perm.png" },
            new RiskItem { Title = "Azure AD Misconfiguration", Description = "Improper tenant setup, weak MFA.", ImageUrl = "aad.png" },
            new RiskItem { Title = "Container Escapes", Description = "Breaking out of Docker/K8s.", ImageUrl = "container.png" }
        }); 
            context.SaveChanges();
        }
    } 
}
