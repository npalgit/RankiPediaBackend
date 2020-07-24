using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;
using System.Linq;
using System.Text.RegularExpressions;
using Rankipedia.WebApi;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Rankipedia.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                        c.MultipleApiVersions(
                            (apiDesc, targetApiVersion) =>
                            { 
                                if(targetApiVersion == "unversioned")
                                {
                                    return IsUnversioned(apiDesc.RelativePath);
                                }
                                return apiDesc.RelativePath.Contains(targetApiVersion);
                            },
                            (vc) =>
                            {
                                vc.Version("unversioned", "Rankipedia API Unversioned")
                                .Description("Unversioned")
                                .Contact(cc=> cc
                                    .Name("Devteam")
                                    .Email("Rankipedia@abc.com"));

                                vc.Version("v1", "SIB API V1")
                               .Description("Version 1")
                               .Contact(cc => cc
                                   .Name("Devteam")
                                   .Email("Rankipedia@abc.com"));
                            });                      
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.EnableDiscoveryUrlSelector();
                        c.DisableValidator();
                        c.EnableDiscoveryUrlSelector();
                        c.DocExpansion(DocExpansion.None);                      
                    });
        }
        private static bool IsUnversioned(string relativePath)
        {
            Regex re = new Regex(@"/v\d", RegexOptions.IgnoreCase);
            bool isMatch = re.IsMatch(relativePath);
            return !isMatch;
        }
    }
}
