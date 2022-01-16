﻿using AutoMapper;
using HMZ4th.Helpers.Cache;
using HMZ4th.Models;
using HMZ4th.Services;
using HMZ4th.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
namespace HMZ4th.Pages
{
    public partial class Work : TransitionPageBase<Work>
    {
        [Inject] IStateContainer StateContainer { get; set; }
        [Inject] IMapper Mapper { get; set; }
        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        HttpClient HttpClient { get; set; }

        public List<WorkProjectModel> WorkCards { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            HttpClient = HttpClientFactory.CreateClient("External");

            if (StateContainer.TryGet<List<WorkProjectModel>>(CacheKeys.WorkKey, out List<WorkProjectModel> Value) == false)
            {
                var repos = await HttpClient.GetFromJsonAsync<List<RepoModel>>("https://api.github.com/users/hmz777/repos");

                Value = Mapper.Map<List<WorkProjectModel>>(repos);

                StateContainer.Set<List<WorkProjectModel>>(CacheKeys.WorkKey, Value);
            }

            WorkCards = Value;
        }
    }
}
