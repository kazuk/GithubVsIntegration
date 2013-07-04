
namespace GithubClient 
{
// ReSharper disable InconsistentNaming

/**** Authorization
{
 "id":2972767,
 "url":"https://api.github.com/authorizations/2972767",
 "app":{
  "name":"admin script (API)",
  "url":"http://developer.github.com/v3/oauth/#oauth-authorizations-api",
  "client_id":"いやん"
 },
 "token":"みちゃいや",
 "note":"admin script",
 "note_url":null,
 "created_at":"2013-07-03T22:13:22Z",
 "updated_at":"2013-07-03T22:13:22Z",
 "scopes":["public_repo"]
}
*/

    internal class Authorization
    {
    	public double id { get; set; }
    	public string url { get; set; }
    	public TempClass0001 app { get; set; }
    	public string token { get; set; }
    	public string note { get; set; }
    	public object note_url { get; set; }
    	public string created_at { get; set; }
    	public string updated_at { get; set; }
    	public string[] scopes { get; set; }
    }
    internal class TempClass0001
    {
    	public string name { get; set; }
    	public string url { get; set; }
    	public string client_id { get; set; }
    }
}
