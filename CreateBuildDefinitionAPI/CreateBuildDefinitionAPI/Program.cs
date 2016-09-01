using CreateBuildDefinitionAPI.Create;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CreateBuildDefinitionAPI
{
    class Program
    {
        // TFS Address
        static String uriSources = "http://vm03-tfsap:8080/tfs/DefaultCollection/{0}/_apis/";

        //Api version query parameter
        static String apiVersion = "?api-version=2.0";

        static String teamProject = "ProjetoTFVC";

        static String user = @"VSALM\Administrator";

        static String pass = "P@ssw0rd";

        static void Main(string[] args)
        {
            Console.WriteLine("INICIO\n");

            //GetAllBuildDefinitions();
            //GetBuildDefinitionById(3);
            //CreateBuildDefinition();
            CreateBuildDefinitionJsonFile();

            Console.WriteLine("\nFIM");
            Console.ReadLine();

        }

        #region GetAllBuildDefinitions
        static void GetAllBuildDefinitions()
        {

            Console.WriteLine("\n******************************\nGet All Build Definitions\n******************************\n");

            using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(user, pass) })
            {
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    uriSources = String.Format(uriSources, teamProject);
                    string completeAddress = uriSources + "/build/definitions/" + apiVersion;
                    
                    HttpResponseMessage response = client.GetAsync(completeAddress).Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;

                        ApiCollection<BuildDefinitionList> buildDefinitions = JsonConvert.DeserializeObject<ApiCollection<BuildDefinitionList>>(data);

                        if (buildDefinitions.Value.Count() > 0)
                        {
                            foreach (var buildDefinition in buildDefinitions.Value)
                            {
                                Console.WriteLine("ID: "+ buildDefinition.Id);
                                Console.WriteLine("Name: " + buildDefinition.Name);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region GetBuildDefinitionById
        static void GetBuildDefinitionById(int id)
        {
            Console.WriteLine("\n******************************\nGet Build Definition By Id (" + id + ")\n******************************\n");

            using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(user, pass) })
            {
                using (var client = new HttpClient(handler))
                {

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    uriSources = String.Format(uriSources, teamProject);
                    string completeAddress = uriSources + "/build/definitions/" + id + apiVersion;

                    HttpResponseMessage response = client.GetAsync(completeAddress).Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;

                        BuildDefinitionItem buildDefinition = JsonConvert.DeserializeObject<BuildDefinitionItem>(data);

                        if (buildDefinition != null )
                        { 
                            Console.WriteLine("ID: " + buildDefinition.Id);
                            Console.WriteLine("Name: " + buildDefinition.Name);

                            if (buildDefinition.Variables != null)
                            {
                                Console.WriteLine("Build Variables");

                                if (buildDefinition.Variables.SystemDebug != null)
                                {
                                    Console.WriteLine("   System Debug");
                                    Console.WriteLine("      Value: " + buildDefinition.Variables.SystemDebug.Value);
                                    Console.WriteLine("      AllowOverride: " + buildDefinition.Variables.SystemDebug.AllowOverride);
                                }

                                if (buildDefinition.Variables.BuildConfiguration != null)
                                {
                                    Console.WriteLine("   Build Configuration");
                                    Console.WriteLine("      Value: " + buildDefinition.Variables.BuildConfiguration.Value);
                                    Console.WriteLine("      AllowOverride: " + buildDefinition.Variables.BuildConfiguration.AllowOverride);
                                }

                                if (buildDefinition.Variables.BuildPlatform != null)
                                {
                                    Console.WriteLine("   Build Platform");
                                    Console.WriteLine("      Value: " + buildDefinition.Variables.BuildPlatform.Value);
                                    Console.WriteLine("      AllowOverride: " + buildDefinition.Variables.BuildPlatform.AllowOverride);
                                }
                            }
                        }
                    }
                }
            }

        }
        #endregion

        #region CreateBuildDefinition
        static async void CreateBuildDefinition()
        {

            Console.WriteLine("\n******************************\nCreate Build Definition\n******************************\n");

            using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(user, pass) })
            {
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    uriSources = String.Format(uriSources, teamProject);
                    string completeAddress = uriSources + "build/definitions" + apiVersion;

                    BuildDefinitionCreate newBuild = new BuildDefinitionCreate();
                    newBuild.name = "Teste - " + Guid.NewGuid().ToString();
                    newBuild.type = "build";
                    newBuild.quality = "definition";
                    newBuild.queue = new Queue {id = 2 };

                    Variables variaveis = new Variables();
                    variaveis.BuildConfiguration = new BuildConfiguration { value = "Debug", allowOverride = true };
                    variaveis.BuildPlatform = new BuildPlatform { value = "Any CPU", allowOverride = true };
                    newBuild.variables = variaveis;

                    List<Build> lstBuild = new List<Build>();
                    lstBuild.Add(new Build { enabled = true, continueOnError = false, alwaysRun = false, displayName = "NuGet restore", task = new CreateBuildDefinitionAPI.Create.Task { id = "333b11bd-d341-40d9-afcf-b32d5ce6f23b", versionSpec = "*" }, inputs = new Inputs { solution = "**\\*.sln" } });
                    lstBuild.Add(new Build { enabled = true, continueOnError = false, alwaysRun = false, displayName = "Build solution", task = new CreateBuildDefinitionAPI.Create.Task { id = "71a9a2d3-a98a-4caa-96ab-affca411ecda", versionSpec = "*" }, inputs = new Inputs { solution = "**\\*.sln", platform = "$(BuildPlatform)", configuration = "$(BuildConfiguration)", vsVersion = "14.0", msbuildArchitecture = "x86", logProjectEvents = "true" } });
                    lstBuild.Add(new Build { enabled = true, continueOnError = false, alwaysRun = false, displayName = "Test Assemblies", task = new CreateBuildDefinitionAPI.Create.Task { id = "ef087383-ee5e-42c7-9a53-ab56c98420f9", versionSpec = "*" }, inputs = new Inputs { testAssembly = "**\\$(BuildConfiguration)\\*test*.dll", platform = "$(BuildPlatform)", configuration = "$(BuildConfiguration)", codeCoverageEnabled = "true", vsTestVersion = "14.0", publishRunAttachments = "true" } });
                    lstBuild.Add(new Build { enabled = true, continueOnError = false, alwaysRun = true, displayName = "Copy Files", task = new CreateBuildDefinitionAPI.Create.Task { id = "5bfb729a-a7c8-4a78-a7c3-8d717bb7c13c", versionSpec = "*" }, inputs = new Inputs { SourceFolder = "$(build.sourcesdirectory)", Contents = "**\\bin\\$(BuildConfiguration)\\**", TargetFolder = "$(build.artifactstagingdirectory)", CleanTargetFolder = "false", OverWrite = "false" } });
                    lstBuild.Add(new Build { enabled = true, continueOnError = false, alwaysRun = true, displayName = "Publish Artifact", task = new CreateBuildDefinitionAPI.Create.Task { id = "2ff763a7-ce83-4e1f-bc89-0ae63477cebe", versionSpec = "*" }, inputs = new Inputs { PathtoPublish = "$(build.artifactstagingdirectory)", ArtifactName = "drop", ArtifactType = "Container" } });
                    newBuild.build = lstBuild;

                    newBuild.buildNumberFormat = "$(date:yyyyMMdd)$(rev:.r)";
                    newBuild.jobAuthorizationScope = "projectCollection";
                    newBuild.jobTimeoutInMinutes = 60;

                    Repository rep = new Repository();
                    rep.id = "$/";
                    rep.type = "TfsVersionControl";
                    rep.name = teamProject;
                    rep.defaultBranch = "$/" + teamProject;
                    rep.rootFolder = "$/" + teamProject;
                    rep.clean = "undefined";
                    newBuild.repository = rep;

                    var responseBody = await CreateBuildAsync(client, newBuild, completeAddress);

                    Console.WriteLine("Build criado");

                }
            }
        }

        static async Task<String> CreateBuildAsync(HttpClient client, BuildDefinitionCreate data, String apiUrl)
        {
            var responseBody = String.Empty;

            var temp = JsonConvert.SerializeObject(data);

            var content = new StringContent(
                JsonConvert.SerializeObject(data),
                Encoding.UTF8,
                "application/json");

            try
            {
                using (HttpResponseMessage response = client.PostAsync(apiUrl, content).Result)
                {
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return responseBody;
        }
        #endregion

        #region CreateBuildDefinition JsonFile
        static async void CreateBuildDefinitionJsonFile()
        {

            Console.WriteLine("\n******************************\nCreate Build Definition Json File\n******************************\n");

            using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(user, pass) })
            {
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    uriSources = String.Format(uriSources, teamProject);
                    string completeAddress = uriSources + "build/definitions" + apiVersion;

                    string json;
                    using (StreamReader r = new StreamReader(@"JsonFile\CreateBuildDefinition.json"))
                    {
                        json = r.ReadToEnd();
                    }

                    var responseBody = await CreateBuildJsonFileAsync(client, json, completeAddress);

                    Console.WriteLine("Build criado");

                }
            }
        }

        static async Task<String> CreateBuildJsonFileAsync(HttpClient client, string data, String apiUrl)
        {
            var responseBody = String.Empty;

            var temp = JsonConvert.SerializeObject(data);

            var content = new StringContent(
                data,
                Encoding.UTF8,
                "application/json");

            try
            {
                using (HttpResponseMessage response = client.PostAsync(apiUrl, content).Result)
                {
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return responseBody;
        }

        
        #endregion


    }
}
