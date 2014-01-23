using System.Net.Http;
using PortableRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wistia.Core.Models;

namespace Wistia.Core.Services
{
    public class ProjectService : WistiaClientBase
    {
        public ProjectService(string apiKey) : base(apiKey)
        {
        }

        public async Task<List<Project>> All()
        {
            return await GetRequest<List<Project>>("projects.json");
        }
  
        public async Task<Project> GetById(string hashedProjectId)
        {
            return await GetRequest<Project>("projects/{0}.json", hashedProjectId);
        }

        /// <summary>
        /// Create a new project.
        /// </summary>
        /// <param name="project">The project to create</param>
        /// <returns>The created project</returns>
        public async Task<Project> Create(Project project)
        {
            return await PostRequest<Project, Project>(project, "projects.json");
        }
  
        /// <summary>
        /// Update settings for an existing project under your control (ie: only the ones you own).
        /// </summary>
        /// <param name="project">The project to update</param>
        public async Task Update(Project project)
        {
            await PutRequest<Project, Project>(project, "projects/{0}.json", project.hashedId);
        }
  
        /// <summary>
        /// Delete method for projects
        /// </summary>
        /// <param name="projectId">The projectId to delete</param>
        public async Task Delete(int projectId)
        {
            await DeleteRequest("/projects/{0}", projectId);
        }
    }
}
