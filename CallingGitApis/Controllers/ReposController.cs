using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LBH.APIHub.Data.Domain;

namespace CallingGitApis.Controllers
{
    public class ReposController : Controller
    {
        public async Task<IActionResult> Index(string repoName)
        {
            Repository repo = await GitRepo.GetRepoAsync(repoName);
            return View(repo);
        }

        public async Task<IActionResult> ReadMe(string repoName)
        {
            BlobFile readMeFile = await GitRepo.GetReadMeFile(repoName);
            byte[] readMeBytes = Convert.FromBase64String(readMeFile.content);
            string readMeContents = System.Text.Encoding.Default.GetString(readMeBytes);

            return View((object)readMeContents);
        }
    }
}