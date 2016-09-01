using GIT_API.Commits;
using GIT_API.GetRepository;
using GIT_API.List;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GIT_API
{
    class Program
    {
        // TFS Address
        static String uriSources = "http://vm03-tfsap:8080/tfs/DefaultCollection/_apis/";

        //Api version query parameter
        static String apiVersion = "?api-version=2.0";

        static String user = @"VSALM\Administrator";

        static String pass = "P@ssw0rd";

        static void Main(string[] args)
        {
            Console.WriteLine("INICIO\n");

            GetAllRepositories();
            GetRepositoryById("42ffcd1c-bbb9-48ca-a247-f61a5170590f");
            GetFolderAndChildren("42ffcd1c-bbb9-48ca-a247-f61a5170590f", "/");
            CommitsByRepositoryID("42ffcd1c-bbb9-48ca-a247-f61a5170590f");
            Console.WriteLine("\nFIM");
            Console.ReadLine();

        }

        #region GetAllRepositories
        static void GetAllRepositories()
        {
            Console.WriteLine("\n******************************\nGet All Repositories\n******************************\n");

            using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(user, pass) })
            {
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string completeAddress = uriSources + "git/repositories/" + apiVersion;

                    HttpResponseMessage response = client.GetAsync(completeAddress).Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;

                        GetListRepositories res = JsonConvert.DeserializeObject<GetListRepositories>(data);

                        if (res.count > 0)
                        {
                            foreach (var _item in res.value)
                            {
                                Console.WriteLine("ID: " + _item.id);
                                Console.WriteLine("Name: " + _item.name);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region GetRepositoryById
        static void GetRepositoryById(string id)
        {
            Console.WriteLine("\n******************************\nGet Repository\n******************************\n");

            using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(user, pass) })
            {
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string completeAddress = uriSources + "git/repositories/" +id + apiVersion;

                    HttpResponseMessage response = client.GetAsync(completeAddress).Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;

                        GetRepositoryById res = JsonConvert.DeserializeObject<GetRepositoryById>(data);

                        if (res != null)
                        {
                            Console.WriteLine("ID: " + res.id);
                            Console.WriteLine("Name: " + res.name);
                            Console.WriteLine("Branch: " + res.defaultBranch);
                        }
                    }
                }
            }
        }
        #endregion

        private static void GetFolderAndChildren(string id, string scopePath)
        {

            Console.WriteLine("\n******************************\nGet folder and its children\n******************************\n");
            
            using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(user, pass) })
            {
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string completeAddress = uriSources + "git/repositories/" + id + "/items?scopePath=" + scopePath + "&recursionLevel=Full&includeContentMetadata=true&api-version=1.0";

                    HttpResponseMessage response = client.GetAsync(completeAddress).Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;

                        GetRepositoryList res = JsonConvert.DeserializeObject<GetRepositoryList>(data);

                        if (res.count > 0)
                        {
                            Console.WriteLine("Total: " + res.count);
                            Console.WriteLine("");

                            foreach (var _item in res.value)
                            {
                                Console.WriteLine("objectId: " + _item.objectId);
                                Console.WriteLine("gitObjectType: " + _item.gitObjectType);
                                Console.WriteLine("commitId: " + _item.commitId);
                                Console.WriteLine("path: " + _item.path);
                                Console.WriteLine("isFolder: " + _item.isFolder);
                                Console.WriteLine("");
                            }
                        }
                    }
                }
            }
        }


        #region CommitsByRepositoryID
        static void CommitsByRepositoryID(string id)
        {
            Console.WriteLine("\n******************************\nGet Commits By Repository ID\n******************************\n");

            using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(user, pass) })
            {
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string completeAddress = uriSources + "git/repositories/" + id + "/commits?api-version=1.0";

                    HttpResponseMessage response = client.GetAsync(completeAddress).Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;

                        GetCommitsByRepository res = JsonConvert.DeserializeObject<GetCommitsByRepository>(data);

                        if (res.count > 0)
                        {
                            Console.WriteLine("Total: " + res.count);
                            Console.WriteLine("");

                            foreach (var _item in res.value)
                            {
                                Console.WriteLine("commitId: " + _item.commitId);
                                Console.WriteLine("author: " + _item.author.name);
                                Console.WriteLine("comment: " + _item.comment);
                                Console.WriteLine("");
                            }
                        }
                    }
                }
            }
        }
        #endregion

        
    }
}
