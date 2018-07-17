using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Nucleus.Models;

namespace Nucleus
{
    public class ApiClient
    {
        const string BaseUrl = "http://localhost:5001/api";


        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", token);
        }

        public void ClearToken()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<UserResponse> SignUpAsync(UserModel userForm)
        {
            return await PostUserFormAsync("/users", userForm);
        }

        public async Task<UserResponse> SignInAsync(UserModel userForm)
        {
            return await PostUserFormAsync("/users/login", userForm);
        }

        public async Task<UserResponse> UpdateUserAsync(UserModel userForm)
        {
            return await PutUserFormAsync("/user", userForm);
        }

        public async Task<UserModel> GetUserAsync()
        {
            var response = await _httpClient.GetJsonAsync<UserResponse>($"{BaseUrl}/user");
            return response.user;
        }

        async Task<UserResponse> PostUserFormAsync(string urlFragment, UserModel userForm)
        {
            return await _httpClient.PostJsonAsync<UserResponse>($"{BaseUrl}{urlFragment}",
                new
                {
                    user = userForm
                });
        }

        async Task<UserResponse> PutUserFormAsync(string urlFragment, UserModel userForm)
        {
            return await _httpClient.PutJsonAsync<UserResponse>($"{BaseUrl}{urlFragment}",
                new
                {
                    user = userForm
                });
        }

        public async Task<ProfileModel> GetProfileAsync(string username)
        {
            var response = await _httpClient.GetJsonAsync<ProfileResponse>($"{BaseUrl}/profiles/{username}");
            return response.profile;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await GetPostsAsync("/posts", null, null);
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(string tag)
        {
            return await GetPostsAsync("/posts", tag, null);
        }

        public async Task<IEnumerable<Post>> GetPostsByAuthorAsync(string author)
        {
            return await GetPostsAsync("/posts", null, author);
        }

        public async Task<IEnumerable<Post>> GetPostFeedAsync()
        {
            return await GetPostsAsync("/posts/feed", null, null);
        }

        async Task<IEnumerable<Post>> GetPostsAsync(string urlFragment, string tag, string author)
        {
            var tagFilter = tag == null ? "" : $"tag={tag}&";
            var authorFilter = author == null ? "" : $"author={author}&";
            var query = $"?{tagFilter}{authorFilter}limit=10&offset=0";
            var response = await _httpClient.GetJsonAsync<PostsResponse>($"{BaseUrl}{urlFragment}{query}");
            //var response = await _httpClient.GetAsync($"{BaseUrl}{urlFragment}{query}");
            return response.posts;
        }

        public async Task<Post> GetPostAsync(string slug)
        {
            var response = await _httpClient.GetJsonAsync<PostResponse>($"{BaseUrl}/post/{slug}");
            return response.post;
        }

        public async Task<IEnumerable<string>> GetTagsAsync()
        {
            var response = await _httpClient.GetJsonAsync<TagResponse>($"{BaseUrl}/tags");
            return response.tags;
        }

        public async Task<PostResponse> SavePostAsync(Post post)
        {
            string url = $"{BaseUrl}/posts";
            object content = new
            {
                post = post
            };

            if (String.IsNullOrEmpty(post.Id.ToString()))
                return await _httpClient.PostJsonAsync<PostResponse>(url, content);
            else
                return await _httpClient.PutJsonAsync<PostResponse>($"{url}/{post.Id}", content);
        }

        public async Task<bool> DeletePostAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/articles/{id}");
            return response.IsSuccessStatusCode;
        }
    }

    public class UserResponse
    {
        public ErrorsModel errors { get; set; }
        public UserModel user { get; set; }
    }

    public class ProfileResponse
    {
        public ProfileModel profile { get; set; }
    }

    public class PostResponse
    {
        public ErrorsModel errors { get; set; }
        public Post post { get; set; }
    }

    class PostsResponse
    {
        public Post[] posts { get; set; }
    }

    class TagResponse
    {
        public string[] tags { get; set; }
    }
}
