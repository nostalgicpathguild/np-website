using np_website.Models.Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace np_website.Controllers
{
    [RoutePrefix("discord")]
    public class DiscordController : Controller
    {

        [Route("login")]
        public ActionResult Login()
        {
            //https://discordapp.com/api/oauth2/authorize?client_id=576555412162215958&redirect_uri=http%3A%2F%2Flocalhost%3A64429%2Fdiscord%2Fcallback&response_type=code&scope=email%20identify

            var callbackUrl = Uri.EscapeDataString($"{Url.Content("~/")}/discord/callback");
            var state = Utilities.String.GetHashString(Session.SessionID);
            return Redirect($"{"https://"}discordapp.com/oauth2/authorize?client_id={Resources.AppSettings.DiscordClientId}&scope=email%20identify&response_type=code&state={state}&redirect_uri={callbackUrl}");
        }

        [Route("callback")]
        public async System.Threading.Tasks.Task<ActionResult> CallbackAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            var callbackUrl = Uri.EscapeDataString($"{Url.Content("~/")}/discord/callback");
            var credentials = Utilities.String.Base64Encode($"{Resources.AppSettings.DiscordClientId}:{Resources.AppSettings.DiscordClientSecret}");
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri($"{"https://"}discordapp.com/api/oauth2/token?grant_type=authorization_code&code={code}&redirect_uri={callbackUrl}");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.ContentType
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var data = new AccessTokenRequestModel()
                {
                    client_id = Resources.AppSettings.DiscordClientId,
                    client_secret = Resources.AppSettings.DiscordClientSecret,
                    code = code,
                    redirect_uri = "callbackUrl",
                };

                var request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
                request.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data),
                                                    Encoding.UTF8,
                                                    "application/json");//CONTENT-TYPE header

                await client.SendAsync(request).ContinueWith(responseTask =>
                   {
                       Console.WriteLine("Response: {0}", responseTask.Result);
                       var result = Newtonsoft.Json.JsonConvert.DeserializeObject<AccessTokenResponseModel>(responseTask.Result.Content.ToString());
                   });

                //var response = await client.PostAsync($"{"https://"}discordapp.com/api/oauth2/token?grant_type=authorization_code&code={code}&redirect_uri={callbackUrl}", new StringContent(null));

                //response.EnsureSuccessStatusCode();

                //var content = await response.Content.ReadAsStringAsync();
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<AccessTokenResponseModel>(content);
                //var token = result.access_token;
                //return await Task.Run(() = &gt; JsonObject.Parse(content));
            }

            return View();
        }
    }
}