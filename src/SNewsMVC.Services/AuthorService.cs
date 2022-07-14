using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SNewsMVC.DataModel;
using SNewsMVC.DataModel.Author;
using SNewsMVC.Resource;
using SNewsMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SNewsMVC.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _authorRestService;
        private readonly IConfiguration _configuration;

        public AuthorService(IConfiguration configuration)
        {
            _configuration = configuration;
            _authorRestService = new HttpClient();
            _authorRestService.BaseAddress = new Uri(_configuration.GetSection("ExternalServices").GetSection("SNewsAPI").Value);
        }

        public async Task<CommandResponse<IEnumerable<Author>>> Get()
        {
            var result = new CommandResponse<IEnumerable<Author>>();

            try
            {
                var response = await _authorRestService.GetAsync("Authors");
                if (response.IsSuccessStatusCode)
                {
                    // Read all of the response and deserialise it into an instace of Employee class
                    var content = await response.Content.ReadAsStringAsync();

                    var loadedResponse = JsonConvert.DeserializeObject<CommandResponseSNewsAPI<IEnumerable<Author>>>(content);
                    if (loadedResponse.Success)
                    {
                        result.Data = loadedResponse.Data;
                    }
                    else
                    {
                        result.ErrorMessage = loadedResponse.ErrorMessage;
                    }

                }
                else
                {
                    result.ErrorMessage = Resources.errErrorCallingSNewsAPI;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public async Task<CommandResponse<Author>> GetById(int id)
        {
            var result = new CommandResponse<Author>();
            try
            {
                string requestPath = $"Authors/{id}";
                var response = await _authorRestService.GetAsync(requestPath);
                if (response.IsSuccessStatusCode)
                {
                    // Read all of the response and deserialise it into an instace of Employee class
                    var content = await response.Content.ReadAsStringAsync();

                    var loadedResponse = JsonConvert.DeserializeObject<CommandResponseSNewsAPI<Author>>(content);
                    if (loadedResponse.Success)
                    {
                        result.Data = loadedResponse.Data;
                    }
                    else
                    {
                        result.ErrorMessage = loadedResponse.ErrorMessage;
                    }

                }
                else
                {
                    result.ErrorMessage = Resources.errErrorCallingSNewsAPI;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<CommandResponse<Author>> Insert(InsertAuthorRequest author)
        {
            var result = new CommandResponse<Author>();
            try
            {
                var json = JsonConvert.SerializeObject(author);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _authorRestService.PostAsync("Authors", data);
                if (response.IsSuccessStatusCode)
                {
                    // Read all of the response and deserialise it into an instace of Employee class
                    var content = await response.Content.ReadAsStringAsync();

                    var loadedResponse = JsonConvert.DeserializeObject<CommandResponseSNewsAPI<Author>>(content);
                    if (loadedResponse.Success)
                    {
                        result.Data = loadedResponse.Data;
                    }
                    else
                    {
                        result.ErrorMessage = loadedResponse.ErrorMessage;
                    }

                }
                else
                {
                    result.ErrorMessage = Resources.errErrorCallingSNewsAPI;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
