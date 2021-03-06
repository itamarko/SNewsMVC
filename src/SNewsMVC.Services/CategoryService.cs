using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SNewsMVC.DataModel;
using SNewsMVC.DataModel.Category;
using SNewsMVC.Resource;
using SNewsMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SNewsMVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _categoryRestService;
        private readonly IConfiguration _configuration;

        public CategoryService(IConfiguration configuration)
        {
            _configuration = configuration;
            _categoryRestService = new HttpClient();
            _categoryRestService.BaseAddress = new Uri(_configuration.GetSection("ExternalServices").GetSection("SNewsAPI").Value);
        }
        public async Task<CommandResponse<IEnumerable<Category>>> Get()
        {
            var result = new CommandResponse<IEnumerable<Category>>();

            try
            {
                var response = await _categoryRestService.GetAsync("Categories");
                if (response.IsSuccessStatusCode)
                {
                    // Read all of the response and deserialise it into an instace of Employee class
                    var content = await response.Content.ReadAsStringAsync();

                    var loadedResponse = JsonConvert.DeserializeObject<CommandResponseSNewsAPI<IEnumerable<Category>>>(content);
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

        public async Task<CommandResponse<Category>> GetById(int id)
        {
            var result = new CommandResponse<Category>();
            try
            {
                string requestPath = $"Categories/{id}";
                var response = await _categoryRestService.GetAsync(requestPath);
                if (response.IsSuccessStatusCode)
                {
                    // Read all of the response and deserialise it into an instace of Employee class
                    var content = await response.Content.ReadAsStringAsync();

                    var loadedResponse = JsonConvert.DeserializeObject<CommandResponseSNewsAPI<Category>>(content);
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
            catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<CommandResponse<Category>> Insert(InsertCategoryRequest category)
        {
            var result = new CommandResponse<Category>();
            try
            {
                var json = JsonConvert.SerializeObject(category);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _categoryRestService.PostAsync("Categories", data);
                if (response.IsSuccessStatusCode)
                {
                    // Read all of the response and deserialise it into an instace of Employee class
                    var content = await response.Content.ReadAsStringAsync();

                    var loadedResponse = JsonConvert.DeserializeObject<CommandResponseSNewsAPI<Category>>(content);
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
