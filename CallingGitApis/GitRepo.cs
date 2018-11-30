using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CallingGitApis.Models;
using System.Collections.Generic;
using System.Linq;

namespace CallingGitApis
{
    public class GitRepo
    {
        static HttpClient client = new HttpClient();
        //static string repoOwner = "LBHMKeyworth";
        static string repoOwner = "LBHackney-IT";

        public static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://api.github.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "LBHMKeyworth");
            client.Timeout = TimeSpan.FromSeconds(30);
        }

        public static async Task<List<Repository>> GetReposAsync()
        {
            List<Repository> repos = new List<Repository>();
            HttpResponseMessage response = await client.GetAsync($"users/{repoOwner}/repos");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                repos = await response.Content.ReadAsAsync<List<Repository>>();
            }
            // return URI of the created resource.
            return repos;
        }
        public static async Task<Repository> GetRepoAsync(string repoName)
        {
            Repository repo = new Repository();
            HttpResponseMessage response = await client.GetAsync($"repos/{repoOwner}/{repoName}");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                repo = await response.Content.ReadAsAsync<Repository>();
            }
            // return URI of the created resource.
            return repo;
        }

        private static async Task<RepoContents> GetRepoRootObjectAsync(string repoName)
        {
            RepoContents rootObject = new RepoContents();
            ///repos/LBHMKeyworth/mktest1/git/trees/master
            HttpResponseMessage response = await client.GetAsync($"repos/{repoOwner}/{repoName}/git/trees/master");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                rootObject = await response.Content.ReadAsAsync<RepoContents>();
            }
            // return URI of the created resource.
            return rootObject;
        }

        public static async Task<BlobFile> GetReadMeFile(string repoName)
        {
            
            RepoContents repoContents = await GetRepoRootObjectAsync(repoName);

            Tree tree = repoContents.tree.FirstOrDefault(x => x.path == "README.md");

            string fileSha = tree.sha;
            
            return await GetBlobFileFromRepo(fileSha, repoName);
            

        }

        private static async Task<BlobFile> GetBlobFileFromRepo(string fileSha, string repoName)
        {
            BlobFile blobFile = new BlobFile();
            ///repos/:owner/:repo/git/blobs/:file_sha
            HttpResponseMessage response = await client.GetAsync($"repos/{repoOwner}/{repoName}/git/blobs/{fileSha}");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                blobFile = await response.Content.ReadAsAsync<BlobFile>();
            }
            // return URI of the created resource.
            return blobFile;
        }
    }
}
